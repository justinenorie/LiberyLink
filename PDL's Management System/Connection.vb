Imports MySql.Data.MySqlClient
Module Connection
    Public conn As New MySqlConnection
    Public connectionString As String = "server=localhost;port=3306;database=pdl_management_system;uid=root;password=;"

    Public Sub OpenConnection()
        Try
            conn = New MySqlConnection(connectionString)
            conn.Open()
            Console.WriteLine("Database connection opened successfully.")
        Catch ex As Exception
            Console.WriteLine("Error opening database connection: " & ex.Message)
        End Try
    End Sub

    Public Sub CloseConnection()
        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
                conn.Dispose()
                Console.WriteLine("Database connection closed successfully.")
            End If
        Catch ex As Exception
            Console.WriteLine("Error closing database connection: " & ex.Message)
        End Try
    End Sub

End Module
