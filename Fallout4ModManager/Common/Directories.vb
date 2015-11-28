Imports Microsoft.Win32
Imports System.IO

Module Directories

    ' Fallout directories
    Private _install As String
    Private _data As String
    Private _mods As String
    Private _modcache As String
    Private _temp As String
    Private _download As String
    ' Windows directories
    Private _appdata As String
    Private _mygames As String

    ' Find Fallout 4 install directory
    Public Function FindInstall() As Boolean
        Log.Log("Searching for fallout 4 install directory ...")
        Dim directory_found As Boolean
        ' Check if install dir is set
        If String.IsNullOrEmpty(My.Settings.InstallDir) Then
            ' Attempt to read install directory from registry
            Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\bethesda softworks\Fallout4")
            If IsNothing(Key) Then Key = Registry.LocalMachine.OpenSubKey("SOFTWARE\bethesda softworks\Fallout4")
            If Not IsNothing(Key) Then
                Log.Log("Found fallout 4 install directory in registry.")
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
                Log.Log("Found fallout 4 install directory not found.")
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
        If String.IsNullOrEmpty(_install) Then
            _install = My.Settings.InstallDir
            Log.Log(String.Format("Fetched install directory '{0}'.", _install))
        End If
        Return _install
    End Function

    ' Get Fallout 4 data directory
    Public Function Data() As String
        If String.IsNullOrEmpty(_data) Then
            _data = Install() + "Data"
            Log.Log(String.Format("Fetched data directory '{0}'.", _data))
        End If
        Return _data
    End Function

    ' Get Fallout 4 appdata directory
    Public Function Appdata() As String
        If String.IsNullOrEmpty(_appdata) Then
            _appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Fallout4"
            Log.Log(String.Format("Fetched appdata directory '{0}'.", _appdata))
        End If
        Return _appdata
    End Function

    ' Get Fallout 4 documents directory
    Public Function MyGames() As String
        If String.IsNullOrEmpty(_mygames) Then
            _mygames = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\My Games\Fallout4"
            Log.Log(String.Format("Fetched my games directory '{0}'.", _mygames))
        End If
        Return _mygames
    End Function

    ' Get Fallout 4 mods directory
    Public Function Mods() As String
        If String.IsNullOrEmpty(_mods) Then
            _mods = Directories.Data + "\Mods"
            Log.Log(String.Format("Fetched mods directory '{0}'.", _mods))
            If Not Exists(_mods) Then
                Create(_mods)
                Log.Log(String.Format("Created mods directory '{0}'.", _mods))
            End If
        End If        
        Return _mods
    End Function

    ' Get Fallout 4 modcache directory
    Public Function ModCache() As String
        If String.IsNullOrEmpty(_modcache) Then
            _modcache = Directories.Mods + "\Cache"
            Log.Log(String.Format("Fetched mod cache directory '{0}'.", _modcache))
            If Not Exists(_modcache) Then
                Create(_modcache)
                Log.Log(String.Format("Created mod cache directory '{0}'.", _modcache))
            End If
        End If        
        Return _modcache
    End Function

    ' Get Fallout 4 temp directory
    Public Function Temp() As String
        If String.IsNullOrEmpty(_temp) Then
            _temp = Directories.Mods + "\f4mm_install"
            Log.Log(String.Format("Fetched temp directory '{0}'.", _temp))
            If Not Exists(_temp) Then
                Create(_temp)
                Log.Log(String.Format("Created temp directory '{0}'.", _temp))
            End If
        End If        
        Return _temp
    End Function

    ' Get Fallout 4 download directory
    Public Function Downloads() As String
        If String.IsNullOrEmpty(_download) Then
            _download = Directories.Mods + "\Downloads"
            Log.Log(String.Format("Fetched download directory '{0}'.", _download))
            If Not Exists(_download) Then
                Create(_download)
                Log.Log(String.Format("Created download directory '{0}'.", _download))
            End If
        End If        
        Return _download
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
        Log.Log(String.Format("Cleaning directory '{0}' ...", Dir))
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
        Log.Log(String.Format("Cleaning of directory '{0}' finished.", Dir))
    End Sub

    ' Check if directory exists
    Public Function Exists(ByVal Directory As String) As Boolean
        Return My.Computer.FileSystem.DirectoryExists(Directory)
    End Function

    ' Create a directory
    Public Function Create(ByVal Directory As String) As Boolean
        Try
            My.Computer.FileSystem.CreateDirectory(Directory)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
