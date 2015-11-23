Imports SevenZip
Imports System.IO
Imports System.Xml
Imports System.ComponentModel

Public Class Manager

    Public WithEvents Downloads As New ModDownloads
    Public WithEvents InstalledMods As New InstalledMods
    Public WithEvents InstalledPlugins As New InstalledPlugins
    Public WithEvents InstalledArchives As New InstalledArchives

    Public Shared CreateLog As Boolean
    Private legacy_message_shown As Boolean
    Private legacy_mods_found As Boolean

    Private Const sResourceDataDirsFinal_Default As String = _
        "STRINGS\, TEXTURES\, INTERFACE\, SOUND\, MUSIC\, VIDEO\, MESHES\, PROGRAMS\, MATERIALS\, LODSETTINGS\, VIS\, MISC\, SCRIPTS\, SHADERSFX\"
    Public Const sResourceStartUpArchiveList_Default As String = _
        "Fallout4 - Startup.ba2, Fallout4 - Shaders.ba2, Fallout4 - Interface.ba2"
    'Private archives_default As New List(Of String) _
    '    ({"Fallout4 - Textures1.ba2", "Fallout4 - Textures2.ba2", "Fallout4 - Textures3.ba2", "Fallout4 - Textures4.ba2", "Fallout4 - Textures5.ba2", _
    '      "Fallout4 - Textures6.ba2", "Fallout4 - Textures7.ba2", "Fallout4 - Textures8.ba2", "Fallout4 - Textures9.ba2", "Fallout4 - Startup.ba2", _
    '      "Fallout4 - Shaders.ba2", "Fallout4 - Interface.ba2", "Fallout4 - Animations.ba2", "Fallout4 - Interface.ba2", "Fallout4 - Materials.ba2", _
    '      "Fallout4 - Meshes.ba2", "Fallout4 - MeshesExtra.ba2", "Fallout4 - Misc.ba2", "Fallout4 - Shaders.ba2", "Fallout4 - Sounds.ba2", _
    '      "Fallout4 - Startup.ba2", "Fallout4 - Voices.ba2"})

    Private exit_without_save As Boolean
    Private listen_to_cell_changes As Boolean

    ' ##### INIT ###################################################################################

    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CreateLog Then Log.CreateWriter()
        If Environment.Is64BitProcess Then
            If CreateLog Then Log.Log("Attempting to load 7z64.dll")
            SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\7z64.dll")
        Else
            If CreateLog Then Log.Log("Attempting to load 7z.dll")
            SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\7z.dll")
        End If        
    End Sub

    Private Sub Manager_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Fetch directory
        If CreateLog Then Log.Log("Attempting to fetch fallout 4 directory")
        If Not Directories.FindInstall() Then
            If CreateLog Then Log.Log("Fallout 4 directory wasn't specified. Program is closing now.")
            exit_without_save = True
            MsgBox("Fallout 4 directory wasn't specified." + vbCrLf + "Program is closing now.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error")
            Application.Exit()
        End If
        If CreateLog Then
            If Not exit_without_save Then Log.Log("Startup complete.")
        End If
        ' Load data
        InstalledMods.Reload()
        InstalledPlugins.Reload()
        InstalledArchives.Reload()
        Downloads.FindFinishedDownloads()
        ' sResourceDataDirsFinal
        If String.IsNullOrEmpty(My.Settings.sResourceDataDirsFinal) Then _
            My.Settings.sResourceDataDirsFinal = sResourceDataDirsFinal_Default
        ' Check for update
        Fallout4ModManager.Update.CheckUpdate()
        ' Legacy Mods
        If legacy_mods_found Then ShowFixMessage()
    End Sub

    Private Sub ShowFixMessage()
        If Not legacy_message_shown Then
            MsgBox("Some of your mods were installed by an earlier mod manager version." + vbCrLf + _
               "Since mods are stored in a different structure now you'll have to reinstall or fix those mods." + vbCrLf + _
               "To fix them double click on them or right click them and select" + vbCrLf + "'Fix Legacy Mod'.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _
               "Legacy Mods detected")
            legacy_message_shown = True
        End If        
    End Sub

    ' ##### CLOSE ###################################################################################

    Private Sub Manager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not exit_without_save Then Save()
        ' Cancel downloads
        Downloads.AbortAll()
    End Sub

    Private Sub Save()
        ' Get active plugins
        Dim Plugins As New List(Of String)
        For Each Row As DataGridViewRow In dgv_plugins.Rows
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
        For Each Row As DataGridViewRow In dgv_archives.Rows
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

    ' ##### BUTTONS ###################################################################################

    Private Sub btn_play_Click(sender As Object, e As EventArgs) Handles btn_play.Click
        Save()
        ' Start
        If My.Computer.FileSystem.FileExists(Directories.Install + "\Fallout4Launcher.exe") Then
            Process.Start(Directories.Install + "\Fallout4Launcher.exe")
        ElseIf My.Computer.FileSystem.FileExists(Directories.Install + "\Fallout4.exe") Then
            Process.Start(Directories.Install + "\Fallout4.exe")
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
    End Sub

    Private Sub btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click
        Dim about As New About
        about.ShowDialog()
    End Sub

    Private Sub btn_settings_Click(sender As Object, e As EventArgs) Handles btn_settings.Click
        Dim options As New Options
        options.ShowDialog()
    End Sub

    ' ##### MOD UPDATES ############################################################################################################
    
    Private Sub InstalledMods_ModFound(InstalledMod As InstalledMod) Handles InstalledMods.ModFound
        Dim Warning As String
        With InstalledMod
            If .Legacy Then
                legacy_mods_found = True
                Warning = " ( Legacy - Reinstall or Right Click to fix )"
            Else
                Warning = String.Empty
            End If
            listen_to_cell_changes = False
            If dgv_mods.InvokeRequired Then
                dgv_mods.Invoke(Sub()
                                    dgv_mods.Rows.Add(.Active, .Name + Warning, .Info, .Version, "", .ID.ToString)
                                    If .Legacy Then dgv_mods.Rows(dgv_mods.Rows.Count - 1).Cells("mods_active").ReadOnly = True
                                End Sub)
            Else
                dgv_mods.Rows.Add(.Active, .Name + Warning, .Info, .Version, "", .ID.ToString)
                If .Legacy Then dgv_mods.Rows(dgv_mods.Rows.Count - 1).Cells("mods_active").ReadOnly = True
            End If
            listen_to_cell_changes = True
        End With
        'CheckModWarnings()
    End Sub

    Private Sub InstalledMods_ModChanged(InstalledMod As InstalledMod) Handles InstalledMods.ModChanged
        ReloadPlugins()
        ReloadArchives()
        ' Save
        Save()
    End Sub

    Private Sub InstalledMods_ModUninstalled(InstalledMod As InstalledMod) Handles InstalledMods.ModUninstalled
        'InstalledPlugins.Reload()
    End Sub

    Private Sub InstalledMods_UpdateFound(InstalledMod As InstalledMod) Handles InstalledMods.UpdateFound
        With InstalledMod
            For Each Row As DataGridViewRow In dgv_mods.Rows
                If Row.Cells("mods_id").Value = .ID.ToString And Row.Cells("mods_version").Value = .Version Then
                    If dgv_mods.InvokeRequired Then
                        dgv_mods.Invoke(Sub()
                                            'Row.Cells("mods_version").Value = .Version + " > " + .Latest
                                            Row.Cells("mods_update").Value = .Latest
                                            Row.Cells("mods_version").Style.BackColor = Color.Red
                                        End Sub)
                    Else
                        'Row.Cells("mods_version").Value = .Version + " > " + .Latest
                        Row.Cells("mods_update").Value = .Latest
                        Row.Cells("mods_version").Style.BackColor = Color.Red
                    End If
                End If
            Next
        End With
        CheckModUpdates()
    End Sub

    Private Sub CheckModUpdates()
        Dim updates_available As Boolean
        For Each InstalledMod As InstalledMod In InstalledMods
            If Not InstalledMod.Version = InstalledMod.Latest Then
                updates_available = True
                Exit For
            End If
        Next
        If updates_available Then
            If dgv_mods.InvokeRequired Then
                dgv_mods.Invoke(Sub()
                                    dgv_mods.Columns("mods_update").Visible = True
                                End Sub)
            Else
                dgv_mods.Columns("mods_update").Visible = True
            End If
        End If
    End Sub

    'Private Sub CheckModWarnings()
    '    For Each InstalledMod As InstalledMod In InstalledMods
    '        If InstalledMod.Legacy Then
    '            dgv_mods.Columns("mods_warning").Visible = True
    '            Exit Sub
    '        End If
    '    Next
    '    dgv_mods.Columns("mods_warning").Visible = False
    'End Sub

    ' ##### MOD CONTROLS ############################################################################################################

    Private Sub btn_fix_legacy_Click(sender As Object, e As EventArgs) Handles btn_fix_legacy.Click
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                If InstalledMod.Legacy Then
                    InstalledMod.FixLegacy()
                    ReloadMods()
                End If
            End If
        End If
    End Sub

    Private Sub dgv_mods_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_mods.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dgv_mods.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub dgv_mods_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_mods.CellMouseUp
        If e.ColumnIndex = 0 And e.RowIndex > -1 And listen_to_cell_changes Then
            dgv_mods.EndEdit()
        End If
    End Sub

    Private Sub ReloadMods()
        dgv_mods.Rows.Clear()
        dgv_mods.Columns("mods_update").Visible = False
        Me.InstalledMods.Reload()
    End Sub

    Private Sub dgv_mods_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_mods.CellContentClick
        If e.ColumnIndex = dgv_mods.Columns("mods_version").Index And e.RowIndex > -1 Then
            If Not String.IsNullOrEmpty(dgv_mods.Rows(e.RowIndex).Cells("mods_id").Value) Then
                Process.Start(NexusAPI.ModUrl.Replace("%ID%", dgv_mods.Rows(e.RowIndex).Cells("mods_id").Value))
            End If
        End If
    End Sub

    Private Sub UninstallMod()
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                If MsgBox("Do you really want to uninstall the mod" + vbCrLf + """" + dgv_mods.SelectedRows(0).Cells("mods_name").Value + """?",
                      MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Uninstall?") = MsgBoxResult.Yes Then
                    InstalledMod.Uninstall()
                    ' Update
                    ReloadMods()
                End If
            End If
        End If
    End Sub

    Private Sub btn_deinstall_Click(sender As Object, e As EventArgs) Handles btn_deinstall.Click
        UninstallMod()
    End Sub

    Private Sub ActivateMod()
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                ' Legacy
                If InstalledMod.Legacy Then
                    InstalledMod.FixLegacy()
                    ReloadMods()
                    Exit Sub
                End If

                InstalledMod.Activate()
                EvaluateModSelection()
                listen_to_cell_changes = False
                dgv_mods.SelectedRows(0).Cells("mods_active").Value = True
                listen_to_cell_changes = True
            End If
        End If
    End Sub

    Private Sub DeactivateMod()
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                ' Legacy
                If InstalledMod.Legacy Then
                    InstalledMod.FixLegacy()
                    ReloadMods()
                    Exit Sub
                End If

                InstalledMod.Deactivate()
                EvaluateModSelection()
                listen_to_cell_changes = False
                dgv_mods.SelectedRows(0).Cells("mods_active").Value = False
                listen_to_cell_changes = True
            End If
        End If
    End Sub

    Private Sub btn_activate_Click(sender As Object, e As EventArgs) Handles btn_activate.Click
        ActivateMod()        
    End Sub

    Private Sub btn_deactivate_Click(sender As Object, e As EventArgs) Handles btn_deactivate.Click
        DeactivateMod()
    End Sub

    Private Sub dgv_mods_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_mods.SelectionChanged
        EvaluateModSelection()
    End Sub

    Private Sub dgv_mods_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_mods.CellValueChanged
        If e.ColumnIndex = 0 And e.RowIndex > -1 And listen_to_cell_changes Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.Rows(e.RowIndex).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                With InstalledMod
                    ' Legacy
                    If .Legacy Then
                        InstalledMod.FixLegacy()
                        ReloadMods()
                        Exit Sub
                    End If

                    If .Active Then
                        .Deactivate()
                    Else
                        If Not .Activate() Then
                            listen_to_cell_changes = False
                            dgv_mods.Rows(e.RowIndex).Cells("mods_active").Value = False
                            listen_to_cell_changes = True
                        End If
                    End If
                End With
            End If
            EvaluateModSelection()
        End If
    End Sub

    Private Sub EvaluateModSelection()
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                With InstalledMod
                    If .Legacy Then
                        btn_deactivate.Visible = False
                        btn_activate.Visible = False
                        btn_deinstall.Visible = False
                        btn_fix_legacy.Visible = True
                        Exit Sub
                    End If

                    btn_fix_legacy.Visible = False
                    btn_deactivate.Visible = .Active
                    btn_activate.Visible = Not .Active
                    btn_deinstall.Visible = True
                End With
            End If
        End If
    End Sub

    ' ##### MODS CONTEXTMENU ############################################################################################################

    Private Sub mods_context_Opening(sender As Object, e As CancelEventArgs) Handles mods_context.Opening
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                ' Legacy
                If InstalledMod.Legacy Then
                    ActivateToolStripMenuItem.Visible = False
                    DeactivateToolStripMenuItem.Visible = False
                    ToolStripSeparator2.Visible = False
                    ToolStripSeparator3.Visible = False
                    UninstallToolStripMenuItem.Visible = False
                    EditInfoToolStripMenuItem.Visible = False
                    FixLegacyModToolStripMenuItem.Visible = True
                    Exit Sub
                End If

                ' Normal
                If InstalledMod.Active Then
                    ActivateToolStripMenuItem.Visible = False
                    DeactivateToolStripMenuItem.Visible = True
                Else
                    ActivateToolStripMenuItem.Visible = True
                    DeactivateToolStripMenuItem.Visible = False
                End If
                ToolStripSeparator2.Visible = True
                ToolStripSeparator3.Visible = True
                UninstallToolStripMenuItem.Visible = True
                EditInfoToolStripMenuItem.Visible = True
                FixLegacyModToolStripMenuItem.Visible = False
            End If
        End If
    End Sub

    Private Sub FixLegacyModToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixLegacyModToolStripMenuItem.Click
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                InstalledMod.FixLegacy()
                ReloadMods()
            End If
        End If
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateToolStripMenuItem.Click
        ActivateMod()
    End Sub

    Private Sub DeactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeactivateToolStripMenuItem.Click
        DeactivateMod()
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        UninstallMod()
    End Sub

    Private Sub dgv_mods_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_mods.CellDoubleClick
        If dgv_mods.SelectedRows.Count > 0 And e.RowIndex > -1 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                ' Legacy
                If InstalledMod.Legacy Then
                    InstalledMod.FixLegacy()
                    ReloadMods()
                    Exit Sub
                End If

                If InstalledMod.Active Then
                    DeactivateMod()
                Else
                    ActivateMod()
                End If
            End If
        End If
    End Sub

    Private Sub EditInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditInfoToolStripMenuItem.Click
        If dgv_mods.SelectedRows.Count > 0 Then
            Dim InstalledMod As InstalledMod = Me.InstalledMods.GetByInfo(dgv_mods.SelectedRows(0).Cells("mods_txt").Value)
            If Not IsNothing(InstalledMod) Then
                Dim edit As New EditModInfo(InstalledMod)
                If edit.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ReloadMods()
                End If
            End If
        End If
    End Sub

    ' ##### PLUGIN UPDATES ############################################################################################################

    Private Sub ReloadPlugins()
        dgv_plugins.Rows.Clear()
        InstalledPlugins.Reload()
    End Sub

    Private Sub InstalledPlugins_PluginFound(InstalledPlugin As InstalledPlugin) Handles InstalledPlugins.PluginFound
        With InstalledPlugin
            If dgv_mods.InvokeRequired Then
                dgv_mods.Invoke(Sub()
                                    dgv_plugins.Rows.Add(.Active, .Name)
                                End Sub)
            Else
                dgv_plugins.Rows.Add(.Active, .Name)
            End If
        End With
    End Sub

    ' ##### PLUGIN CONTROLS ############################################################################################################

    Private Sub dgv_plugins_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgv_plugins.RowStateChanged
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
                If e.Row.Index = dgv_plugins.Rows.Count - 1 Then
                    btn_down.Enabled = False
                Else
                    btn_down.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub dgv_plugins_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_plugins.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dgv_plugins.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub dgv_plugins_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_plugins.CellDoubleClick
        If dgv_plugins.SelectedRows.Count > 0 Then
            dgv_plugins.SelectedRows(0).Cells("esp_active").Value = _
                Not dgv_plugins.SelectedRows(0).Cells("esp_active").Value
        End If
    End Sub

    Private Sub btn_up_Click(sender As Object, e As EventArgs) Handles btn_up.Click
        If dgv_plugins.SelectedRows.Count > 0 Then
            Dim Index As Integer = dgv_plugins.SelectedRows(0).Index
            If Index > 1 Then
                For i = 0 To dgv_plugins.Columns.Count - 1
                    Dim val As Object = dgv_plugins.Rows(Index - 1).Cells(i).Value
                    dgv_plugins.Rows(Index - 1).Cells(i).Value = dgv_plugins.Rows(Index).Cells(i).Value
                    dgv_plugins.Rows(Index).Cells(i).Value = val
                Next
                dgv_plugins.Rows(Index - 1).Selected = True
            End If
        End If
    End Sub

    Private Sub btn_down_Click(sender As Object, e As EventArgs) Handles btn_down.Click
        If dgv_plugins.SelectedRows.Count > 0 Then
            Dim Index As Integer = dgv_plugins.SelectedRows(0).Index
            If Index > 0 And Index < dgv_plugins.Rows.Count - 1 Then
                For i = 0 To dgv_plugins.Columns.Count - 1
                    Dim val As Object = dgv_plugins.Rows(Index + 1).Cells(i).Value
                    dgv_plugins.Rows(Index + 1).Cells(i).Value = dgv_plugins.Rows(Index).Cells(i).Value
                    dgv_plugins.Rows(Index).Cells(i).Value = val
                Next
                dgv_plugins.Rows(Index + 1).Selected = True
            End If
        End If
    End Sub

    ' ##### ARCHIVE UPDATES ############################################################################################################

    Private Sub ReloadArchives()
        dgv_archives.Rows.Clear()
        InstalledArchives.Reload()
    End Sub

    Private Sub InstalledArchives_ArchiveFound(InstalledArchive As InstalledArchive) Handles InstalledArchives.ArchiveFound
        With InstalledArchive
            If dgv_archives.InvokeRequired Then
                dgv_archives.Invoke(Sub()
                                        dgv_archives.Rows.Add(.Active, .Name)
                                    End Sub)
            Else
                dgv_archives.Rows.Add(.Active, .Name)
            End If
        End With        
    End Sub

    ' ##### DOWNLOAD UPDATES ############################################################################################################

    Private Sub Downloads_Added(ByVal Download As ModDownload) Handles Downloads.Added
        Dim add_it As Boolean = True
        For Each Row As DataGridViewRow In dgv_downloads.Rows
            If Row.Cells("dls_path").Value = Download.Path Then
                add_it = False
                Exit For
            End If
        Next
        If add_it Then
            dgv_downloads.Rows.Add(Download.Name, "", Download.Percentage.ToString + "%", Download.Path, False)
        End If        
    End Sub

    Private Sub Downloads_Finished(ByVal Download As ModDownload) Handles Downloads.Finished
        For Each Row As DataGridViewRow In dgv_downloads.Rows
            If Row.Cells("dls_path").Value = Download.Path Then
                Row.Cells("dls_finished").Value = True
                Row.Cells("dls_speed").Value = String.Empty
                Row.Cells("dls_done").Value = "100%"
            End If
        Next
        If dgv_downloads.SelectedRows.Count > 0 Then
            dgv_downloads_select()
        End If
    End Sub

    Private Sub Downloads_Update(ByVal Download As ModDownload) Handles Downloads.Update
        For Each Row As DataGridViewRow In dgv_downloads.Rows
            If Row.Cells("dls_path").Value = Download.Path Then
                Row.Cells("dls_done").Value = Download.Percentage.ToString + "%"
                Row.Cells("dls_speed").Value = Download.Speed.ToString + " kb/s"
            End If
        Next
    End Sub

    ' ##### DOWNLOAD CONTROLS ############################################################################################################

    Private Sub dgv_downloads_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgv_downloads.RowStateChanged
        If e.StateChanged = DataGridViewElementStates.Selected Then
            dgv_downloads_select()
        End If
    End Sub

    Private Sub dgv_downloads_select()
        If dgv_downloads.SelectedRows.Count > 0 Then
            Dim ModDownload As ModDownload = Downloads.FindDownloadByName(dgv_downloads.SelectedRows(0).Cells("dls_name").Value)
            If Not IsNothing(ModDownload) Then
                If ModDownload.IsFinished Then
                    btn_dl_install.Visible = True
                    btn_pause.Visible = False
                    btn_resume.Visible = False
                Else
                    If ModDownload.IsPaused Then
                        btn_resume.Visible = True
                        btn_pause.Visible = False
                    Else
                        btn_resume.Visible = False
                        btn_pause.Visible = True
                    End If
                    btn_dl_install.Visible = False
                End If
            End If
            btn_dl_delete.Visible = True
        Else
            btn_dl_install.Visible = False
            btn_dl_delete.Visible = False
            btn_pause.Visible = False
            btn_resume.Visible = False
        End If
    End Sub

    Private Sub DownloadInstall()
        If dgv_downloads.SelectedRows.Count > 0 Then
            Dim ModDownload As ModDownload = Downloads.FindDownloadByName(dgv_downloads.SelectedRows(0).Cells("dls_name").Value)
            If Not IsNothing(ModDownload) Then
                If ModDownload.Install() Then
                    'Update
                    ReloadMods()
                End If                
            End If
        End If
    End Sub

    Private Sub DownloadTogglePause()
        If dgv_downloads.SelectedRows.Count > 0 Then
            Dim ModDownload As ModDownload = Downloads.FindDownloadByName(dgv_downloads.SelectedRows(0).Cells("dls_name").Value)
            If Not IsNothing(ModDownload) Then
                ModDownload.TogglePause()
                dgv_downloads_select()
            End If
        End If
    End Sub

    Private Sub DownloadDelete()
        If dgv_downloads.SelectedRows.Count > 0 Then
            Dim ModDownload As ModDownload = Downloads.FindDownloadByName(dgv_downloads.SelectedRows(0).Cells("dls_name").Value)
            If Not IsNothing(ModDownload) Then
                ModDownload.Delete()
                dgv_downloads.Rows.Remove(dgv_downloads.SelectedRows(0))
            End If
        End If
    End Sub

    Private Sub btn_dl_install_Click_1(sender As Object, e As EventArgs) Handles btn_dl_install.Click
        DownloadInstall()
    End Sub

    Private Sub dgv_downloads_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_downloads.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim ModDownload As ModDownload = Downloads.FindDownloadByName(dgv_downloads.Rows(e.RowIndex).Cells("dls_name").Value)
            If Not IsNothing(ModDownload) Then
                If ModDownload.Install() Then
                    'Update
                    ReloadMods()
                End If
            End If
        End If        
    End Sub

    Private Sub btn_dl_delete_Click(sender As Object, e As EventArgs) Handles btn_dl_delete.Click
        DownloadDelete()
    End Sub

    Private Sub btn_pause_Click(sender As Object, e As EventArgs) Handles btn_pause.Click
        DownloadTogglePause()
    End Sub

    ' ##### DOWNLOAD CONTEXTMENU ############################################################################################################

    Private Sub InstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallToolStripMenuItem.Click
        DownloadInstall()
    End Sub

    Private Sub dgv_downloads_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_downloads.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dgv_downloads.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub dls_context_Opening(sender As Object, e As CancelEventArgs) Handles dls_context.Opening
        If dgv_downloads.SelectedRows.Count > 0 Then
            Dim ModDownload As ModDownload = Downloads.FindDownloadByName(dgv_downloads.SelectedRows(0).Cells("dls_name").Value)
            If Not IsNothing(ModDownload) Then
                If ModDownload.IsFinished Then
                    PauseToolStripMenuItem.Visible = False
                    ResumeToolStripMenuItem.Visible = False
                    InstallToolStripMenuItem.Visible = True
                Else
                    If ModDownload.IsPaused Then
                        ResumeToolStripMenuItem.Visible = True
                        PauseToolStripMenuItem.Visible = False
                    Else
                        ResumeToolStripMenuItem.Visible = False
                        PauseToolStripMenuItem.Visible = True
                    End If
                    InstallToolStripMenuItem.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub PauseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PauseToolStripMenuItem.Click
        DownloadTogglePause()
    End Sub

    Private Sub ResumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumeToolStripMenuItem.Click
        DownloadTogglePause()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        DownloadDelete()
    End Sub

End Class
