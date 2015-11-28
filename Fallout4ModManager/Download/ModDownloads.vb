Imports System.Collections.Generic

Public Class ModDownloads
    Inherits List(Of ModDownload)

    ' ##### EVENTS ################################################################################

    Public Event Added(ByVal Download As ModDownload)
    Public Event Update(ByVal Download As ModDownload)
    Public Event Finished(ByVal Download As ModDownload)
    Public Event Removed(ByVal Download As ModDownload)

    ' ##### FUNCTIONS ################################################################################

    ' Cancel all downloads
    Public Sub AbortAll()
        For i = Me.Count - 1 To 0 Step -1
            If Not Me(i).IsFinished Then
                Me(i).Delete()
            End If
        Next
    End Sub

    ' Add download
    Public Sub AddDownload(ByVal ModDownload As ModDownload)
        ' Check if already added
        Dim add_id As Boolean = True
        For i = Me.Count - 1 To 0 Step -1
            If Me(i).Path = ModDownload.Path Then
                If Me(i).IsFinished Then
                    Me.RemoveAt(i)
                    Exit For
                Else
                    add_id = False
                    Exit For
                End If
            End If
        Next
        ' Add
        If add_id Then
            LoadDownload(ModDownload)
        End If
    End Sub

    ' ##### DOWNLOAD FEEDBACKS ################################################################################

    ' Update download
    Private Sub Updated(ByVal Download As ModDownload)
        RaiseEvent Update(Download)
    End Sub

    ' Download finished
    Private Sub WasFinished(ByVal Download As ModDownload)
        RaiseEvent Finished(Download)
    End Sub

    ' Download removed
    Private Sub WasRemoved(ByVal Download As ModDownload)
        RaiseEvent Removed(Download)
        Me.Remove(Download)
    End Sub

    ' ##### LOAD ################################################################################

    ' Load finished downloads
    Public Sub LoadDownloads()
        Log.Log(String.Format("{0}Searching for finished downloads ...", vbCrLf))
        Dim Downloads As List(Of String) = FindFinishedDownloads()
        For Each Download As String In Downloads
            Dim archive As String = FindArchive(Download)
            If My.Computer.FileSystem.FileExists(archive) Then
                Try
                    Dim modfile As New Xml.XmlDocument
                    modfile.Load(Directories.Downloads + "\" + Download)
                    Dim node As Xml.XmlNode = modfile.GetElementsByTagName("Info")(0)
                    Dim Name As String = node.Attributes("Name").Value + " " + node.Attributes("Version").Value
                    LoadDownload(New ModDownload(Name, 100, archive), True)
                Catch ex As Exception
                    Log.Log(String.Format("Error reading download xml '{0}'.{1}{2}{1}{3}", Download, vbCrLf, ex.Message, ex.StackTrace))
                End Try
            Else
                Log.Log(String.Format("Error loading download archive '{0}'.{1}Archive not found.", Download, vbCrLf))
            End If
        Next
        Log.Log(String.Format("Downloads loaded. finished {0}", Downloads.Count))
    End Sub

    ' Load download
    Private Sub LoadDownload(ByVal ModDownload As ModDownload, Optional ByVal Finished As Boolean = False)
        AddHandler ModDownload.Update, AddressOf Updated
        AddHandler ModDownload.Finished, AddressOf WasFinished
        AddHandler ModDownload.Remove, AddressOf WasRemoved
        Me.Add(ModDownload)
        RaiseEvent Added(ModDownload)
        If Finished Then RaiseEvent Finished(ModDownload)
    End Sub

    ' ##### FILES #######################################################################################################################

    ' Find finished download files
    Private Function FindFinishedDownloads() As List(Of String)
        Dim Downloads As New List(Of String)
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Directories.Downloads)
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.xml")
        Dim dra As IO.FileInfo
        'list the names of all files in the specified directory
        For Each dra In diar1
            Downloads.Add(dra.Name)
        Next
        Return Downloads
    End Function

    ' ##### HELP #######################################################################################################################

    ' Find download by name
    Public Function FindDownloadByName(ByVal Name As String) As ModDownload
        For Each ModDownload As ModDownload In Me
            If ModDownload.Name = Name Then Return ModDownload
        Next
        Return Nothing
    End Function

    ' Get archive from xml
    Private Function FindArchive(ByVal XML As String) As String
        Return Directories.Downloads + "\" + Microsoft.VisualBasic.Left(XML, Len(XML) - 4)
    End Function

End Class
