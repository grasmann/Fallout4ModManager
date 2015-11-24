Imports SevenZip
Imports System.IO
Imports System.Xml
Imports System.Security
Imports System.Security.Permissions
Imports System.ComponentModel

Public Class ModSolver

    Private common_data_folders As New List(Of String) _
        ({"music", "textures", "interface", "video", "sound", "meshes", "programs", "materials", "lodsettings", "vis", "misc", "scripts", "shadersfx", "strings"})
    Private common_data_files As New List(Of String) _
        ({"esp", "esm", "bsa", "ba2", "ini"})
    Private archive_data As New TreeNode("Data ( don't disable )")
    Private path As String
    Private extract_jobs As New List(Of ExtractJob)
    Private WithEvents extracter As SevenZipExtractor
    'Private writer As StreamWriter
    Private extractor_working As Boolean
    Private add_folder_node As TreeNode

    Public Event ModInstalled(ByVal InstalledMod As InstalledMod)

    Private already_exist As New List(Of ExtractJob)

    Private WithEvents _scan_worker As New BackgroundWorker
    Private WithEvents _install_worker As New BackgroundWorker

    Private _archive As String
    Private _name As String
    Private _version As String
    Private _id As Integer
    Private _info As String

    Private _in_progress As Boolean

    Private _test As Integer

#Region "Start"

    Public Sub New(ByVal Archive As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        '_scan_worker.RunWorkerAsync(Archive)
        'ScanArchive(Archive)
        _archive = Archive

    End Sub

    Private Sub ModSolver_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Scan
        _scan_worker.RunWorkerAsync(_archive)
        '' UI
        'TreeView1.Nodes.Clear()
        'archive_data.Checked = True
        'archive_data.ForeColor = SystemColors.InactiveCaptionText
        'TreeView1.Nodes.Add(archive_data)
        'TreeView1.ExpandAll()
        '' Check structure
        'CheckStructure()
    End Sub

#End Region

#Region "Close"

    Private Sub ModSolver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If extractor_working Then e.Cancel = True
    End Sub

#End Region

#Region "DragAndDrop and Structure"

    Private Sub TreeView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles TreeView1.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub TreeView1_DragEnter(sender As Object, e As DragEventArgs) Handles TreeView1.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TreeView1_DragDrop(sender As Object, e As DragEventArgs) Handles TreeView1.DragDrop
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)
        'Get the TreeNode being dragged
        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = selectedTreeview.SelectedNode
        'Remove the drop node from its current location
        dropNode.Remove()
        'If there is no targetNode add dropNode to the bottom of
        'the TreeView root nodes, otherwise add it to the end of
        'the dropNode child nodes
        If targetNode Is Nothing Then
            selectedTreeview.Nodes.Add(dropNode)
        Else
            targetNode.Nodes.Add(dropNode)
        End If
        'Ensure the newley created node is visible to
        'the user and select it
        dropNode.EnsureVisible()
        selectedTreeview.SelectedNode = dropNode
        ' Check structure
        CheckStructure()
    End Sub

    Private Sub TreeView1_DragOver(sender As Object, e As DragEventArgs) Handles TreeView1.DragOver
        'Check that there is a TreeNode being dragged 
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)
        'As the mouse moves over nodes, provide feedback to 
        'the user by highlighting the node that is the 
        'current drop target
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = selectedTreeview.GetNodeAt(pt)
        'See if the targetNode is currently selected, 
        'if so no need to validate again
        If Not (selectedTreeview.SelectedNode Is targetNode) Then
            'Select the    node currently under the cursor
            selectedTreeview.SelectedNode = targetNode
            'Check that the selected node is not the dropNode and
            'also that it is not a child of the dropNode and 
            'therefore an invalid target
            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            Do Until targetNode Is Nothing
                If targetNode Is dropNode Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
                targetNode = targetNode.Parent
            Loop
            'Currently selected node is a suitable target
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Function CheckStructure() As Boolean        
        Dim valid As Boolean
        lbl_status_bad.Visible = True
        lbl_status_good.Visible = False
        btn_install.Enabled = False
        For Each Node As TreeNode In TreeView1.Nodes(0).Nodes
            If common_data_folders.Contains(Node.Text.ToLower) Or common_data_files.Contains(Node.Text.ToLower.Ending) Then
                Node.Checked = True
                valid = True
                lbl_status_good.Visible = True
                btn_install.Enabled = True
            Else
                Node.Checked = False
            End If
        Next
        If valid Then Return True
        lbl_status_bad.Visible = True        
        Return False
    End Function

