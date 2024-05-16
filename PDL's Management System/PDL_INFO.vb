Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class PDL_INFO
    Public Sub PDL_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        edit_btn.Visible = True
        update_btn.Visible = False
        cancel_btn.Visible = False
        delete_btn.Visible = False
        PopulateComboBox(cellblock_location)
        DisplayPDLsForCellBlock()

    End Sub

    Public Sub New(rowData As List(Of List(Of String)), Optional isTabPage3 As Boolean = False, Optional isTabPage1 As Boolean = False, Optional isTabPage5 As Boolean = False)
        InitializeComponent()
        If isTabPage3 Then
            For Each rowDataItem As List(Of String) In rowData
                cellblock_display.Text = rowDataItem(0)
                gender_unit_display.Text = rowDataItem(1)
                If rowDataItem.Count >= 4 Then
                    cell_block_table.Rows.Add(rowDataItem(2) & " " & rowDataItem(3))
                Else
                    cell_block_table.Rows.Add("No PDL assigned")
                End If
                If rowDataItem.Count >= 5 Then
                    display_capacity.Text = rowDataItem(4)
                End If
            Next
        ElseIf isTabPage1 Then
            For Each rowDataItem As List(Of String) In rowData
                If rowDataItem.Count > 1 Then
                    case_unique_val.Text = rowDataItem(0)
                    first_name_pdl.Text = rowDataItem(1)
                    last_name_pdl.Text = rowDataItem(2)
                    status_box.Text = rowDataItem(3)
                    crime_listed.Text = rowDataItem(4)
                    gender_profile.Text = rowDataItem(5)
                    Dim dateBirth As DateTime = GetDateTimeFromMySQLDate(rowDataItem(6))
                    birth_display.Value = dateBirth
                    years_sentence.Text = rowDataItem(7)
                    display_cellBlockVal.Text = rowDataItem(8)
                    If rowDataItem.Count >= 10 Then
                        display_capacity.Text = rowDataItem(9)
                    End If
                End If
            Next
        ElseIf isTabPage5 Then
            For Each rowDataItem As List(Of String) In rowData
                If rowDataItem.Count >= 4 Then
                    visitor_name.Text = rowDataItem(0)
                    visited_pdl_name.Text = rowDataItem(1)
                    schedule_date.Text = rowDataItem(2)
                    schedule_time.Text = rowDataItem(3)
                End If
            Next
        Else

        End If
    End Sub

    Private Function GetDateTimeFromMySQLDate(mysqlDate As String) As DateTime
        Dim formats() As String = {"yyyy-MM-dd", "dd/MM/yyyy hh:mm:ss tt"}
        Dim dateResult As DateTime
        If DateTime.TryParseExact(mysqlDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, dateResult) Then
            Return dateResult
        Else
            Throw New ArgumentException("Invalid date format: " & mysqlDate)
        End If
    End Function

    Private editButtonClicked As Boolean = False
    Private Sub edit_btn_Click(sender As Object, e As EventArgs) Handles edit_btn.Click
        If Not String.IsNullOrEmpty(display_cellBlockVal.Text) Then
            If Not editButtonClicked Then
                cellblock_location.Items.Add(display_cellBlockVal.Text)
                cellblock_location.SelectedIndex = cellblock_location.Items.Count - 1
                editButtonClicked = True
            Else
                cellblock_location.Items.Clear()
                PopulateComboBox(cellblock_location)
                editButtonClicked = False
            End If
        End If

        first_name_pdl.FillColor = Color.White
        first_name_pdl.ForeColor = Color.Black
        first_name_pdl.ReadOnly = False

        last_name_pdl.FillColor = Color.White
        last_name_pdl.ForeColor = Color.Black
        last_name_pdl.ReadOnly = False

        case_unique_val.FillColor = Color.White
        case_unique_val.ForeColor = Color.Black
        case_unique_val.ReadOnly = False

        cellblock_location.Visible = True
        display_cellBlockVal.Visible = False

        gender_profile.FillColor = Color.White
        gender_profile.ForeColor = Color.Black
        gender_profile.Enabled = True

        birth_display.FillColor = Color.White
        birth_display.ForeColor = Color.Black
        birth_display.Enabled = True

        status_box.FillColor = Color.White
        status_box.ForeColor = Color.Black
        status_box.Enabled = True

        crime_listed.FillColor = Color.White
        crime_listed.ForeColor = Color.Black
        crime_listed.ReadOnly = False

        years_sentence.FillColor = Color.White
        years_sentence.ForeColor = Color.Black
        years_sentence.ReadOnly = False

        edit_btn.Visible = False
        update_btn.Visible = True
        cancel_btn.Visible = True
        delete_btn.Visible = True
    End Sub

    Private Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        first_name_pdl.FillColor = Color.FromArgb(41, 73, 98)
        first_name_pdl.ForeColor = Color.White
        first_name_pdl.ReadOnly = True

        last_name_pdl.FillColor = Color.FromArgb(41, 73, 98)
        last_name_pdl.ForeColor = Color.White
        last_name_pdl.ReadOnly = True

        case_unique_val.FillColor = Color.FromArgb(41, 73, 98)
        case_unique_val.ForeColor = Color.White
        case_unique_val.ReadOnly = True

        cellblock_location.Visible = False
        display_cellBlockVal.Visible = True

        gender_profile.FillColor = Color.FromArgb(41, 73, 98)
        gender_profile.ForeColor = Color.White
        status_box.Enabled = False

        birth_display.FillColor = Color.FromArgb(41, 73, 98)
        birth_display.ForeColor = Color.White
        birth_display.Enabled = False

        status_box.FillColor = Color.FromArgb(41, 73, 98)
        status_box.ForeColor = Color.White
        status_box.Enabled = False

        crime_listed.FillColor = Color.FromArgb(41, 73, 98)
        crime_listed.ForeColor = Color.White
        crime_listed.ReadOnly = True

        years_sentence.FillColor = Color.FromArgb(41, 73, 98)
        years_sentence.ForeColor = Color.White
        years_sentence.ReadOnly = True


        edit_btn.Visible = True
        update_btn.Visible = False
        cancel_btn.Visible = False
        delete_btn.Visible = False
    End Sub

    Private Sub update_btn_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        first_name_pdl.FillColor = Color.FromArgb(41, 73, 98)
        first_name_pdl.ForeColor = Color.White
        first_name_pdl.ReadOnly = True

        last_name_pdl.FillColor = Color.FromArgb(41, 73, 98)
        last_name_pdl.ForeColor = Color.White
        last_name_pdl.ReadOnly = True

        case_unique_val.FillColor = Color.FromArgb(41, 73, 98)
        case_unique_val.ForeColor = Color.White
        case_unique_val.ReadOnly = True

        cellblock_location.Visible = False
        display_cellBlockVal.Visible = True

        gender_profile.FillColor = Color.FromArgb(41, 73, 98)
        gender_profile.ForeColor = Color.White
        status_box.Enabled = False

        birth_display.FillColor = Color.FromArgb(41, 73, 98)
        birth_display.ForeColor = Color.White
        birth_display.Enabled = False

        status_box.FillColor = Color.FromArgb(41, 73, 98)
        status_box.ForeColor = Color.White
        status_box.Enabled = False

        crime_listed.FillColor = Color.FromArgb(41, 73, 98)
        crime_listed.ForeColor = Color.White
        crime_listed.ReadOnly = True

        years_sentence.FillColor = Color.FromArgb(41, 73, 98)
        years_sentence.ForeColor = Color.White
        years_sentence.ReadOnly = True

        edit_btn.Visible = True
        update_btn.Visible = False
        cancel_btn.Visible = False
        delete_btn.Visible = False
        Dim dashboardForm As New DASHBOARD
        Try
            Dim updatedCaseNum = case_unique_val.Text
            Dim updatedFirstName = first_name_pdl.Text
            Dim updatedLastName = last_name_pdl.Text
            Dim updatedStatus = status_box.Text
            Dim updatedCrime = crime_listed.Text
            Dim updatedGender = gender_profile.Text
            Dim updatedDateOfBirth = birth_display.Value.ToString("yyyy-MM-dd")
            Dim updatedYearsSentence = years_sentence.Text
            Dim updatedCellBLock = cellblock_location.Text
            OpenConnection()

            If conn.State = ConnectionState.Open Then
                ' Update data in the database
                UpdateDataInDatabase(updatedCaseNum, updatedFirstName, updatedLastName, updatedStatus, updatedCrime, updatedGender, updatedDateOfBirth, updatedYearsSentence, updatedCellBLock)
                MessageBox.Show("Information updated successfully!")
                dashboardForm.RefreshDataGridView()
                dashboardForm.DisplayStatusCounts()
                ' Clear the DataGridView rows and refresh it
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating data in database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
        Close()
    End Sub

    Private Sub UpdateDataInDatabase(caseNum As String, firstName As String, lastName As String, status As String, crime As String, gender As String, dateOfBirth As String, yearsSentence As String, cellBLock As String)
        ' Construct the SQL update query
        Dim query As String = "UPDATE pdl_list SET first_name = @firstName, last_name = @lastName, status = @status, crime = @crime, gender = @gender, date_birth = @dateOfBirth, sentence_years = @yearsSentence, cellblock_id = @cellblockid WHERE case_num = @caseNum"
        Using cmd As New MySqlCommand(query, conn)
            ' Add parameters to the command
            cmd.Parameters.AddWithValue("@firstName", firstName)
            cmd.Parameters.AddWithValue("@lastName", lastName)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@crime", crime)
            cmd.Parameters.AddWithValue("@gender", gender)
            cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth)
            cmd.Parameters.AddWithValue("@yearsSentence", yearsSentence)
            cmd.Parameters.AddWithValue("@caseNum", caseNum)
            cmd.Parameters.AddWithValue("@cellblockid", cellBLock)
            ' Execute the update query
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub PDL_INFO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2Panel2.BackColor = Color.FromArgb(90, 0, 0, 0)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            ' Get the values from the textboxes
            Dim caseNum = input_caseNum.Text
            Dim firstName = input_fname.Text
            Dim lastName = input_Lname.Text
            Dim status = input_status.Text
            Dim crime = input_crime.Text
            Dim gender = input_gender.Text
            Dim dateOfBirth = input_birth_picker.Value.ToString("yyyy-MM-dd")
            Dim sentenceYears = input_sentence.Text
            Dim cellBlock = assign_cellblock.Text

            ' Open the database connection
            OpenConnection()
            Dim query = "INSERT INTO pdl_list (case_num, first_name, last_name, status, crime, gender, date_birth, sentence_years, cellblock_id) VALUES (@caseNum, @firstName, @lastName, @status, @crime, @gender, @dateOfBirth, @sentenceYears, @cellblockid)"

            Using cmd As New MySqlCommand(query, conn)
                ' Add parameters to the command
                cmd.Parameters.AddWithValue("@caseNum", caseNum)
                cmd.Parameters.AddWithValue("@firstName", firstName)
                cmd.Parameters.AddWithValue("@lastName", lastName)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@crime", crime)
                cmd.Parameters.AddWithValue("@gender", gender)
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth)
                cmd.Parameters.AddWithValue("@sentenceYears", sentenceYears)
                cmd.Parameters.AddWithValue("@cellblockid", cellBlock)

                ' Execute the insert query
                cmd.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("New data added to the database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            ' Display an error message if an exception occurs
            MessageBox.Show("Error adding new data to the database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            CloseConnection()
        End Try
        Close()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles delete_btn.Click
        Dim caseNum = case_unique_val.Text ' Assuming input_caseNum contains the case number to be deleted

        ' Display a confirmation message
        Dim result = MessageBox.Show("Are you sure you want to delete this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check the user's response
        If result = DialogResult.Yes Then
            DeleteDataFromDatabase(caseNum)
            Close()
        Else
            ' User chose not to delete, do nothing
        End If
    End Sub

    Private Sub DeleteDataFromDatabase(caseNum As String)
        Try
            OpenConnection()
            ' Construct the SQL delete query
            Dim query As String = "DELETE FROM pdl_list WHERE case_num = @caseNum"
            Using cmd As New MySqlCommand(query, conn)
                ' Add parameter to the command
                cmd.Parameters.AddWithValue("@caseNum", caseNum)
                ' Execute the delete query
                cmd.ExecuteNonQuery()

                ' Display a success message
                MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            ' Display an error message if an exception occurs
            MessageBox.Show("Error deleting data from the database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            CloseConnection()
        End Try
    End Sub

    Private Sub cancel_back_btn_Click(sender As Object, e As EventArgs) Handles cancel_back_btn.Click
        Close()
    End Sub

    Private Sub cell_save_btn_Click(sender As Object, e As EventArgs) Handles cell_save_btn.Click
        Dim dashboardForm As New DASHBOARD
        Try
            If String.IsNullOrEmpty(cell_blocknum.Text) Then
                MessageBox.Show("Please enter a cell block number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim cellblockId = cell_blocknum.Text
            Dim cellCapacity As Integer = cell_block_capacity.Value
            Dim genderUnit = cell_gender_units.SelectedItem.ToString

            OpenConnection()
            dashboardForm.RefreshDataGridView()
            dashboardForm.DisplayStatusCounts()
            Dim query = "INSERT INTO cell_block_list (cellblock_id, cell_capacity, gender_unit) VALUES (@cellblockId, @cellCapacity, @genderUnit)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@cellblockId", cellblockId)
                cmd.Parameters.AddWithValue("@cellCapacity", cellCapacity)
                cmd.Parameters.AddWithValue("@genderUnit", genderUnit)
                cmd.ExecuteNonQuery()
                MessageBox.Show("New cell block added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            ' Display an error message if an exception occurs
            MessageBox.Show("Error adding new cell block: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            CloseConnection()
        End Try
        Close()
    End Sub

    Public Sub PopulateComboBox(comboBox As Guna.UI2.WinForms.Guna2ComboBox)
        comboBox.Items.Clear()
        Try
            OpenConnection()
            If conn.State = ConnectionState.Open Then
                Dim gender As String = If(String.IsNullOrWhiteSpace(input_gender.Text), gender_profile.Text, input_gender.Text)
                Dim query As String = "SELECT DISTINCT cb.cellblock_id " &
                                  "FROM cell_block_list cb " &
                                  "LEFT JOIN (SELECT cellblock_id, COUNT(*) AS num_occupants FROM pdl_list GROUP BY cellblock_id) AS pl " &
                                  "ON cb.cellblock_id = pl.cellblock_id " &
                                  "LEFT JOIN pdl_list AS pdl ON cb.cellblock_id = pdl.cellblock_id " &
                                  "WHERE cb.gender_unit = @gender AND (pl.num_occupants IS NULL OR pl.num_occupants < cb.cell_capacity)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@gender", gender)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            comboBox.Items.Add(reader("cellblock_id").ToString())
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub gender_profile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gender_profile.SelectedIndexChanged
        PopulateComboBox(cellblock_location)
    End Sub

    Private Sub input_gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles input_gender.SelectedIndexChanged
        PopulateComboBox(assign_cellblock)
    End Sub

    Private Sub createCell_cancelBtn_Click(sender As Object, e As EventArgs) Handles createCell_cancelBtn.Click
        Me.Close()
    End Sub

    Private Sub cell_modify_btn_Click(sender As Object, e As EventArgs) Handles cell_modify_btn.Click
        cell_modify_btn.Visible = False
        cell_delete_btn.Visible = True
        save_btn_cell.Visible = True
        cell_cancel_btn.Visible = True
        cellval_display_capacity.Visible = True
        display_capacity.Visible = False
    End Sub

    Private Sub save_btn_cell_Click(sender As Object, e As EventArgs) Handles save_btn_cell.Click
        Dim dashboardForm As New DASHBOARD
        Try
            If cellval_display_capacity.Value <= 0 Then
                MessageBox.Show("Please enter a valid capacity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim cellblockId As String = cellblock_display.Text
            Dim cellCapacity As Integer = CInt(cellval_display_capacity.Value)

            OpenConnection()
            dashboardForm.RefreshDataGridView()
            dashboardForm.DisplayStatusCounts()
            If Not cellval_display_capacity.Value <= 0 Then
                Dim updateQuery As String = "UPDATE cell_block_list SET cell_capacity = @cellCapacity WHERE cellblock_id = @cellblockId"

                Using updateCmd As New MySqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@cellCapacity", cellCapacity)
                    updateCmd.Parameters.AddWithValue("@cellblockId", cellblockId)
                    updateCmd.ExecuteNonQuery()
                    MessageBox.Show("Cell Capacity update successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
        cell_modify_btn.Visible = True
        cell_delete_btn.Visible = False
        save_btn_cell.Visible = False
        cell_cancel_btn.Visible = False
        cellval_display_capacity.Visible = False
        display_capacity.Visible = True
        Me.Close()
    End Sub

    Private Sub DisplayPDLsForCellBlock()
        Try
            OpenConnection()
            Dim cellblockId As String = cellblock_display.Text
            Dim query As String = "SELECT cb.cellblock_id, cb.gender_unit, pdl.first_name, pdl.last_name, cb.cell_capacity, IFNULL(pl.num_occupants, 0) AS num_occupants " &
                                "FROM cell_block_list cb " &
                                "LEFT JOIN pdl_list pdl ON cb.cellblock_id = pdl.cellblock_id " &
                                "LEFT JOIN (SELECT cellblock_id, COUNT(*) AS num_occupants FROM pdl_list GROUP BY cellblock_id) AS pl ON cb.cellblock_id = pl.cellblock_id " &
                                "WHERE cb.cellblock_id = @cellblockId"
            Using cmd As New MySqlCommand(query, Connection.conn)
                cmd.Parameters.AddWithValue("@cellblockId", cellblockId)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    cellblock_display.Text = reader("cellblock_id").ToString()
                    gender_unit_display.Text = reader("gender_unit").ToString()
                    Dim numOccupants As Integer = Convert.ToInt32(reader("num_occupants"))
                    Dim cellCapacity As Integer = Convert.ToInt32(reader("cell_capacity"))
                    Dim displayCapacity As String = $"{numOccupants}/{cellCapacity}"
                    display_capacity.Text = displayCapacity
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub cell_cancel_btn_Click(sender As Object, e As EventArgs) Handles cell_cancel_btn.Click
        cell_modify_btn.Visible = True
        cell_delete_btn.Visible = False
        save_btn_cell.Visible = False
        cell_cancel_btn.Visible = False
        cellval_display_capacity.Visible = False
        display_capacity.Visible = True
    End Sub

    Public Sub New(visitorName As String, pdlName As String, scheduleDate As String, scheduleTime As String)
        InitializeComponent()
        Guna2TabControl1.SelectedTab = TabPage5
        visitor_name.Text = visitorName
        visited_pdl_name.Text = pdlName
        schedule_date.Text = scheduleDate
        schedule_time.Text = scheduleTime
    End Sub

    'NEED TO FIX'
    Private Sub visit_decline_Click(sender As Object, e As EventArgs) Handles visit_decline.Click
        Dim visitorUsername As String = visitor_name.Text
        Dim connectionString As String = "your_connection_string"
        Dim query As String = "UPDATE appointment_requests SET status_id = 3 WHERE visitor_username = @visitor_username"

        Using conn As New MySqlConnection(connectionString)
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@visitor_username", visitorUsername)
            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Appointment Declined.")
            Me.Close()
        End Using
    End Sub

    Private Sub visit_confirm_Click(sender As Object, e As EventArgs) Handles visit_confirm.Click
        Dim visitorUsername As String = visitor_name.Text
        Dim connectionString As String = "your_connection_string"
        Dim query As String = "UPDATE appointment_requests SET status_id = 2 WHERE visitor_username = @visitor_username"

        Using conn As New MySqlConnection(connectionString)
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@visitor_username", visitorUsername)
            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Appointment Confirmed.")
            Me.Close()
        End Using
    End Sub
End Class