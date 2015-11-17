Imports System.Collections.Generic

Public Class ModDownloads

    Private WithEvents _downloads As New List(Of ModDownload)

    Public Event Added(ByVal Download As ModDownload)
    Public Event Update()
    Public Event Finished(ByVal Path As String)

    Public ReadOnly Property Downloads As List(Of ModDownload)
        Get
            Return _downloads
        End Get
    End Property

    Public Sub AddDownload(ByVal Download As ModDownload)
        AddHandler Download.Update, AddressOf Updated
        AddHandler Download.Finished, AddressOf WasFinished
        _downloads.Add(Download)
        RaiseEvent Added(Download)
    End Sub

    Private Sub Updated()
        RaiseEvent Update()
    End Sub

    Private Sub WasFinished(ByVal Path As String)
        RaiseEvent Finished(Path)
    End Sub

End Class
