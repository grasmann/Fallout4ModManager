Imports SevenZip
Imports System.IO
Imports System.Security
Imports System.Security.Permissions

Public Class ModSolver

    Private common_data_folders As New List(Of String) _
        ({"music", "textures", "interface", "video", "sound", "meshes", "programs", "materials", "lodsettings", "vis", "misc", "scripts", "shadersfx", "strings"})
    Private common_data_files As New List(Of String) _
        ({"esp", "esm", "bsa", "ba2"})
    Private archive_data As New TreeNode("Data ( don't disable )")
    Private path As String
    Private extract_jobs As New List(Of ExtractJob)
    Private WithEvents extracter As SevenZipExtractor
    Private writer As StreamWriter
    Private extractor_working As Boolean
    Private add_folder_node As TreeNode

    Private already_exist As New List(Of ExtractJob)

#Region "Start"

    Public Sub New(ByVal Archive As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ScanArchive(Archive)

    End Sub

    Private Sub ModSolver_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TreeView1.Nodes.Clear()
        archive_data.Checked = True
        archive_data.ForeColor = SystemColors.InactiveCaptionText
        TreeView1.Nodes.Add(archive_data)
        TreeView1.ExpandAll()
        ' Check structure
        CheckStructure()
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
        writer = My.Computer.FileSystem.OpenTextFileWriter(Directories.Mods + "\" + path.Filename + ".txt", False)
        extracter = New SevenZipExtractor(path)
        already_exist = New List(Of ExtractJob)
        Preprocess(TreeView1.Nodes(0), Directories.Data)
        Install()
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

    Private Sub ScanArchive(ByVal Archive As String)
        path = Archive
        Using fs As Stream = File.OpenRead(path)
            Try
                Using ext As New SevenZipExtractor(path)
                    If ext.Check Then
                        For Each Item As ArchiveFileInfo In ext.ArchiveFileData
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
                                        If i < seperate.Count - 1 Then
                                            newnode.ToolTipText = "Dir"
                                        End If
                                        parent = newnode
                                    Else
                                        parent = archive_data.Nodes.Find(node, True)(0)
                                    End If
                                Next
                            End If
                        Next
                    End If
                End Using
            Catch ex As Exception
                MsgBox("The mod manager can't open file """ + path + """." + vbCrLf + "The file might be corrutped.")
            End Try
        End Using
    End Sub

    Private Sub Preprocess(ByVal Node As TreeNode, ByVal Dir As String)
        For Each SubNode As TreeNode In Node.Nodes
            Dim ExtractFile As Boolean = True
            If SubNode.Checked Then

                If Not SubNode.ToolTipText = "Dir" Then
                    Dim filepath As String = Dir + "\" + SubNode.Text

                    If My.Computer.FileSystem.FileExists(filepath) Then
                        already_exist.Add(New ExtractJob(SubNode.Tag, filepath))
                    Else
                        extract_jobs.Add(New ExtractJob(SubNode.Tag, filepath))
                    End If

                Else
                    My.Computer.FileSystem.CreateDirectory(Dir + "\" + SubNode.Text)
                    If SubNode.Nodes.Count > 0 Then Preprocess(SubNode, Dir + "\" + SubNode.Text)
                End If

            End If
        Next
    End Sub

#End Region

#Region "Install and Extract"

    Private Sub Install()
        ' Evaluate overwrite
        Dim overwrite_files As New List(Of ExtractJob)
        If already_exist.Count > 0 Then
            Dim overwrite As New OverwriteSolver(already_exist, overwrite_files)
            If overwrite.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                writer.Close()
                My.Computer.FileSystem.DeleteFile(Directories.Mods + "\" + path.Filename + ".txt")
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
            extracter.BeginExtractFiles(Directories.Temp, filenames.ToArray)
        Catch ex As Exception
            MsgBox("Mod Manager doesn't have permission to write to folder """ + Directories.Temp + """.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Permission Error")
        End Try
    End Sub

    Private Sub extracter_Extracting(sender As Object, e As ProgressEventArgs) Handles extracter.Extracting
        ProgressBar1.Value = e.PercentDone
    End Sub

    Private Sub extracter_ExtractionFinished(sender As Object, e As EventArgs) Handles extracter.ExtractionFinished
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
                writer.WriteLine(Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.Data) - 1))
            Catch ex As Exception
                MsgBox("Mod Manager doesn't have permission to write to folder """ + Directories.Temp + """.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Permission Error")
            End Try
        Next
        ' Close
        extractor_working = False
        writer.Close()
        ' Delete temp folder
        Try
            My.Computer.FileSystem.DeleteDirectory(Directories.Temp, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Me.Close()
        Catch ex As Exception
            MsgBox("Mod Manager doesn't have permission to delete to folder """ + Directories.Temp + """.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Permission Error")
        End Try
    End Sub

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim help As New ModSolverHelp
        help.ShowDialog()
    End Sub

    Private Sub ModSolver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = System.Drawing.Icon.FromHandle(My.Resources.install.GetHicon)
    End Sub

End Class