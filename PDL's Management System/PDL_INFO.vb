Imports MySql.Data.MySqlClient

Public Class PDL_INFO
    Public Sub New(rowData As List(Of String))
        ' This call is required by the designer.
        InitializeComponent()

        ' Display information based on the provided row data
        Try
            ' Check if row data is available
            If rowData.Count > 1 Then
                case_num_label.Text = rowData(0) ' First element is case_num
                pdl_name_list.Text = rowData(1) ' Second element is pdl_name
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

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Set the form border style and opacity
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Opacity = 0.9 ' Set the opacity to 75%
    End Sub
End Class
