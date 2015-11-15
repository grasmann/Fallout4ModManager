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

End Class