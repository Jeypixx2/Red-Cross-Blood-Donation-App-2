<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Dashboard
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Daily = New System.Windows.Forms.Button()
        Me.Weekly = New System.Windows.Forms.Button()
        Me.Monthly = New System.Windows.Forms.Button()
        Me.User = New System.Windows.Forms.Button()
        Me.Donor = New System.Windows.Forms.Button()
        Me.Inventory = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.Bar_Graph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Line_Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.back = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar_Graph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Line_Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Daily
        '
        Me.Daily.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Daily.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Daily.Location = New System.Drawing.Point(166, 83)
        Me.Daily.Name = "Daily"
        Me.Daily.Size = New System.Drawing.Size(85, 32)
        Me.Daily.TabIndex = 2
        Me.Daily.Text = "Daily"
        Me.Daily.UseVisualStyleBackColor = False
        '
        'Weekly
        '
        Me.Weekly.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Weekly.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Weekly.Location = New System.Drawing.Point(257, 83)
        Me.Weekly.Name = "Weekly"
        Me.Weekly.Size = New System.Drawing.Size(85, 32)
        Me.Weekly.TabIndex = 3
        Me.Weekly.Text = "Weekly"
        Me.Weekly.UseVisualStyleBackColor = False
        '
        'Monthly
        '
        Me.Monthly.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Monthly.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Monthly.Location = New System.Drawing.Point(348, 83)
        Me.Monthly.Name = "Monthly"
        Me.Monthly.Size = New System.Drawing.Size(84, 32)
        Me.Monthly.TabIndex = 4
        Me.Monthly.Text = "Monthly"
        Me.Monthly.UseVisualStyleBackColor = False
        '
        'User
        '
        Me.User.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.User.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.User.Location = New System.Drawing.Point(447, 6)
        Me.User.Name = "User"
        Me.User.Size = New System.Drawing.Size(125, 50)
        Me.User.TabIndex = 5
        Me.User.Text = "Donor Management"
        Me.User.UseVisualStyleBackColor = False
        '
        'Donor
        '
        Me.Donor.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Donor.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Donor.Location = New System.Drawing.Point(166, 6)
        Me.Donor.Name = "Donor"
        Me.Donor.Size = New System.Drawing.Size(125, 50)
        Me.Donor.TabIndex = 6
        Me.Donor.Text = "Donation Management"
        Me.Donor.UseVisualStyleBackColor = False
        '
        'Inventory
        '
        Me.Inventory.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Inventory.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Inventory.Location = New System.Drawing.Point(307, 6)
        Me.Inventory.Name = "Inventory"
        Me.Inventory.Size = New System.Drawing.Size(125, 50)
        Me.Inventory.TabIndex = 7
        Me.Inventory.Text = "Inventory Management"
        Me.Inventory.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 121)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1174, 357)
        Me.DataGridView1.TabIndex = 8
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MonthCalendar1.Location = New System.Drawing.Point(536, 83)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 14
        Me.MonthCalendar1.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(451, 83)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Firebrick
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(1252, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(192, 881)
        Me.Panel1.TabIndex = 24
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(25, 139)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 58)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Donor Registration Report"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(20, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 72)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Generate " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Report"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(25, 227)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 58)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Donation History Report"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.Control
        Me.Button3.Location = New System.Drawing.Point(25, 314)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(143, 58)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Blood Inventory Report"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.SystemColors.Control
        Me.Button8.Location = New System.Drawing.Point(25, 494)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(143, 67)
        Me.Button8.TabIndex = 25
        Me.Button8.Text = "Healthcare Provider Access Report"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.Control
        Me.Button4.Location = New System.Drawing.Point(25, 405)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(143, 58)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Inegibility Status Report"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.Red_Cross_Blood_Donation_App_2.My.Resources.Resources.Red_Cross_logo
        Me.pbLogo.Location = New System.Drawing.Point(21, 6)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(129, 109)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 1
        Me.pbLogo.TabStop = False
        '
        'Bar_Graph
        '
        Me.Bar_Graph.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bar_Graph.BackColor = System.Drawing.Color.MistyRose
        ChartArea1.Name = "ChartArea1"
        Me.Bar_Graph.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Bar_Graph.Legends.Add(Legend1)
        Me.Bar_Graph.Location = New System.Drawing.Point(2, 705)
        Me.Bar_Graph.Name = "Bar_Graph"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Bar_Graph.Series.Add(Series1)
        Me.Bar_Graph.Size = New System.Drawing.Size(1234, 176)
        Me.Bar_Graph.TabIndex = 25
        Me.Bar_Graph.Text = "Chart1"
        '
        'Line_Chart
        '
        Me.Line_Chart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Line_Chart.BackColor = System.Drawing.Color.MistyRose
        ChartArea2.Name = "ChartArea1"
        Me.Line_Chart.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Line_Chart.Legends.Add(Legend2)
        Me.Line_Chart.Location = New System.Drawing.Point(2, 484)
        Me.Line_Chart.Name = "Line_Chart"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Line_Chart.Series.Add(Series2)
        Me.Line_Chart.Size = New System.Drawing.Size(1234, 206)
        Me.Line_Chart.TabIndex = 26
        Me.Line_Chart.Text = "Chart2"
        '
        'back
        '
        Me.back.BackColor = System.Drawing.Color.Red
        Me.back.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.back.ForeColor = System.Drawing.SystemColors.Control
        Me.back.Location = New System.Drawing.Point(589, 6)
        Me.back.Name = "back"
        Me.back.Size = New System.Drawing.Size(106, 51)
        Me.back.TabIndex = 47
        Me.back.Text = "Back"
        Me.back.UseVisualStyleBackColor = False
        '
        'Admin_Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1444, 881)
        Me.Controls.Add(Me.back)
        Me.Controls.Add(Me.Line_Chart)
        Me.Controls.Add(Me.Bar_Graph)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Inventory)
        Me.Controls.Add(Me.Donor)
        Me.Controls.Add(Me.User)
        Me.Controls.Add(Me.Monthly)
        Me.Controls.Add(Me.Weekly)
        Me.Controls.Add(Me.Daily)
        Me.Controls.Add(Me.pbLogo)
        Me.Name = "Admin_Dashboard"
        Me.Text = "Admin_Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar_Graph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Line_Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents Daily As Button
    Friend WithEvents Weekly As Button
    Friend WithEvents Monthly As Button
    Friend WithEvents User As Button
    Friend WithEvents Donor As Button
    Friend WithEvents Inventory As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button8 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Bar_Graph As DataVisualization.Charting.Chart
    Friend WithEvents Line_Chart As DataVisualization.Charting.Chart
    Friend WithEvents back As Button
End Class
