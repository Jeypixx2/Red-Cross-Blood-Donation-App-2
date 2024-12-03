<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Donor_Management_New
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
        Me.Last_name = New System.Windows.Forms.Label()
        Me.Middle_name = New System.Windows.Forms.Label()
        Me.First_name = New System.Windows.Forms.Label()
        Me.Baranggay = New System.Windows.Forms.Label()
        Me.City = New System.Windows.Forms.Label()
        Me.Province = New System.Windows.Forms.Label()
        Me.Birth = New System.Windows.Forms.Label()
        Me.Blood_type = New System.Windows.Forms.Label()
        Me.Gender = New System.Windows.Forms.Label()
        Me.txtlastname = New System.Windows.Forms.RichTextBox()
        Me.txtFirstName = New System.Windows.Forms.RichTextBox()
        Me.txtmiddlename = New System.Windows.Forms.RichTextBox()
        Me.TxtBaranggay = New System.Windows.Forms.RichTextBox()
        Me.txtcity = New System.Windows.Forms.RichTextBox()
        Me.txtprovince = New System.Windows.Forms.RichTextBox()
        Me.txtsex = New System.Windows.Forms.RichTextBox()
        Me.txtbloodtype = New System.Windows.Forms.RichTextBox()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Last_name
        '
        Me.Last_name.AutoSize = True
        Me.Last_name.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Last_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Last_name.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.Last_name.Location = New System.Drawing.Point(77, 50)
        Me.Last_name.Name = "Last_name"
        Me.Last_name.Size = New System.Drawing.Size(102, 27)
        Me.Last_name.TabIndex = 25
        Me.Last_name.Text = "Last Name"
        '
        'Middle_name
        '
        Me.Middle_name.AutoSize = True
        Me.Middle_name.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Middle_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Middle_name.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.Middle_name.Location = New System.Drawing.Point(906, 50)
        Me.Middle_name.Name = "Middle_name"
        Me.Middle_name.Size = New System.Drawing.Size(128, 27)
        Me.Middle_name.TabIndex = 26
        Me.Middle_name.Text = "Middle Name"
        '
        'First_name
        '
        Me.First_name.AutoSize = True
        Me.First_name.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.First_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.First_name.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.First_name.Location = New System.Drawing.Point(501, 50)
        Me.First_name.Name = "First_name"
        Me.First_name.Size = New System.Drawing.Size(104, 27)
        Me.First_name.TabIndex = 27
        Me.First_name.Text = "First Name"
        '
        'Baranggay
        '
        Me.Baranggay.AutoSize = True
        Me.Baranggay.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Baranggay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Baranggay.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.Baranggay.Location = New System.Drawing.Point(77, 145)
        Me.Baranggay.Name = "Baranggay"
        Me.Baranggay.Size = New System.Drawing.Size(104, 27)
        Me.Baranggay.TabIndex = 28
        Me.Baranggay.Text = "Baranggay"
        '
        'City
        '
        Me.City.AutoSize = True
        Me.City.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.City.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.City.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.City.Location = New System.Drawing.Point(501, 148)
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(46, 27)
        Me.City.TabIndex = 29
        Me.City.Text = "City"
        '
        'Province
        '
        Me.Province.AutoSize = True
        Me.Province.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Province.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Province.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.Province.Location = New System.Drawing.Point(906, 145)
        Me.Province.Name = "Province"
        Me.Province.Size = New System.Drawing.Size(87, 27)
        Me.Province.TabIndex = 30
        Me.Province.Text = "Province"
        '
        'Birth
        '
        Me.Birth.AutoSize = True
        Me.Birth.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Birth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Birth.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.Birth.Location = New System.Drawing.Point(77, 276)
        Me.Birth.Name = "Birth"
        Me.Birth.Size = New System.Drawing.Size(120, 27)
        Me.Birth.TabIndex = 31
        Me.Birth.Text = "Date of Birth"
        '
        'Blood_type
        '
        Me.Blood_type.AutoSize = True
        Me.Blood_type.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Blood_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Blood_type.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.Blood_type.Location = New System.Drawing.Point(688, 276)
        Me.Blood_type.Name = "Blood_type"
        Me.Blood_type.Size = New System.Drawing.Size(107, 27)
        Me.Blood_type.TabIndex = 32
        Me.Blood_type.Text = "Blood Type"
        '
        'Gender
        '
        Me.Gender.AutoSize = True
        Me.Gender.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Gender.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Gender.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.Gender.Location = New System.Drawing.Point(501, 276)
        Me.Gender.Name = "Gender"
        Me.Gender.Size = New System.Drawing.Size(43, 27)
        Me.Gender.TabIndex = 33
        Me.Gender.Text = "Sex"
        '
        'txtlastname
        '
        Me.txtlastname.Font = New System.Drawing.Font("Segoe UI", 24.0!)
        Me.txtlastname.Location = New System.Drawing.Point(77, 80)
        Me.txtlastname.Name = "txtlastname"
        Me.txtlastname.Size = New System.Drawing.Size(380, 38)
        Me.txtlastname.TabIndex = 34
        Me.txtlastname.Text = ""
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFirstName.Location = New System.Drawing.Point(501, 80)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(364, 38)
        Me.txtFirstName.TabIndex = 35
        Me.txtFirstName.Text = ""
        '
        'txtmiddlename
        '
        Me.txtmiddlename.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtmiddlename.Location = New System.Drawing.Point(906, 80)
        Me.txtmiddlename.Name = "txtmiddlename"
        Me.txtmiddlename.Size = New System.Drawing.Size(420, 38)
        Me.txtmiddlename.TabIndex = 36
        Me.txtmiddlename.Text = ""
        '
        'TxtBaranggay
        '
        Me.TxtBaranggay.Font = New System.Drawing.Font("Segoe UI", 24.0!)
        Me.TxtBaranggay.Location = New System.Drawing.Point(77, 175)
        Me.TxtBaranggay.Name = "TxtBaranggay"
        Me.TxtBaranggay.Size = New System.Drawing.Size(380, 38)
        Me.TxtBaranggay.TabIndex = 37
        Me.TxtBaranggay.Text = ""
        '
        'txtcity
        '
        Me.txtcity.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtcity.Location = New System.Drawing.Point(501, 179)
        Me.txtcity.Name = "txtcity"
        Me.txtcity.Size = New System.Drawing.Size(364, 38)
        Me.txtcity.TabIndex = 38
        Me.txtcity.Text = ""
        '
        'txtprovince
        '
        Me.txtprovince.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtprovince.Location = New System.Drawing.Point(906, 175)
        Me.txtprovince.Name = "txtprovince"
        Me.txtprovince.Size = New System.Drawing.Size(420, 38)
        Me.txtprovince.TabIndex = 39
        Me.txtprovince.Text = ""
        '
        'txtsex
        '
        Me.txtsex.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtsex.Location = New System.Drawing.Point(501, 312)
        Me.txtsex.Name = "txtsex"
        Me.txtsex.Size = New System.Drawing.Size(157, 38)
        Me.txtsex.TabIndex = 41
        Me.txtsex.Text = ""
        '
        'txtbloodtype
        '
        Me.txtbloodtype.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtbloodtype.Location = New System.Drawing.Point(688, 312)
        Me.txtbloodtype.Name = "txtbloodtype"
        Me.txtbloodtype.Size = New System.Drawing.Size(177, 38)
        Me.txtbloodtype.TabIndex = 42
        Me.txtbloodtype.Text = ""
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(77, 312)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 43
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Blue
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 24.0!)
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Location = New System.Drawing.Point(77, 654)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 58)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "Back"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Blue
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 24.0!)
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(1165, 654)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 58)
        Me.Button1.TabIndex = 45
        Me.Button1.Text = "Proceed"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Donor_Management_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1843, 995)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.txtbloodtype)
        Me.Controls.Add(Me.txtsex)
        Me.Controls.Add(Me.txtprovince)
        Me.Controls.Add(Me.txtcity)
        Me.Controls.Add(Me.TxtBaranggay)
        Me.Controls.Add(Me.txtmiddlename)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtlastname)
        Me.Controls.Add(Me.Gender)
        Me.Controls.Add(Me.Blood_type)
        Me.Controls.Add(Me.Birth)
        Me.Controls.Add(Me.Province)
        Me.Controls.Add(Me.City)
        Me.Controls.Add(Me.Baranggay)
        Me.Controls.Add(Me.First_name)
        Me.Controls.Add(Me.Middle_name)
        Me.Controls.Add(Me.Last_name)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Donor_Management_New"
        Me.Text = "Donor_Management_New"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Last_name As Label
    Friend WithEvents Middle_name As Label
    Friend WithEvents First_name As Label
    Friend WithEvents Baranggay As Label
    Friend WithEvents City As Label
    Friend WithEvents Province As Label
    Friend WithEvents Birth As Label
    Friend WithEvents Blood_type As Label
    Friend WithEvents Gender As Label
    Friend WithEvents txtlastname As RichTextBox
    Friend WithEvents txtFirstName As RichTextBox
    Friend WithEvents txtmiddlename As RichTextBox
    Friend WithEvents TxtBaranggay As RichTextBox
    Friend WithEvents txtcity As RichTextBox
    Friend WithEvents txtprovince As RichTextBox
    Friend WithEvents txtsex As RichTextBox
    Friend WithEvents txtbloodtype As RichTextBox
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
End Class
