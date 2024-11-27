<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Eligibility_Checker_old
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
        Me.Proceed = New System.Windows.Forms.Button()
        Me.Back = New System.Windows.Forms.Button()
        Me.medicationDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.tattooDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.Medication_Date = New System.Windows.Forms.Label()
        Me.TattooPiercingDate = New System.Windows.Forms.Label()
        Me.medicationCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.tattoopiercingCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.substanceDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.substanceCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.conditionCheckCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bloodpressuretextbox2 = New System.Windows.Forms.RichTextBox()
        Me.Meds = New System.Windows.Forms.Label()
        Me.Accessory = New System.Windows.Forms.Label()
        Me.conditiontypetextbox = New System.Windows.Forms.RichTextBox()
        Me.hemoglobinleveltextbox = New System.Windows.Forms.RichTextBox()
        Me.bloodpressuretextbox1 = New System.Windows.Forms.RichTextBox()
        Me.weighttextbox = New System.Windows.Forms.RichTextBox()
        Me.Subtance_Date = New System.Windows.Forms.Label()
        Me.Substance_Usage = New System.Windows.Forms.Label()
        Me.ConditionType = New System.Windows.Forms.Label()
        Me.Condition = New System.Windows.Forms.Label()
        Me.Blood_pres = New System.Windows.Forms.Label()
        Me.Hem_lvl = New System.Windows.Forms.Label()
        Me.Weight = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Proceed
        '
        Me.Proceed.BackColor = System.Drawing.Color.Blue
        Me.Proceed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Proceed.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Proceed.Location = New System.Drawing.Point(784, 409)
        Me.Proceed.Name = "Proceed"
        Me.Proceed.Size = New System.Drawing.Size(159, 24)
        Me.Proceed.TabIndex = 95
        Me.Proceed.Text = "Proceed"
        Me.Proceed.UseVisualStyleBackColor = False
        '
        'Back
        '
        Me.Back.BackColor = System.Drawing.Color.Blue
        Me.Back.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Back.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Back.Location = New System.Drawing.Point(39, 409)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(98, 23)
        Me.Back.TabIndex = 94
        Me.Back.Text = "Back"
        Me.Back.UseVisualStyleBackColor = False
        '
        'medicationDatePicker
        '
        Me.medicationDatePicker.Location = New System.Drawing.Point(312, 323)
        Me.medicationDatePicker.Name = "medicationDatePicker"
        Me.medicationDatePicker.Size = New System.Drawing.Size(200, 20)
        Me.medicationDatePicker.TabIndex = 93
        '
        'tattooDatePicker
        '
        Me.tattooDatePicker.Location = New System.Drawing.Point(312, 254)
        Me.tattooDatePicker.Name = "tattooDatePicker"
        Me.tattooDatePicker.Size = New System.Drawing.Size(200, 20)
        Me.tattooDatePicker.TabIndex = 92
        '
        'Medication_Date
        '
        Me.Medication_Date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Medication_Date.AutoSize = True
        Me.Medication_Date.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Medication_Date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Medication_Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Medication_Date.Location = New System.Drawing.Point(312, 303)
        Me.Medication_Date.Name = "Medication_Date"
        Me.Medication_Date.Size = New System.Drawing.Size(126, 17)
        Me.Medication_Date.TabIndex = 91
        Me.Medication_Date.Text = "Medication Last Taken"
        '
        'TattooPiercingDate
        '
        Me.TattooPiercingDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TattooPiercingDate.AutoSize = True
        Me.TattooPiercingDate.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TattooPiercingDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TattooPiercingDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TattooPiercingDate.Location = New System.Drawing.Point(312, 234)
        Me.TattooPiercingDate.Name = "TattooPiercingDate"
        Me.TattooPiercingDate.Size = New System.Drawing.Size(152, 17)
        Me.TattooPiercingDate.TabIndex = 90
        Me.TattooPiercingDate.Text = "Tattoo/Piercing Last Added"
        '
        'medicationCheckedListBox
        '
        Me.medicationCheckedListBox.FormattingEnabled = True
        Me.medicationCheckedListBox.Items.AddRange(New Object() {"Yes", "No"})
        Me.medicationCheckedListBox.Location = New System.Drawing.Point(66, 323)
        Me.medicationCheckedListBox.Name = "medicationCheckedListBox"
        Me.medicationCheckedListBox.Size = New System.Drawing.Size(120, 34)
        Me.medicationCheckedListBox.TabIndex = 89
        '
        'tattoopiercingCheckedListBox
        '
        Me.tattoopiercingCheckedListBox.FormattingEnabled = True
        Me.tattoopiercingCheckedListBox.Items.AddRange(New Object() {"Yes", "No"})
        Me.tattoopiercingCheckedListBox.Location = New System.Drawing.Point(66, 254)
        Me.tattoopiercingCheckedListBox.Name = "tattoopiercingCheckedListBox"
        Me.tattoopiercingCheckedListBox.Size = New System.Drawing.Size(120, 34)
        Me.tattoopiercingCheckedListBox.TabIndex = 88
        '
        'substanceDatePicker
        '
        Me.substanceDatePicker.Location = New System.Drawing.Point(312, 184)
        Me.substanceDatePicker.Name = "substanceDatePicker"
        Me.substanceDatePicker.Size = New System.Drawing.Size(200, 20)
        Me.substanceDatePicker.TabIndex = 87
        '
        'substanceCheckedListBox
        '
        Me.substanceCheckedListBox.FormattingEnabled = True
        Me.substanceCheckedListBox.Items.AddRange(New Object() {"Yes", "No"})
        Me.substanceCheckedListBox.Location = New System.Drawing.Point(66, 184)
        Me.substanceCheckedListBox.Name = "substanceCheckedListBox"
        Me.substanceCheckedListBox.Size = New System.Drawing.Size(120, 34)
        Me.substanceCheckedListBox.TabIndex = 86
        '
        'conditionCheckCheckedListBox
        '
        Me.conditionCheckCheckedListBox.FormattingEnabled = True
        Me.conditionCheckCheckedListBox.Items.AddRange(New Object() {"Yes", "No"})
        Me.conditionCheckCheckedListBox.Location = New System.Drawing.Point(66, 111)
        Me.conditionCheckCheckedListBox.Name = "conditionCheckCheckedListBox"
        Me.conditionCheckCheckedListBox.Size = New System.Drawing.Size(120, 34)
        Me.conditionCheckCheckedListBox.TabIndex = 85
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.Label3.Location = New System.Drawing.Point(395, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 30)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "/"
        '
        'bloodpressuretextbox2
        '
        Me.bloodpressuretextbox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bloodpressuretextbox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bloodpressuretextbox2.Location = New System.Drawing.Point(423, 45)
        Me.bloodpressuretextbox2.Name = "bloodpressuretextbox2"
        Me.bloodpressuretextbox2.Size = New System.Drawing.Size(69, 33)
        Me.bloodpressuretextbox2.TabIndex = 83
        Me.bloodpressuretextbox2.Text = ""
        '
        'Meds
        '
        Me.Meds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Meds.AutoSize = True
        Me.Meds.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Meds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Meds.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Meds.Location = New System.Drawing.Point(66, 303)
        Me.Meds.Name = "Meds"
        Me.Meds.Size = New System.Drawing.Size(91, 17)
        Me.Meds.TabIndex = 82
        Me.Meds.Text = "Medication Use"
        '
        'Accessory
        '
        Me.Accessory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Accessory.AutoSize = True
        Me.Accessory.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Accessory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Accessory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Accessory.Location = New System.Drawing.Point(66, 234)
        Me.Accessory.Name = "Accessory"
        Me.Accessory.Size = New System.Drawing.Size(113, 17)
        Me.Accessory.TabIndex = 81
        Me.Accessory.Text = "Has Tattoo/Piercing"
        '
        'conditiontypetextbox
        '
        Me.conditiontypetextbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conditiontypetextbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.conditiontypetextbox.Location = New System.Drawing.Point(312, 113)
        Me.conditiontypetextbox.Name = "conditiontypetextbox"
        Me.conditiontypetextbox.Size = New System.Drawing.Size(200, 32)
        Me.conditiontypetextbox.TabIndex = 80
        Me.conditiontypetextbox.Text = ""
        '
        'hemoglobinleveltextbox
        '
        Me.hemoglobinleveltextbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hemoglobinleveltextbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.hemoglobinleveltextbox.Location = New System.Drawing.Point(558, 45)
        Me.hemoglobinleveltextbox.Name = "hemoglobinleveltextbox"
        Me.hemoglobinleveltextbox.Size = New System.Drawing.Size(162, 32)
        Me.hemoglobinleveltextbox.TabIndex = 79
        Me.hemoglobinleveltextbox.Text = ""
        '
        'bloodpressuretextbox1
        '
        Me.bloodpressuretextbox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bloodpressuretextbox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bloodpressuretextbox1.Location = New System.Drawing.Point(312, 45)
        Me.bloodpressuretextbox1.Name = "bloodpressuretextbox1"
        Me.bloodpressuretextbox1.Size = New System.Drawing.Size(87, 33)
        Me.bloodpressuretextbox1.TabIndex = 78
        Me.bloodpressuretextbox1.Text = ""
        '
        'weighttextbox
        '
        Me.weighttextbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.weighttextbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.weighttextbox.Location = New System.Drawing.Point(66, 45)
        Me.weighttextbox.Name = "weighttextbox"
        Me.weighttextbox.Size = New System.Drawing.Size(193, 32)
        Me.weighttextbox.TabIndex = 77
        Me.weighttextbox.Text = ""
        '
        'Subtance_Date
        '
        Me.Subtance_Date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Subtance_Date.AutoSize = True
        Me.Subtance_Date.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Subtance_Date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Subtance_Date.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Subtance_Date.Location = New System.Drawing.Point(312, 165)
        Me.Subtance_Date.Name = "Subtance_Date"
        Me.Subtance_Date.Size = New System.Drawing.Size(120, 17)
        Me.Subtance_Date.TabIndex = 76
        Me.Subtance_Date.Text = "Substance Last Taken"
        '
        'Substance_Usage
        '
        Me.Substance_Usage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Substance_Usage.AutoSize = True
        Me.Substance_Usage.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Substance_Usage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Substance_Usage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Substance_Usage.Location = New System.Drawing.Point(66, 164)
        Me.Substance_Usage.Name = "Substance_Usage"
        Me.Substance_Usage.Size = New System.Drawing.Size(85, 17)
        Me.Substance_Usage.TabIndex = 75
        Me.Substance_Usage.Text = "Substance Use"
        '
        'ConditionType
        '
        Me.ConditionType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConditionType.AutoSize = True
        Me.ConditionType.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ConditionType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ConditionType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ConditionType.Location = New System.Drawing.Point(312, 93)
        Me.ConditionType.Name = "ConditionType"
        Me.ConditionType.Size = New System.Drawing.Size(130, 17)
        Me.ConditionType.TabIndex = 74
        Me.ConditionType.Text = "What Illness/Condition"
        '
        'Condition
        '
        Me.Condition.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Condition.AutoSize = True
        Me.Condition.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Condition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Condition.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Condition.Location = New System.Drawing.Point(66, 93)
        Me.Condition.Name = "Condition"
        Me.Condition.Size = New System.Drawing.Size(122, 17)
        Me.Condition.TabIndex = 73
        Me.Condition.Text = "Has Illness/Condition"
        '
        'Blood_pres
        '
        Me.Blood_pres.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Blood_pres.AutoSize = True
        Me.Blood_pres.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Blood_pres.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Blood_pres.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Blood_pres.Location = New System.Drawing.Point(312, 27)
        Me.Blood_pres.Name = "Blood_pres"
        Me.Blood_pres.Size = New System.Drawing.Size(87, 17)
        Me.Blood_pres.TabIndex = 72
        Me.Blood_pres.Text = "Blood Pressure"
        '
        'Hem_lvl
        '
        Me.Hem_lvl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Hem_lvl.AutoSize = True
        Me.Hem_lvl.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Hem_lvl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Hem_lvl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Hem_lvl.Location = New System.Drawing.Point(558, 27)
        Me.Hem_lvl.Name = "Hem_lvl"
        Me.Hem_lvl.Size = New System.Drawing.Size(106, 17)
        Me.Hem_lvl.TabIndex = 71
        Me.Hem_lvl.Text = "Hemoglobin Level"
        '
        'Weight
        '
        Me.Weight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Weight.AutoSize = True
        Me.Weight.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Weight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Weight.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Weight.Location = New System.Drawing.Point(66, 27)
        Me.Weight.Name = "Weight"
        Me.Weight.Size = New System.Drawing.Size(47, 17)
        Me.Weight.TabIndex = 70
        Me.Weight.Text = "Weight"
        '
        'Eligibility_Checker_old
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 450)
        Me.Controls.Add(Me.Proceed)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.medicationDatePicker)
        Me.Controls.Add(Me.tattooDatePicker)
        Me.Controls.Add(Me.Medication_Date)
        Me.Controls.Add(Me.TattooPiercingDate)
        Me.Controls.Add(Me.medicationCheckedListBox)
        Me.Controls.Add(Me.tattoopiercingCheckedListBox)
        Me.Controls.Add(Me.substanceDatePicker)
        Me.Controls.Add(Me.substanceCheckedListBox)
        Me.Controls.Add(Me.conditionCheckCheckedListBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.bloodpressuretextbox2)
        Me.Controls.Add(Me.Meds)
        Me.Controls.Add(Me.Accessory)
        Me.Controls.Add(Me.conditiontypetextbox)
        Me.Controls.Add(Me.hemoglobinleveltextbox)
        Me.Controls.Add(Me.bloodpressuretextbox1)
        Me.Controls.Add(Me.weighttextbox)
        Me.Controls.Add(Me.Subtance_Date)
        Me.Controls.Add(Me.Substance_Usage)
        Me.Controls.Add(Me.ConditionType)
        Me.Controls.Add(Me.Condition)
        Me.Controls.Add(Me.Blood_pres)
        Me.Controls.Add(Me.Hem_lvl)
        Me.Controls.Add(Me.Weight)
        Me.Name = "Eligibility_Checker_old"
        Me.Text = "Eligibility Checker Existing Donor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Proceed As Button
    Friend WithEvents Back As Button
    Friend WithEvents medicationDatePicker As DateTimePicker
    Friend WithEvents tattooDatePicker As DateTimePicker
    Friend WithEvents Medication_Date As Label
    Friend WithEvents TattooPiercingDate As Label
    Friend WithEvents medicationCheckedListBox As CheckedListBox
    Friend WithEvents tattoopiercingCheckedListBox As CheckedListBox
    Friend WithEvents substanceDatePicker As DateTimePicker
    Friend WithEvents substanceCheckedListBox As CheckedListBox
    Friend WithEvents conditionCheckCheckedListBox As CheckedListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents bloodpressuretextbox2 As RichTextBox
    Friend WithEvents Meds As Label
    Friend WithEvents Accessory As Label
    Friend WithEvents conditiontypetextbox As RichTextBox
    Friend WithEvents hemoglobinleveltextbox As RichTextBox
    Friend WithEvents bloodpressuretextbox1 As RichTextBox
    Friend WithEvents weighttextbox As RichTextBox
    Friend WithEvents Subtance_Date As Label
    Friend WithEvents Substance_Usage As Label
    Friend WithEvents ConditionType As Label
    Friend WithEvents Condition As Label
    Friend WithEvents Blood_pres As Label
    Friend WithEvents Hem_lvl As Label
    Friend WithEvents Weight As Label
End Class
