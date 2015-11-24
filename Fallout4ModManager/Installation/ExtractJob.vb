Imports System.IO

Public Class ExtractJob

    Private _archive_path As String
    Private _extract_path As String
    Private _backup As Boolean

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

    Public ReadOnly Property Backup As Boolean
        Get
            Return _backup
        End Get
    End Property

    Public Sub New(ByVal ArchivePath As String, ByVal ExtractPath As String, Optional ByVal Backup As Boolean = False)
        _archive_path = ArchivePath
        _extract_path = ExtractPath
        _backup = Backup
    End Sub

End Class
