Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO

Module Files

    Private Const _plugins_txt_default As String = "# This file is used by Fallout4 to keep track of your downloaded content." + vbCrLf + _
        "# Please do not modify this file." + vbCrLf + _
        "Fallout4.esm" + vbCrLf



    Private _fallout4ini As String
    Private _pluginstxt As String

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Public Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, _
                                              ByVal lpString As String, ByVal lpFileName As String) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Public Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, _
                                            ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, _
                                            ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function

    ' ##### FILES #######################################################################################################################

    Public Function Fallout4ini() As String
        If String.IsNullOrEmpty(_fallout4ini) Then
            _fallout4ini = Directories.MyGames + "\Fallout4.ini"
            Log.Log(String.Format("Fetched Fallout4.ini path '{0}'.", _fallout4ini))
        End If
        Return _fallout4ini
    End Function
    
    Public Function Pluginstxt() As String
        If String.IsNullOrEmpty(_pluginstxt) Then
            _pluginstxt = Directories.Appdata + "\plugins.txt"
            Log.Log(String.Format("Fetched plugins.txt path '{0}'.", _pluginstxt))
        End If
        Return _pluginstxt
    End Function
    

    ' ##### MODS #######################################################################################################################

    ' Find pre-1.0.24 mods
    Public Function InstalledLegacyMods() As List(Of String)
        Dim Installed As New List(Of String)
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Directories.ModCache)
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.txt")
        Dim dra As IO.FileInfo
        'list the names of all files in the specified directory
        For Each dra In diar1
            Installed.Add(dra.Name)
        Next
        Return Installed
    End Function

    ' Find installed mods
    Public Function InstalledMods() As List(Of String)
        Dim Installed As New List(Of String)
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Directories.ModCache)
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.xml")
        Dim dra As IO.FileInfo
        'list the names of all files in the specified directory
        For Each dra In diar1
            Installed.Add(dra.Name)
        Next
        Return Installed
    End Function

    ' Find active pre-1.0.24 mods
    Public Function FindActiveLegacyMods() As List(Of String)
        Dim Installed As New List(Of String)
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Directories.Mods)
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.txt")
        Dim dra As IO.FileInfo
        'list the names of all files in the specified directory
        For Each dra In diar1
            Installed.Add(dra.Name)
        Next
        Return Installed
    End Function

    ' Find active mods
    Public Function FindActiveMods() As List(Of String)
        Dim Installed As New List(Of String)
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Directories.Mods)
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.xml")
        Dim dra As IO.FileInfo
        'list the names of all files in the specified directory
        For Each dra In diar1
            Installed.Add(dra.Name)
        Next
        Return Installed
    End Function

    ' ##### WRITE / EDIT FILES #######################################################################################################################

    ' Set file readonly / not readonly
    Public Function SetReadOnly(ByVal Path As String, ByVal OnlyRead As Boolean) As Boolean
        Dim Info As FileInfo = New FileInfo(Path)
        Dim WasReadOnly As Boolean = Info.IsReadOnly
        Info.IsReadOnly = OnlyRead
        Return WasReadOnly
    End Function

    ' Set attributes of files in a folder
    Public Sub SetAttributes(ByVal directory As String)
        For Each fileName As String In My.Computer.FileSystem.GetFiles(directory)
            Try
                'set the file attributes to ensure that we can delete the file
                My.Computer.FileSystem.GetFileInfo(fileName).Attributes = FileAttributes.Normal
            Catch ex As Exception
                Debug.Print("Could not set attributes on file: " + fileName)
            End Try
        Next
        For Each dirName As String In My.Computer.FileSystem.GetDirectories(directory)
            Try
                'set the file attributes to ensure that we can delete the directory
                My.Computer.FileSystem.GetFileInfo(dirName).Attributes = FileAttributes.Directory
            Catch ex As Exception
                Debug.Print("Could not set attributes on directory: " + dirName)
            End Try
            'run through method recursively so that all files and directories are taken care of
            SetAttributes(dirName)
        Next
    End Sub

    ' Write plugins.txt file
    Public Sub WritePluginsTxt(ByVal Plugins As List(Of String))
        ' plugins.txt
        Dim Path As String = Directories.Appdata + "\plugins.txt"
        ' Write to file
        If System.IO.File.Exists(Path) = True Then
            SetReadOnly(Path, False)
            Dim objWriter As New System.IO.StreamWriter(Path, False)
            objWriter.Write(_plugins_txt_default)
            ' Write plugins
            For Each Plugin As String In Plugins
                If Not Plugin.ToLower = "fallout4.esm" Then
                    objWriter.Write(Plugin + vbCrLf)
                End If
            Next
            ' Close
            objWriter.Close()
        End If
        ' ReadOnly
        SetReadOnly(Path, True)
    End Sub

    ' Write DLCList.txt file
    Public Sub WriteDLCList(ByVal Plugins As List(Of String))
        ' DLCList.txt
        Dim Path As String = Directories.Appdata + "\DLCList.txt"
        ' Write to file
        If System.IO.File.Exists(Path) = True Then
            SetReadOnly(Path, False)
            Dim objWriter As New System.IO.StreamWriter(Path, False)
            ' Write plugins
            For Each Plugin As String In Plugins
                If Not Plugin.ToLower = "fallout4.esm" Then
                    objWriter.Write(Plugin + vbCrLf)
                End If
            Next
            ' Close
            objWriter.Close()
        End If
        ' ReadOnly
        SetReadOnly(Path, True)
    End Sub

    ' Edit Fallout4.ini file
    Public Sub EditFalloutINI(ByVal sResourceDataDirsFinal As String, ByVal sResourceStartUpArchiveList As String)
        ' Path
        Dim Path As String = Directories.MyGames + "\Fallout4.ini"
        ' Write sResourceDataDirsFinal to ini
        WritePrivateProfileString("Archive", "sResourceDataDirsFinal", sResourceDataDirsFinal, Path)
        ' Write sResourceStartUpArchiveList to ini
        WritePrivateProfileString("Archive", "sResourceStartUpArchiveList", sResourceStartUpArchiveList, Path)
    End Sub

    ' Edit Fallout4Prefs.ini file
    Public Sub EditFalloutPrefsINI()
        ' Path
        Dim Path As String = Directories.MyGames + "\Fallout4Prefs.ini"
        ' Write to ini
        WritePrivateProfileString("Launcher", "bEnableFileSelection", "1", Path)
        If My.Settings.SetiPresentInterval Then WritePrivateProfileString("Display", "iPresentInterval", "0", Path)
    End Sub

    ' ##### CHECK FILES #######################################################################################################################

    Public Function ValidExtension(ByVal File As String) As Boolean
        If Right(File, 3) = "rar" Or _
            Right(File, 3) = "zip" Or _
            Right(File, 2) = "7z" Then
            Return True
        End If
        Return False
    End Function

    ' ##### HELP #######################################################################################################################

    Public Function Exists(ByVal File As String) As Boolean
        Return My.Computer.FileSystem.FileExists(File)
    End Function

End Module
