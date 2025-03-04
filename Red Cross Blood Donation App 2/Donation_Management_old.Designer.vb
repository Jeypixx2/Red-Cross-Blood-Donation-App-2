<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Donation_Management_old
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Proceed = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DonationTypeCheckedlist = New System.Windows.Forms.CheckedListBox()
        Me.Don_type = New System.Windows.Forms.Label()
        Me.txtBloodVolume = New System.Windows.Forms.RichTextBox()
        Me.CollectionCheckedList = New System.Windows.Forms.CheckedListBox()
        Me.Blood_vol = New System.Windows.Forms.Label()
        Me.Collect_method = New System.Windows.Forms.Label()
        Me.txtRhesusFactor = New System.Windows.Forms.RichTextBox()
        Me.Rhesus_Factor = New System.Windows.Forms.Label()
        Me.txtBloodType = New System.Windows.Forms.RichTextBox()
        Me.Blood_type = New System.Windows.Forms.Label()
        Me.txtStorage = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Proceed
        '
        Me.Proceed.BackColor = System.Drawing.Color.Blue
        Me.Proceed.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Proceed.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Proceed.Location = New System.Drawing.Point(308, 379)
        Me.Proceed.Name = "Proceed"
        Me.Proceed.Size = New System.Drawing.Size(83, 32)
        Me.Proceed.TabIndex = 23
        Me.Proceed.Text = "Proceed"
        Me.Proceed.UseVisualStyleBackColor = False
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.BackColor = System.Drawing.SystemColors.Menu
        Me.CheckedListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Singe Bag", "Double Bag", "Triple Bag", "Quadruple Bag", "Aphresis"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(391, 183)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(289, 109)
        Me.CheckedListBox1.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(391, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Bag Type"
        '
        'DonationTypeCheckedlist
        '
        Me.DonationTypeCheckedlist.BackColor = System.Drawing.SystemColors.Menu
        Me.DonationTypeCheckedlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.DonationTypeCheckedlist.FormattingEnabled = True
        Me.DonationTypeCheckedlist.Items.AddRange(New Object() {"Whole Blood Donation", "Plasma Donation (Apheresis)", "Platelet Donation (Apheresis)", "Red Blood Cell Donation (Apheresis)", "White Blood Cell Donation (Apheresis)"})
        Me.DonationTypeCheckedlist.Location = New System.Drawing.Point(56, 183)
        Me.DonationTypeCheckedlist.Name = "DonationTypeCheckedlist"
        Me.DonationTypeCheckedlist.Size = New System.Drawing.Size(289, 109)
        Me.DonationTypeCheckedlist.TabIndex = 33
        '
        'Don_type
        '
        Me.Don_type.AutoSize = True
        Me.Don_type.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Don_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Don_type.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Don_type.Location = New System.Drawing.Point(56, 163)
        Me.Don_type.Name = "Don_type"
        Me.Don_type.Size = New System.Drawing.Size(103, 17)
        Me.Don_type.TabIndex = 32
        Me.Don_type.Text = "Donation Method"
        '
        'txtBloodVolume
        '
        Me.txtBloodVolume.BackColor = System.Drawing.SystemColors.Menu
        Me.txtBloodVolume.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtBloodVolume.Location = New System.Drawing.Point(391, 103)
        Me.txtBloodVolume.Name = "txtBloodVolume"
        Me.txtBloodVolume.Size = New System.Drawing.Size(211, 29)
        Me.txtBloodVolume.TabIndex = 31
        Me.txtBloodVolume.Text = ""
        '
        'CollectionCheckedList
        '
        Me.CollectionCheckedList.BackColor = System.Drawing.SystemColors.Menu
        Me.CollectionCheckedList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.CollectionCheckedList.FormattingEnabled = True
        Me.CollectionCheckedList.Items.AddRange(New Object() {"Manual Collection", "Automatic Collection"})
        Me.CollectionCheckedList.Location = New System.Drawing.Point(56, 103)
        Me.CollectionCheckedList.Name = "CollectionCheckedList"
        Me.CollectionCheckedList.Size = New System.Drawing.Size(195, 46)
        Me.CollectionCheckedList.TabIndex = 30
        '
        'Blood_vol
        '
        Me.Blood_vol.AutoSize = True
        Me.Blood_vol.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Blood_vol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Blood_vol.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Blood_vol.Location = New System.Drawing.Point(391, 83)
        Me.Blood_vol.Name = "Blood_vol"
        Me.Blood_vol.Size = New System.Drawing.Size(83, 17)
        Me.Blood_vol.TabIndex = 29
        Me.Blood_vol.Text = "Blood Volume"
        '
        'Collect_method
        '
        Me.Collect_method.AutoSize = True
        Me.Collect_method.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Collect_method.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Collect_method.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Collect_method.Location = New System.Drawing.Point(56, 83)
        Me.Collect_method.Name = "Collect_method"
        Me.Collect_method.Size = New System.Drawing.Size(91, 17)
        Me.Collect_method.TabIndex = 28
        Me.Collect_method.Text = "Collect Method"
        '
        'txtRhesusFactor
        '
        Me.txtRhesusFactor.BackColor = System.Drawing.SystemColors.Menu
        Me.txtRhesusFactor.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtRhesusFactor.Location = New System.Drawing.Point(391, 43)
        Me.txtRhesusFactor.Name = "txtRhesusFactor"
        Me.txtRhesusFactor.Size = New System.Drawing.Size(211, 29)
        Me.txtRhesusFactor.TabIndex = 27
        Me.txtRhesusFactor.Text = ""
        '
        'Rhesus_Factor
        '
        Me.Rhesus_Factor.AutoSize = True
        Me.Rhesus_Factor.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Rhesus_Factor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Rhesus_Factor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Rhesus_Factor.Location = New System.Drawing.Point(391, 23)
        Me.Rhesus_Factor.Name = "Rhesus_Factor"
        Me.Rhesus_Factor.Size = New System.Drawing.Size(82, 17)
        Me.Rhesus_Factor.TabIndex = 26
        Me.Rhesus_Factor.Text = "Rhesus Factor"
        '
        'txtBloodType
        '
        Me.txtBloodType.BackColor = System.Drawing.SystemColors.Menu
        Me.txtBloodType.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtBloodType.Location = New System.Drawing.Point(56, 43)
        Me.txtBloodType.Multiline = False
        Me.txtBloodType.Name = "txtBloodType"
        Me.txtBloodType.Size = New System.Drawing.Size(195, 29)
        Me.txtBloodType.TabIndex = 25
        Me.txtBloodType.Text = ""
        '
        'Blood_type
        '
        Me.Blood_type.AutoSize = True
        Me.Blood_type.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Blood_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Blood_type.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Blood_type.Location = New System.Drawing.Point(56, 23)
        Me.Blood_type.Name = "Blood_type"
        Me.Blood_type.Size = New System.Drawing.Size(76, 17)
        Me.Blood_type.TabIndex = 24
        Me.Blood_type.Text = "Blood Group"
        '
        'txtStorage
        '
        Me.txtStorage.BackColor = System.Drawing.SystemColors.Menu
        Me.txtStorage.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtStorage.Location = New System.Drawing.Point(56, 327)
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.Size = New System.Drawing.Size(211, 29)
        Me.txtStorage.TabIndex = 37
        Me.txtStorage.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(56, 307)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Storage Location"
        '
        'Donation_Management_old
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(726, 434)
        Me.Controls.Add(Me.txtStorage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DonationTypeCheckedlist)
        Me.Controls.Add(Me.Don_type)
        Me.Controls.Add(Me.txtBloodVolume)
        Me.Controls.Add(Me.CollectionCheckedList)
        Me.Controls.Add(Me.Blood_vol)
        Me.Controls.Add(Me.Collect_method)
        Me.Controls.Add(Me.txtRhesusFactor)
        Me.Controls.Add(Me.Rhesus_Factor)
        Me.Controls.Add(Me.txtBloodType)
        Me.Controls.Add(Me.Blood_type)
        Me.Controls.Add(Me.Proceed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Donation_Management_old"
        Me.Text = "Donation Management Existing Donor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Proceed As Button
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DonationTypeCheckedlist As CheckedListBox
    Friend WithEvents Don_type As Label
    Friend WithEvents txtBloodVolume As RichTextBox
    Friend WithEvents CollectionCheckedList As CheckedListBox
    Friend WithEvents Blood_vol As Label
    Friend WithEvents Collect_method As Label
    Friend WithEvents txtRhesusFactor As RichTextBox
    Friend WithEvents Rhesus_Factor As Label
    Friend WithEvents txtBloodType As RichTextBox
    Friend WithEvents Blood_type As Label
    Friend WithEvents txtStorage As RichTextBox
    Friend WithEvents Label2 As Label
End Class
