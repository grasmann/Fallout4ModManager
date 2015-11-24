Imports Microsoft.Win32
Imports System.IO

Module Directories

    ' Find Fallout 4 install directory
    Public Function FindInstall() As Boolean
        Dim directory_found As Boolean
        ' Check if install dir is set
        If String.IsNullOrEmpty(My.Settings.InstallDir) Then
            ' Attempt to read install directory from registry
            Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\bethesda softworks\Fallout4")
            If IsNothing(Key) Then Key = Registry.LocalMachine.OpenSubKey("SOFTWARE\bethesda softworks\Fallout4")
            If Not IsNothing(Key) Then
                ' install directory found in registry
                If MsgBox("Fallout 4 was found in " + vbCrLf + """" + Key.GetValue("installed path") + """." + vbCrLf + _
                          "Is that correct?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Fallout 4 Directory") = MsgBoxResult.Yes Then
                    My.Settings.InstallDir = Key.GetValue("installed path")
                    My.Settings.Save()
                    directory_found = True
                End If
            End If
            ' Check if directory could be found
            If Not directory_found Then
                ' Let user specify directory
                MsgBox("Fallout 4 directory couldn't be found." + vbCrLf + "Please specify it in the options.")
                Dim options As New Options(True)
                options.ShowDialog()
            End If
        End If
        Return Not String.IsNullOrEmpty(My.Settings.InstallDir)
    End Function

    ' Get Fallout 4 install directory
    Public Function Install() As String
        Return My.Settings.InstallDir
    End Function

    ' Get Fallout 4 data directory
    Public Function Data() As String
        Return Install() + "Data"
    End Function

    ' Get Fallout 4 appdata directory
    Public Function Appdata() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Fallout4"
    End Function

    ' Get Fallout 4 documents directory
    Public Function MyGames() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\My Games\Fallout4"
    End Function

    ' Get Fallout 4 mods directory
    Public Function Mods() As String
        Dim Path As String = Directories.Data + "\Mods"
        If Not My.Computer.FileSystem.DirectoryExists(Path) Then
            My.Computer.FileSystem.CreateDirectory(Path)
        End If
        Return Path
    End Function

    ' Get Fallout 4 modcache directory
    Public Function ModCache() As String
        Dim Path As String = Directories.Mods + "\Cache"
        If Not My.Computer.FileSystem.DirectoryExists(Path) Then
            My.Computer.FileSystem.CreateDirectory(Path)
        End If
        Return Path
    End Function

    ' Get Fallout 4 temp directory
    Public Function Temp() As String
        Dim Path As String = Directories.Mods + "\f4mm_install"
        If Not My.Computer.FileSystem.DirectoryExists(Path) Then
            My.Computer.FileSystem.CreateDirectory(Path)
        End If
        Return Path
    End Function

    ' Get Fallout 4 download directory
    Public Function Downloads() As String
        Dim Path As String = Directories.Mods + "\Downloads"
        If Not My.Computer.FileSystem.DirectoryExists(Path) Then
            My.Computer.FileSystem.CreateDirectory(Path)
        End If
        Return Path
    End Function

    ' Get directory count
    Public Sub DirectoryCount(ByVal Dir As String, ByRef Count As Integer)
        For Each folder As String In Directory.GetDirectories(Dir)
            Count += 1
            DirectoryCount(folder, Count)
        Next
    End Sub

    ' Clean directory
    Public Sub CleanDirectories(ByVal Dir As String, ByVal Progressbar As ProgressBar)
        For Each folder As String In Directory.GetDirectories(Dir)
            CleanDirectories(folder, Progressbar)
            Try
                If Progressbar.Value < Progressbar.Maximum Then
                    Progressbar.Value += 1
                End If
                My.Computer.FileSystem.DeleteDirectory(folder, FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        Next
    End Sub

End Module
