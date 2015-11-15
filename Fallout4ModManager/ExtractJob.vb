Imports System.IO

Public Class ExtractJob

    Private _archive_path As String
    Private _extract_path As String

    Public ReadOnly Property ArchivePath As String
        Get
            Return _archive_path
        End Get
    End Property

    Public ReadOnly Property ExtractPath As String
        Get
            Return _extract_path
        End Get
    End Property

    Public Sub New(ByVal ArchivePath As String, ByVal ExtractPath As String)
        _archive_path = ArchivePath
        _extract_path = ExtractPath
    End Sub

End Class
