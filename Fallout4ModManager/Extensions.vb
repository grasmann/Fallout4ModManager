Imports System.Runtime.CompilerServices

Module Extensions

    <Extension>
    Public Function Filename(ByVal Str As String) As String
        Dim Slash As Integer = InStrRev(Str, "/")
        If Slash <= 0 Then Slash = InStrRev(Str, "\")
        Return Right(Str, Len(Str) - Slash)
    End Function

End Module
