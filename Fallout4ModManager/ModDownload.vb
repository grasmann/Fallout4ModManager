Imports System.Net
Imports System.Net.Mime
Imports System.Text.RegularExpressions

Public Class ModDownload

    Private WithEvents _client As WebClient
    Private _path As String
    Private _name As String
    Private _percentage As Integer

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

    Public Event Update()
    Public Event Finished(ByVal Path As String)

    Public Sub New(ByVal URL As String)
        _client = New WebClient
        _client.Encoding = System.Text.Encoding.UTF8
        ' Name
        Dim ModID As String = Regex.Match(URL, "mods/(.+?)/").Groups(1).Value
        Dim ModUrl As String = "http://www.nexusmods.com/fallout4/mods/" + ModID
        Dim ModData As String = _client.DownloadString(ModUrl)
        _name = Regex.Match(ModData, "header-name"">(.+?)<").Groups(1).Value
        Debug.Print(_name)

        Dim Info As String = _client.DownloadString("http://www.nexusmods.com/fallout4/ajax/downloadfile?id=" + URL.Filename)

        Dim FileName As String = Regex.Match(Info, "nexusmods.com/.+?/.+?/(.+?)tll").Groups(1).Value
        _path = Directories.Downloads + "\" + URL.Filename

        _client.DownloadFileAsync(New Uri("http://www.nexusmods.com/fallout4/download/" + URL.Filename), _path)
        '_client.OpenRead(New Uri("http://www.nexusmods.com/fallout4/download/" + URL.Filename))

        'Dim header_contentDisposition As String = _client.ResponseHeaders("content-disposition")
        'Dim filename As String = New ContentDisposition(header_contentDisposition).FileName

        'Dim myRequest As System.Net.WebRequest = System.Net.WebRequest.Create("http://www.nexusmods.com/replaceMyUrl?""""/http:/www.nexusmods.com/fallout4/download/2316/?""")
        'Dim myResponse As System.Net.WebResponse = myRequest.GetResponse()
        'Dim myStream As System.IO.Stream = myResponse.GetResponseStream
        'Dim sr As System.IO.StreamReader = New System.IO.StreamReader(myStream)

        'Clipboard.SetText(sr.ReadToEnd)

        ''open notepad and wait for it to completely load
        'Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start("notepad.exe")
        'p.WaitForInputIdle()

        '' paste the data from the clipboard
        'SendKeys.Send("^V")
        'myStream.Close()
        'myResponse.Close()

    End Sub

    Private Sub client_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles _client.DownloadFileCompleted
        RaiseEvent Finished(_path)
    End Sub

    Private Sub client_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles _client.DownloadProgressChanged
        _percentage = e.ProgressPercentage
        RaiseEvent Update()
    End Sub

End Class
