Imports SevenZip
Imports System.IO

Public Class ModSolver

    Private common_data_folders As New List(Of String)({"music", "textures", "interface", "video", "sound", "meshes", "programs", "materials", "lodsettings", "vis", "misc", "scripts", "shadersfx"})
    Private archive_data As New TreeNode("Data")
    Private path As String
    Private extract_jobs As New List(Of ExtractJob)
    Private WithEvents extracter As SevenZipExtractor
    Private writer As StreamWriter
    Private extractor_working As Boolean
    Private add_folder_node As TreeNode

    Private already_exist As New List(Of ExtractJob)

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

    Public Sub Data(ByVal Archive As String)
        path = Archive
        Using fs As Stream = File.OpenRead(path)
            Using ext As New SevenZipExtractor(path)
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
                    'If InStr(Name, "\") Then
                    '    Dim parent As TreeNode = Nothing
                    '    Dim seperate As List(Of String) = Name.Split("\").ToList
                    '    For Each node As String In seperate
                    '        If IsNothing(parent) Then
                    '            If Not archive_data.Nodes.ContainsKey(node) Then
                    '                Dim newnode As TreeNode = archive_data.Nodes.Add(node, node)
                    '                newnode.Tag = Name
                    '                newnode.Checked = True
                    '                If Item.IsDirectory Then newnode.ToolTipText = "Dir"
                    '                'archive_data.Nodes.Add(node, node).Checked = True
                    '                parent = archive_data.Nodes(archive_data.Nodes.Count - 1)
                    '            Else
                    '                parent = archive_data.Nodes.Find(node, True)(0)
                    '            End If
                    '        Else
                    '            If Not parent.Nodes.ContainsKey(node) Then
                    '                Dim newnode As TreeNode = parent.Nodes.Add(node, node)
                    '                newnode.Tag = Name
                    '                newnode.Checked = True
                    '                If Item.IsDirectory Then newnode.ToolTipText = "Dir"
                    '                'parent.Nodes.Add(node, node).Checked = True
                    '                parent = parent.Nodes(parent.Nodes.Count - 1)
                    '            Else
                    '                parent = parent.Nodes.Find(node, True)(0)
                    '            End If
                    '        End If
                    '    Next
                    'Else
                    '    If Not archive_data.Nodes.ContainsKey(Item.FileName) Then
                    '        Dim newnode As TreeNode = archive_data.Nodes.Add(Item.FileName, Item.FileName)
                    '        newnode.Tag = Name
                    '        newnode.Checked = True
                    '        'archive_data.Nodes.Add(Item.FileName, Item.FileName).Checked = True
                    '        If Item.IsDirectory Then newnode.ToolTipText = "Dir"
                    '    End If
                    'End If
                Next
            End Using
        End Using        
    End Sub

    Private Sub ModSolver_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TreeView1.Nodes.Clear()
        archive_data.Checked = True
        TreeView1.Nodes.Add(archive_data)
        TreeView1.ExpandAll()
        ' Check structure
        CheckStructure()
    End Sub

    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        For Each node As TreeNode In e.Node.Nodes
            node.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub btn_install_Click(sender As Object, e As EventArgs) Handles btn_install.Click
        'Extract(TreeView1.Nodes(0), Directories.Data)
        writer = My.Computer.FileSystem.OpenTextFileWriter(Directories.Mods + "\" + path.Filename + ".txt", False)
        extracter = New SevenZipExtractor(path)
        already_exist = New List(Of ExtractJob)
        Extract(TreeView1.Nodes(0), Directories.Data)
        Install()        
        'ProcessExtract()
        'ProcessExtractB()        
        'Me.Close()
    End Sub

    Private Sub CheckStructure()
        Dim valid As Boolean
        lbl_status_bad.Visible = True
        lbl_status_good.Visible = False
        For Each Node As TreeNode In TreeView1.Nodes(0).Nodes
            If common_data_folders.Contains(Node.Text.ToLower) Or Microsoft.VisualBasic.Right(Node.Text.ToLower, 4) = ".esp" Then
                Node.Checked = True
                valid = True
                lbl_status_good.Visible = True
            Else
                Node.Checked = False
            End If
        Next
        If valid Then Exit Sub
        lbl_status_bad.Visible = True
    End Sub

    Private Sub Extract(ByVal Node As TreeNode, ByVal Dir As String)        
        For Each SubNode As TreeNode In Node.Nodes
            Dim ExtractFile As Boolean = True
            If SubNode.Checked Then

                'If InStr(SubNode.Text, ".") Then
                If Not SubNode.ToolTipText = "Dir" Then
                    Dim filepath As String = Dir + "\" + SubNode.Text

                    If My.Computer.FileSystem.FileExists(filepath) Then
                        already_exist.Add(New ExtractJob(SubNode.Tag, filepath))
                    Else
                        extract_jobs.Add(New ExtractJob(SubNode.Tag, filepath))
                    End If

                    'If My.Computer.FileSystem.FileExists(filepath) Then
                    '    Select Case MsgBox("File """ + filepath + """ already exists." + vbCrLf + "Do you want to make a backup?" + vbCrLf + "Press cancel to skip the file.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel)
                    '        Case MsgBoxResult.Cancel
                    '            ExtractFile = False
                    '        Case MsgBoxResult.Yes
                    '            My.Computer.FileSystem.CopyFile(filepath, filepath + ".bak")
                    '            MsgBox("The backup was saved as """ + filepath + ".bak""", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Backup created")
                    '    End Select
                    'End If
                    'If ExtractFile Then
                    '    extract_jobs.Add(New ExtractJob(SubNode.Tag, filepath))
                    '    'Using fs As Stream = File.Create(filepath)
                    '    '    Using ext As New SevenZipExtractor(path)
                    '    '        ext.ExtractFile(SubNode.Tag, fs)
                    '    '        Writer.WriteLine(Microsoft.VisualBasic.Right(filepath, Len(filepath) - Len(Directories.Data) - 1))
                    '    '    End Using
                    '    'End Using
                    '    writer.WriteLine(Microsoft.VisualBasic.Right(filepath, Len(filepath) - Len(Directories.Data) - 1))
                    'End If
                Else
                    My.Computer.FileSystem.CreateDirectory(Dir + "\" + SubNode.Text)
                    If SubNode.Nodes.Count > 0 Then Extract(SubNode, Dir + "\" + SubNode.Text)
                End If
            End If
        Next
        
    End Sub

    Private Sub Install()
        ' Evaluate overwrite
        Dim overwrite_files As New List(Of ExtractJob)
        If already_exist.Count > 0 Then            
            Dim overwrite As New OverwriteSolver(already_exist, overwrite_files)
            If overwrite.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                writer.Close()
                Exit Sub
            End If            
        End If        
        ' Add overwrite files
        For Each job As ExtractJob In overwrite_files
            extract_jobs.Add(job)
        Next

        ProcessExtractB()
    End Sub

    'Private Sub ProcessExtract()
    '    ProgressBar1.Maximum = extract_jobs.Count
    '    ProgressBar1.Value = 0
    '    For Each job As ExtractJob In extract_jobs
    '        Using fs As Stream = File.Create(job.ExtractPath)
    '            'Using ext As New SevenZipExtractor(path)
    '            extracter.ExtractFile(job.ArchivePath, fs)
    '            writer.WriteLine(Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.Data) - 1))
    '            ProgressBar1.Value += 1
    '            Application.DoEvents()
    '            'End Using
    '        End Using
    '    Next
    'End Sub

    Private Sub ProcessExtractB()
        'extracter.BeginExtractArchive(System.IO.Path.GetTempPath + "\" + path.Filename)
        extractor_working = True
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0
        Dim filenames As New List(Of String)
        For Each job As ExtractJob In extract_jobs
            filenames.Add(job.ArchivePath)
        Next
        'extracter.ExtractFiles(System.IO.Path.GetTempPath + "\" + path.Filename, filenames.ToArray)
        'extracter.BeginExtractFiles(System.IO.Path.GetTempPath + path.Filename, filenames.ToArray)
        extracter.BeginExtractFiles(Directories.Mods + "\f4mm_install", filenames.ToArray)
    End Sub

    Private Sub extracter_Extracting(sender As Object, e As ProgressEventArgs) Handles extracter.Extracting
        ProgressBar1.Value = e.PercentDone
    End Sub

    Private Sub extracter_ExtractionFinished(sender As Object, e As EventArgs) Handles extracter.ExtractionFinished
        For Each job As ExtractJob In extract_jobs
            ' Backup
            'If My.Computer.FileSystem.FileExists(job.ExtractPath) Then
            '    If job.Backup Then
            '        Using sourceStream As FileStream = File.Open(job.ExtractPath, FileMode.Open)
            '            Using destinationStream As FileStream = File.Create(job.ExtractPath + ".bak")
            '                sourceStream.CopyTo(destinationStream)
            '            End Using
            '        End Using
            '    End If
            'End If
            If My.Computer.FileSystem.FileExists(job.ExtractPath) Then
                If job.Backup Then
                    My.Computer.FileSystem.MoveFile(job.ExtractPath, job.ExtractPath + ".bak")
                End If
            End If            
            ' Move
            'Using sourceStream As FileStream = File.Open(Directories.Mods + "\f4mm_install\" + job.ArchivePath, FileMode.Open)
            '    Using destinationStream As FileStream = File.Create(job.ExtractPath)
            '        sourceStream.CopyTo(destinationStream)
            '    End Using
            'End Using
            My.Computer.FileSystem.MoveFile(Directories.Mods + "\f4mm_install\" + job.ArchivePath, job.ExtractPath)
            writer.WriteLine(Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.Data) - 1))
        Next
        My.Computer.FileSystem.DeleteDirectory(Directories.Mods + "\f4mm_install", FileIO.DeleteDirectoryOption.DeleteAllContents)
        ' Close
        extractor_working = False
        writer.Close()
        Me.Close()        
    End Sub

    Private Sub ModSolver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If extractor_working Then e.Cancel = True
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
                add_folder_node.Nodes.Add(NewFolder)
            End If
        End If
    End Sub

End Class