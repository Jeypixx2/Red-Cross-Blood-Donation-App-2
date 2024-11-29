<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HealthCare_Access
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
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHospitalName = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNameAquirer = New System.Windows.Forms.RichTextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbLogo
        '
        Me.pbLogo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbLogo.Image = Global.Red_Cross_Blood_Donation_App_2.My.Resources.Resources.Red_Cross_logo
        Me.pbLogo.Location = New System.Drawing.Point(882, 78)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(211, 217)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 1
        Me.pbLogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(731, 389)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Company or Hospital Name"
        '
        'txtHospitalName
        '
        Me.txtHospitalName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHospitalName.Location = New System.Drawing.Point(735, 414)
        Me.txtHospitalName.Name = "txtHospitalName"
        Me.txtHospitalName.Size = New System.Drawing.Size(489, 35)
        Me.txtHospitalName.TabIndex = 3
        Me.txtHospitalName.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(731, 478)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Personnel Name"
        '
        'txtNameAquirer
        '
        Me.txtNameAquirer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNameAquirer.Location = New System.Drawing.Point(735, 503)
        Me.txtNameAquirer.Name = "txtNameAquirer"
        Me.txtNameAquirer.Size = New System.Drawing.Size(489, 35)
        Me.txtNameAquirer.TabIndex = 5
        Me.txtNameAquirer.Text = ""
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnLogin.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.btnLogin.Location = New System.Drawing.Point(736, 558)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(489, 68)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "Access"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'HealthCare_Access
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 918)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtNameAquirer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHospitalName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbLogo)
        Me.Name = "HealthCare_Access"
        Me.Text = "HealthCare_Access"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtHospitalName As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNameAquirer As RichTextBox
    Friend WithEvents btnLogin As Button
End Class
