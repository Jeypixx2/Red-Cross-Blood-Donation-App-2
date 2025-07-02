<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HealthCare_Dashboard
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.SearchTextBox = New System.Windows.Forms.RichTextBox()
        Me.Retrieve_Data = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.Monthly = New System.Windows.Forms.Button()
        Me.Weekly = New System.Windows.Forms.Button()
        Me.Daily = New System.Windows.Forms.Button()
        Me.ChartDonut = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChartBar = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.back = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.dtpDonutMonth = New System.Windows.Forms.DateTimePicker()
        Me.cmbBloodType = New System.Windows.Forms.ComboBox()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartDonut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.Red_Cross_Blood_Donation_App_2.My.Resources.Resources.Red_Cross_logo
        Me.pbLogo.Location = New System.Drawing.Point(21, 6)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(129, 109)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 3
        Me.pbLogo.TabStop = False
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SearchTextBox.Location = New System.Drawing.Point(335, 92)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(267, 35)
        Me.SearchTextBox.TabIndex = 4
        Me.SearchTextBox.Text = ""
        '
        'Retrieve_Data
        '
        Me.Retrieve_Data.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.Retrieve_Data.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Retrieve_Data.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Retrieve_Data.Location = New System.Drawing.Point(187, 72)
        Me.Retrieve_Data.Name = "Retrieve_Data"
        Me.Retrieve_Data.Size = New System.Drawing.Size(129, 54)
        Me.Retrieve_Data.TabIndex = 5
        Me.Retrieve_Data.Text = "Retrieve Data"
        Me.Retrieve_Data.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(21, 142)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1394, 239)
        Me.DataGridView1.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(931, 94)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 16
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(931, 94)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 15
        '
        'Monthly
        '
        Me.Monthly.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Monthly.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Monthly.Location = New System.Drawing.Point(822, 92)
        Me.Monthly.Name = "Monthly"
        Me.Monthly.Size = New System.Drawing.Size(84, 32)
        Me.Monthly.TabIndex = 14
        Me.Monthly.Text = "Monthly"
        Me.Monthly.UseVisualStyleBackColor = False
        '
        'Weekly
        '
        Me.Weekly.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Weekly.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Weekly.Location = New System.Drawing.Point(720, 92)
        Me.Weekly.Name = "Weekly"
        Me.Weekly.Size = New System.Drawing.Size(85, 32)
        Me.Weekly.TabIndex = 13
        Me.Weekly.Text = "Weekly"
        Me.Weekly.UseVisualStyleBackColor = False
        '
        'Daily
        '
        Me.Daily.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Daily.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Daily.Location = New System.Drawing.Point(620, 92)
        Me.Daily.Name = "Daily"
        Me.Daily.Size = New System.Drawing.Size(85, 32)
        Me.Daily.TabIndex = 12
        Me.Daily.Text = "Daily"
        Me.Daily.UseVisualStyleBackColor = False
        '
        'ChartDonut
        '
        Me.ChartDonut.Anchor = System.Windows.Forms.AnchorStyles.Left
        ChartArea1.Name = "ChartArea1"
        Me.ChartDonut.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.ChartDonut.Legends.Add(Legend1)
        Me.ChartDonut.Location = New System.Drawing.Point(21, 537)
        Me.ChartDonut.Name = "ChartDonut"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartDonut.Series.Add(Series1)
        Me.ChartDonut.Size = New System.Drawing.Size(423, 317)
        Me.ChartDonut.TabIndex = 27
        Me.ChartDonut.Text = "Chart2"
        '
        'ChartBar
        '
        Me.ChartBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.Name = "ChartArea1"
        Me.ChartBar.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.ChartBar.Legends.Add(Legend2)
        Me.ChartBar.Location = New System.Drawing.Point(450, 537)
        Me.ChartBar.Name = "ChartBar"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.ChartBar.Series.Add(Series2)
        Me.ChartBar.Size = New System.Drawing.Size(965, 317)
        Me.ChartBar.TabIndex = 28
        Me.ChartBar.Text = "Chart1"
        '
        'back
        '
        Me.back.BackColor = System.Drawing.Color.Red
        Me.back.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.back.ForeColor = System.Drawing.SystemColors.Control
        Me.back.Location = New System.Drawing.Point(1326, 75)
        Me.back.Name = "back"
        Me.back.Size = New System.Drawing.Size(106, 51)
        Me.back.TabIndex = 47
        Me.back.Text = "Back"
        Me.back.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.Control
        Me.btnPrint.Location = New System.Drawing.Point(1199, 75)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(106, 51)
        Me.btnPrint.TabIndex = 48
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'dtpDonutMonth
        '
        Me.dtpDonutMonth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpDonutMonth.Location = New System.Drawing.Point(21, 499)
        Me.dtpDonutMonth.Name = "dtpDonutMonth"
        Me.dtpDonutMonth.Size = New System.Drawing.Size(200, 20)
        Me.dtpDonutMonth.TabIndex = 49
        '
        'cmbBloodType
        '
        Me.cmbBloodType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbBloodType.FormattingEnabled = True
        Me.cmbBloodType.Location = New System.Drawing.Point(427, 502)
        Me.cmbBloodType.Name = "cmbBloodType"
        Me.cmbBloodType.Size = New System.Drawing.Size(121, 21)
        Me.cmbBloodType.TabIndex = 50
        '
        'HealthCare_Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1444, 881)
        Me.Controls.Add(Me.cmbBloodType)
        Me.Controls.Add(Me.dtpDonutMonth)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.back)
        Me.Controls.Add(Me.ChartBar)
        Me.Controls.Add(Me.ChartDonut)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.Monthly)
        Me.Controls.Add(Me.Weekly)
        Me.Controls.Add(Me.Daily)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Retrieve_Data)
        Me.Controls.Add(Me.SearchTextBox)
        Me.Controls.Add(Me.pbLogo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HealthCare_Dashboard"
        Me.Text = "HealthCare_Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartDonut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents SearchTextBox As RichTextBox
    Friend WithEvents Retrieve_Data As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents Monthly As Button
    Friend WithEvents Weekly As Button
    Friend WithEvents Daily As Button
    Friend WithEvents ChartDonut As DataVisualization.Charting.Chart
    Friend WithEvents ChartBar As DataVisualization.Charting.Chart
    Friend WithEvents back As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents dtpDonutMonth As DateTimePicker
    Friend WithEvents cmbBloodType As ComboBox
End Class
