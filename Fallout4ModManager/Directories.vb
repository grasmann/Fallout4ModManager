Imports Microsoft.Win32
Imports System.IO

Module Directories

    Public Function Install() As String
        Dim Dir As String = String.Empty
        Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\bethesda softworks\Fallout4")
        If IsNothing(Key) Then Key = Registry.LocalMachine.OpenSubKey("SOFTWARE\bethesda softworks\Fallout4")
        Dir = Key.GetValue("installed path")
        Return Dir
    End Function

    Public Function Data() As String
        Return Install() + "Data"
    End Function

    Public Function Appdata() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Fallout4"
    End Function

    Public Function MyGames() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\My Games\Fallout4"
    End Function

    Public Function Mods() As String
        Dim Path As String = Directories.Data + "\Mods"
        If Not My.Computer.FileSystem.DirectoryExists(Path) Then
            My.Computer.FileSystem.CreateDirectory(Path)
        End If
        Return Path
    End Function

    Public Sub CleanDirectories(ByVal Dir As String)
        For Each folder As String In Directory.GetDirectories(Dir)
            CleanDirectories(folder)
            Try
                My.Computer.FileSystem.DeleteDirectory(folder, FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        Next
    End Sub

End Module
