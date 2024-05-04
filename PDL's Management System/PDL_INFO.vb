Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class PDL_INFO
    Public Sub PDL_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        edit_btn.Visible = True
        update_btn.Visible = False
        cancel_btn.Visible = False
        delete_btn.Visible = False
    End Sub

    Public Sub New(rowData As List(Of String))
        ' This call is required by the designer.
        InitializeComponent()
        ' Display information based on the provided row data
        Try

            ' Check if row data is available
            If rowData.Count > 1 Then
                case_unique_val.Text = rowData(0) ' First element is case_num
                first_name_pdl.Text = rowData(1) ' Second element is pdl_name
                last_name_pdl.Text = rowData(2)
                status_box.Text = rowData(3) ' Third element is status
                crime_listed.Text = rowData(4)  ' Fourth element is crime
                gender_profile.Text = rowData(5)  ' Fifth element is gender
                ' Convert the date_birth value to a .NET DateTime object
                Dim dateBirth As DateTime = GetDateTimeFromMySQLDate(rowData(6))
                birth_display.Value = dateBirth

                years_sentence.Text = rowData(7) ' Seventh element is sentence_years
                cell_value_loc.Text = rowData(8)

            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub edit_btn_Click(sender As Object, e As EventArgs) Handles edit_btn.Click
        'Textbox Design
        first_name_pdl.FillColor = Color.White
        first_name_pdl.ForeColor = Color.Black
        first_name_pdl.ReadOnly = False

        last_name_pdl.FillColor = Color.White
        last_name_pdl.ForeColor = Color.Black
        last_name_pdl.ReadOnly = False

        case_unique_val.FillColor = Color.White
        case_unique_val.ForeColor = Color.Black
        case_unique_val.ReadOnly = False

        cell_value_loc.FillColor = Color.White
        cell_value_loc.ForeColor = Color.Black
        cell_value_loc.ReadOnly = False

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

        cell_value_loc.FillColor = Color.FromArgb(41, 73, 98)
        cell_value_loc.ForeColor = Color.White
        cell_value_loc.ReadOnly = True

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

        cell_value_loc.FillColor = Color.FromArgb(41, 73, 98)
        cell_value_loc.ForeColor = Color.White
        cell_value_loc.ReadOnly = True

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
            Dim updatedCellBLock = cell_value_loc.Text
            OpenConnection()

            If conn.State = ConnectionState.Open Then
                ' Update data in the database
                UpdateDataInDatabase(updatedCaseNum, updatedFirstName, updatedLastName, updatedStatus, updatedCrime, updatedGender, updatedDateOfBirth, updatedYearsSentence, updatedCellBLock)
                MessageBox.Show("Information updated successfully!")
                dashboardForm.RefreshDataGridView()
                ' Clear the DataGridView rows and refresh it
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating data in database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
        ' Display a success message
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
            Dim caseNum As String = input_caseNum.Text
            Dim firstName As String = input_fname.Text
            Dim lastName As String = input_Lname.Text
            Dim status As String = input_status.Text
            Dim crime As String = input_crime.Text
            Dim gender As String = input_gender.Text
            Dim dateOfBirth As String = input_birth_picker.Value.ToString("yyyy-MM-dd")
            Dim sentenceYears As String = input_sentence.Text
            Dim cellBlock As String = input_cellblock.Text

            ' Open the database connection
            OpenConnection()
            Dim query As String = "INSERT INTO pdl_list (case_num, first_name, last_name, status, crime, gender, date_birth, sentence_years, cellblock_id) VALUES (@caseNum, @firstName, @lastName, @status, @crime, @gender, @dateOfBirth, @sentenceYears, @cellblockid)"

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
        Me.Close()
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
        Me.Close()
    End Sub
End Class



