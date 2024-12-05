<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class User_Status
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Old_Donor = New System.Windows.Forms.Button()
        Me.New_Donor = New System.Windows.Forms.Button()
        Me.Back = New System.Windows.Forms.Button()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbLogo
        '
        Me.pbLogo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbLogo.Image = Global.Red_Cross_Blood_Donation_App_2.My.Resources.Resources.Red_Cross_logo
        Me.pbLogo.Location = New System.Drawing.Point(12, -2)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(400, 154)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 2
        Me.pbLogo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Old_Donor)
        Me.Panel1.Controls.Add(Me.New_Donor)
        Me.Panel1.Location = New System.Drawing.Point(84, 158)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(266, 204)
        Me.Panel1.TabIndex = 3
        '
        'Old_Donor
        '
        Me.Old_Donor.BackColor = System.Drawing.Color.MediumBlue
        Me.Old_Donor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Old_Donor.ForeColor = System.Drawing.Color.White
        Me.Old_Donor.Location = New System.Drawing.Point(35, 102)
        Me.Old_Donor.Name = "Old_Donor"
        Me.Old_Donor.Size = New System.Drawing.Size(198, 57)
        Me.Old_Donor.TabIndex = 1
        Me.Old_Donor.Text = "Existing Donor"
        Me.Old_Donor.UseVisualStyleBackColor = False
        '
        'New_Donor
        '
        Me.New_Donor.BackColor = System.Drawing.Color.MediumBlue
        Me.New_Donor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.New_Donor.ForeColor = System.Drawing.Color.White
        Me.New_Donor.Location = New System.Drawing.Point(35, 42)
        Me.New_Donor.Name = "New_Donor"
        Me.New_Donor.Size = New System.Drawing.Size(198, 57)
        Me.New_Donor.TabIndex = 0
        Me.New_Donor.Text = "New Donor"
        Me.New_Donor.UseVisualStyleBackColor = False
        '
        'Back
        '
        Me.Back.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Back.BackColor = System.Drawing.Color.Red
        Me.Back.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Back.ForeColor = System.Drawing.SystemColors.Control
        Me.Back.Location = New System.Drawing.Point(176, 368)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(87, 39)
        Me.Back.TabIndex = 4
        Me.Back.Text = "Back"
        Me.Back.UseVisualStyleBackColor = False
        '
        'User_Status
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(423, 431)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pbLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "User_Status"
        Me.Text = "User_Status"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents New_Donor As Button
    Friend WithEvents Old_Donor As Button
    Friend WithEvents Back As Button
End Class
