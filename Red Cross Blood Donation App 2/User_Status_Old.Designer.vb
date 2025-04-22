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
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.Search = New System.Windows.Forms.Button()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.MiddleNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpBdate = New System.Windows.Forms.DateTimePicker()
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
        'LastNameTextBox
        '
        Me.LastNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LastNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastNameTextBox.Location = New System.Drawing.Point(62, 196)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(180, 32)
        Me.LastNameTextBox.TabIndex = 9
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FirstNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstNameTextBox.Location = New System.Drawing.Point(62, 256)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(180, 32)
        Me.FirstNameTextBox.TabIndex = 10
        '
        'MiddleNameTextBox
        '
        Me.MiddleNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MiddleNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MiddleNameTextBox.Location = New System.Drawing.Point(62, 321)
        Me.MiddleNameTextBox.Name = "MiddleNameTextBox"
        Me.MiddleNameTextBox.Size = New System.Drawing.Size(180, 32)
        Me.MiddleNameTextBox.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Middle Name"
        '
        'dtpBdate
        '
        Me.dtpBdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBdate.Location = New System.Drawing.Point(62, 366)
        Me.dtpBdate.Name = "dtpBdate"
        Me.dtpBdate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBdate.TabIndex = 15
        '
        'User_Status_Old
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(319, 493)
        Me.Controls.Add(Me.dtpBdate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MiddleNameTextBox)
        Me.Controls.Add(Me.FirstNameTextBox)
        Me.Controls.Add(Me.LastNameTextBox)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.pbLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "User_Status_Old"
        Me.Text = "User_Status_Old"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Back As Button
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents Search As Button
    Friend WithEvents LastNameTextBox As TextBox
    Friend WithEvents FirstNameTextBox As TextBox
    Friend WithEvents MiddleNameTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpBdate As DateTimePicker
End Class
