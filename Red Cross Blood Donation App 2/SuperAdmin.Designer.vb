<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuperAdmin
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
        Me.History = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Health_Provider = New System.Windows.Forms.Button()
        Me.cmbMonths = New System.Windows.Forms.ComboBox()
        Me.dtpCalendar = New System.Windows.Forms.MonthCalendar()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.EligibilityRecord = New System.Windows.Forms.Button()
        Me.DonationRecord = New System.Windows.Forms.Button()
        Me.DonorRecord = New System.Windows.Forms.Button()
        Me.Monthly = New System.Windows.Forms.Button()
        Me.Weekly = New System.Windows.Forms.Button()
        Me.Daily = New System.Windows.Forms.Button()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.Logs = New System.Windows.Forms.Button()
        Me.Accounts = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'History
        '
        Me.History.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.History.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.History.Location = New System.Drawing.Point(612, 0)
        Me.History.Name = "History"
        Me.History.Size = New System.Drawing.Size(117, 50)
        Me.History.TabIndex = 40
        Me.History.Text = "History"
        Me.History.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSearch.Location = New System.Drawing.Point(118, 60)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(305, 23)
        Me.txtSearch.TabIndex = 39
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Firebrick
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1258, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(180, 881)
        Me.Panel1.TabIndex = 38
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(19, 163)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 58)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Donor Registration Report"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(19, 251)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 58)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "Donation History Report"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.Control
        Me.Button3.Location = New System.Drawing.Point(19, 338)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(143, 58)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "Blood Inventory Report"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.SystemColors.Control
        Me.Button8.Location = New System.Drawing.Point(19, 518)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(143, 67)
        Me.Button8.TabIndex = 30
        Me.Button8.Text = "Healthcare Provider Access Report"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.Control
        Me.Button4.Location = New System.Drawing.Point(19, 429)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(143, 58)
        Me.Button4.TabIndex = 29
        Me.Button4.Text = "Inegibility Status Report"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(40, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 62)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Generate " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Report"
        '
        'Health_Provider
        '
        Me.Health_Provider.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Health_Provider.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Health_Provider.Location = New System.Drawing.Point(489, 0)
        Me.Health_Provider.Name = "Health_Provider"
        Me.Health_Provider.Size = New System.Drawing.Size(117, 50)
        Me.Health_Provider.TabIndex = 36
        Me.Health_Provider.Text = "Health Provider"
        Me.Health_Provider.UseVisualStyleBackColor = False
        '
        'cmbMonths
        '
        Me.cmbMonths.FormattingEnabled = True
        Me.cmbMonths.Location = New System.Drawing.Point(392, 99)
        Me.cmbMonths.Name = "cmbMonths"
        Me.cmbMonths.Size = New System.Drawing.Size(121, 21)
        Me.cmbMonths.TabIndex = 35
        '
        'dtpCalendar
        '
        Me.dtpCalendar.Location = New System.Drawing.Point(392, 97)
        Me.dtpCalendar.Name = "dtpCalendar"
        Me.dtpCalendar.TabIndex = 34
        Me.dtpCalendar.Visible = False
        '
        'dgvInventory
        '
        Me.dgvInventory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventory.Location = New System.Drawing.Point(111, 130)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.Size = New System.Drawing.Size(1104, 718)
        Me.dgvInventory.TabIndex = 33
        '
        'EligibilityRecord
        '
        Me.EligibilityRecord.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.EligibilityRecord.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.EligibilityRecord.Location = New System.Drawing.Point(364, 0)
        Me.EligibilityRecord.Name = "EligibilityRecord"
        Me.EligibilityRecord.Size = New System.Drawing.Size(119, 50)
        Me.EligibilityRecord.TabIndex = 32
        Me.EligibilityRecord.Text = "Eligibility"
        Me.EligibilityRecord.UseVisualStyleBackColor = False
        '
        'DonationRecord
        '
        Me.DonationRecord.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.DonationRecord.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DonationRecord.Location = New System.Drawing.Point(241, 0)
        Me.DonationRecord.Name = "DonationRecord"
        Me.DonationRecord.Size = New System.Drawing.Size(117, 50)
        Me.DonationRecord.TabIndex = 31
        Me.DonationRecord.Text = "Donation"
        Me.DonationRecord.UseVisualStyleBackColor = False
        '
        'DonorRecord
        '
        Me.DonorRecord.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.DonorRecord.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DonorRecord.Location = New System.Drawing.Point(118, 0)
        Me.DonorRecord.Name = "DonorRecord"
        Me.DonorRecord.Size = New System.Drawing.Size(117, 48)
        Me.DonorRecord.TabIndex = 30
        Me.DonorRecord.Text = "Donor"
        Me.DonorRecord.UseVisualStyleBackColor = False
        '
        'Monthly
        '
        Me.Monthly.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Monthly.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Monthly.Location = New System.Drawing.Point(300, 90)
        Me.Monthly.Name = "Monthly"
        Me.Monthly.Size = New System.Drawing.Size(86, 32)
        Me.Monthly.TabIndex = 29
        Me.Monthly.Text = "Monthly"
        Me.Monthly.UseVisualStyleBackColor = False
        '
        'Weekly
        '
        Me.Weekly.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Weekly.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Weekly.Location = New System.Drawing.Point(209, 90)
        Me.Weekly.Name = "Weekly"
        Me.Weekly.Size = New System.Drawing.Size(85, 32)
        Me.Weekly.TabIndex = 28
        Me.Weekly.Text = "Weekly"
        Me.Weekly.UseVisualStyleBackColor = False
        '
        'Daily
        '
        Me.Daily.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Daily.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Daily.Location = New System.Drawing.Point(118, 90)
        Me.Daily.Name = "Daily"
        Me.Daily.Size = New System.Drawing.Size(85, 32)
        Me.Daily.TabIndex = 27
        Me.Daily.Text = "Daily"
        Me.Daily.UseVisualStyleBackColor = False
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.Red_Cross_Blood_Donation_App_2.My.Resources.Resources.Red_Cross_logo
        Me.pbLogo.Location = New System.Drawing.Point(6, 0)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(99, 130)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 26
        Me.pbLogo.TabStop = False
        '
        'Logs
        '
        Me.Logs.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Logs.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Logs.Location = New System.Drawing.Point(735, 0)
        Me.Logs.Name = "Logs"
        Me.Logs.Size = New System.Drawing.Size(117, 50)
        Me.Logs.TabIndex = 41
        Me.Logs.Text = "Logs"
        Me.Logs.UseVisualStyleBackColor = False
        '
        'Accounts
        '
        Me.Accounts.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Accounts.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Accounts.Location = New System.Drawing.Point(858, 0)
        Me.Accounts.Name = "Accounts"
        Me.Accounts.Size = New System.Drawing.Size(117, 50)
        Me.Accounts.TabIndex = 42
        Me.Accounts.Text = "Accounts"
        Me.Accounts.UseVisualStyleBackColor = False
        '
        'SuperAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1444, 881)
        Me.Controls.Add(Me.Accounts)
        Me.Controls.Add(Me.Logs)
        Me.Controls.Add(Me.History)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Health_Provider)
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SuperAdmin"
        Me.Text = "SuperAdmin"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents History As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Health_Provider As Button
    Friend WithEvents cmbMonths As ComboBox
    Friend WithEvents dtpCalendar As MonthCalendar
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents EligibilityRecord As Button
    Friend WithEvents DonationRecord As Button
    Friend WithEvents DonorRecord As Button
    Friend WithEvents Monthly As Button
    Friend WithEvents Weekly As Button
    Friend WithEvents Daily As Button
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents Logs As Button
    Friend WithEvents Accounts As Button
End Class
