Imports System.IO

Module Log

    Private writer As StreamWriter

    Public Sub CreateWriter()
        writer = New StreamWriter("log_" + String.Format("{0}-{1}-{2}_{3}-{4}-{5}", Now.Second.ToString, Now.Minute.ToString, _
                                                         Now.Hour.ToString, Now.Day.ToString, Now.Month.ToString, Now.Year.ToString) + ".txt")
    End Sub

    Public Sub Log(ByVal Message As String)
        Debug.Print(Message)
        'If My.Settings.WriteLogFile Then
        If IsNothing(writer) Then
            CreateWriter()
        End If
        writer.WriteLine(Message)
        'End If
    End Sub

    Public Sub CloseWriter()
        If Not IsNothing(writer) Then
            writer.Close()
        End If
    End Sub

End Module
