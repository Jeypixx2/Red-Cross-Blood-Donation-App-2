<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class User_Status_Old
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
        Me.Back = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.MiddleNameTextBox = New System.Windows.Forms.TextBox()
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.Search = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Back
        '
        Me.Back.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Back.BackColor = System.Drawing.Color.Red
        Me.Back.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Back.ForeColor = System.Drawing.SystemColors.Control
        Me.Back.Location = New System.Drawing.Point(82, 449)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(140, 33)
        Me.Back.TabIndex = 7
        Me.Back.Text = "Back"
        Me.Back.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LastNameTextBox)
        Me.Panel1.Controls.Add(Me.MiddleNameTextBox)
        Me.Panel1.Controls.Add(Me.FirstNameTextBox)
        Me.Panel1.Location = New System.Drawing.Point(41, 179)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(236, 207)
        Me.Panel1.TabIndex = 6
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.LastNameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LastNameTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.LastNameTextBox.Location = New System.Drawing.Point(0, 135)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(236, 23)
        Me.LastNameTextBox.TabIndex = 2
        Me.LastNameTextBox.Text = "Last Name"
        Me.LastNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MiddleNameTextBox
        '
        Me.MiddleNameTextBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.MiddleNameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MiddleNameTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.MiddleNameTextBox.Location = New System.Drawing.Point(0, 68)
        Me.MiddleNameTextBox.Name = "MiddleNameTextBox"
        Me.MiddleNameTextBox.Size = New System.Drawing.Size(236, 23)
        Me.MiddleNameTextBox.TabIndex = 1
        Me.MiddleNameTextBox.Text = "Middle Name"
        Me.MiddleNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.FirstNameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FirstNameTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.FirstNameTextBox.Location = New System.Drawing.Point(0, 0)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(236, 23)
        Me.FirstNameTextBox.TabIndex = 0
        Me.FirstNameTextBox.Tag = ""
        Me.FirstNameTextBox.Text = "First Name"
        Me.FirstNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pbLogo
        '
        Me.pbLogo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbLogo.Image = Global.Red_Cross_Blood_Donation_App_2.My.Resources.Resources.Red_Cross_logo
        Me.pbLogo.Location = New System.Drawing.Point(50, 12)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(207, 161)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 5
        Me.pbLogo.TabStop = False
        '
        'Search
        '
        Me.Search.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Search.BackColor = System.Drawing.Color.MediumBlue
        Me.Search.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Search.ForeColor = System.Drawing.Color.White
        Me.Search.Location = New System.Drawing.Point(82, 392)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(140, 51)
        Me.Search.TabIndex = 8
        Me.Search.Text = "Proceed"
        Me.Search.UseVisualStyleBackColor = False
        '
        'User_Status_Old
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(319, 493)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pbLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "User_Status_Old"
        Me.Text = "User_Status_Old"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Back As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents Search As Button
    Friend WithEvents FirstNameTextBox As TextBox
    Friend WithEvents LastNameTextBox As TextBox
    Friend WithEvents MiddleNameTextBox As TextBox
End Class
