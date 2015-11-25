Public Class Options

    Private open_dialog As Boolean

    Public Sub New(Optional ByVal OpenDialog As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        open_dialog = OpenDialog

    End Sub

    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = System.Drawing.Icon.FromHandle(My.Resources.settings.GetHicon)
        TextBox1.Text = My.Settings.sResourceDataDirsFinal
        TextBox2.Text = My.Settings.InstallDir
        CheckBox1.Checked = My.Settings.SetiPresentInterval
        CheckBox2.Checked = My.Settings.CleanDirectories
        TextBox3.Text = My.Settings.NexusUser
        TextBox4.Text = My.Settings.NexusPassword
        chk_start_f4se.Checked = Not My.Settings.DontStartF4SE
        chk_ask_download_delete.Checked = Not My.Settings.DontAskDeleteDownloads
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenDialog
    End Sub

    Private Sub Options_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If String.IsNullOrEmpty(My.Settings.InstallDir) And String.IsNullOrEmpty(TextBox2.Text) Then            
            Select Case MsgBox("Please specify an install directory.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Error")
                Case MsgBoxResult.Ok
                    e.Cancel = True
                    OpenDialog()
                Case MsgBoxResult.Cancel
                    DialogResult = Windows.Forms.DialogResult.Abort
            End Select
        Else
            My.Settings.InstallDir = TextBox2.Text
            My.Settings.sResourceDataDirsFinal = TextBox1.Text
            My.Settings.SetiPresentInterval = CheckBox1.Checked
            My.Settings.CleanDirectories = CheckBox2.Checked
            My.Settings.NexusUser = TextBox3.Text
            My.Settings.NexusPassword = TextBox4.Text
            My.Settings.DontStartF4SE = Not chk_start_f4se.Checked
            My.Settings.DontAskDeleteDownloads = Not chk_ask_download_delete.Checked
            My.Settings.Save()
        End If        
    End Sub

    Private Sub Options_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If open_dialog Then OpenDialog()
    End Sub

    Private Sub OpenDialog()
        Dim folderdiag As New OpenFileDialog
        folderdiag.Filter = "Fallout4.exe(Fallout4.exe)|Fallout4.exe"
        folderdiag.InitialDirectory = TextBox2.Text
        If folderdiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = folderdiag.FileName.Folder
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Count As Integer
        Directories.DirectoryCount(Directories.Data, Count)
        ProgressBar1.Maximum = Count
        Directories.CleanDirectories(Directories.Data, ProgressBar1)
        ProgressBar1.Value = 0
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        URLProtocol.Register()
    End Sub

End Class