<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDL_INFO
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
        components = New ComponentModel.Container()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Guna2TabControl1 = New Guna.UI2.WinForms.Guna2TabControl()
        TabPage1 = New TabPage()
        case_num_label = New Label()
        Label16 = New Label()
        years_sentence = New Label()
        Label14 = New Label()
        date_birth = New Label()
        Label12 = New Label()
        gender_value = New Label()
        Label10 = New Label()
        crime_commit = New Label()
        Label8 = New Label()
        status_assign = New Label()
        Label6 = New Label()
        Label5 = New Label()
        cell_Bl = New Label()
        Label3 = New Label()
        pdl_name_list = New Label()
        Label1 = New Label()
        TabPage2 = New TabPage()
        Guna2TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.9R
        Guna2BorderlessForm1.DragEndTransparencyValue = 0.9R
        Guna2BorderlessForm1.ResizeForm = False
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' Guna2TabControl1
        ' 
        Guna2TabControl1.Controls.Add(TabPage1)
        Guna2TabControl1.Controls.Add(TabPage2)
        Guna2TabControl1.ItemSize = New Size(180, 40)
        Guna2TabControl1.Location = New Point(142, 50)
        Guna2TabControl1.Name = "Guna2TabControl1"
        Guna2TabControl1.SelectedIndex = 0
        Guna2TabControl1.Size = New Size(900, 600)
        Guna2TabControl1.TabButtonHoverState.BorderColor = Color.Empty
        Guna2TabControl1.TabButtonHoverState.FillColor = Color.FromArgb(CByte(40), CByte(52), CByte(70))
        Guna2TabControl1.TabButtonHoverState.Font = New Font("Segoe UI Semibold", 10F)
        Guna2TabControl1.TabButtonHoverState.ForeColor = Color.White
        Guna2TabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(CByte(40), CByte(52), CByte(70))
        Guna2TabControl1.TabButtonIdleState.BorderColor = Color.Empty
        Guna2TabControl1.TabButtonIdleState.FillColor = Color.FromArgb(CByte(33), CByte(42), CByte(57))
        Guna2TabControl1.TabButtonIdleState.Font = New Font("Segoe UI Semibold", 10F)
        Guna2TabControl1.TabButtonIdleState.ForeColor = Color.FromArgb(CByte(156), CByte(160), CByte(167))
        Guna2TabControl1.TabButtonIdleState.InnerColor = Color.FromArgb(CByte(33), CByte(42), CByte(57))
        Guna2TabControl1.TabButtonSelectedState.BorderColor = Color.Empty
        Guna2TabControl1.TabButtonSelectedState.FillColor = Color.FromArgb(CByte(29), CByte(37), CByte(49))
        Guna2TabControl1.TabButtonSelectedState.Font = New Font("Segoe UI Semibold", 10F)
        Guna2TabControl1.TabButtonSelectedState.ForeColor = Color.White
        Guna2TabControl1.TabButtonSelectedState.InnerColor = Color.FromArgb(CByte(76), CByte(132), CByte(255))
        Guna2TabControl1.TabButtonSize = New Size(180, 40)
        Guna2TabControl1.TabIndex = 0
        Guna2TabControl1.TabMenuBackColor = Color.FromArgb(CByte(33), CByte(42), CByte(57))
        Guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        TabPage1.Controls.Add(case_num_label)
        TabPage1.Controls.Add(Label16)
        TabPage1.Controls.Add(years_sentence)
        TabPage1.Controls.Add(Label14)
        TabPage1.Controls.Add(date_birth)
        TabPage1.Controls.Add(Label12)
        TabPage1.Controls.Add(gender_value)
        TabPage1.Controls.Add(Label10)
        TabPage1.Controls.Add(crime_commit)
        TabPage1.Controls.Add(Label8)
        TabPage1.Controls.Add(status_assign)
        TabPage1.Controls.Add(Label6)
        TabPage1.Controls.Add(Label5)
        TabPage1.Controls.Add(cell_Bl)
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(pdl_name_list)
        TabPage1.Controls.Add(Label1)
        TabPage1.Location = New Point(4, 44)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(892, 552)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        ' 
        ' case_num_label
        ' 
        case_num_label.AutoSize = True
        case_num_label.Location = New Point(242, 79)
        case_num_label.Name = "case_num_label"
        case_num_label.Size = New Size(48, 15)
        case_num_label.TabIndex = 18
        case_num_label.Text = "11-1111"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(162, 79)
        Label16.Name = "Label16"
        Label16.Size = New Size(79, 15)
        Label16.TabIndex = 15
        Label16.Text = "Case Number"
        ' 
        ' years_sentence
        ' 
        years_sentence.AutoSize = True
        years_sentence.Location = New Point(242, 304)
        years_sentence.Name = "years_sentence"
        years_sentence.Size = New Size(65, 15)
        years_sentence.TabIndex = 14
        years_sentence.Text = "00-00-0000"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(187, 304)
        Label14.Name = "Label14"
        Label14.Size = New Size(48, 15)
        Label14.TabIndex = 13
        Label14.Text = "Sentece"
        ' 
        ' date_birth
        ' 
        date_birth.AutoSize = True
        date_birth.Location = New Point(241, 273)
        date_birth.Name = "date_birth"
        date_birth.Size = New Size(65, 15)
        date_birth.TabIndex = 12
        date_birth.Text = "00-00-0000"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(162, 273)
        Label12.Name = "Label12"
        Label12.Size = New Size(73, 15)
        Label12.TabIndex = 11
        Label12.Text = "Date of Birth"
        ' 
        ' gender_value
        ' 
        gender_value.AutoSize = True
        gender_value.Location = New Point(241, 244)
        gender_value.Name = "gender_value"
        gender_value.Size = New Size(40, 15)
        gender_value.TabIndex = 10
        gender_value.Text = "others"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(196, 244)
        Label10.Name = "Label10"
        Label10.Size = New Size(45, 15)
        Label10.TabIndex = 9
        Label10.Text = "Gender"
        ' 
        ' crime_commit
        ' 
        crime_commit.AutoSize = True
        crime_commit.Location = New Point(241, 212)
        crime_commit.Name = "crime_commit"
        crime_commit.Size = New Size(49, 15)
        crime_commit.TabIndex = 8
        crime_commit.Text = "commit"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(196, 212)
        Label8.Name = "Label8"
        Label8.Size = New Size(39, 15)
        Label8.TabIndex = 7
        Label8.Text = "Crime"
        ' 
        ' status_assign
        ' 
        status_assign.AutoSize = True
        status_assign.Location = New Point(241, 182)
        status_assign.Name = "status_assign"
        status_assign.Size = New Size(46, 15)
        status_assign.TabIndex = 6
        status_assign.Text = "............."
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(196, 182)
        Label6.Name = "Label6"
        Label6.Size = New Size(39, 15)
        Label6.TabIndex = 5
        Label6.Text = "Status"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(331, 45)
        Label5.Name = "Label5"
        Label5.Size = New Size(110, 15)
        Label5.TabIndex = 4
        Label5.Text = "PDL INFORMATION"
        ' 
        ' cell_Bl
        ' 
        cell_Bl.AutoSize = True
        cell_Bl.Location = New Point(241, 143)
        cell_Bl.Name = "cell_Bl"
        cell_Bl.Size = New Size(66, 15)
        cell_Bl.TabIndex = 3
        cell_Bl.Text = "NUM NUM"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(176, 143)
        Label3.Name = "Label3"
        Label3.Size = New Size(59, 15)
        Label3.TabIndex = 2
        Label3.Text = "Cell Block"
        ' 
        ' pdl_name_list
        ' 
        pdl_name_list.AutoSize = True
        pdl_name_list.Location = New Point(241, 108)
        pdl_name_list.Name = "pdl_name_list"
        pdl_name_list.Size = New Size(98, 15)
        pdl_name_list.TabIndex = 1
        pdl_name_list.Text = "SAMPLE SAMPLE"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(196, 108)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 0
        Label1.Text = "Name"
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 44)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(892, 552)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' PDL_INFO
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1184, 700)
        Controls.Add(Guna2TabControl1)
        FormBorderStyle = FormBorderStyle.None
        Name = "PDL_INFO"
        Opacity = 0.9R
        StartPosition = FormStartPosition.CenterScreen
        Text = "PDL_INFO"
        Guna2TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2TabControl1 As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents years_sentence As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents date_birth As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents gender_value As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents crime_commit As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents status_assign As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cell_Bl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pdl_name_list As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents case_num_label As Label
End Class
