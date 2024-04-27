Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class DASHBOARD
    Private Sub DASHBOARD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        If Connection.conn.State = ConnectionState.Open Then
            Try
                ' SQL query to retrieve the admin_key for the entered username and password
                Dim query As String = "SELECT admin_key FROM admin WHERE username = @username AND password = @password;"
                Using cmd As New MySqlCommand(query, Connection.conn)
                    ' Provide parameter values for username and password from text boxes
                    cmd.Parameters.AddWithValue("@username", LOGINFORM.txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", LOGINFORM.txtPassword.Text.Trim())

                    ' Execute the query and retrieve the admin_key
                    Dim adminKey As Object = cmd.ExecuteScalar()

                    If adminKey IsNot Nothing AndAlso Not DBNull.Value.Equals(adminKey) Then
                        ' Display the admin_key in a label on the form
                        admin_key.Text = "Admin - " & Convert.ToString(adminKey)
                    Else
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving admin key: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Database connection is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub TabButton_Click(sender As Object, e As EventArgs) Handles Btn_1.Click, Btn_2.Click, Btn_3.Click, Btn_4.Click, Btn_5.Click
        ' Cast the sender object back to a Button to identify which button was clicked
        Dim clickedButton = DirectCast(sender, Guna2Button)
        Select Case clickedButton.Name
            Case "Btn_1"
                TabControl.SelectedTab = dash
            Case "Btn_2"
                TabControl.SelectedTab = cell
            Case "Btn_3"
                TabControl.SelectedTab = pdl
            Case "Btn_4"
                TabControl.SelectedTab = vis
            Case "Btn_5"
                TabControl.SelectedTab = rep
        End Select
        For Each btn In {Btn_1, Btn_2, Btn_3, Btn_4, Btn_5}
            btn.Checked = btn Is clickedButton
        Next
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        Select Case TabControl.SelectedTab.Name
            Case "dash"
                lblDisplay.Text = "Dashboard"
            Case "cell"
                lblDisplay.Text = "Cell Block List"
            Case "pdl"
                lblDisplay.Text = "PDL's List"
            Case "vis"
                lblDisplay.Text = "Visitor List"
            Case "rep"
                lblDisplay.Text = "Reports"
            Case Else
                lblDisplay.Text = "-"
        End Select
    End Sub

    Private Sub dash_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add sample data to the Guna2DataGridView
        Guna2DataGridView1.Rows.Add("Block A", "Cell 101", "Male")
        Guna2DataGridView1.Rows.Add("Block B", "Cell 202", "Female")

        ' Add action buttons to each row
        For Each row As DataGridViewRow In Guna2DataGridView1.Rows
            Dim actionCell As New DataGridViewButtonCell()
            actionCell.Value = "View"
            row.Cells("act") = actionCell
            actionCell.Style.ForeColor = Color.White ' Set text color
            actionCell.Style.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
            actionCell.Style.Padding = New Padding(10, 5, 10, 5)
        Next
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        ' Check if the clicked cell is in the "Action" column
        If e.ColumnIndex = Guna2DataGridView1.Columns("act").Index AndAlso e.RowIndex >= 0 Then
            Dim selectedRow = Guna2DataGridView1.Rows(e.RowIndex)

            ' Check if the cell value is not Nothing before accessing it
            If selectedRow.Cells("block_num").Value IsNot Nothing AndAlso
                   selectedRow.Cells("cell_num").Value IsNot Nothing AndAlso
                   selectedRow.Cells("gen").Value IsNot Nothing Then
                Dim blockNumber = selectedRow.Cells("block_num").Value.ToString
                Dim cellNumber = selectedRow.Cells("cell_num").Value.ToString
                Dim gender = selectedRow.Cells("gen").Value.ToString

                ' Perform action based on the data in the row
                ' Change this into Panel Display hide, If the button clicked it will show the panel
                MessageBox.Show($"Block Number: {blockNumber}, Cell Number: {cellNumber}, Gender: {gender}", "Action Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                selectedRow.Cells("act").Value = Nothing
            End If
        End If
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged

    End Sub
End Class
