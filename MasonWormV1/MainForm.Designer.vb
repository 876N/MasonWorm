<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.LinkTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FileNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CreateButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LinkTextBox
        '
        Me.LinkTextBox.Location = New System.Drawing.Point(12, 26)
        Me.LinkTextBox.Name = "LinkTextBox"
        Me.LinkTextBox.Size = New System.Drawing.Size(214, 20)
        Me.LinkTextBox.TabIndex = 0
        Me.LinkTextBox.Text = "http://example.com/payload.exe"
        AddHandler Me.LinkTextBox.TextChanged, AddressOf Me.LinkTextBox_TextChanged_1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Direct download link"
        '
        'FileNameTextBox
        '
        Me.FileNameTextBox.Location = New System.Drawing.Point(232, 26)
        Me.FileNameTextBox.Name = "FileNameTextBox"
        Me.FileNameTextBox.Size = New System.Drawing.Size(80, 20)
        Me.FileNameTextBox.TabIndex = 2
        Me.FileNameTextBox.Text = "File.exe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(229, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Output File Name"
        '
        'CreateButton
        '
        Me.CreateButton.Location = New System.Drawing.Point(12, 52)
        Me.CreateButton.Name = "CreateButton"
        Me.CreateButton.Size = New System.Drawing.Size(75, 23)
        Me.CreateButton.TabIndex = 4
        Me.CreateButton.Text = "Create"
        Me.CreateButton.UseVisualStyleBackColor = True
        AddHandler Me.CreateButton.Click, AddressOf Me.CreateButton_Click_1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 83)
        Me.Controls.Add(Me.CreateButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FileNameTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinkTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MasonWorm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FileNameTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CreateButton As Button
End Class