<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Donation_Management_new
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
        Me.Blood_type = New System.Windows.Forms.Label()
        Me.txtBloodType = New System.Windows.Forms.RichTextBox()
        Me.Rhesus_Factor = New System.Windows.Forms.Label()
        Me.txtRhesusFactor = New System.Windows.Forms.RichTextBox()
        Me.Collect_method = New System.Windows.Forms.Label()
        Me.Blood_vol = New System.Windows.Forms.Label()
        Me.CollectionCheckedList = New System.Windows.Forms.CheckedListBox()
        Me.txtBloodVolume = New System.Windows.Forms.RichTextBox()
        Me.Don_type = New System.Windows.Forms.Label()
        Me.DonationTypeCheckedlist = New System.Windows.Forms.CheckedListBox()
        Me.Back = New System.Windows.Forms.Button()
        Me.Proceed = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Blood_type
        '
        Me.Blood_type.AutoSize = True
        Me.Blood_type.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Blood_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Blood_type.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Blood_type.Location = New System.Drawing.Point(794, 65)
        Me.Blood_type.Name = "Blood_type"
        Me.Blood_type.Size = New System.Drawing.Size(67, 17)
        Me.Blood_type.TabIndex = 0
        Me.Blood_type.Text = "Blood Type"
        '
        'txtBloodType
        '
        Me.txtBloodType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBloodType.Location = New System.Drawing.Point(794, 86)
        Me.txtBloodType.Name = "txtBloodType"
        Me.txtBloodType.Size = New System.Drawing.Size(188, 33)
        Me.txtBloodType.TabIndex = 1
        Me.txtBloodType.Text = ""
        '
        'Rhesus_Factor
        '
        Me.Rhesus_Factor.AutoSize = True
        Me.Rhesus_Factor.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Rhesus_Factor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Rhesus_Factor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Rhesus_Factor.Location = New System.Drawing.Point(1040, 65)
        Me.Rhesus_Factor.Name = "Rhesus_Factor"
        Me.Rhesus_Factor.Size = New System.Drawing.Size(82, 17)
        Me.Rhesus_Factor.TabIndex = 2
        Me.Rhesus_Factor.Text = "Rhesus Factor"
        '
        'txtRhesusFactor
        '
        Me.txtRhesusFactor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRhesusFactor.Location = New System.Drawing.Point(1040, 83)
        Me.txtRhesusFactor.Name = "txtRhesusFactor"
        Me.txtRhesusFactor.Size = New System.Drawing.Size(188, 33)
        Me.txtRhesusFactor.TabIndex = 3
        Me.txtRhesusFactor.Text = ""
        '
        'Collect_method
        '
        Me.Collect_method.AutoSize = True
        Me.Collect_method.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Collect_method.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Collect_method.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Collect_method.Location = New System.Drawing.Point(794, 136)
        Me.Collect_method.Name = "Collect_method"
        Me.Collect_method.Size = New System.Drawing.Size(91, 17)
        Me.Collect_method.TabIndex = 4
        Me.Collect_method.Text = "Collect Method"
        '
        'Blood_vol
        '
        Me.Blood_vol.AutoSize = True
        Me.Blood_vol.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Blood_vol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Blood_vol.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Blood_vol.Location = New System.Drawing.Point(1040, 136)
        Me.Blood_vol.Name = "Blood_vol"
        Me.Blood_vol.Size = New System.Drawing.Size(83, 17)
        Me.Blood_vol.TabIndex = 5
        Me.Blood_vol.Text = "Blood Volume"
        '
        'CollectionCheckedList
        '
        Me.CollectionCheckedList.FormattingEnabled = True
        Me.CollectionCheckedList.Items.AddRange(New Object() {"Manual Collection", "Automatic Collection"})
        Me.CollectionCheckedList.Location = New System.Drawing.Point(794, 156)
        Me.CollectionCheckedList.Name = "CollectionCheckedList"
        Me.CollectionCheckedList.Size = New System.Drawing.Size(141, 34)
        Me.CollectionCheckedList.TabIndex = 6
        '
        'txtBloodVolume
        '
        Me.txtBloodVolume.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBloodVolume.Location = New System.Drawing.Point(1040, 157)
        Me.txtBloodVolume.Name = "txtBloodVolume"
        Me.txtBloodVolume.Size = New System.Drawing.Size(188, 33)
        Me.txtBloodVolume.TabIndex = 7
        Me.txtBloodVolume.Text = ""
        '
        'Don_type
        '
        Me.Don_type.AutoSize = True
        Me.Don_type.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Don_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Don_type.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Don_type.Location = New System.Drawing.Point(794, 217)
        Me.Don_type.Name = "Don_type"
        Me.Don_type.Size = New System.Drawing.Size(103, 17)
        Me.Don_type.TabIndex = 8
        Me.Don_type.Text = "Donation Method"
        '
        'DonationTypeCheckedlist
        '
        Me.DonationTypeCheckedlist.FormattingEnabled = True
        Me.DonationTypeCheckedlist.Items.AddRange(New Object() {"Whole Blood Donation", "Plasma Donation (Apheresis)", "Platelet Donation (Apheresis)", "Red Blood Cell Donation (Apheresis)", "Double Red Cell Donation", "Autologous Donation", "Directed Donation"})
        Me.DonationTypeCheckedlist.Location = New System.Drawing.Point(794, 237)
        Me.DonationTypeCheckedlist.Name = "DonationTypeCheckedlist"
        Me.DonationTypeCheckedlist.Size = New System.Drawing.Size(216, 124)
        Me.DonationTypeCheckedlist.TabIndex = 9
        '
        'Back
        '
        Me.Back.BackColor = System.Drawing.Color.Blue
        Me.Back.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Back.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Back.Location = New System.Drawing.Point(164, 572)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(98, 23)
        Me.Back.TabIndex = 10
        Me.Back.Text = "Back"
        Me.Back.UseVisualStyleBackColor = False
        '
        'Proceed
        '
        Me.Proceed.BackColor = System.Drawing.Color.Blue
        Me.Proceed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Proceed.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Proceed.Location = New System.Drawing.Point(896, 572)
        Me.Proceed.Name = "Proceed"
        Me.Proceed.Size = New System.Drawing.Size(159, 24)
        Me.Proceed.TabIndex = 11
        Me.Proceed.Text = "Proceed"
        Me.Proceed.UseVisualStyleBackColor = False
        '
        'Donation_Management_new
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 752)
        Me.Controls.Add(Me.Proceed)
        Me.Controls.Add(Me.Back)
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
        Me.Name = "Donation_Management_new"
        Me.Text = "Donation Management New Donor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Blood_type As Label
    Friend WithEvents txtBloodType As RichTextBox
    Friend WithEvents Rhesus_Factor As Label
    Friend WithEvents txtRhesusFactor As RichTextBox
    Friend WithEvents Collect_method As Label
    Friend WithEvents Blood_vol As Label
    Friend WithEvents CollectionCheckedList As CheckedListBox
    Friend WithEvents txtBloodVolume As RichTextBox
    Friend WithEvents Don_type As Label
    Friend WithEvents DonationTypeCheckedlist As CheckedListBox
    Friend WithEvents Back As Button
    Friend WithEvents Proceed As Button
End Class
