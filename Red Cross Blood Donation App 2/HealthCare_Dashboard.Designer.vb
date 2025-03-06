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
        Me.Bar_Graph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Line_Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFilterCharts = New System.Windows.Forms.Button()
        Me.back = New System.Windows.Forms.Button()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar_Graph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Line_Chart, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left
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
        Me.DataGridView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(21, 142)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1394, 247)
        Me.DataGridView1.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(971, 92)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 16
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MonthCalendar1.Location = New System.Drawing.Point(971, 92)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 15
        '
        'Monthly
        '
        Me.Monthly.Anchor = System.Windows.Forms.AnchorStyles.Left
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
        Me.Weekly.Anchor = System.Windows.Forms.AnchorStyles.Left
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
        Me.Daily.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Daily.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Daily.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Daily.Location = New System.Drawing.Point(620, 92)
        Me.Daily.Name = "Daily"
        Me.Daily.Size = New System.Drawing.Size(85, 32)
        Me.Daily.TabIndex = 12
        Me.Daily.Text = "Daily"
        Me.Daily.UseVisualStyleBackColor = False
        '
        'Bar_Graph
        '
        Me.Bar_Graph.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bar_Graph.BackColor = System.Drawing.Color.MistyRose
        ChartArea1.Name = "ChartArea1"
        Me.Bar_Graph.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Bar_Graph.Legends.Add(Legend1)
        Me.Bar_Graph.Location = New System.Drawing.Point(21, 436)
        Me.Bar_Graph.Name = "Bar_Graph"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Bar_Graph.Series.Add(Series1)
        Me.Bar_Graph.Size = New System.Drawing.Size(1394, 204)
        Me.Bar_Graph.TabIndex = 27
        Me.Bar_Graph.Text = "Chart2"
        '
        'Line_Chart
        '
        Me.Line_Chart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Line_Chart.BackColor = System.Drawing.Color.MistyRose
        ChartArea2.Name = "ChartArea1"
        Me.Line_Chart.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Line_Chart.Legends.Add(Legend2)
        Me.Line_Chart.Location = New System.Drawing.Point(21, 646)
        Me.Line_Chart.Name = "Line_Chart"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Line_Chart.Series.Add(Series2)
        Me.Line_Chart.Size = New System.Drawing.Size(1394, 179)
        Me.Line_Chart.TabIndex = 28
        Me.Line_Chart.Text = "Chart1"
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(503, 407)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(145, 20)
        Me.dtpFrom.TabIndex = 29
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(706, 407)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(145, 20)
        Me.dtpTo.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(451, 407)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(673, 407)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 20)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "To"
        '
        'btnFilterCharts
        '
        Me.btnFilterCharts.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilterCharts.Location = New System.Drawing.Point(879, 400)
        Me.btnFilterCharts.Name = "btnFilterCharts"
        Me.btnFilterCharts.Size = New System.Drawing.Size(89, 34)
        Me.btnFilterCharts.TabIndex = 33
        Me.btnFilterCharts.Text = "Filter"
        Me.btnFilterCharts.UseVisualStyleBackColor = True
        '
        'back
        '
        Me.back.BackColor = System.Drawing.Color.Red
        Me.back.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.back.ForeColor = System.Drawing.SystemColors.Control
        Me.back.Location = New System.Drawing.Point(1227, 75)
        Me.back.Name = "back"
        Me.back.Size = New System.Drawing.Size(106, 51)
        Me.back.TabIndex = 47
        Me.back.Text = "Back"
        Me.back.UseVisualStyleBackColor = False
        '
        'HealthCare_Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1444, 881)
        Me.Controls.Add(Me.back)
        Me.Controls.Add(Me.btnFilterCharts)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Line_Chart)
        Me.Controls.Add(Me.Bar_Graph)
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
        CType(Me.Bar_Graph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Line_Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents Bar_Graph As DataVisualization.Charting.Chart
    Friend WithEvents Line_Chart As DataVisualization.Charting.Chart
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFilterCharts As Button
    Friend WithEvents back As Button
End Class
