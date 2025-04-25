'Justin Bell
'RCET3371
'Spring 2025
Public Class FileStuff

    Public Shared Function GetFileName()
        'general file name maker
        Dim fileName As String

        'currently makes the file name from the year, month, day, hour
        fileName = $"log_{DateTime.Now.ToString("yyMMddHH")}.log"

        Return fileName
    End Function

    Public Shared Sub SaveToLogFile(toBeSaved As List(Of String()))
        Dim folderPath As String = "../logs/"
        Dim fileName As String = GetFileName()
        Dim fullPath As String = IO.Path.Combine(folderPath, fileName)

        'verify folder/create folder for logs
        If Not IO.Directory.Exists(folderPath) Then
            IO.Directory.CreateDirectory(folderPath)
        End If

        'writes to or creates and writes to the file
        If IO.File.Exists(fullPath) Then
            'file exists write to it
            Using writer As New IO.StreamWriter(fullPath, True)
                Dim row As Integer = toBeSaved.Count

                For i = 0 To row - 1
                    Dim line As String = String.Join(",", toBeSaved.Item(i))
                    writer.WriteLine(line)
                Next
            End Using
        Else
            'file does not exsist creat it and write to it
            Using writer As New IO.StreamWriter(fullPath)
                Dim row = DirectCast(toBeSaved, IList)

                For i = 0 To row.Count - 1
                    Dim line As String = DirectCast(row(i), String)
                    writer.WriteLine(line)
                Next
            End Using
        End If
    End Sub

End Class