Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class DASHBOARD
    Public Sub DASHBOARD_Load(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                ' Retrieve the admin key
                Dim adminQuery As String = "SELECT admin_key FROM admin WHERE username = @username AND password = @password;"
                Using adminCmd As New MySqlCommand(adminQuery, Connection.conn)
                    adminCmd.Parameters.AddWithValue("@username", LOGINFORM.txtUsername.Text.Trim())
                    adminCmd.Parameters.AddWithValue("@password", LOGINFORM.txtPassword.Text.Trim())
                    Dim adminKey As Object = adminCmd.ExecuteScalar()
                    If adminKey IsNot Nothing AndAlso Not DBNull.Value.Equals(adminKey) Then
                        admin_key.Text = "Admin - " & Convert.ToString(adminKey)
                    Else
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
                ' Populate the DataGridView
                RefreshDataGridView()

                RefreshCellBlockDataGrid()
            Else
                MessageBox.Show("Database connection is not open.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Console.WriteLine("Error reading data: " & ex.ToString)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub TabButton_Click(sender As Object, e As EventArgs) Handles Btn_1.Click, Btn_2.Click, Btn_3.Click, Btn_4.Click, Btn_5.Click, log_out.Click
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
            Case "log_out"
                LOGINFORM.Show()
                Me.Close()
                LOGINFORM.txtUsername.Text = ""
                LOGINFORM.txtPassword.Text = ""
        End Select
        For Each btn In {Btn_1, Btn_2, Btn_3, Btn_4, Btn_5, log_out}
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

    Private Sub pdl_searchbar_TextChanged(sender As Object, e As EventArgs) Handles pdl_searchbar.TextChanged
        Dim searchTerm As String = pdl_searchbar.Text.Trim()
        For Each row As DataGridViewRow In pdl_list_information.Rows
            If Not row.IsNewRow Then
                Dim matchFound As Boolean = False
                ' Check if any cell in the specified columns contains the search term
                matchFound = row.Cells.Cast(Of DataGridViewCell)().Where(Function(cell) cell.ColumnIndex >= 0 AndAlso cell.ColumnIndex <= 4 AndAlso cell.Value IsNot Nothing AndAlso cell.Value.ToString().IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).Any()
                row.Visible = If(String.IsNullOrEmpty(searchTerm), True, matchFound)
            End If
        Next
    End Sub

    Public Sub pdl_list_information_ContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pdl_list_information.CellContentClick
        ' Check if the clicked cell is in the "acti" column and not in the header row

        If e.ColumnIndex = pdl_list_information.Columns("acti").Index AndAlso e.RowIndex >= 0 Then
            Try
                ' Get all information for the selected row
                Dim rowData As List(Of String) = GetRowDataFromDatabase(e.RowIndex)

                ' Open the PDL_INFO form and pass the row data
                Dim pdlInfoForm As New PDL_INFO(rowData)
                pdlInfoForm.Guna2TabControl1.SelectedTab = pdlInfoForm.TabPage1
                pdlInfoForm.ShowDialog()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        Try
            OpenConnection()
            If Connection.conn.State = ConnectionState.Open Then
                RefreshDataGridView()
            End If
        Catch ex As Exception
            Throw New Exception("Error updating data in database: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Function GetRowDataFromDatabase(rowIndex As Integer) As List(Of String)
        Dim rowData As New List(Of String)()
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                ' Fetch all information for the selected row
                Dim query As String = "SELECT * FROM pdl_list LIMIT @rowIndex, 1"
                Using cmd As New MySqlCommand(query, Connection.conn)
                    cmd.Parameters.AddWithValue("@rowIndex", rowIndex)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Add all fields to the rowData list
                        For i As Integer = 0 To reader.FieldCount - 1
                            rowData.Add(reader(i).ToString())
                        Next
                    End If
                    reader.Close()
                End Using
            End If
        Catch ex As Exception
            Throw New Exception("Error fetching row data from database: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        Return rowData
    End Function

    Public Sub RefreshDataGridView()
        pdl_list_information.Rows.Clear()
        Dim pdlQuery As String = "SELECT case_num, CONCAT(first_name, ' ', last_name) AS pdlName, status, crime FROM pdl_list"
        Using pdlCmd As New MySqlCommand(pdlQuery, conn)
            Using reader As MySqlDataReader = pdlCmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim caseNum As String = reader.GetString("case_num")
                        Dim pdlName As String = reader.GetString("pdlName") ' Concatenated name
                        Dim status As String = reader.GetString("status")
                        Dim crime As String = reader.GetString("crime")
                        pdl_list_information.Rows.Add(caseNum, pdlName, status, crime)
                    End While
                Else
                    MessageBox.Show("No data found in the pdl_list table.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim rowData As New List(Of String)()
        Dim pdl_info As New PDL_INFO(rowData)
        pdl_info.Guna2TabControl1.SelectedTab = pdl_info.TabPage2
        pdl_info.ShowDialog()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            OpenConnection()
            If Connection.conn.State = ConnectionState.Open Then
                RefreshDataGridView()
            End If
        Catch ex As Exception
            Throw New Exception("Error updating data in database: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub RefreshCellBlockDataGrid()
        cell_block_table.Rows.Clear()
        Dim pdlQuery As String = "SELECT cellblock_id, gender_unit FROM cell_block_list"
        Using pdlCmd As New MySqlCommand(pdlQuery, conn)
            Using reader As MySqlDataReader = pdlCmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim cellId As String = reader.GetString("cellblock_id")
                        Dim gencellUnit As String = reader.GetString("gender_unit")
                        cell_block_table.Rows.Add(cellId, gencellUnit)
                    End While
                Else
                    MessageBox.Show("No data found in the cell_block_list table.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub

    Public Sub cell_block_table_ContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles cell_block_table.CellContentClick
        If e.ColumnIndex = cell_block_table.Columns("act").Index AndAlso e.RowIndex >= 0 Then
            Try
                ' Get all information for the selected row
                Dim rowData As List(Of String) = GetRowDataFromDatabase(e.RowIndex) ' Assuming you have a similar method to fetch row data

                ' Open the PDL_INFO form and pass the row data
                Dim pdlInfoForm As New PDL_INFO(rowData)
                pdlInfoForm.Guna2TabControl1.SelectedTab = pdlInfoForm.TabPage3
                pdlInfoForm.ShowDialog()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


End Class

