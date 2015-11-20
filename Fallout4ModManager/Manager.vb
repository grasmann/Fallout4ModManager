Imports SevenZip
Imports System.IO

Public Class Manager

    Public WithEvents Downloads As New ModDownloads
    Public Shared CreateLog As Boolean

    Private Const sResourceDataDirsFinal_Default As String = _
        "STRINGS\, TEXTURES\, INTERFACE\, SOUND\, MUSIC\, VIDEO\, MESHES\, PROGRAMS\, MATERIALS\, LODSETTINGS\, VIS\, MISC\, SCRIPTS\, SHADERSFX\"
    Public Const sResourceStartUpArchiveList_Default As String = _
        "Fallout4 - Startup.ba2, Fallout4 - Shaders.ba2, Fallout4 - Interface.ba2"
    Private archives_default As New List(Of String) _
        ({"Fallout4 - Textures1.ba2", "Fallout4 - Textures2.ba2", "Fallout4 - Textures3.ba2", "Fallout4 - Textures4.ba2", "Fallout4 - Textures5.ba2", _
          "Fallout4 - Textures6.ba2", "Fallout4 - Textures7.ba2", "Fallout4 - Textures8.ba2", "Fallout4 - Textures9.ba2", "Fallout4 - Startup.ba2", _
          "Fallout4 - Shaders.ba2", "Fallout4 - Interface.ba2", "Fallout4 - Animations.ba2", "Fallout4 - Interface.ba2", "Fallout4 - Materials.ba2", _
          "Fallout4 - Meshes.ba2", "Fallout4 - MeshesExtra.ba2", "Fallout4 - Misc.ba2", "Fallout4 - Shaders.ba2", "Fallout4 - Sounds.ba2", _
          "Fallout4 - Startup.ba2", "Fallout4 - Voices.ba2"})

    Private exit_without_save As Boolean
    Private listen_to_cell_changes As Boolean

    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If CreateLog Then Log.CreateWriter()

        If Environment.Is64BitProcess Then
            If CreateLog Then Log.Log("Attempting to load 7z64.dll")
            SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\7z64.dll")
        Else
            If CreateLog Then Log.Log("Attempting to load 7z.dll")
            SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\7z.dll")
        End If

        If CreateLog Then Log.Log("Attempting to fetch fallout 4 directory")
        If Not Directories.CheckInstall() Then
            If CreateLog Then Log.Log("Fallout 4 directory wasn't specified. Program is closing now.")
            exit_without_save = True
            MsgBox("Fallout 4 directory wasn't specified." + vbCrLf + "Program is closing now.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error")
            Application.Exit()
        End If

        If CreateLog Then
            If Not exit_without_save Then
                Log.Log("Startup complete.")
            End If
        End If        

    End Sub

    Private Sub Manager_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'URLProtocol.Register()

        UpdateUI()

        ' sResourceDataDirsFinal
        If String.IsNullOrEmpty(My.Settings.sResourceDataDirsFinal) Then _
            My.Settings.sResourceDataDirsFinal = sResourceDataDirsFinal_Default
        'TextBox1.Text = My.Settings.sResourceDataDirsFinal

        ' iPresentInterval
        'CheckBox1.Checked = My.Settings.SetiPresentInterval

        Fallout4ModManager.Update.CheckUpdate()
    End Sub

    Private Function ListContains(ByVal Esp As String) As Boolean
        For Each Row As DataGridViewRow In DataGridView1.Rows
            If Row.Cells(1).Value = Esp Then Return True
        Next
        Return False
    End Function

    Private Function EspsContain(ByVal Esps As List(Of String), ByVal Esp As String) As Boolean
        For Each e As String In Esps
            If e.Filename = Esp Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub UpdateUI()
        Dim Dir As String = Directories.Data
        Dim Esps As List(Of String) = Files.FindPlugins(Dir)
        Dim Active As List(Of String) = Files.GetActivePlugins
        Dim Archives As List(Of String) = Files.FindArchives(Dir)
        Dim ActiveArchvies As List(Of String) = Files.ActiveArchives

        ' Plugins
        DataGridView1.Rows.Clear()
        For Each Esp As String In Active
            If EspsContain(Esps, Esp) Or Esp.ToLower = "fallout4.esm" Then
                DataGridView1.Rows.Add(True, Esp.Filename, Esp)
                ' Fallout 4 esm
                If Esp.Filename.ToLower = "fallout4.esm" Then
                    Dim Row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
                    Row.ReadOnly = True
                    Row.Cells(0).Style.BackColor = SystemColors.InactiveCaption
                    Row.Cells(1).Style.BackColor = SystemColors.InactiveCaption
                End If
            End If
        Next
        For Each Esp As String In Esps
            If Not ListContains(Esp.Filename) Then DataGridView1.Rows.Add(False, Esp.Filename, Esp)
        Next

        ' Archives
        DataGridView3.Rows.Clear()
        For Each Archive As String In Archives
            If Not archives_default.Contains(Archive.Filename) Then
                DataGridView3.Rows.Add(ActiveArchives.Contains(Archive.Filename), Archive.Filename)
            End If
        Next

        Dim ActiveMods As List(Of String) = Files.ActiveMods
        Dim InstalledMods As List(Of String) = Files.InstalledMods
        ' Mods
        listen_to_cell_changes = False
        dgv_mods.Rows.Clear()
        Dim Name As String
        Dim Warning As String = "Reinstall to use deactivate feature!"
        For Each ActMod As String In ActiveMods
            Name = Microsoft.VisualBasic.Left(ActMod, InStrRev(ActMod, ".", Len(ActMod) - 4) - 1)
            If Not InstalledMods.Contains(ActMod) Then
                dgv_mods.Rows.Add(True, Name, ActMod, Warning)
            Else
                dgv_mods.Rows.Add(True, Name, ActMod, String.Empty)
            End If
        Next        
        For Each InsMod As String In InstalledMods
            If Not ActiveMods.Contains(InsMod) Then
                Name = Microsoft.VisualBasic.Left(InsMod, InStrRev(InsMod, ".", Len(InsMod) - 4) - 1)
                dgv_mods.Rows.Add(False, Name, InsMod)
            End If
        Next
        ' Post process
        Dim hide_warning As Boolean = True
        For Each Row As DataGridViewRow In dgv_mods.Rows
            Row.Cells("mods_warning").Style.ForeColor = Color.Red
            If hide_warning Then
                If Not String.IsNullOrEmpty(Row.Cells("mods_warning").Value) Then hide_warning = False
            End If
        Next
        If hide_warning Then dgv_mods.Columns("mods_warning").Visible = False
        listen_to_cell_changes = True

    End Sub

    Private Sub btn_play_Click(sender As Object, e As EventArgs) Handles btn_play.Click
        Save()
        ' Start
        If My.Computer.FileSystem.FileExists(Directories.Install + "\Fallout4Launcher.exe") Then
            Process.Start(Directories.Install + "\Fallout4Launcher.exe")
        ElseIf My.Computer.FileSystem.FileExists(Directories.Install + "\Fallout4.exe") Then
            Process.Start(Directories.Install + "\Fallout4.exe")
        End If
    End Sub

    Private Sub Save()
        ' Get active plugins
        Dim Plugins As New List(Of String)
        For Each Row As DataGridViewRow In DataGridView1.Rows
            If Row.Cells("esp_active").Value Then
                Plugins.Add(Row.Cells("esp_name").Value)
            End If
        Next
        ' Write plugins.txt
        Files.WritePluginsTxt(Plugins)
        ' Write DLCList.txt
        Files.WriteDLCList(Plugins)
        ' Edit Fallout.ini
        Dim sResourceStartUpArchiveList As String = sResourceStartUpArchiveList_Default
        For Each Row As DataGridViewRow In DataGridView3.Rows
            If Row.Cells(0).Value Then
                sResourceStartUpArchiveList += ", " + Row.Cells(1).Value
            End If
        Next
        Files.EditFalloutINI(My.Settings.sResourceDataDirsFinal, sResourceStartUpArchiveList)
        ' Edit Fallout4Prefs.ini
        Files.EditFalloutPrefsINI()
        ' Save sResourceDataDirsFinal
        'My.Settings.sResourceDataDirsFinal = TextBox1.Text
        ' Save
        My.Settings.Save()
    End Sub

    Private Sub btn_up_Click(sender As Object, e As EventArgs) Handles btn_up.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim Index As Integer = DataGridView1.SelectedRows(0).Index
            If Index > 1 Then
                For i = 0 To DataGridView1.Columns.Count - 1
                    Dim val As Object = DataGridView1.Rows(Index - 1).Cells(i).Value
                    DataGridView1.Rows(Index - 1).Cells(i).Value = DataGridView1.Rows(Index).Cells(i).Value
                    DataGridView1.Rows(Index).Cells(i).Value = val
                Next
                DataGridView1.Rows(Index - 1).Selected = True
            End If
        End If
    End Sub

    Private Sub btn_down_Click(sender As Object, e As EventArgs) Handles btn_down.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim Index As Integer = DataGridView1.SelectedRows(0).Index
            If Index > 0 And Index < DataGridView1.Rows.Count - 1 Then
                For i = 0 To DataGridView1.Columns.Count - 1
                    Dim val As Object = DataGridView1.Rows(Index + 1).Cells(i).Value
                    DataGridView1.Rows(Index + 1).Cells(i).Value = DataGridView1.Rows(Index).Cells(i).Value
                    DataGridView1.Rows(Index).Cells(i).Value = val
                Next
                DataGridView1.Rows(Index + 1).Selected = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged
        If e.StateChanged = DataGridViewElementStates.Selected Then
            If e.Row.Index = 0 Then
                btn_down.Enabled = False
                btn_up.Enabled = False
            Else
                If e.Row.Index = 1 Then
                    btn_up.Enabled = False
                Else
                    btn_up.Enabled = True
                End If
                If e.Row.Index = DataGridView1.Rows.Count - 1 Then
                    btn_down.Enabled = False
                Else
                    btn_down.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub btn_install_Click(sender As Object, e As EventArgs) Handles btn_install.Click
        Dim openFileDialog1 As New OpenFileDialog()
        If String.IsNullOrEmpty(My.Settings.FileDirectory) Then
            openFileDialog1.InitialDirectory = Directories.Install
        Else
            openFileDialog1.InitialDirectory = My.Settings.FileDirectory
        End If
        openFileDialog1.Filter = "All files (*.*)|*.*|Compressed files (*.7z;*.zip;*.rar)|*.7z;*.zip;*.rar"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                If My.Computer.FileSystem.DirectoryExists(openFileDialog1.FileName.Folder) Then
                    My.Settings.FileDirectory = openFileDialog1.FileName.Folder
                End If
                Dim solve As New ModSolver(openFileDialog1.FileName)
                solve.ShowDialog()
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
        UpdateUI()
    End Sub

    Private Sub btn_deinstall_Click(sender As Object, e As EventArgs) Handles btn_deinstall.Click
        If dgv_mods.SelectedRows.Count > 0 Then
            If MsgBox("Do you really want to uninstall the mod" + vbCrLf + """" + dgv_mods.SelectedRows(0).Cells("mods_name").Value + """?",
                      MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Uninstall?") = MsgBoxResult.Yes Then
                '    UninstallMod(dgv_mods.SelectedRows(0).Cells("mod_txt").Value)
                '    UpdateUI()
                UninstallMod(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            End If
        End If        
    End Sub

    Private Sub Manager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not exit_without_save Then Save()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    TextBox1.Text = sResourceDataDirsFinal_Default
    'End Sub

    Private Sub btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click
        Dim about As New About
        about.ShowDialog()
    End Sub

    'Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
    '    My.Settings.SetiPresentInterval = CheckBox1.Checked
    'End Sub

    Private Sub Downloads_Added(ByVal Download As ModDownload) Handles Downloads.Added
        'DataGridView3.Rows.Add(Download.Name)
    End Sub

    Private Sub Downloads_Finished(ByVal Path As String) Handles Downloads.Finished
        Dim solver As New ModSolver(Path)
        solver.ShowDialog()
    End Sub

    Private Sub Downloads_Update() Handles Downloads.Update
        'DataGridView3.Rows.Clear()
        'For Each Download As ModDownload In Downloads.Downloads
        '    DataGridView3.Rows.Add(Download.Name, Download.Percentage.ToString + "%")
        'Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim options As New Options
        options.ShowDialog()
    End Sub

    Private Sub ActivateMod(ByVal ModFile As String)
        Dim files As New List(Of ExtractJob)
        Dim exist As New List(Of ExtractJob)
        Dim overwrite As New List(Of ExtractJob)
        ' Get files
        Dim Path As String = Directories.ModCache + "\" + ModFile
        Using mfs As New StreamReader(Path)
            While Not mfs.EndOfStream
                Dim Line As String = mfs.ReadLine
                Dim FilePath As String = Directories.ModCache + "\" + Line
                Dim DataPath As String = Directories.Data + "\" + Microsoft.VisualBasic.Right(Line, Len(Line) - (Len(ModFile) - 3))
                If My.Computer.FileSystem.FileExists(DataPath) And Not My.Computer.FileSystem.FileExists(DataPath + ".bak") Then
                    exist.Add(New ExtractJob(FilePath, DataPath))
                Else
                    files.Add(New ExtractJob(FilePath, DataPath))
                End If
            End While
        End Using
        ' Handle overwrite
        If exist.Count > 0 Then
            Dim overwrite_solver As New OverwriteSolver(exist, overwrite)
            If overwrite_solver.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            For Each File As ExtractJob In overwrite
                files.Add(File)
            Next
        End If        
        ' Copy files   
        Dim writer As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Directories.Mods + "\" + ModFile, False)
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
            ' Mod file
            writer.WriteLine(Microsoft.VisualBasic.Right(job.ExtractPath, Len(job.ExtractPath) - Len(Directories.Data) - 1))
        Next
        writer.Close()
        ' Save
        Save()
        ' Update
        UpdateUI()
    End Sub

    Private Sub DeactivateMod(ByVal ModFile As String)
        Dim backups As New List(Of String)
        Dim restore_backups As New List(Of String)
        Dim delete_backups As New List(Of String)
        Dim Path As String = Directories.Mods + "\" + ModFile
        If My.Computer.FileSystem.FileExists(Directories.Mods + "\" + ModFile) Then
            Using mfs As New StreamReader(Path)
                While Not mfs.EndOfStream
                    Try
                        Dim Line As String = mfs.ReadLine
                        If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line) Then
                            My.Computer.FileSystem.DeleteFile(Directories.Data + "\" + Line)
                            If My.Computer.FileSystem.FileExists(Directories.Data + "\" + Line + ".bak") Then
                                backups.Add(Directories.Data + "\" + Line)
                            End If
                        End If
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try
                End While
            End Using
            ' Delete Mod file
            My.Computer.FileSystem.DeleteFile(Path)
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
                    My.Computer.FileSystem.DeleteFile(File + ".bak")
                Next
            End If
            ' Clean Directories
            If My.Settings.CleanDirectories Then
                Dim Count As Integer
                Directories.DirectoryCount(Directories.Data, Count)
                ProgressBar1.Maximum = Count
                Directories.CleanDirectories(Directories.Data, ProgressBar1)
                ProgressBar1.Value = 0
            End If            
        End If
        ' Save
        Save()
        ' Update
        UpdateUI()
    End Sub

    Private Sub UninstallMod(ByVal ModFile As String)
        DeactivateMod(ModFile)
        Dim File As String = Directories.ModCache + "\" + ModFile
        If My.Computer.FileSystem.FileExists(File) Then
            My.Computer.FileSystem.DeleteFile(File)
        End If
        Dim Folder As String = Directories.ModCache + "\" + Microsoft.VisualBasic.Left(ModFile, Len(ModFile) - 4)
        If My.Computer.FileSystem.DirectoryExists(Folder) Then
            Try
                Files.SetAttributes(Folder)
                My.Computer.FileSystem.DeleteDirectory(Folder, FileIO.DeleteDirectoryOption.DeleteAllContents)
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
        ' Save
        Save()
        ' Update
        UpdateUI()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_activate.Click
        If dgv_mods.SelectedRows.Count > 0 Then
            ActivateMod(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_deactivate.Click
        If dgv_mods.SelectedRows.Count > 0 Then
            DeactivateMod(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
        End If        
    End Sub

    Private Sub dgv_mods_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_mods.SelectionChanged
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim ActiveMods As List(Of String) = Files.ActiveMods
            If ActiveMods.Contains(dgv_mods.SelectedRows(0).Cells("mods_txt").Value) Then
                btn_deactivate.Enabled = True
                btn_activate.Enabled = False
            Else
                btn_deactivate.Enabled = False
                btn_activate.Enabled = True
            End If
            Dim InstalledMods As List(Of String) = Files.InstalledMods
            If InstalledMods.Contains(dgv_mods.SelectedRows(0).Cells("mods_txt").Value) Then
                btn_deinstall.Enabled = True
            Else
                btn_deinstall.Enabled = False
            End If
        End If        
    End Sub

    Private Sub dgv_mods_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_mods.CellValueChanged
        If e.ColumnIndex = 0 And e.RowIndex > -1 And listen_to_cell_changes Then
            Select Case dgv_mods.Rows(e.RowIndex).Cells("mods_active").Value
                Case True
                    ActivateMod(dgv_mods.Rows(e.RowIndex).Cells("mods_txt").Value)
                Case Else
                    DeactivateMod(dgv_mods.Rows(e.RowIndex).Cells("mods_txt").Value)
            End Select
        End If
    End Sub

    Private Sub dgv_mods_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_mods.CellMouseUp
        If e.ColumnIndex = 0 And e.RowIndex > -1 And listen_to_cell_changes Then
            dgv_mods.EndEdit()
        End If
    End Sub

End Class
