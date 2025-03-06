<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Save = New System.Windows.Forms.Button()
        Me.ServerTextBox = New System.Windows.Forms.TextBox()
        Me.Server = New System.Windows.Forms.Label()
        Me.UID = New System.Windows.Forms.Label()
        Me.UIDTextBox = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Database = New System.Windows.Forms.Label()
        Me.DatabaseTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Save
        '
        Me.Save.BackColor = System.Drawing.Color.MediumBlue
        Me.Save.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Save.ForeColor = System.Drawing.Color.White
        Me.Save.Location = New System.Drawing.Point(104, 338)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(198, 57)
        Me.Save.TabIndex = 1
        Me.Save.Text = "Save"
        Me.Save.UseVisualStyleBackColor = False
        '
        'ServerTextBox
        '
        Me.ServerTextBox.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ServerTextBox.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServerTextBox.Location = New System.Drawing.Point(45, 56)
        Me.ServerTextBox.Name = "ServerTextBox"
        Me.ServerTextBox.Size = New System.Drawing.Size(327, 32)
        Me.ServerTextBox.TabIndex = 2
        '
        'Server
        '
        Me.Server.AutoSize = True
        Me.Server.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Server.Location = New System.Drawing.Point(40, 32)
        Me.Server.Name = "Server"
        Me.Server.Size = New System.Drawing.Size(67, 25)
        Me.Server.TabIndex = 3
        Me.Server.Text = "Server"
        '
        'UID
        '
        Me.UID.AutoSize = True
        Me.UID.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UID.Location = New System.Drawing.Point(40, 98)
        Me.UID.Name = "UID"
        Me.UID.Size = New System.Drawing.Size(41, 25)
        Me.UID.TabIndex = 5
        Me.UID.Text = "UID"
        '
        'UIDTextBox
        '
        Me.UIDTextBox.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.UIDTextBox.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UIDTextBox.Location = New System.Drawing.Point(45, 121)
        Me.UIDTextBox.Name = "UIDTextBox"
        Me.UIDTextBox.Size = New System.Drawing.Size(327, 32)
        Me.UIDTextBox.TabIndex = 4
        '
        'Password
        '
        Me.Password.AutoSize = True
        Me.Password.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Password.Location = New System.Drawing.Point(40, 160)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(95, 25)
        Me.Password.TabIndex = 7
        Me.Password.Text = "Password"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.PasswordTextBox.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.Location = New System.Drawing.Point(45, 188)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.Size = New System.Drawing.Size(327, 32)
        Me.PasswordTextBox.TabIndex = 6
        '
        'Database
        '
        Me.Database.AutoSize = True
        Me.Database.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Database.Location = New System.Drawing.Point(40, 229)
        Me.Database.Name = "Database"
        Me.Database.Size = New System.Drawing.Size(91, 25)
        Me.Database.TabIndex = 9
        Me.Database.Text = "Database"
        '
        'DatabaseTextBox
        '
        Me.DatabaseTextBox.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.DatabaseTextBox.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatabaseTextBox.Location = New System.Drawing.Point(45, 257)
        Me.DatabaseTextBox.Name = "DatabaseTextBox"
        Me.DatabaseTextBox.Size = New System.Drawing.Size(327, 32)
        Me.DatabaseTextBox.TabIndex = 8
        '
        'SetConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(423, 431)
        Me.Controls.Add(Me.Database)
        Me.Controls.Add(Me.DatabaseTextBox)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UID)
        Me.Controls.Add(Me.UIDTextBox)
        Me.Controls.Add(Me.Server)
        Me.Controls.Add(Me.ServerTextBox)
        Me.Controls.Add(Me.Save)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetConfig"
        Me.Text = "SetConfig"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Save As Button
    Friend WithEvents ServerTextBox As TextBox
    Friend WithEvents Server As Label
    Friend WithEvents UID As Label
    Friend WithEvents UIDTextBox As TextBox
    Friend WithEvents Password As Label
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents Database As Label
    Friend WithEvents DatabaseTextBox As TextBox
End Class
