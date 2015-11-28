Imports System.IO
Imports System.Net
Imports System.Net.Mime
Imports System.Text.RegularExpressions
Imports AdvancedDownloadClient
Imports System.Xml
Imports System.ComponentModel

Public Class ModDownload

    Private Const _id_pattern As String = "mods/(.+?)/"

    ' Attributes
    Private _name As String
    Private _path As String
    Private _info As String
    Private _percentage As Integer
    Private _speed As String
    Private _finished As Boolean
    Private _mod_id As Integer
    Private _file_id As Integer

    ' Objects
    Private WithEvents _dl_client As AdvancedDownloadClient.DownloadClient
    Private nexus As NexusAPI

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Percentage As Integer
        Get
            Return _percentage
        End Get
    End Property

    Public ReadOnly Property Path As String
        Get
            Return _path
        End Get
    End Property

    Public ReadOnly Property Info As String
        Get
            Return _info
        End Get
    End Property

    Public ReadOnly Property Speed As Integer
        Get
            Return _speed
        End Get
    End Property

    Public ReadOnly Property IsFinished As Boolean
        Get
            Return _finished
        End Get
    End Property

    Public ReadOnly Property Filename As String
        Get
            Return nexus.Filename
        End Get
    End Property

    Public ReadOnly Property Infoname As String
        Get
            Return nexus.Filename + ".xml"
        End Get
    End Property

    Public ReadOnly Property IsPaused As Boolean
        Get
            Return Not _dl_client.IsBusy
        End Get
    End Property

    ' ##### EVENTS ##########################################################################################

    Public Event Update(ByVal Download As ModDownload)
    Public Event Finished(ByVal Download As ModDownload)
    Public Event Remove(ByVal Download As ModDownload)

    ' ##### INIT ##########################################################################################

    Public Sub New(ByVal Name As String, ByVal Percentage As Integer, ByVal Archive As String)
        Log.Log(String.Format("Initializing mod download '{0}' ...", Name))
        _name = Name
        _percentage = Percentage
        _path = Archive
        _finished = True
    End Sub

    Public Sub New(ByVal URL As String)
        Try
            ' Extract IDs
            _mod_id = Val(Regex.Match(URL, _id_pattern).Groups(1).Value)
            _file_id = Val(URL.Filename)

            ' Get infos
            nexus = New NexusAPI(_mod_id)
            nexus.FetchFileInfo(_file_id)

            _name = nexus.Name + " " + nexus.Version

            ' Paths
            _path = Directories.Downloads + "\" + nexus.Filename
            _info = _path + ".xml"

            ' Start download
            _dl_client = New AdvancedDownloadClient.DownloadClient(Manager)
            _dl_client.DeleteFileWhenCancelled = True
            _dl_client.DownloadFileAsync(New Uri(nexus.Address), _path)

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    ' ##### FUNCTIONS ##########################################################################################

    ' Toggle download pause
    Public Sub TogglePause()
        If Not _finished Then
            If _dl_client.IsBusy Then
                _dl_client.PauseAsync()
            Else
                _dl_client.ResumeAsync()
            End If
        End If        
    End Sub

    ' Cancel download
    Private Sub Abort()
        _dl_client.CancelAsync()
    End Sub

    ' Delete download
    Public Sub Delete()
        If Not _finished Then
            Abort()
        End If
        If My.Computer.FileSystem.FileExists(_path) Then
            DeleteJobs.DeleteFile(_path)
        End If
        If My.Computer.FileSystem.FileExists(_path + ".xml") Then
            DeleteJobs.DeleteFile(_path + ".xml")
        End If
        RaiseEvent Remove(Me)
    End Sub

    Private Sub CreateInfoFile()
        ' Create document
        Dim doc As New XmlDocument
        Dim declaration As XmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
        ' Create root and decleration
        Dim root As XmlElement = doc.CreateElement("Mod")
        doc.InsertBefore(declaration, doc.DocumentElement)
        doc.AppendChild(root)
        ' Create info
        Dim info As XmlElement = doc.CreateElement("Info")
        info.SetAttribute("Name", nexus.Name)
        info.SetAttribute("ID", _mod_id.ToString)
        info.SetAttribute("Version", nexus.Version)
        info.SetAttribute("Category", nexus.Category)
        doc.DocumentElement.AppendChild(info)
        ' Save
        doc.Save(_path + ".xml")
    End Sub

    ' ##### DOWNLOAD ##########################################################################################

    Private Sub _dl_client_DownloadFileComplete(sender As Object, e As FileDownloadCompletedEventArgs) Handles _dl_client.DownloadFileComplete
        _speed = String.Empty
        _finished = True
        _dl_client = Nothing        
        If Not e.Cancelled Then
            CreateInfoFile()
            RaiseEvent Finished(Me)
        End If
    End Sub

    Private Sub _dl_client_DownloadProgessChanged(sender As Object, e As FileDownloadProgressChangedEventArgs) Handles _dl_client.DownloadProgessChanged
        _percentage = e.ProgressPercentage
        _speed = (e.DownloadSpeedBytesPerSec / 1000).ToString
        RaiseEvent Update(Me)
    End Sub

End Class