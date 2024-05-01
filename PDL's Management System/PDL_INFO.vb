Imports System.Xml
Imports MySql.Data.MySqlClient

Public Class PDL_INFO
    Public Sub New(rowData As List(Of String))
        ' This call is required by the designer.
        InitializeComponent()

        ' Display information based on the provided row data
        Try
            ' Check if row data is available
            If rowData.Count > 1 Then
                case_unique_val.Text = rowData(0) ' First element is case_num
                name_of_pdl.Text = rowData(1) ' Second element is pdl_name
                status_assign.Text = rowData(2) ' Third element is status
                crime_commit.Text = rowData(3)  ' Fourth element is crime
                gender_value.Text = rowData(4)  ' Fifth element is gender

                ' Convert the date_birth value to a .NET DateTime object
                Dim dateBirth As DateTime = GetDateTimeFromMySQLDate(rowData(5))
                date_birth.Text = dateBirth.ToString("yyyy-MM-dd")

                years_sentence.Text = rowData(6) ' Seventh element is sentence_years
            Else
                MessageBox.Show("No record found for the given row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    'CONFIGURATION FOR DATABASE ALSO
    Private Sub edit_btn_Click(sender As Object, e As EventArgs) Handles edit_btn.Click
        'Textbox readonly to false
        tixtbox1.ReadOnly = False
        name_of_pdl.ReadOnly = False

        edit_btn.Visible = False
        update_btn.Visible = True

        'Textbox Design
        tixtbox1.FillColor = Color.White
        name_of_pdl.FillColor = Color.White
    End Sub

    Private Sub update_btn_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        tixtbox1.ReadOnly = True
        name_of_pdl.ReadOnly = True

        edit_btn.Visible = True
        update_btn.Visible = False

        'Textbox Design
        tixtbox1.FillColor = Color.FromArgb(77, 100, 141)
        name_of_pdl.FillColor = Color.FromArgb(0, 63, 94)
        mesahebox.Show("Update Sucess!")
    End Sub
End Class
