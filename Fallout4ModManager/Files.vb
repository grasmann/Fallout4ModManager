Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO

Module Files

    Public Function FindArchives(ByVal Dir As String) As List(Of String)
        Dim Plugins As New List(Of String)
        For Each Plugin As String In My.Computer.FileSystem.GetFiles(Dir, FileIO.SearchOption.SearchTopLevelOnly, "*.ba2", "*.bsa")
            Plugins.Add(Plugin)
        Next
        Return Plugins
    End Function

    Public Function ActiveArchives() As List(Of String)
        Dim Archives As New List(Of String)
        Dim Path As String = Directories.MyGames + "\Fallout4.ini"
        ' Read
        Dim sb As New StringBuilder(1024)
        Dim rt As Integer = GetPrivateProfileString("Archive", "sResourceStartUpArchiveList", "", sb, sb.Capacity, Path) 'Manager.sResourceStartUpArchiveList_Default, sb, sb.Capacity, Path)
        ' Split
        Archives = sb.ToString.Split(",").ToList
        For i = 0 To Archives.Count - 1
            Archives(i) = Trim(Archives(i))
        Next
        Return Archives
    End Function

    Public Function FindPlugins(ByVal Dir As String) As List(Of String)
        Dim Plugins As New List(Of String)
        For Each Plugin As String In My.Computer.FileSystem.GetFiles(Dir, FileIO.SearchOption.SearchTopLevelOnly, "*.esp")
            Plugins.Add(Plugin)
        Next
        Return Plugins
    End Function

    Public Sub SetReadOnly(ByVal Path As String, ByVal OnlyRead As Boolean)
        Dim Info As FileInfo = New FileInfo(Path)
        Info.IsReadOnly = OnlyRead
    End Sub

    Private Const _plugins_txt_default As String = "# This file is used by Fallout4 to keep track of your downloaded content." + vbCrLf + _
        "# Please do not modify this file." + vbCrLf + _
        "Fallout4.esm" + vbCrLf

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

    Public Function GetActivePlugins() As List(Of String)
        Dim Plugins As New List(Of String)
        Dim Plugin As String
        ' plugins.txt
        Dim Path As String = Directories.Appdata + "\plugins.txt"
        ' Read from file
        If System.IO.File.Exists(Path) = True Then
            Dim objReader As New System.IO.StreamReader(Path)
            While Not objReader.EndOfStream
                Plugin = objReader.ReadLine
                If Not Left(Plugin, 1) = "#" Then Plugins.Add(Plugin)
            End While
            ' Close
            objReader.Close()
        End If
        ' Return
        Return Plugins
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, _
                                               ByVal lpString As String, ByVal lpFileName As String) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, _
                            ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, _
                            ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function

    'Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
    '    (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, _
    '     ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, _
    '     ByVal lpFileName As String) As Integer

    'Private Declare Function GetPrivateProfileString Lib "kernel32" Alias _
    '    "GetPrivateProfileStringA" (ByVal lpApplicationName As String, _
    '        ByVal lpKeyName As String, _
    '        ByVal lpDefault As String, _
    '        ByVal lpReturnedString As String, _
    '        ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Public Sub EditFalloutINI(ByVal sResourceDataDirsFinal As String, ByVal sResourceStartUpArchiveList As String)
        ' Path
        Dim Path As String = Directories.MyGames + "\Fallout4.ini"
        ' Write sResourceDataDirsFinal to ini
        WritePrivateProfileString("Archive", "sResourceDataDirsFinal", sResourceDataDirsFinal, Path)
        ' Write sResourceStartUpArchiveList to ini
        WritePrivateProfileString("Archive", "sResourceStartUpArchiveList", sResourceStartUpArchiveList, Path)
    End Sub

    Public Sub EditFalloutPrefsINI()
        ' Path
        Dim Path As String = Directories.MyGames + "\Fallout4Prefs.ini"
        ' Write to ini
        WritePrivateProfileString("Launcher", "bEnableFileSelection", "1", Path)
        If My.Settings.SetiPresentInterval Then WritePrivateProfileString("Display", "iPresentInterval", "0", Path)
    End Sub

    Public Function ActiveMods() As List(Of String)
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

    Public Function InstalledMods() As List(Of String)
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

    'Public Sub DeinstallMod(ByVal ModFile As String)
    '    Dim backups As New List(Of String)
    '    Dim restore_backups As New List(Of String)
    '    Dim delete_backups As New List(Of String)
    '    Dim Path As String = Directories.Mods + "\" + ModFile
    '    If My.Computer.FileSystem.FileExists(Directories.Mods + "\" + ModFile) Then
    '        Using mfs As New StreamReader(Path)
    '            While Not mfs.EndOfStream
    '                Try
    '                    Dim Line As String = mfs.ReadLine
    '                    If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line) Then
    '                        My.Computer.FileSystem.DeleteFile(Directories.Data + "\" + Line)
    '                        If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line + ".bak") Then
    '                            backups.Add(Directories.Data + "\" + Line)
    '                            'If MsgBox("It appears there is a backup file of """ + Directories.Data + "\" + Line + """." + vbCrLf + _
    '                            '          "Restore backup?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Backup found") = MsgBoxResult.Yes Then
    '                            'My.Computer.FileSystem.MoveFile(Directories.Data + "\" + Line + ".bak", Directories.Data + "\" + Line)
    '                            'End If
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    Debug.Print(ex.Message)
    '                End Try
    '            End While
    '        End Using
    '        ' Delete Mod file
    '        My.Computer.FileSystem.DeleteFile(Path)
    '        ' Backups
    '        If backups.Count > 0 Then
    '            Dim backup As New BackupSolver(backups, restore_backups, delete_backups)
    '            backup.ShowDialog()
    '            ' Restore
    '            For Each File As String In restore_backups
    '                My.Computer.FileSystem.MoveFile(File + ".bak", File)
    '            Next
    '            ' Delete
    '            For Each File As String In delete_backups
    '                My.Computer.FileSystem.DeleteFile(File + ".bak")
    '            Next
    '        End If
    '        ' Directories
    '        Directories.CleanDirectories(Directories.Data)
    '    End If                      
    'End Sub

    Public Function ValidExtension(ByVal File As String) As Boolean
        If Right(File, 3) = "rar" Or _
            Right(File, 3) = "zip" Or _
            Right(File, 2) = "7z" Then
            Return True
        End If
        Return False
    End Function

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

End Module