#End Region

#Region "Control"

    Private ignore_changes As Boolean
    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        If Not ignore_changes Then
            DoChildNodes(e.Node)
        End If
    End Sub

    Private Function CorrectNodes() As Boolean
        Dim change As Boolean
        Dim change2 As Boolean
        If Not TreeView1.Nodes(0).Checked Then
            TreeView1.Nodes(0).Checked = True
            change = True
        End If
        For Each n As TreeNode In TreeView1.Nodes
            ignore_changes = True
            change2 = DoParentNodes(n)
            ignore_changes = False
        Next
        Return change Or change2
    End Function

    Private Sub DoChildNodes(ByVal Node As TreeNode)
        For Each n As TreeNode In Node.Nodes
            n.Checked = Node.Checked
            If n.Nodes.Count > 0 Then DoChildNodes(n)
        Next
    End Sub

    Private Function DoParentNodes(ByVal Node As TreeNode) As Boolean
        Dim change As Boolean
        If Node.Checked Then
            Dim Parent As TreeNode = Node.Parent
            While Not IsNothing(Parent)
                If Not Parent.Checked = Node.Checked Then
                    Parent.Checked = True
                    change = True
                End If
                Parent = Parent.Parent
            End While
        End If
        Return change
    End Function

    Private Sub btn_install_Click(sender As Object, e As EventArgs) Handles btn_install.Click
        btn_install.Enabled = False
        DialogResult = Windows.Forms.DialogResult.OK
        'extracter = New SevenZipExtractor(path)
        already_exist = New List(Of ExtractJob)
        Preprocess(TreeView1.Nodes(0), Directories.ModCache + "\" + path.Filename)
        ' Values
        _name = txt_name.Text
        _version = txt_version.Text
        _id = Val(txt_id.Text)
        'Install()
        _install_worker.RunWorkerAsync()
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            add_folder_node = e.Node
            ContextMenuStrip1.Show(MousePosition)
        End If
    End Sub

    Private Sub NewFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFolderToolStripMenuItem.Click
        If Not IsNothing(add_folder_node) Then
            Dim NewFolder As String = InputBox("Name the new folder.", "New folder", "")
            If Not String.IsNullOrEmpty(NewFolder) Then
                Dim newnode As TreeNode = add_folder_node.Nodes.Add(NewFolder)
                newnode.ToolTipText = "Dir"
            End If
        End If
    End Sub

#End Region

#Region "Scan and Preprocess"

    Private Sub _scan_worker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _scan_worker.DoWork
        ScanArchive(e.Argument)
    End Sub

    Private Sub _scan_worker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _scan_worker.RunWorkerCompleted
        ' Values
        txt_name.Text = _name
        txt_version.Text = _version
        txt_id.Text = _id.ToString
        ' Wait
        Panel1.Visible = False
        ' UI
        TreeView1.Nodes.Clear()
        archive_data.Checked = True        
        TreeView1.Nodes.Add(archive_data)
        archive_data.ForeColor = SystemColors.InactiveCaptionText
        TreeView1.ExpandAll()
        ' Check structure
        CheckStructure()
    End Sub

    Private Sub ScanArchive(ByVal Archive As String)
        path = Archive
        Using fs As Stream = File.OpenRead(path)
            Try
                Dim ext As New SevenZipExtractor(fs)
                If ext.Check Then
                    Dim Items As List(Of ArchiveFileInfo) = ext.ArchiveFileData.ToList
                    Items = Items.OrderBy(Function(x) x.FileName).ToList
                    For Each Item As ArchiveFileInfo In Items 'ext.ArchiveFileData
                        Dim Name As String = Item.FileName
                        Debug.Print(Name)
                        If Not Item.IsDirectory Then
                            Dim parent As TreeNode = archive_data
                            Dim seperate As List(Of String) = Name.Split("\").ToList
                            For i = 0 To seperate.Count - 1
                                Dim node = seperate(i)
                                If Not parent.Nodes.ContainsKey(node) Then
                                    Dim newnode As TreeNode = parent.Nodes.Add(node, node)
                                    newnode.Tag = Name
                                    If common_data_folders.Contains(node.ToLower) Or common_data_files.Contains(Microsoft.VisualBasic.Right(node.ToLower, 3)) Then
                                        newnode.ForeColor = Color.Green
                                    ElseIf parent.ForeColor = Color.Green Then
                                        newnode.ForeColor = Color.Green
                                    End If
                                    If i < seperate.Count - 1 Then
                                        newnode.ToolTipText = "Dir"
                                        parent = newnode
                                    End If
                                    'parent = newnode
                                Else
                                    Dim nodes() As TreeNode = archive_data.Nodes.Find(node, True)
                                    parent = nodes(nodes.Count - 1)
                                End If
                            Next
                            'parent = archive_data
                        End If
                    Next
                End If
                ext.Dispose()
                ext = Nothing
            Catch ex As Exception
                Debug.Print(ex.Message)
                MsgBox("The mod manager can't open file """ + path + """." + vbCrLf + "The file might be corrutped.")
            End Try
            fs.Close()
        End Using
        _info = path + ".xml"
        If My.Computer.FileSystem.FileExists(_info) Then
            Dim doc As New Xml.XmlDocument
            Dim node As Xml.XmlNode
            doc.Load(_info)
            Try
                node = doc.GetElementsByTagName("Info")(0)
                _name = node.Attributes("Name").Value
                _version = node.Attributes("Version").Value
                _id = Val(node.Attributes("ID").Value)
                Exit Sub
            Catch ex As Exception
                MsgBox("The mod manager can't open file """ + _info + """." + vbCrLf + "The file might be corrutped.")
            End Try
        End If
        _name = path.Filename
        _version = "N/A"
        _id = 0
    End Sub

    Private Sub Preprocess(ByVal Node As TreeNode, ByVal Dir As String)
        For Each SubNode As TreeNode In Node.Nodes
            Dim ExtractFile As Boolean = True
            If SubNode.Checked Then
                If Not SubNode.ToolTipText = "Dir" Then
                    Dim filepath As String = Dir + "\" + SubNode.Text
                    extract_jobs.Add(New ExtractJob(SubNode.Tag, filepath))
                Else
                    My.Computer.FileSystem.CreateDirectory(Dir + "\" + SubNode.Text)
                    If SubNode.Nodes.Count > 0 Then Preprocess(SubNode, Dir + "\" + SubNode.Text)
                End If
            End If
        Next
    End Sub

#End Region

#Region "Install and Extract"

    Private Sub _install_worker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _install_worker.DoWork
        Install()
    End Sub

    Private Sub _install_worker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _install_worker.RunWorkerCompleted
        ' Event
        Dim Info As String = Microsoft.VisualBasic.Right(_info, Len(_info) - Len(Directories.Downloads) - 1)
        Dim InstalledMod As New InstalledMod(_name, _id, _version, False, Info)
        RaiseEvent ModInstalled(InstalledMod)
    End Sub

    Private Sub Install()        
        ' Evaluate overwrite
        Dim overwrite_files As New List(Of ExtractJob)
        If already_exist.Count > 0 Then
            Dim overwrite As New OverwriteSolver(already_exist, overwrite_files)
            If overwrite.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                'extracter.Dispose()
                Exit Sub
            End If
        End If
        ' Add overwrite files
        For Each job As ExtractJob In overwrite_files
            extract_jobs.Add(job)
        Next
        ProcessExtractB()
    End Sub

    Private Sub ProcessExtractB()
        extractor_working = True
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0
        Dim filenames As New List(Of String)
        For Each job As ExtractJob In extract_jobs
            filenames.Add(job.ArchivePath)
        Next
        Try
            extracter = New SevenZipExtractor(path)
            extracter.BeginExtractFiles(Directories.Temp, filenames.ToArray)
        Catch ex As Exception
            MsgBox("Mod Manager doesn't have permission to write to folder """ + Directories.Temp + """.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Permission Error")
        End Try
    End Sub

    Private Sub extracter_Extracting(sender As Object, e As ProgressEventArgs) Handles extracter.Extracting
        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(Sub()
                                    ProgressBar1.Value = e.PercentDone
                                End Sub)
        Else
            ProgressBar1.Value = e.PercentDone
        End If
    End Sub

    Private Sub extracter_ExtractionFinished(sender As Object, e As EventArgs) Handles extracter.ExtractionFinished
        'Dim writer As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Directories.ModCache + "\" + path.Filename + ".txt", False)
        For Each job As ExtractJob In extract_jobs
            Try
                ' Backup
                If My.Computer.FileSystem.FileExists(job.ExtractPath) Then
                    If job.Backup Then
                        My.Computer.FileSystem.MoveFile(job.ExtractPath, job.ExtractPath + ".bak")
                    End If
                End If
                ' Move
                My.Computer.FileSystem.MoveFile(Directories.Temp + "\" + job.ArchivePath, job.ExtractPath, True)
                ' Mod file
                'writer.WriteLine(Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.ModCache) - 1))
            Catch ex As Exception
                MsgBox("Mod Manager doesn't have permission to write to folder """ + Directories.Temp + """.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Permission Error")
            End Try
        Next
        ' Release
        extracter.Dispose()
        ' Create mod file
        CreateModFile(extract_jobs)
        ' Close
        extractor_working = False
        'writer.Close()
        ' Delete temp folder
        Try
            My.Computer.FileSystem.DeleteDirectory(Directories.Temp, FileIO.DeleteDirectoryOption.DeleteAllContents)
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("Mod Manager doesn't have permission to delete to folder """ + Directories.Temp + """.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Permission Error")
        End Try        
    End Sub

#End Region

    Private Sub CreateModFile(ByVal Files As List(Of ExtractJob))
        Dim doc As New XmlDocument
        Dim declaration As XmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", Nothing)

        Dim root As XmlElement = doc.CreateElement("Mod")
        doc.InsertBefore(declaration, doc.DocumentElement)
        doc.AppendChild(root)

        Dim info As XmlElement = doc.CreateElement("Info")
        info.SetAttribute("Name", _name)
        info.SetAttribute("ID", _id.ToString)
        info.SetAttribute("Version", _version)
        doc.DocumentElement.AppendChild(info)

        Dim filelist As XmlElement = doc.CreateElement("Files")
        doc.DocumentElement.AppendChild(filelist)
        For Each job As ExtractJob In Files
            Dim file As XmlElement = doc.CreateElement("File")
            file.SetAttribute("Path", Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.ModCache) - 1))
            filelist.AppendChild(file)
        Next        

        doc.Save(Directories.ModCache + "\" + path.Filename + ".xml")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim help As New ModSolverHelp
        help.ShowDialog()
    End Sub

    Private Sub ModSolver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = System.Drawing.Icon.FromHandle(My.Resources.install.GetHicon)
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub TreeView1_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeCheck
        If Not ignore_changes And e.Node.Handle = TreeView1.Nodes(0).Handle Then
            e.Cancel = True
            '_test += 1
            'Debug.Print("Check " + _test.ToString)
        End If
    End Sub

    'Private Sub TreeView1_MouseMove(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseMove
    '    If TreeView1.Nodes.Count > 0 Then
    '        If Not TreeView1.Nodes(0).Checked Then
    '            ignore_changes = True
    '            TreeView1.Nodes(0).Checked = True
    '            ignore_changes = False
    '        End If
    '    End If
    '    _test += 1
    '    Debug.Print("Check " + _test.ToString)
    'End Sub

    'Private Sub TreeView1_MouseUp(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseUp
    '    If TreeView1.Nodes.Count > 0 Then
    '        ignore_changes = True
    '        TreeView1.Nodes(0).Checked = True
    '        ignore_changes = False
    '    End If
    '    _test += 1
    '    Debug.Print("MUp " + _test.ToString)
    'End Sub

    Private Sub TreeView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseDoubleClick
        Dim localPosition As Point = TreeView1.PointToClient(e.Location)
        Dim hitTestInfo As TreeViewHitTestInfo = TreeView1.HitTest(localPosition)
        If hitTestInfo.Location = TreeViewHitTestLocations.StateImage Then
            Exit Sub
        End If
    End Sub

End Class