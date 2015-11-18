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

End Class