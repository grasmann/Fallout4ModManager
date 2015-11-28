Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices

Public Class InstalledArchives
    Inherits List(Of InstalledArchive)

    ' Fallout 4 default archive files
    Private _archives_default As New List(Of String) _
        ({"Fallout4 - Textures1.ba2", "Fallout4 - Textures2.ba2", "Fallout4 - Textures3.ba2", "Fallout4 - Textures4.ba2", "Fallout4 - Textures5.ba2", _
          "Fallout4 - Textures6.ba2", "Fallout4 - Textures7.ba2", "Fallout4 - Textures8.ba2", "Fallout4 - Textures9.ba2", "Fallout4 - Startup.ba2", _
          "Fallout4 - Shaders.ba2", "Fallout4 - Interface.ba2", "Fallout4 - Animations.ba2", "Fallout4 - Interface.ba2", "Fallout4 - Materials.ba2", _
          "Fallout4 - Meshes.ba2", "Fallout4 - MeshesExtra.ba2", "Fallout4 - Misc.ba2", "Fallout4 - Shaders.ba2", "Fallout4 - Sounds.ba2", _
          "Fallout4 - Startup.ba2", "Fallout4 - Voices.ba2"})

    ' Fallout 4 archive file endings
    Private _archive_files() As String = {"*.ba2", "*.bsa"}

    ' ##### EVENTS ####################################################################################

    Public Event ArchivesCleared()
    Public Event ArchiveFound(ByVal InstalledArchive As InstalledArchive)

    ' ##### LOAD ARCHIVES ####################################################################################

    ' Reload archives
    Public Sub Reload()
        Log.Log(String.Format("{0}Reloading archive files ...", vbCrLf))
        Me.Clear()
        RaiseEvent ArchivesCleared()
        LoadArchives()
    End Sub

    ' Load archives
    Private Sub LoadArchives()
        Log.Log("Loading archive files ...")
        Dim Archives As List(Of String) = FindArchives()
        Dim ActiveArchives As List(Of String) = FindActiveArchives()
        Dim InstalledArchive As InstalledArchive
        ' Iterate
        For Each Archive As String In Archives
            If Not _archives_default.Contains(Archive.Filename) Then
                InstalledArchive = New InstalledArchive(Archive.Filename, _
                                                        ActiveArchives.Contains(Archive.Filename))
                Me.Add(InstalledArchive)
                RaiseEvent ArchiveFound(InstalledArchive)
            End If
        Next
        Log.Log(String.Format("Archives loaded. total {0}; active {1}", Archives.Count, ActiveArchives.Count))
    End Sub

    ' ##### FILES ####################################################################################

    ' Find archive files
    Private Function FindArchives() As List(Of String)
        Log.Log("Searching for archive files ...")
        Dim Archives As New List(Of String)
        Dim Files As List(Of String) = _
            My.Computer.FileSystem.GetFiles(Directories.Data, _
                                            FileIO.SearchOption.SearchTopLevelOnly, _
                                            _archive_files).ToList
        For Each Archive As String In Files
            If Not _archives_default.Contains(Archive.Filename) Then
                Archives.Add(Archive)
            End If
        Next
        Log.Log(String.Format("Found {0} archive file(s).", Archives.Count))
        Return Archives
    End Function

    ' Find active archives
    Private Function FindActiveArchives() As List(Of String)
        Log.Log("Searching for active archive files ...")
        Dim Archives As New List(Of String)
        ' Read
        Dim sb As New StringBuilder(1024)
        Dim rt As Integer = _
            GetPrivateProfileString("Archive", "sResourceStartUpArchiveList", _
                                    "", sb, sb.Capacity, Files.Fallout4ini)
        ' Split
        Archives = sb.ToString.Split(",").ToList
        For i = Archives.Count - 1 To 0 Step -1
            Archives(i) = Trim(Archives(i))
            If _archives_default.Contains(Archives(i)) Then
                Archives.RemoveAt(i)
            End If
        Next
        Log.Log(String.Format("Found {0} active archive file(s).", Archives.Count))
        Return Archives
    End Function

End Class
