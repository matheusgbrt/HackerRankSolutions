Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Module Module1
    Sub Main()
        Dim csvFilePath As String = "C:\Users\Inovea\Documents\tbproduto.csv"
        Dim dataTable As DataTable = CreateDataTableFromCSV(csvFilePath)

        ' Display the DataTable (for demonstration purposes)
        For Each row As DataRow In dataTable.Rows
            For Each col As DataColumn In dataTable.Columns
                Console.Write(row(col) & vbTab)
            Next
            Console.WriteLine()
        Next
    End Sub

    Function CreateDataTableFromCSV(ByVal filePath As String) As DataTable
        Dim dt As New DataTable()

        Try
            Using parser As New TextFieldParser(filePath)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(";")

                ' Assuming the first row contains the column names
                If Not parser.EndOfData Then
                    Dim headers As String() = parser.ReadFields()
                    For Each header As String In headers
                        dt.Columns.Add(New DataColumn(header))
                    Next
                End If

                While Not parser.EndOfData
                    Dim fields As String() = parser.ReadFields()

                    ' Check if the number of fields matches the number of columns
                    If fields.Length = dt.Columns.Count Then
                        dt.Rows.Add(fields)
                    Else
                        Console.WriteLine("Skipping row due to field count mismatch: " & String.Join(";", fields))
                    End If
                End While
            End Using
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Return dt
    End Function
End Module
'Module Module1
'    Sub Main()
'        Dim csvFilePath As String = "C:\Users\Inovea\Documents\tbproduto.csv"
'        Dim dataTable As DataTable = CreateDataTableFromCSV(csvFilePath)

'        ' Display the DataTable (for demonstration purposes)
'        For Each row As DataRow In dataTable.Rows
'            For Each col As DataColumn In dataTable.Columns
'                Console.Write(row(col) & vbTab)
'            Next
'            Console.WriteLine()
'        Next
'    End Sub

'    Function CreateDataTableFromCSV(ByVal filePath As String) As DataTable
'        Dim dt As New DataTable()
'        Dim folderPath As String = IO.Path.GetDirectoryName(filePath)
'        Dim fileName As String = IO.Path.GetFileName(filePath)
'        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" & folderPath & ";Extended Properties='text;HDR=Yes;FMT=Delimited(;)'"

'        Try
'            Using conn As New OleDbConnection(connString)
'                conn.Open()
'                Dim query As String = "SELECT * FROM [" & fileName & "]"
'                Using cmd As New OleDbCommand(query, conn)
'                    Using adapter As New OleDbDataAdapter(cmd)
'                        adapter.Fill(dt)
'                    End Using
'                End Using
'            End Using
'        Catch ex As Exception
'            Console.WriteLine("Error: " & ex.Message)
'        End Try

'        Return dt
'    End Function





'End Module
