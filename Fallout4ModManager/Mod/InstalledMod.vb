Imports System.ComponentModel
Imports System.Xml
Imports System.IO

Public Class InstalledMod

    Private Enum ModFileType
        Installed
        Activated
    End Enum

    Private _category As String
    Private _name As String
    Private _id As Integer
    Private _hash As String
    Private _version As String
    Private _latest As String
    Private _legacy As Boolean
    Private _active As Boolean
    Private _info As String
    Private WithEvents _worker As New BackgroundWorker

    Public Event UpdateFound(ByVal InstalledMod As InstalledMod)
    Public Event Changed(ByVal InstalledMod As InstalledMod)
    Public Event Update(ByVal InstalledMod As InstalledMod)
    Public Event Uninstalled(ByVal InstalledMod As InstalledMod)

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property ID As Integer
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property Version As String
        Get
            Return _version
        End Get
    End Property

    Public ReadOnly Property Legacy As Boolean
        Get
            Return _legacy
        End Get
    End Property

    Public ReadOnly Property Active As Boolean
        Get
            Return _active
        End Get
    End Property

    Public ReadOnly Property Info As String
        Get
            Return _info
        End Get
    End Property

    Public ReadOnly Property Latest As String
        Get
            Return _latest
        End Get
    End Property

    Public ReadOnly Property Hash As String
        Get
            Return _hash
        End Get
    End Property

    Public ReadOnly Property Category As String
        Get
            Return _category
        End Get
    End Property

    ' ##### INIT ###############################################################################################

    Public Sub New(ByVal Name As String, ByVal ID As Integer, ByVal Version As String, ByVal Active As Boolean, _
                   ByVal Info As String, Optional ByVal Legacy As Boolean = False, Optional ByVal Category As String = "", _
                   Optional ByVal Hash As String = "")
        _name = Name
        _id = ID
        _version = Version
        _latest = _version
        _active = Active
        _legacy = Legacy
        _info = Info
        _category = Category
        _worker.RunWorkerAsync()
    End Sub

    ' ##### ACTIONS ###############################################################################################

    Public Sub UpdateInfo(ByVal Name As String, ByVal ID As Integer, ByVal Version As String, ByVal Category As String)
        _name = Name
        _id = ID
        _version = Version
        _category = Category
    End Sub

    Public Sub RecheckUpdate()
        If Not _worker.IsBusy Then
            _worker.RunWorkerAsync()
        End If
    End Sub

    Public Function Activate() As Boolean
        Dim files As New List(Of ExtractJob)
        Dim exist As New List(Of ExtractJob)
        Dim overwrite As New List(Of ExtractJob)
        ' Get files
        Dim Path As String = Directories.ModCache + "\" + _info
        Dim modxml As New Xml.XmlDocument
        Dim nodes As Xml.XmlNodeList
        modxml.Load(Directories.ModCache + "\" + _info)
        Dim Info As XmlNode = modxml.GetElementsByTagName("Info")(0)
        Dim Name As String = Info.Attributes("Name").Value
        Dim ID As String = Info.Attributes("ID").Value
        Dim Version As String = Info.Attributes("Version").Value
        nodes = modxml.GetElementsByTagName("File")
        For Each Node As Xml.XmlNode In nodes
            Dim Line As String = Node.Attributes("Path").Value
            Dim FilePath As String = Directories.ModCache + "\" + Line
            Dim DataPath As String = Directories.Data + "\" + Microsoft.VisualBasic.Right(Line, Len(Line) - (Len(_info) - 3))
            If My.Computer.FileSystem.FileExists(DataPath) And Not My.Computer.FileSystem.FileExists(DataPath + ".bak") Then
                exist.Add(New ExtractJob(FilePath, DataPath))
            Else
                files.Add(New ExtractJob(FilePath, DataPath))
            End If
        Next
        ' Handle overwrite
        If exist.Count > 0 Then
            Dim overwrite_solver As New OverwriteSolver(exist, overwrite)
            If overwrite_solver.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Return False
            End If
            For Each File As ExtractJob In overwrite
                files.Add(File)
            Next
        End If
        ' Copy files   
        For Each job As ExtractJob In files
            ' Backup
            If My.Computer.FileSystem.FileExists(job.ExtractPath) Then
                If job.Backup Then
                    If Not My.Computer.FileSystem.FileExists(job.ExtractPath + ".bak") Then
                        My.Computer.FileSystem.MoveFile(job.ExtractPath, job.ExtractPath + ".bak")
                    End If
                End If
            End If
            ' Copy
            My.Computer.FileSystem.CopyFile(job.ArchivePath, job.ExtractPath, True)
        Next
        ' Mod file
        CreateModFile(ModFileType.Activated, files)
        ' Value
        _active = True
        ' Event
        RaiseEvent Changed(Me)
        Return True
    End Function

    Public Function Deactivate() As Boolean
        Dim backups As New List(Of String)
        Dim restore_backups As New List(Of String)
        Dim delete_backups As New List(Of String)
        Dim Path As String = Directories.Mods + "\" + _info
        If Not _active Then Return True
        If My.Computer.FileSystem.FileExists(Path) Then
            Dim modxml As New Xml.XmlDocument
            Dim nodes As Xml.XmlNodeList
            modxml.Load(Path)
            nodes = modxml.GetElementsByTagName("File")
            For Each Node As Xml.XmlNode In nodes
                Dim Line As String = Node.Attributes("Path").Value
                If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line) Then
                    'My.Computer.FileSystem.DeleteFile(Directories.Data + "\" + Line)
                    DeleteJobs.DeleteFile(Directories.Data + "\" + Line)
                    If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line + ".bak") Then
                        backups.Add(Directories.Data + "\" + Line)
                    End If
                End If
            Next
            ' Delete Mod file
            'My.Computer.FileSystem.DeleteFile(Path)
            DeleteJobs.DeleteFile(Path)
            ' Backups
            If backups.Count > 0 Then
                Dim backup As New BackupSolver(backups, restore_backups, delete_backups)
                backup.ShowDialog()
                ' Restore
                For Each File As String In restore_backups
                    My.Computer.FileSystem.MoveFile(File + ".bak", File)
                Next
                ' Delete
                For Each File As String In delete_backups
                    'My.Computer.FileSystem.DeleteFile(File + ".bak")
                    DeleteJobs.DeleteFile(File + ".bak")
                Next
            End If
            ' Value
            _active = False
            ' Event
            RaiseEvent Changed(Me)
            Return True
        End If
        Return False
    End Function

    Public Sub Uninstall()
        If Deactivate() Then
            Dim File As String = Directories.ModCache + "\" + _info
            If My.Computer.FileSystem.FileExists(File) Then
                'My.Computer.FileSystem.DeleteFile(File)
                DeleteJobs.DeleteFile(File)
            End If
            Dim Folder As String = Directories.ModCache + "\" + Microsoft.VisualBasic.Left(_info, Len(_info) - 4)
            If My.Computer.FileSystem.DirectoryExists(Folder) Then
                Try
                    Files.SetAttributes(Folder)
                    'My.Computer.FileSystem.DeleteDirectory(Folder, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    DeleteJobs.DeleteDirectory(Folder)
                Catch ex As Exception
                    Debug.Print(ex.Message)
                    Try
                        System.IO.Directory.Delete(Folder, True)
                    Catch ex2 As Exception
                        MsgBox("Couldn't delete directory """ + Folder + """.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                        Process.Start(Folder)
                        Debug.Print(ex2.Message)
                    End Try
                End Try
            End If
            ' Event
            RaiseEvent Uninstalled(Me)
        End If        
    End Sub

    Private Sub CreateModFile(ByVal Type As ModFileType, ByVal Files As List(Of ExtractJob), _
                              Optional ByVal FixName As String = "")
        Dim doc As New XmlDocument
        Dim declaration As XmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
        ' create root and decleration
        Dim root As XmlElement = doc.CreateElement("Mod")
        doc.InsertBefore(declaration, doc.DocumentElement)
        doc.AppendChild(root)
        ' create info
        Dim info As XmlElement = doc.CreateElement("Info")
        info.SetAttribute("Name", _name)
        info.SetAttribute("ID", _id)
        info.SetAttribute("Version", _version)
        info.SetAttribute("Category", _category)
        info.SetAttribute("Hash", _hash)
        doc.DocumentElement.AppendChild(info)
        ' list files
        Dim filelist As XmlElement = doc.CreateElement("Files")
        doc.DocumentElement.AppendChild(filelist)
        For Each job As ExtractJob In Files
            Dim file As XmlElement = doc.CreateElement("File")
            Select Case Type
                Case ModFileType.Installed
                    file.SetAttribute("Path", Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.ModCache) - 1))
                Case ModFileType.Activated
                    file.SetAttribute("Path", Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.Data) - 1))
            End Select            
            filelist.AppendChild(file)
        Next
        ' Fix
        If Not String.IsNullOrEmpty(FixName) Then _info = FixName
        ' save file
        Dim Path As String
        Select Case Type
            Case ModFileType.Installed
                Path = Directories.ModCache + "/" + _info
            Case ModFileType.Activated
                Path = Directories.Mods + "/" + _info
            Case Else
                Path = Directories.ModCache + "/" + _info
        End Select
        doc.Save(Path)
    End Sub

    Public Sub UpdateInfoFiles(ByVal Name As String, ByVal ID As Integer, ByVal Version As String, ByVal Category As String)
        Dim xmldoc As New Xml.XmlDocument
        Dim node As Xml.XmlNode

        ' Edit modcache file
        Dim Path As String = Directories.ModCache + "\" + _info
        If My.Computer.FileSystem.FileExists(Path) Then
            xmldoc.Load(Path)
            node = xmldoc.GetElementsByTagName("Info")(0)
            node.Attributes("Name").Value = Name
            node.Attributes("Version").Value = Version
            node.Attributes("ID").Value = ID.ToString
            If node.Attributes.ItemOf("Category") Is Nothing Then
                Dim attr As XmlAttribute = xmldoc.CreateAttribute("Category")
                attr.Value = Category
                node.Attributes.Append(attr)
            Else
                node.Attributes("Category").Value = Category
            End If            
            xmldoc.Save(Path)
            ' Edit mod file
            Path = Directories.Mods + "/" + _info
            If My.Computer.FileSystem.FileExists(Path) Then
                xmldoc.Load(Path)
                node = xmldoc.GetElementsByTagName("Info")(0)
                node.Attributes("Name").Value = Name
                node.Attributes("Version").Value = Version
                node.Attributes("ID").Value = ID.ToString
                If node.Attributes.ItemOf("Category") Is Nothing Then
                    Dim attr As XmlAttribute = xmldoc.CreateAttribute("Category")
                    attr.Value = Category
                    node.Attributes.Append(attr)
                Else
                    node.Attributes("Category").Value = Category
                End If
                xmldoc.Save(Path)
            End If

            UpdateInfo(Name, ID, Version, Category)
        End If
    End Sub

    Public Sub FixLegacy()
        If MsgBox("Mod Manager will now attempt to convert the mod """ + _name + """.", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "Converting Mod") = MsgBoxResult.Ok Then
            Try
                Dim Files As List(Of ExtractJob)
                Dim Line As String
                Dim OrigName As String = _info
                Dim FixName As String = Left(_info, Len(_info) - 3) + "xml"
                ' Install
                Files = New List(Of ExtractJob)
                Using fs As New StreamReader(Directories.ModCache + "\" + OrigName)
                    While Not fs.EndOfStream
                        Line = fs.ReadLine
                        Files.Add(New ExtractJob(Line, Directories.ModCache + "\" + Line))
                    End While
                End Using
                CreateModFile(ModFileType.Installed, Files, FixName)
                'My.Computer.FileSystem.DeleteFile(Directories.ModCache + "\" + OrigName)
                DeleteJobs.DeleteFile(Directories.ModCache + "\" + OrigName)
                ' Active
                If _active Then
                    Files = New List(Of ExtractJob)
                    Using fs As New StreamReader(Directories.Mods + "\" + OrigName)
                        While Not fs.EndOfStream
                            Line = fs.ReadLine
                            Files.Add(New ExtractJob(Line, Directories.Data + "\" + Line))
                        End While
                    End Using
                    CreateModFile(ModFileType.Activated, Files, FixName)
                    'My.Computer.FileSystem.DeleteFile(Directories.Mods + "\" + OrigName)
                    DeleteJobs.DeleteFile(Directories.Mods + "\" + OrigName)
                End If
                ' Info file
                _info = Left(_info, Len(_info) - 3) + "xml"
                RaiseEvent Changed(Me)
                ' Message
                MsgBox("Mod was successfully converted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Success")
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If        
    End Sub

    ' ##### CHECK FOR UPDATE ###############################################################################################

    ' Background worker for update check

    Private Sub _worker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _worker.DoWork
        If Not Version = "N/A" Then
            Dim nexus As New NexusAPI(_id)
            If String.IsNullOrEmpty(_category) And Not nexus.Category = _category Then
                UpdateInfoFiles(_name, _id, _version, nexus.Category)
                RaiseEvent Update(Me)
            End If
            If Not String.IsNullOrEmpty(nexus.Latest) And Not nexus.Latest = Version Then
                _latest = nexus.Latest
                RaiseEvent UpdateFound(Me)
            End If
        End If
    End Sub

End Class
