Imports System.IO

Module Log

    Private writer As StreamWriter

    Public Sub CreateWriter()
        writer = New StreamWriter("log.txt")
    End Sub

    Public Sub Log(ByVal Message As String)
        Debug.Print(Message)
        writer.WriteLine(Message)
    End Sub

    Public Sub CloseWriter()
        If Not IsNothing(writer) Then
            writer.Close()
        End If
    End Sub

End Module
