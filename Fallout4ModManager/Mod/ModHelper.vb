Imports System.Xml

Module ModHelper

    'Public Sub UninstallMod(ByVal ModFile As String)
    '    DeactivateMod(ModFile)
    '    Dim File As String = Directories.ModCache + "\" + ModFile
    '    If My.Computer.FileSystem.FileExists(File) Then
    '        My.Computer.FileSystem.DeleteFile(File)
    '    End If
    '    Dim Folder As String = Directories.ModCache + "\" + Microsoft.VisualBasic.Left(ModFile, Len(ModFile) - 4)
    '    If My.Computer.FileSystem.DirectoryExists(Folder) Then
    '        Try
    '            Files.SetAttributes(Folder)
    '            My.Computer.FileSystem.DeleteDirectory(Folder, FileIO.DeleteDirectoryOption.DeleteAllContents)
    '        Catch ex As Exception
    '            Debug.Print(ex.Message)
    '            Try
    '                System.IO.Directory.Delete(Folder, True)
    '            Catch ex2 As Exception
    '                MsgBox("Couldn't delete directory """ + Folder + """.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
    '                Process.Start(Folder)
    '                Debug.Print(ex2.Message)
    '            End Try
    '        End Try
    '    End If
    'End Sub

    'Public Sub ActivateMod(ByVal ModFile As String)
    '    Dim files As New List(Of ExtractJob)
    '    Dim exist As New List(Of ExtractJob)
    '    Dim overwrite As New List(Of ExtractJob)
    '    ' Get files
    '    Dim Path As String = Directories.ModCache + "\" + ModFile
    '    Dim modxml As New Xml.XmlDocument
    '    Dim nodes As Xml.XmlNodeList
    '    modxml.Load(Directories.ModCache + "\" + ModFile)
    '    Dim Info As XmlNode = modxml.GetElementsByTagName("Info")(0)
    '    Dim Name As String = Info.Attributes("Name").Value
    '    Dim ID As String = Info.Attributes("ID").Value
    '    Dim Version As String = Info.Attributes("Version").Value
    '    nodes = modxml.GetElementsByTagName("File")
    '    For Each Node As Xml.XmlNode In nodes
    '        Dim Line As String = Node.Attributes("Path").Value
    '        Dim FilePath As String = Directories.ModCache + "\" + Line
    '        Dim DataPath As String = Directories.Data + "\" + Microsoft.VisualBasic.Right(Line, Len(Line) - (Len(ModFile) - 3))
    '        If My.Computer.FileSystem.FileExists(DataPath) And Not My.Computer.FileSystem.FileExists(DataPath + ".bak") Then
    '            exist.Add(New ExtractJob(FilePath, DataPath))
    '        Else
    '            files.Add(New ExtractJob(FilePath, DataPath))
    '        End If
    '    Next
    '    ' Handle overwrite
    '    If exist.Count > 0 Then
    '        Dim overwrite_solver As New OverwriteSolver(exist, overwrite)
    '        If overwrite_solver.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
    '            Exit Sub
    '        End If
    '        For Each File As ExtractJob In overwrite
    '            files.Add(File)
    '        Next
    '    End If
    '    ' Copy files   
    '    For Each job As ExtractJob In files
    '        ' Backup
    '        If My.Computer.FileSystem.FileExists(job.ExtractPath) Then
    '            If job.Backup Then
    '                If Not My.Computer.FileSystem.FileExists(job.ExtractPath + ".bak") Then
    '                    My.Computer.FileSystem.MoveFile(job.ExtractPath, job.ExtractPath + ".bak")
    '                End If
    '            End If
    '        End If
    '        ' Copy
    '        My.Computer.FileSystem.CopyFile(job.ArchivePath, job.ExtractPath, True)
    '    Next
    '    ' Mod file
    '    ModHelper.CreateModFile(Name, Version, ID, ModFile, files)
    'End Sub

    'Public Function DeactivateMod(ByVal ModFile As String) As Boolean
    '    Dim backups As New List(Of String)
    '    Dim restore_backups As New List(Of String)
    '    Dim delete_backups As New List(Of String)
    '    Dim Path As String = Directories.Mods + "\" + ModFile
    '    If My.Computer.FileSystem.FileExists(Directories.Mods + "\" + ModFile) Then
    '        Dim modxml As New Xml.XmlDocument
    '        Dim nodes As Xml.XmlNodeList
    '        modxml.Load(Directories.Mods + "\" + ModFile)
    '        nodes = modxml.GetElementsByTagName("File")
    '        For Each Node As Xml.XmlNode In nodes
    '            Dim Line As String = Node.Attributes("Path").Value
    '            If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line) Then
    '                My.Computer.FileSystem.DeleteFile(Directories.Data + "\" + Line)
    '                If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line + ".bak") Then
    '                    backups.Add(Directories.Data + "\" + Line)
    '                End If
    '            End If
    '        Next
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
    '        Return True
    '    End If
    '    Return False
    'End Function

    'Public Sub CreateModFile(ByVal Name As String, _
    '                          ByVal Version As String, _
    '                          ByVal ID As String, _
    '                          ByVal Filename As String, _
    '                          ByVal Files As List(Of ExtractJob))
    '    Dim doc As New XmlDocument
    '    Dim declaration As XmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", Nothing)

    '    Dim root As XmlElement = doc.CreateElement("Mod")
    '    doc.InsertBefore(declaration, doc.DocumentElement)
    '    doc.AppendChild(root)

    '    Dim info As XmlElement = doc.CreateElement("Info")
    '    info.SetAttribute("Name", Name)
    '    info.SetAttribute("ID", ID)
    '    info.SetAttribute("Version", Version)
    '    doc.DocumentElement.AppendChild(info)

    '    Dim filelist As XmlElement = doc.CreateElement("Files")
    '    doc.DocumentElement.AppendChild(filelist)
    '    For Each job As ExtractJob In Files
    '        Dim file As XmlElement = doc.CreateElement("File")
    '        file.SetAttribute("Path", Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.Data) - 1))
    '        filelist.AppendChild(file)
    '    Next

    '    doc.Save(Directories.Mods + "\" + Filename)
    'End Sub

End Module
