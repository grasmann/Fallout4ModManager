Imports System.Runtime.InteropServices
Imports System.IO

Module Files

    Public Function Find(ByVal Dir As String) As List(Of String)
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
                objWriter.Write(Plugin + vbCrLf)
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
                objWriter.Write(Plugin + vbCrLf)
            Next
            ' Close
            objWriter.Close()
        End If
        ' ReadOnly
        SetReadOnly(Path, True)
    End Sub

    Public Function GetActivePlugins() As List(Of String)
        Dim Plugins As New List(Of String)
        ' plugins.txt
        Dim Path As String = Directories.Appdata + "\plugins.txt"
        ' Read from file
        If System.IO.File.Exists(Path) = True Then
            Dim objReader As New System.IO.StreamReader(Path)
            While Not objReader.EndOfStream
                Plugins.Add(objReader.ReadLine)
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

    Public Sub EditFalloutINI(ByVal sResourceDataDirsFinal As String)
        ' Path
        Dim Path As String = Directories.MyGames + "\Fallout4.ini"
        ' Write to ini
        WritePrivateProfileString("Archive", "sResourceDataDirsFinal", sResourceDataDirsFinal, Path)
    End Sub

    Public Sub EditFalloutPrefsINI()
        ' Path
        Dim Path As String = Directories.MyGames + "\Fallout4Prefs.ini"
        ' Write to ini
        WritePrivateProfileString("Launcher", "bEnableFileSelection", "1", Path)
    End Sub

    Public Function InstalledMods() As List(Of String)
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

    Public Sub DeinstallMod(ByVal ModFile As String)
        Dim Path As String = Directories.Mods + "\" + ModFile
        Using mfs As New StreamReader(Path)
            While Not mfs.EndOfStream
                Try
                    Dim Line As String = mfs.ReadLine
                    My.Computer.FileSystem.DeleteFile(Directories.Data + "\" + Line)
                    If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line + ".bak") Then
                        If MsgBox("It appears there is a backup file of """ + Directories.Data + "\" + Line + """." + vbCrLf + _
                                  "Restore backup?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Backup found") = MsgBoxResult.Yes Then
                            My.Computer.FileSystem.MoveFile(Directories.Data + "\" + Line + ".bak", Directories.Data + "\" + Line)
                        End If
                    End If
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try
            End While
        End Using
        Directories.CleanDirectories(Directories.Data)
        My.Computer.FileSystem.DeleteFile(Path)
    End Sub

    Public Function ValidExtension(ByVal File As String) As Boolean
        If Right(File, 3) = "rar" Or _
            Right(File, 3) = "zip" Or _
            Right(File, 2) = "7z" Then
            Return True
        End If
        Return False
    End Function

End Module
