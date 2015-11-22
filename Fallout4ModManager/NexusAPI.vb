Imports System.Text.RegularExpressions
Imports System.Net

Public Class NexusAPI

    Public Const ModUrl As String = "http://www.nexusmods.com/fallout4/mods/%ID%"

    ' Login
    Private Const _login_url As String = "http://www.nexusmods.com/games/sessions/?login&username=%NAME%&password=%PW%"

    ' MOD Infos
    Private Const _nexus_page_url As String = "http://www.nexusmods.com/fallout4/mods/%ID%/?tab=2&navtag=http://www.nexusmods.com/fallout4/ajax/modfiles/?id=%ID%"
    Private Const _name_pattern As String = "header-name"">(.+?)<"
    Private Const _latest_version_pattern As String = "file-version"">\s+?<strong>(.+?)<"

    ' File Infos
    Private Const _nexus_files_url As String = "http://www.nexusmods.com/fallout4/ajax/modfiles/?id=%ID%"
    Private Const _version_pattern As String = "files-tab-files-list\s|.+?href=""http://www.nexusmods.com/fallout4/download/%ID%\s|.+?version (.+?)</"

    ' Download Infos
    Private Const _download_url As String = "http://www.nexusmods.com/fallout4/ajax/downloadfile?id=%ID%&continueDL=true&skipdonate"
    Private Const _filename_pattern As String = "window.location.href.+?nexusmods.com/.+?/.+?/(.+?)\?"
    Private Const _fileaddress_pattern As String = "window.location.href = ""(.+?)"""

    Private _client As CookieAwareWebClient

    Private _id As Integer
    Private _current_version As String
    Private _latest_version As String
    Private _name As String
    Private _filename As String
    Private _fileaddress As String

    Public ReadOnly Property Version As String
        Get
            Return _current_version
        End Get
    End Property

    Public ReadOnly Property Latest As String
        Get
            Return _latest_version
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Filename As String
        Get
            Return _filename
        End Get
    End Property

    Public ReadOnly Property Address As String
        Get
            Return _fileaddress
        End Get
    End Property

    Public Sub New(ByVal ID As Integer)
        _id = ID
        While login_open
            Threading.Thread.Sleep(1000)
        End While
        login_open = True
        Login()
        login_open = False
        FetchModInfo()
    End Sub

    Private Sub FetchModInfo()
        ' Mod Infos
        Dim ModData As String = _client.DownloadString(_nexus_page_url.Replace("%ID%", _id.ToString))
        ' Name
        _name = Uri.UnescapeDataString(Regex.Match(ModData, _name_pattern).Groups(1).Value)
        _name = _name.Replace("&#39;", "'")
        ' Latest version
        _latest_version = Regex.Match(ModData, _latest_version_pattern).Groups(1).Value
    End Sub

    Public Sub FetchFileInfo(ByVal ID As Integer)
        ' File infos
        Dim FileData As String = _client.DownloadString(_nexus_files_url.Replace("%ID%", _id.ToString))
        ' Version
        _current_version = Regex.Match(FileData, _version_pattern.Replace("%ID%", ID.ToString)).Groups(1).Value

        ' Download infos        
        Dim DLData As String = _client.DownloadString(_download_url.Replace("%ID%", ID.ToString))
        ' Filename
        _filename = Uri.UnescapeDataString(Regex.Match(DLData, _filename_pattern).Groups(1).Value)
        ' Address
        _fileaddress = Regex.Match(DLData, _fileaddress_pattern).Groups(1).Value
    End Sub

    ' ##### LOGIN ##########################################################################################

    Private Shared login_open As Boolean

    Private Function Login() As Boolean
        If IsNothing(_client) Then            
            _client = New CookieAwareWebClient

            Dim user As String = String.Empty
            Dim password As String = String.Empty

            ' Check login data            
            If String.IsNullOrEmpty(My.Settings.NexusUser) Or String.IsNullOrEmpty(My.Settings.NexusPassword) Then                                
                Dim login_form As New Login(user, password)                
                If login_form.ShowDialog = DialogResult.Cancel Then
                    Return False
                Else
                    user = login_form.User
                    password = login_form.Password
                End If
            Else
                user = My.Settings.NexusUser
                password = My.Settings.NexusPassword
            End If

            ' Login data
            Dim LoginUrl As String = _login_url
            LoginUrl = LoginUrl.Replace("%NAME%", user)
            LoginUrl = LoginUrl.Replace("%PW%", password)

            ' Request login
            Dim response As String = _client.DownloadString(LoginUrl)

            ' Evaluate
            If Not response = "null" Then
                ' Success
                Dim cookie As String = _client.ResponseHeaders("Set-Cookie").ToString()
                _client.Headers.Add("Cookie", cookie)
                Return True
            End If

            Return False
        End If
        Return True
    End Function

End Class
