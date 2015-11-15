Public Class BackupSolver

    Private restore As List(Of String)
    Private delete As List(Of String)
    Private check_for_changes As Boolean

    Public Sub New(ByVal Backups As List(Of String), ByRef Restore As List(Of String), ByRef Delete As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.restore = Restore
        Me.delete = Delete

        For Each Backup As String In Backups
            DataGridView1.Rows.Add(True, False, Backup)
        Next

        check_for_changes = True

    End Sub

    Private Sub BackupSolver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        For Each Row As DataGridViewRow In DataGridView1.Rows
            If Row.Cells(0).Value Then
                restore.Add(Row.Cells(2).Value)
            Else
                delete.Add(Row.Cells(2).Value)
            End If
        Next
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If check_for_changes Then
            If e.ColumnIndex = 1 Then
                If Not DataGridView1.Rows(e.RowIndex).Cells(1).Value Then DataGridView1.Rows(e.RowIndex).Cells(0).Value = False
                If DataGridView1.Rows(e.RowIndex).Cells(1).Value Then DataGridView1.Rows(e.RowIndex).Cells(0).Value = True
            ElseIf e.ColumnIndex = 0 Then
                If Not DataGridView1.Rows(e.RowIndex).Cells(0).Value Then DataGridView1.Rows(e.RowIndex).Cells(1).Value = False
                If DataGridView1.Rows(e.RowIndex).Cells(0).Value Then DataGridView1.Rows(e.RowIndex).Cells(1).Value = True
            End If
        End If
    End Sub

End Class