Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports MySql.Data.MySqlClient
Public Class LOGINFORM
    Private Sub LOGINFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = ""
        txtPassword.PasswordChar = "*"
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Try
            Connection.OpenConnection()
            If Connection.conn.State = ConnectionState.Open Then
                Dim query As String = "SELECT * FROM admin WHERE username = @username AND password = @password"

                Using command As New MySqlCommand(query, Connection.conn)
                    command.Parameters.AddWithValue("@username", username)
                    command.Parameters.AddWithValue("@password", password)

                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    If reader.HasRows Then
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        reader.Close()
                        Dim dashboardForm As New DASHBOARD()
                        dashboardForm.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Else
                MessageBox.Show("Failed to open database connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connection.CloseConnection()
        End Try
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