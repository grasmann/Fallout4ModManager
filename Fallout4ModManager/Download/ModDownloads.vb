Imports System.Collections.Generic

Public Class ModDownloads
    Inherits List(Of ModDownload)

    Public Event Added(ByVal Download As ModDownload)
    Public Event Update(ByVal Download As ModDownload)
    Public Event Finished(ByVal Download As ModDownload)
    Public Event Removed(ByVal Download As ModDownload)

    Public Sub AbortAll()
        For i = Me.Count - 1 To 0 Step -1
            If Not Me(i).IsFinished Then
                Me(i).Delete()
            End If
        Next
    End Sub

    Public Sub AddDownload(ByVal Download As ModDownload)
        ' Check if already added
        Dim add_id As Boolean = True
        For i = Me.Count - 1 To 0 Step -1
            If Me(i).Path = Download.Path Then
                If Me(i).IsFinished Then
                    Me.RemoveAt(i)
                    Exit For
                Else
                    add_id = False
                    Exit For
                End If
            End If
        Next
        If add_id Then
            AddHandler Download.Update, AddressOf Updated
            AddHandler Download.Finished, AddressOf WasFinished
            AddHandler Download.Remove, AddressOf WasRemoved
            Me.Add(Download)
            RaiseEvent Added(Download)
        End If        
    End Sub

    Private Sub Updated(ByVal Download As ModDownload)
        RaiseEvent Update(Download)
    End Sub

    Private Sub WasFinished(ByVal Download As ModDownload)
        RaiseEvent Finished(Download)
    End Sub

    Private Sub WasRemoved(ByVal Download As ModDownload)
        RaiseEvent Removed(Download)
        Me.Remove(Download)
    End Sub

    Public Sub Pause(ByVal Name As String)
        For Each Download As ModDownload In Me
            If Download.Name = Name Then Download.TogglePause()
        Next
    End Sub

    Public Function FindDownloadByName(ByVal Name As String) As ModDownload
        For Each ModDownload As ModDownload In Me
            If ModDownload.Name = Name Then Return ModDownload
        Next
        Return Nothing
    End Function

    Public Sub FindFinishedDownloads()
        Dim Downloads As List(Of String) = Files.FindDownloads
        Dim modfile As Xml.XmlDocument
        Dim node As Xml.XmlNode
        Dim Name As String
        Dim ModDownload As ModDownload
        ' Iterate downloads
        For Each dl As String In Downloads
            Dim archive As String = Directories.Downloads + "\" + Microsoft.VisualBasic.Left(dl, Len(dl) - 4)
            If My.Computer.FileSystem.FileExists(archive) Then
                Try
                    modfile = New Xml.XmlDocument
                    modfile.Load(Directories.Downloads + "\" + dl)
                    node = modfile.GetElementsByTagName("Info")(0)
                    Name = node.Attributes("Name").Value + " " + node.Attributes("Version").Value
                    ModDownload = New ModDownload(Name, 100, archive)
                    AddHandler ModDownload.Update, AddressOf Updated
                    AddHandler ModDownload.Finished, AddressOf WasFinished
                    AddHandler ModDownload.Remove, AddressOf WasRemoved
                    Me.Add(ModDownload)
                    RaiseEvent Added(ModDownload)
                    RaiseEvent Finished(ModDownload)
                    'dgv_downloads.Rows.Add(Name, "", "100%", archive, True)
                Catch ex As Exception
                    Debug.Print("List Downloads: " + ex.Message)
                End Try
            End If
        Next
    End Sub

End Class
