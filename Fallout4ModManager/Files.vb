﻿Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO

Module Files

    Private Const _plugins_txt_default As String = "# This file is used by Fallout4 to keep track of your downloaded content." + vbCrLf + _
        "# Please do not modify this file." + vbCrLf + _
        "Fallout4.esm" + vbCrLf

    Private _archive_files() As String = {"*.ba2", "*.bsa"}
    Private _plugin_files() As String = {"*.esp", "*.esm"}

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, _
                                               ByVal lpString As String, ByVal lpFileName As String) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, _
                            ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, _
                            ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function

    ' ##### ARCHIVES #######################################################################################################################

    ' Find archive files
    Public Function FindArchives() As List(Of String)
        Dim Plugins As New List(Of String)
        Dim Files As List(Of String) = My.Computer.FileSystem.GetFiles(Directories.Data, FileIO.SearchOption.SearchTopLevelOnly, _archive_files).ToList
        For Each Plugin As String In Files
            Plugins.Add(Plugin)
        Next
        Return Plugins
    End Function

    ' Find active archives
    Public Function ActiveArchives() As List(Of String)
        Dim Archives As New List(Of String)
        Dim Path As String = Directories.MyGames + "\Fallout4.ini"
        ' Read
        Dim sb As New StringBuilder(1024)
        Dim rt As Integer = GetPrivateProfileString("Archive", "sResourceStartUpArchiveList", "", sb, sb.Capacity, Path)
        ' Split
        Archives = sb.ToString.Split(",").ToList
        For i = 0 To Archives.Count - 1
            Archives(i) = Trim(Archives(i))
        Next
        Return Archives
    End Function

    ' ##### PLUGINS #######################################################################################################################

    ' Find plugins
    Public Function FindPlugins() As List(Of String)
        Dim Plugins As New List(Of String)
        Dim Files As List(Of String) = My.Computer.FileSystem.GetFiles(Directories.Data, FileIO.SearchOption.SearchTopLevelOnly, _plugin_files).ToList
        For Each Plugin As String In Files
            Plugins.Add(Plugin)
        Next
        Return Plugins
    End Function

    ' Get active plugins
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

    ' ##### DOWNLOADS #######################################################################################################################

    Public Function FindDownloads() As List(Of String)
        Dim Downloads As New List(Of String)
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Directories.Downloads)
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.xml")
        Dim dra As IO.FileInfo
        'list the names of all files in the specified directory
        For Each dra In diar1
            Downloads.Add(dra.Name)
        Next
        Return Downloads
    End Function

    ' ##### WRITE / EDIT FILES #######################################################################################################################

    ' Set file readonly / not readonly
    Public Sub SetReadOnly(ByVal Path As String, ByVal OnlyRead As Boolean)
        Dim Info As FileInfo = New FileInfo(Path)
        Info.IsReadOnly = OnlyRead
    End Sub

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

End Module
