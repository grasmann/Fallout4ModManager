Imports Microsoft.Win32
Imports System.IO

Module Directories

    Public Function CheckInstall() As Boolean
        If String.IsNullOrEmpty(My.Settings.InstallDir) Then
            Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\bethesda softworks\Fallout4")
            If IsNothing(Key) Then Key = Registry.LocalMachine.OpenSubKey("SOFTWARE\bethesda softworks\Fallout4")
            If Not IsNothing(Key) Then
                If MsgBox("Fallout 4 was found in " + vbCrLf + """" + Key.GetValue("installed path") + """." + vbCrLf + _
                          "Is that correct?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Fallout 4 Directory") = MsgBoxResult.Yes Then
                    My.Settings.InstallDir = Key.GetValue("installed path")
                    My.Settings.Save()
                Else
                    Dim options As New Options(True)
                    options.ShowDialog()
                End If
            Else
                MsgBox("Fallout 4 directory couldn't be found." + vbCrLf + "Please specify it in the options.")
                Dim options As New Options(True)
                options.ShowDialog()
            End If
        End If
        Return Not String.IsNullOrEmpty(My.Settings.InstallDir)
    End Function

    Public Function Install() As String
        'If String.IsNullOrEmpty(My.Settings.InstallDir) Then
        '    Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\bethesda softworks\Fallout4")
        '    If IsNothing(Key) Then Key = Registry.LocalMachine.OpenSubKey("SOFTWARE\bethesda softworks\Fallout4")
        '    If Not IsNothing(Key) Then
        '        If MsgBox("Fallout 4 was found in " + vbCrLf + """" + Key.GetValue("installed path") + """." + vbCrLf + _
        '                  "Is that correct?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Fallout 4 Directory") = MsgBoxResult.Yes Then
        '            My.Settings.InstallDir = Key.GetValue("installed path")
        '            My.Settings.Save()
        '        Else
        '            Dim options As New Options(True)
        '            If options.ShowDialog() = DialogResult.Abort Then Application.Exit()
        '        End If
        '    End If
        'End If
        Return My.Settings.InstallDir
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

    Public Function Temp() As String
        Dim Path As String = Directories.Mods + "\f4mm_install"
        If Not My.Computer.FileSystem.DirectoryExists(Path) Then
            My.Computer.FileSystem.CreateDirectory(Path)
        End If
        Return Path
    End Function

    Public Function Downloads() As String
        Dim Path As String = Directories.Mods + "\Downloads"
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
