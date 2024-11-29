<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Inventory
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
        Me.cmbMonths = New System.Windows.Forms.ComboBox()
        Me.dtpCalendar = New System.Windows.Forms.MonthCalendar()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.EligibilityRecord = New System.Windows.Forms.Button()
        Me.DonationRecord = New System.Windows.Forms.Button()
        Me.DonorRecord = New System.Windows.Forms.Button()
        Me.Monthly = New System.Windows.Forms.Button()
        Me.Weekly = New System.Windows.Forms.Button()
        Me.Daily = New System.Windows.Forms.Button()
        Me.HistoryRecord = New System.Windows.Forms.Button()
        Me.Home_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbLogo
        '
        Me.pbLogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLogo.Image = Global.Red_Cross_Blood_Donation_App_2.My.Resources.Resources.Red_Cross_logo
        Me.pbLogo.Location = New System.Drawing.Point(12, 12)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(75, 67)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 2
        Me.pbLogo.TabStop = False
        '
        'cmbMonths
        '
        Me.cmbMonths.FormattingEnabled = True
        Me.cmbMonths.Location = New System.Drawing.Point(423, 71)
        Me.cmbMonths.Name = "cmbMonths"
        Me.cmbMonths.Size = New System.Drawing.Size(121, 21)
        Me.cmbMonths.TabIndex = 20
        '
        'dtpCalendar
        '
        Me.dtpCalendar.Location = New System.Drawing.Point(423, 62)
        Me.dtpCalendar.Name = "dtpCalendar"
        Me.dtpCalendar.TabIndex = 19
        Me.dtpCalendar.Visible = False
        '
        'dgvInventory
        '
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventory.Location = New System.Drawing.Point(130, 100)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.Size = New System.Drawing.Size(642, 331)
        Me.dgvInventory.TabIndex = 18
        '
        'EligibilityRecord
        '
        Me.EligibilityRecord.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.EligibilityRecord.Location = New System.Drawing.Point(7, 215)
        Me.EligibilityRecord.Name = "EligibilityRecord"
        Me.EligibilityRecord.Size = New System.Drawing.Size(117, 55)
        Me.EligibilityRecord.TabIndex = 17
        Me.EligibilityRecord.Text = "Eligibility"
        Me.EligibilityRecord.UseVisualStyleBackColor = True
        '
        'DonationRecord
        '
        Me.DonationRecord.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DonationRecord.Location = New System.Drawing.Point(7, 159)
        Me.DonationRecord.Name = "DonationRecord"
        Me.DonationRecord.Size = New System.Drawing.Size(117, 50)
        Me.DonationRecord.TabIndex = 16
        Me.DonationRecord.Text = "Donation"
        Me.DonationRecord.UseVisualStyleBackColor = True
        '
        'DonorRecord
        '
        Me.DonorRecord.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DonorRecord.Location = New System.Drawing.Point(7, 98)
        Me.DonorRecord.Name = "DonorRecord"
        Me.DonorRecord.Size = New System.Drawing.Size(117, 55)
        Me.DonorRecord.TabIndex = 15
        Me.DonorRecord.Text = "Donor"
        Me.DonorRecord.UseVisualStyleBackColor = True
        '
        'Monthly
        '
        Me.Monthly.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Monthly.Location = New System.Drawing.Point(312, 62)
        Me.Monthly.Name = "Monthly"
        Me.Monthly.Size = New System.Drawing.Size(86, 32)
        Me.Monthly.TabIndex = 14
        Me.Monthly.Text = "Monthly"
        Me.Monthly.UseVisualStyleBackColor = True
        '
        'Weekly
        '
        Me.Weekly.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Weekly.Location = New System.Drawing.Point(221, 62)
        Me.Weekly.Name = "Weekly"
        Me.Weekly.Size = New System.Drawing.Size(85, 32)
        Me.Weekly.TabIndex = 13
        Me.Weekly.Text = "Weekly"
        Me.Weekly.UseVisualStyleBackColor = True
        '
        'Daily
        '
        Me.Daily.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Daily.Location = New System.Drawing.Point(130, 62)
        Me.Daily.Name = "Daily"
        Me.Daily.Size = New System.Drawing.Size(85, 32)
        Me.Daily.TabIndex = 12
        Me.Daily.Text = "Daily"
        Me.Daily.UseVisualStyleBackColor = True
        '
        'HistoryRecord
        '
        Me.HistoryRecord.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.HistoryRecord.Location = New System.Drawing.Point(7, 276)
        Me.HistoryRecord.Name = "HistoryRecord"
        Me.HistoryRecord.Size = New System.Drawing.Size(117, 55)
        Me.HistoryRecord.TabIndex = 21
        Me.HistoryRecord.Text = "History"
        Me.HistoryRecord.UseVisualStyleBackColor = True
        '
        'Home_Button
        '
        Me.Home_Button.BackColor = System.Drawing.Color.DarkBlue
        Me.Home_Button.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Home_Button.ForeColor = System.Drawing.SystemColors.Control
        Me.Home_Button.Location = New System.Drawing.Point(7, 350)
        Me.Home_Button.Name = "Home_Button"
        Me.Home_Button.Size = New System.Drawing.Size(117, 37)
        Me.Home_Button.TabIndex = 22
        Me.Home_Button.Text = "Home Page"
        Me.Home_Button.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Firebrick
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(792, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(180, 463)
        Me.Panel1.TabIndex = 23
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button9.ForeColor = System.Drawing.SystemColors.Control
        Me.Button9.Location = New System.Drawing.Point(22, 389)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(145, 30)
        Me.Button9.TabIndex = 26
        Me.Button9.Text = "Donation Trends Report"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button8.ForeColor = System.Drawing.SystemColors.Control
        Me.Button8.Location = New System.Drawing.Point(22, 344)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(145, 39)
        Me.Button8.TabIndex = 25
        Me.Button8.Text = "Healthcare Provider Access Report"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button7.ForeColor = System.Drawing.SystemColors.Control
        Me.Button7.Location = New System.Drawing.Point(22, 298)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(145, 40)
        Me.Button7.TabIndex = 24
        Me.Button7.Text = "Donor Demographics Report"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button6.ForeColor = System.Drawing.SystemColors.Control
        Me.Button6.Location = New System.Drawing.Point(22, 262)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(145, 30)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Monthly Donation Statistics"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button5.ForeColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(22, 218)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(145, 37)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Blood Type Demand Report"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button4.ForeColor = System.Drawing.SystemColors.Control
        Me.Button4.Location = New System.Drawing.Point(22, 182)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(145, 30)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Inegibility Status Report"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button3.ForeColor = System.Drawing.SystemColors.Control
        Me.Button3.Location = New System.Drawing.Point(22, 146)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(145, 30)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Blood Inventory Report"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.ForeColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(22, 110)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(145, 30)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Donation History Report"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.ForeColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(22, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Donor Registration Report"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(32, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 62)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Generate " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Report"
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSearch.Location = New System.Drawing.Point(130, 27)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(305, 23)
        Me.txtSearch.TabIndex = 24
        Me.txtSearch.Text = "Search"
        '
        'Admin_Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 491)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Home_Button)
        Me.Controls.Add(Me.HistoryRecord)
        Me.Controls.Add(Me.cmbMonths)
        Me.Controls.Add(Me.dtpCalendar)
        Me.Controls.Add(Me.dgvInventory)
        Me.Controls.Add(Me.EligibilityRecord)
        Me.Controls.Add(Me.DonationRecord)
        Me.Controls.Add(Me.DonorRecord)
        Me.Controls.Add(Me.Monthly)
        Me.Controls.Add(Me.Weekly)
        Me.Controls.Add(Me.Daily)
        Me.Controls.Add(Me.pbLogo)
        Me.Name = "Admin_Inventory"
        Me.Text = "Admin_Inventory"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents cmbMonths As ComboBox
    Friend WithEvents dtpCalendar As MonthCalendar
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents EligibilityRecord As Button
    Friend WithEvents DonationRecord As Button
    Friend WithEvents DonorRecord As Button
    Friend WithEvents Monthly As Button
    Friend WithEvents Weekly As Button
    Friend WithEvents Daily As Button
    Friend WithEvents HistoryRecord As Button
    Friend WithEvents Home_Button As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents txtSearch As TextBox
End Class
