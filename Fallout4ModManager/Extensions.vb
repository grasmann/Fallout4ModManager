Imports System.Runtime.CompilerServices

Module Extensions

    <Extension>
    Public Function Filename(ByVal Str As String) As String
        Dim Slash As Integer = InStrRev(Str, "/")
        If Slash <= 0 Then Slash = InStrRev(Str, "\")
        Return Right(Str, Len(Str) - Slash)
    End Function

    <Extension>
    Public Function Folder(ByVal Str As String) As String
        Dim Slash As Integer = InStrRev(Str, "/")
        If Slash <= 0 Then Slash = InStrRev(Str, "\")
        Return Left(Str, Slash)
    End Function

    <Extension>
    Public Function Ending(ByVal Str As String) As String
        Dim Dot As Integer = InStrRev(Str, ".")
        Return Right(Str, Len(Str) - Dot)
    End Function

End Module
