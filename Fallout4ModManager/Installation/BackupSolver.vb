Public Class BackupSolver

    Private restore As List(Of String)
    Private delete As List(Of String)
    Private check_for_changes As Boolean

    ' ##### INIT ####################################################################################

    Public Sub New(ByVal Backups As List(Of String), _
                   ByRef Restore As List(Of String), _
                   ByRef Delete As List(Of String))
        InitializeComponent()
        ' Link references
        Me.restore = Restore
        Me.delete = Delete
        ' list files
        For Each Backup As String In Backups
            dgv_files.Rows.Add(True, False, Backup)
        Next
        ' Check for changes
        check_for_changes = True
    End Sub

    Private Sub BackupSolver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = System.Drawing.Icon.FromHandle(My.Resources.install.GetHicon)
    End Sub

    ' ##### CLOSE ###################################################################################

    Private Sub BackupSolver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        For Each Row As DataGridViewRow In dgv_files.Rows
            If Row.Cells(0).Value Then
                restore.Add(Row.Cells(2).Value)
            Else
                delete.Add(Row.Cells(2).Value)
            End If
        Next
    End Sub

    ' ##### LIST ###################################################################################

    Private Sub dgv_files_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_files.CellContentClick
        If check_for_changes Then
            If e.ColumnIndex = 1 Then
                If Not dgv_files.Rows(e.RowIndex).Cells(1).Value Then dgv_files.Rows(e.RowIndex).Cells(0).Value = False
                If dgv_files.Rows(e.RowIndex).Cells(1).Value Then dgv_files.Rows(e.RowIndex).Cells(0).Value = True
            ElseIf e.ColumnIndex = 0 Then
                If Not dgv_files.Rows(e.RowIndex).Cells(0).Value Then dgv_files.Rows(e.RowIndex).Cells(1).Value = False
                If dgv_files.Rows(e.RowIndex).Cells(0).Value Then dgv_files.Rows(e.RowIndex).Cells(1).Value = True
            End If
        End If
    End Sub

    ' ##### CONTEXTMENU ###################################################################################

    Private Sub RestoreAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreAllToolStripMenuItem.Click
        For Each Row As DataGridViewRow In dgv_files.Rows
            Row.Cells(0).Value = True
            Row.Cells(1).Value = False
        Next
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllToolStripMenuItem.Click
        For Each Row As DataGridViewRow In dgv_files.Rows
            Row.Cells(0).Value = False
            Row.Cells(1).Value = True
        Next
    End Sub

End Class