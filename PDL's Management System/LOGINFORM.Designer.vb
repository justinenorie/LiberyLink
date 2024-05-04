<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LOGINFORM
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Panel1 = New Panel()
        Guna2ImageCheckBox1 = New Guna.UI2.WinForms.Guna2ImageCheckBox()
        Label5 = New Label()
        txtPassword = New Guna.UI2.WinForms.Guna2TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        txtUsername = New Guna.UI2.WinForms.Guna2TextBox()
        btnLogin = New Guna.UI2.WinForms.Guna2Button()
        Label1 = New Label()
        Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(0), CByte(63), CByte(94))
        Panel1.Controls.Add(Guna2ImageCheckBox1)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(txtPassword)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(txtUsername)
        Panel1.Controls.Add(btnLogin)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(510, 569)
        Panel1.TabIndex = 0
        ' 
        ' Guna2ImageCheckBox1
        ' 
        Guna2ImageCheckBox1.BackColor = Color.Transparent
        Guna2ImageCheckBox1.CheckedState.Image = My.Resources.Resources.icons8_show_60
        Guna2ImageCheckBox1.CheckedState.ImageSize = New Size(30, 30)
        Guna2ImageCheckBox1.HoverState.ImageSize = New Size(30, 30)
        Guna2ImageCheckBox1.Image = My.Resources.Resources.icons8_hide_50
        Guna2ImageCheckBox1.ImageOffset = New Point(0, 0)
        Guna2ImageCheckBox1.ImageRotate = 0F
        Guna2ImageCheckBox1.ImageSize = New Size(30, 30)
        Guna2ImageCheckBox1.Location = New Point(412, 313)
        Guna2ImageCheckBox1.Name = "Guna2ImageCheckBox1"
        Guna2ImageCheckBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges1
        Guna2ImageCheckBox1.Size = New Size(40, 31)
        Guna2ImageCheckBox1.TabIndex = 12
        Guna2ImageCheckBox1.UseTransparentBackground = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(42, 275)
        Label5.Name = "Label5"
        Label5.Size = New Size(91, 26)
        Label5.TabIndex = 9
        Label5.Text = "Password"
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.Transparent
        txtPassword.BorderRadius = 15
        txtPassword.CustomizableEdges = CustomizableEdges2
        txtPassword.DefaultText = ""
        txtPassword.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtPassword.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtPassword.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtPassword.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtPassword.Font = New Font("Segoe UI Variable Display", 12F)
        txtPassword.ForeColor = Color.Black
        txtPassword.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtPassword.Location = New Point(42, 305)
        txtPassword.Margin = New Padding(4)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = ChrW(0)
        txtPassword.PlaceholderText = ""
        txtPassword.SelectedText = ""
        txtPassword.ShadowDecoration.CustomizableEdges = CustomizableEdges3
        txtPassword.Size = New Size(419, 45)
        txtPassword.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(42, 180)
        Label4.Name = "Label4"
        Label4.Size = New Size(97, 26)
        Label4.TabIndex = 7
        Label4.Text = "Username"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(162, 90)
        Label3.Name = "Label3"
        Label3.Size = New Size(192, 26)
        Label3.TabIndex = 6
        Label3.Text = "Control Login System"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Emoji", 24F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(486, 566)
        Label2.Name = "Label2"
        Label2.Size = New Size(341, 43)
        Label2.TabIndex = 5
        Label2.Text = "Login as Administrator"
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.Transparent
        txtUsername.BorderRadius = 15
        txtUsername.CustomizableEdges = CustomizableEdges4
        txtUsername.DefaultText = ""
        txtUsername.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtUsername.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtUsername.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtUsername.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtUsername.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.ForeColor = Color.Black
        txtUsername.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtUsername.Location = New Point(42, 210)
        txtUsername.Margin = New Padding(4)
        txtUsername.Name = "txtUsername"
        txtUsername.PasswordChar = ChrW(0)
        txtUsername.PlaceholderText = ""
        txtUsername.SelectedText = ""
        txtUsername.ShadowDecoration.CustomizableEdges = CustomizableEdges5
        txtUsername.Size = New Size(419, 45)
        txtUsername.TabIndex = 4
        ' 
        ' btnLogin
        ' 
        btnLogin.BorderRadius = 15
        btnLogin.CustomizableEdges = CustomizableEdges6
        btnLogin.DisabledState.BorderColor = Color.DarkGray
        btnLogin.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogin.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogin.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogin.FillColor = Color.FromArgb(CByte(255), CByte(112), CByte(8))
        btnLogin.Font = New Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.HoverState.FillColor = Color.FromArgb(CByte(255), CByte(159), CByte(89))
        btnLogin.Location = New Point(42, 408)
        btnLogin.Name = "btnLogin"
        btnLogin.ShadowDecoration.CustomizableEdges = CustomizableEdges7
        btnLogin.Size = New Size(419, 45)
        btnLogin.TabIndex = 2
        btnLogin.Text = "LOGIN"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Variable Display", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(86, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(336, 43)
        Label1.TabIndex = 0
        Label1.Text = "Login as Administrator"
        ' 
        ' Guna2ControlBox1
        ' 
        Guna2ControlBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Guna2ControlBox1.BackColor = Color.Transparent
        Guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom
        Guna2ControlBox1.CustomIconSize = 20F
        Guna2ControlBox1.CustomizableEdges = CustomizableEdges8
        Guna2ControlBox1.FillColor = Color.Transparent
        Guna2ControlBox1.IconColor = Color.White
        Guna2ControlBox1.Location = New Point(822, 3)
        Guna2ControlBox1.Name = "Guna2ControlBox1"
        Guna2ControlBox1.PressedColor = Color.White
        Guna2ControlBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges9
        Guna2ControlBox1.Size = New Size(50, 50)
        Guna2ControlBox1.TabIndex = 1
        ' 
        ' LOGINFORM
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.image__6_
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(874, 569)
        Controls.Add(Guna2ControlBox1)
        Controls.Add(Panel1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Name = "LOGINFORM"
        StartPosition = FormStartPosition.CenterScreen
        Text = "PDL's Management System"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLogin As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtUsername As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2ImageCheckBox1 As Guna.UI2.WinForms.Guna2ImageCheckBox
    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
End Class
