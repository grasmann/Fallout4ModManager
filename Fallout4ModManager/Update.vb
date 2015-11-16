Imports System.Net
Imports System.Text.RegularExpressions

Module Update

    Public Const Version As String = "1.0.9"
    Public UpdateAvailable As Boolean

    Private WithEvents client As New WebClient

    Public Sub CheckUpdate()
        client.DownloadStringAsync(New Uri("http://www.nexusmods.com/fallout4/mods/495"))
    End Sub

    Private Sub client_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles client.DownloadStringCompleted
        Dim match As Match = Regex.Match(e.Result, "file-version"">\s+<strong>(.+?)</")
        If Not IsNothing(match) Then
            Dim NexusVersion As String = match.Groups(1).Value
            If Not String.IsNullOrEmpty(NexusVersion) Then
                Dim NexusNrs As List(Of String) = NexusVersion.Split(".").ToList
                Dim Nrs As List(Of String) = Version.Split(".").ToList
                For i = 0 To 2
                    If CType(NexusNrs(i), Integer) > CType(Nrs(i), Integer) Then
                        UpdateAvailable = True
                        If MsgBox("An update is available." + vbCrLf + "Do you want to download it?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Update") = MsgBoxResult.Yes Then
                            Process.Start("http://www.nexusmods.com/fallout4/mods/495")
                        End If
                        Exit Sub
                    End If
                Next
            End If            
        End If        
    End Sub

End Module
