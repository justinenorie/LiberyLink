Imports MySql.Data.MySqlClient
Module Connection
    Private cmd As New MySqlCommand
    Public conn As New MySqlConnection
    Public connectionString As String = "server=localhost;port=3306;database=pdl_management_system;uid=root;password=;"

    Sub OpenConnection()
        Try
            conn = New MySqlConnection(connectionString)
            conn.Open()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Sub CloseConnection()
        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
                conn.Dispose()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Sub ExecuteCommands(sql As String)
        OpenConnection()
        Try
            cmd = New MySqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        CloseConnection()
    End Sub

    Function checkCommand(sql As String)
        Dim result As Boolean = False
        Try
            OpenConnection()
            cmd = New MySqlCommand(sql, conn)
            Dim count As Integer = Convert.ToInt64(cmd.ExecuteScalar())
            If count > 0 Then
                result = True
            End If
        Catch ex As Exception
            Console.WriteLine("Error cheking data " & ex.ToString)
        Finally
            CloseConnection()
        End Try
        Return result
    End Function

    Function ReadCommand(sql As String)
        Dim dataTable As New DataTable()
        Try
            OpenConnection()
            cmd = New MySqlCommand(sql, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(dataTable)
        Catch ex As Exception
            Console.WriteLine("Error reading data: " & ex.ToString)
        Finally
            CloseConnection()
        End Try
        Return dataTable
    End Function
End Module
