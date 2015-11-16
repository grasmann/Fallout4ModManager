Imports SevenZip

Public Class Manager

    Private Const sResourceDataDirsFinal_Default As String = "STRINGS\, TEXTURES\, INTERFACE\, SOUND\, MUSIC\, VIDEO\, MESHES\, PROGRAMS\, MATERIALS\, LODSETTINGS\, VIS\, MISC\, SCRIPTS\, SHADERSFX\"

    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Environment.Is64BitProcess Then
            SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\7z64.dll")
        Else
            SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\7z.dll")
        End If

        UpdateUI()

        ' sResourceDataDirsFinal
        If String.IsNullOrEmpty(My.Settings.sResourceDataDirsFinal) Then My.Settings.sResourceDataDirsFinal = sResourceDataDirsFinal_Default
        TextBox1.Text = My.Settings.sResourceDataDirsFinal

        ' iPresentInterval
        CheckBox1.Checked = My.Settings.SetiPresentInterval

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
        Dim Esps As List(Of String) = Files.Find(Dir)
        Dim Active As List(Of String) = Files.GetActivePlugins

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

        DataGridView2.Rows.Clear()
        Dim InstalledMods As List(Of String) = Files.InstalledMods
        For Each InsMod As String In InstalledMods
            Dim Name As String = Microsoft.VisualBasic.Left(InsMod, InStrRev(InsMod, ".", Len(InsMod) - 4) - 1)
            DataGridView2.Rows.Add(Name, InsMod)
        Next

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
        Files.EditFalloutINI(TextBox1.Text)
        ' Edit Fallout4Prefs.ini
        Files.EditFalloutPrefsINI()
        ' Save sResourceDataDirsFinal
        My.Settings.sResourceDataDirsFinal = TextBox1.Text
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
                Dim solve As New ModSolver
                solve.Data(openFileDialog1.FileName)
                solve.ShowDialog()
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
        UpdateUI()
    End Sub

    Private Sub btn_deinstall_Click(sender As Object, e As EventArgs) Handles btn_deinstall.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            If MsgBox("Do you really want to uninstall the mod" + vbCrLf + """" + DataGridView2.SelectedRows(0).Cells(0).Value + """?",
                      MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Uninstall?") = MsgBoxResult.Yes Then
                Files.DeinstallMod(DataGridView2.SelectedRows(0).Cells("mod_txt").Value)
                UpdateUI()
            End If
        End If
    End Sub

    Private Sub Manager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Save()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = sResourceDataDirsFinal_Default
    End Sub

    Private Sub btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click
        Dim about As New About
        about.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.SetiPresentInterval = CheckBox1.Checked
    End Sub

End Class
