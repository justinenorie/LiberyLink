Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports MySql.Data.MySqlClient
Public Class LOGINFORM
    Private Sub LOGINFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = ""
        txtPassword.PasswordChar = "*"
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        If checkCommand("SELECT COUNT(*)FROM admin WHERE username = '" & username & "' AND password = '" & password & "'") Then
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim dashboardForm As New DASHBOARD()
            dashboardForm.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid Username and Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private isPasswordVisible As Boolean = False

    Private Sub Guna2ImageCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ImageCheckBox1.CheckedChanged
        If Guna2ImageCheckBox1.Checked Then
            txtPassword.PasswordChar = ""
            isPasswordVisible = True
        Else
            txtPassword.PasswordChar = "*"
            isPasswordVisible = False
        End If
    End Sub
End Class