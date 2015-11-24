Public Class OverwriteSolver

    Private overwrite_files As List(Of ExtractJob)

    Public Sub New(ByVal Files As List(Of ExtractJob), ByRef Overwrite As List(Of ExtractJob))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        overwrite_files = Overwrite
        For Each File As ExtractJob In Files
            DataGridView1.Rows.Add(True, File.ExtractPath, File.ArchivePath, File.ExtractPath, True)
        Next

    End Sub

    Private Sub OverwriteSolver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not e.CloseReason = CloseReason.UserClosing Then
            For Each Row As DataGridViewRow In DataGridView1.Rows
                If Row.Cells(0).Value Then overwrite_files.Add(New ExtractJob(Row.Cells(2).Value, Row.Cells(3).Value, Row.Cells(4).Value))
            Next
        End If        
    End Sub

    Private Sub OverwriteAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OverwriteAllToolStripMenuItem.Click
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Row.Cells(0).Value = True
        Next
    End Sub

    Private Sub BackupAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupAllToolStripMenuItem.Click
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Row.Cells(4).Value = True
        Next
    End Sub

    Private Sub OverwriteSolver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = System.Drawing.Icon.FromHandle(My.Resources.install.GetHicon)
    End Sub

    Private Sub OverwriteNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OverwriteNoneToolStripMenuItem.Click
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Row.Cells(0).Value = False
        Next
    End Sub

    Private Sub BackupNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupNoneToolStripMenuItem.Click
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Row.Cells(4).Value = False
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class