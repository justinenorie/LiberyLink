Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class DASHBOARD
    Public Sub DASHBOARD_Load(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                Dim adminQuery As New MySqlCommand("SELECT admin_key FROM admin WHERE username = @username AND password = @password", conn)
                adminQuery.Parameters.AddWithValue("@username", LOGINFORM.txtUsername.Text.Trim())
                adminQuery.Parameters.AddWithValue("@password", LOGINFORM.txtPassword.Text.Trim())
                Dim adminKey As Object = adminQuery.ExecuteScalar()
                If adminKey IsNot Nothing AndAlso Not DBNull.Value.Equals(adminKey) Then
                    admin_key.Text = "Admin - " & Convert.ToString(adminKey)
                Else
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                DisplayStatusCounts()
                RefreshDataGridView()
                RefreshCellBlockDataGrid()
                LoadAppointments()
            Else
                MessageBox.Show("Database connection is not open.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Console.WriteLine("Error reading data: " & ex.ToString)
        Finally
            CloseConnection()
        End Try
    End Sub

    'DASHBOARD DISPLAY'
    'NEEDED TO ADD VISITATION INFORMATION'
    Public Sub DisplayStatusCounts()
        If conn.State = ConnectionState.Open Then
            Dim dashboard_query As New MySqlCommand("SELECT 'Active' AS status, COUNT(*) AS num_rows FROM pdl_list WHERE status = 'Active' " &
                              "UNION " &
                              "SELECT 'Released' AS status, COUNT(*) AS num_rows FROM pdl_list WHERE status = 'Released' " &
                              "UNION " &
                              "SELECT 'Cell Blocks' AS status, COUNT(*) AS num_rows FROM cell_block_list", conn)
            Using reader As MySqlDataReader = dashboard_query.ExecuteReader()
                Dim activeCount As Integer = 0
                Dim releasedCount As Integer = 0
                Dim cellBlockCount As Integer = 0
                While reader.Read()
                    Dim status As String = reader("status").ToString()
                    Dim count As Integer = Convert.ToInt32(reader("num_rows"))
                    If status = "Active" Then
                        activeCount = count
                    ElseIf status = "Released" Then
                        releasedCount = count
                    ElseIf status = "Cell Blocks" Then
                        cellBlockCount = count
                    End If
                End While
                active_pdl_dis.Text = activeCount.ToString()
                released_pdl_dis.Text = releasedCount.ToString()
                total_cell_block.Text = cellBlockCount.ToString()
            End Using
        End If
    End Sub

    Private Sub TabButton_Click(sender As Object, e As EventArgs) Handles Btn_1.Click, Btn_2.Click, Btn_3.Click, Btn_4.Click, Btn_5.Click, log_out.Click
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

    'REFRESH BUTTONS'
    Private Sub pdllist_refresh_btn_Click(sender As Object, e As EventArgs) Handles pdllist_refresh_btn.Click
        pdl_searchbar.Clear()
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                RefreshDataGridView()
                DisplayStatusCounts()
                RefreshCellBlockDataGrid()
            End If
        Catch ex As Exception
            Throw New Exception("Error updating data in database: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub cellblock_refresh_btn_Click(sender As Object, e As EventArgs) Handles cellblock_refresh_btn.Click
        cell_search_bar.Clear()
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                RefreshDataGridView()
                DisplayStatusCounts()
                RefreshCellBlockDataGrid()
            End If
        Catch ex As Exception
            Throw New Exception("Error updating data in database: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    'SEARCH BARS FUNCTION'
    Private Sub pdl_searchbar_TextChanged(sender As Object, e As EventArgs) Handles pdl_searchbar.TextChanged
        Dim searchTerm As String = pdl_searchbar.Text.Trim()
        For Each row As DataGridViewRow In pdl_list_information.Rows
            If Not row.IsNewRow Then
                row.Visible = row.Cells.Cast(Of DataGridViewCell)() _
                .Take(5) _
                .Any(Function(cell) cell.Value IsNot Nothing AndAlso cell.Value.ToString().IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
            End If
        Next
    End Sub

    Private Sub cell_search_bar_TextChanged(sender As Object, e As EventArgs) Handles cell_search_bar.TextChanged
        Dim searchTerm As String = cell_search_bar.Text.Trim()
        Dim isMaleSearch As Boolean = searchTerm.Equals("Male", StringComparison.OrdinalIgnoreCase)
        For Each row As DataGridViewRow In cell_block_table.Rows
            If Not row.IsNewRow Then
                row.Visible = row.Cells.Cast(Of DataGridViewCell) _
                .Take(3) _
                .Any(Function(cell) cell.Value IsNot Nothing AndAlso (If(isMaleSearch,
                cell.Value.ToString().Equals("Male", StringComparison.OrdinalIgnoreCase),
                cell.Value.ToString().IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)))
            End If
        Next
    End Sub

    Public Sub pdl_list_information_ContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pdl_list_information.CellContentClick
        ' Check if the clicked cell is in the "acti" column and not in the header row
        If e.ColumnIndex = pdl_list_information.Columns("acti").Index AndAlso e.RowIndex >= 0 Then
            Dim rowData As List(Of String) = GetRowDataFromDatabase(e.RowIndex)
            Dim rowDataList As New List(Of List(Of String))()
            rowDataList.Add(rowData)
            Dim pdlInfoForm As New PDL_INFO(rowDataList, isTabPage1:=True)
            pdlInfoForm.Guna2TabControl1.SelectedTab = pdlInfoForm.TabPage1
            pdlInfoForm.ShowDialog()
        End If
    End Sub

    Private Function GetRowDataFromDatabase(rowIndex As Integer) As List(Of String)
        Dim rowData As New List(Of String)()
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                Dim pdlList_query As New MySqlCommand("SELECT * FROM pdl_list LIMIT @rowIndex, 1", conn)
                pdlList_query.Parameters.AddWithValue("@rowIndex", rowIndex)
                Dim reader As MySqlDataReader = pdlList_query.ExecuteReader()
                If reader.Read() Then
                    ' Add all fields to the rowData list
                    For i As Integer = 0 To reader.FieldCount - 1
                        rowData.Add(reader(i).ToString())
                    Next
                End If
                reader.Close()
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
        Dim pdlList_Query As New MySqlCommand("SELECT case_num, CONCAT(first_name, ' ', last_name) AS pdlName, status, crime FROM pdl_list", conn)
        Using reader As MySqlDataReader = pdlList_Query.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    Dim caseNum As String = reader.GetString("case_num")
                    Dim pdlName As String = reader.GetString("pdlName")
                    Dim status As String = reader.GetString("status")
                    Dim crime As String = reader.GetString("crime")
                    pdl_list_information.Rows.Add(caseNum, pdlName, status, crime)
                End While
            Else
                MessageBox.Show("No data found in the pdl_list table.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub create_pdl_list_Click(sender As Object, e As EventArgs) Handles create_pdl_list.Click
        Dim rowDataList As New List(Of List(Of String))()
        ' Now you can pass rowDataList to the constructor
        Dim pdlInfoForm As New PDL_INFO(rowDataList)
        pdlInfoForm.Guna2TabControl1.SelectedTab = pdlInfoForm.TabPage2
        pdlInfoForm.ShowDialog()
    End Sub

    Public Sub RefreshCellBlockDataGrid()
        cell_block_table.Rows.Clear()
        Dim cellblock_Query As New MySqlCommand("SELECT cellblock_id, gender_unit FROM cell_block_list", conn)
        Using reader As MySqlDataReader = cellblock_Query.ExecuteReader()
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
    End Sub

    Private Function GetFromCellBlockList(cellblockId As String) As List(Of List(Of String))
        Dim rowDataList As New List(Of List(Of String))()
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                ' Define the SQL query to retrieve data
                Dim cellblock_Query As New MySqlCommand("SELECT cb.cellblock_id, cb.gender_unit, pdl.first_name, pdl.last_name, cb.cell_capacity, IFNULL(pl.num_occupants, 0) AS num_occupants " &
                            "FROM cell_block_list cb " &
                            "LEFT JOIN pdl_list pdl ON cb.cellblock_id = pdl.cellblock_id " &
                            "LEFT JOIN (SELECT cellblock_id, COUNT(*) AS num_occupants FROM pdl_list GROUP BY cellblock_id) AS pl ON cb.cellblock_id = pl.cellblock_id " &
                            "WHERE cb.cellblock_id = @cellblockId", conn)
                cellblock_Query.Parameters.AddWithValue("@cellblockId", cellblockId)
                Dim reader As MySqlDataReader = cellblock_Query.ExecuteReader()
                While reader.Read()
                    Dim rowData As New List(Of String)()
                    rowData.Add(reader("cellblock_id").ToString())
                    rowData.Add(reader("gender_unit").ToString())
                    ' Add first_name and last_name if they are not null
                    If Not IsDBNull(reader("first_name")) Then
                        rowData.Add(reader("first_name").ToString())
                    End If
                    If Not IsDBNull(reader("last_name")) Then
                        rowData.Add(reader("last_name").ToString())
                    End If
                    Dim cellCapacity As Integer = Convert.ToInt32(reader("cell_capacity"))
                    Dim numOccupants As Integer = Convert.ToInt32(reader("num_occupants"))
                    Dim displayCapacity As String = $"{numOccupants}/{cellCapacity}"
                    rowData.Add(displayCapacity)
                    rowDataList.Add(rowData)
                    End While
                reader.Close()
            End If
        Catch ex As Exception
            Throw New Exception("Error fetching row data from database: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        Return rowDataList
    End Function

    Public Sub cell_block_table_ContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles cell_block_table.CellContentClick
        If e.ColumnIndex = cell_block_table.Columns("act").Index AndAlso e.RowIndex >= 0 Then
            Try
                Dim cellblockId As String = cell_block_table.Rows(e.RowIndex).Cells("cell_num").Value.ToString()
                Dim rowDataList As List(Of List(Of String)) = GetFromCellBlockList(cellblockId)
                If rowDataList.Count > 0 Then
                    Dim pdlInfoForm As New PDL_INFO(rowDataList, True)
                    pdlInfoForm.Guna2TabControl1.SelectedTab = pdlInfoForm.TabPage3
                    pdlInfoForm.ShowDialog()
                Else
                    MessageBox.Show("Error: Unable to retrieve data for the selected cellblock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub create_new_cellblock_Click(sender As Object, e As EventArgs) Handles create_new_cellblock.Click
        DisplayStatusCounts()
        Dim rowDataList As New List(Of List(Of String))()
        Dim pdlInfoForm As New PDL_INFO(rowDataList)
        pdlInfoForm.Guna2TabControl1.SelectedTab = pdlInfoForm.TabPage4
        pdlInfoForm.ShowDialog()
    End Sub

    Public Sub LoadAppointments()
        visitors_sched.Rows.Clear()
        Dim appointment_Query As New MySqlCommand("SELECT request_id, visitor_username, CONCAT(pdl_first_name, ' ', pdl_last_name) AS pdl_full_name, requested_date, requested_time FROM appointment_requests", conn)
        Try
            If conn.State = ConnectionState.Open Then
                Using reader As MySqlDataReader = appointment_Query.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            Dim reqID As String = reader.GetInt32("request_id").ToString()
                            Dim visitorUsern As String = reader.GetString("visitor_username")
                            Dim pdlFullName As String = reader.GetString("pdl_full_name")
                            Dim requestDate As String = reader.GetDateTime("requested_date").ToString("yyyy-MM-dd")
                            Dim requestTime As String = reader.GetTimeSpan("requested_time").ToString()
                            visitors_sched.Rows.Add(reqID, visitorUsern, pdlFullName, requestDate, requestTime)
                        End While
                    Else
                        MessageBox.Show("No data found in the table.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Else
                MessageBox.Show("Database connection is not open.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub visitors_sched_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles visitors_sched.CellContentClick
        If e.ColumnIndex = visitors_sched.Columns("sched_act").Index AndAlso e.RowIndex >= 0 Then
            Try
                Dim visitorName As String = visitors_sched.Rows(e.RowIndex).Cells("visitor_reqID").Value.ToString()
                Dim rowDataList As List(Of List(Of String)) = GetFromVisitorDatabase(visitorName)
                Dim pdlInfoForm As New PDL_INFO(rowDataList, isTabPage5:=True)
                pdlInfoForm.Guna2TabControl1.SelectedTab = pdlInfoForm.TabPage5
                pdlInfoForm.ShowDialog()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function GetFromVisitorDatabase(visitorUsername As String) As List(Of List(Of String))
        Dim rowDataList As New List(Of List(Of String))()
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                Dim getVisitors_query As New MySqlCommand("SELECT * FROM appointment_requests WHERE request_id = @requestID", conn)
                getVisitors_query.Parameters.AddWithValue("@requestID", visitorUsername)
                Using reader As MySqlDataReader = getVisitors_query.ExecuteReader()
                    While reader.Read()
                        Dim rowData As New List(Of String)
                        For i As Integer = 0 To reader.FieldCount - 1
                            rowData.Add(reader(i).ToString())
                        Next
                        rowDataList.Add(rowData)
                    End While
                End Using
            End If
        Catch ex As Exception
            Throw New Exception("Error fetching row data from database: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        Return rowDataList
    End Function
End Class