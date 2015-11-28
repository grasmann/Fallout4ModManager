Public Module DeleteJobs

    ' List of delete jobs
    Private _jobs As New List(Of DeleteJob)

    ' ##### START DELETE PROCESS ################################################################################

    ' Delete a file
    Public Sub DeleteFile(ByVal Path As String)
        Dim Job As New DeleteJob(Path, DeleteJob.DeleteType.File)
        AddHandler Job.Success, AddressOf Deleted
        _jobs.Add(Job)
        Job.Execute()
    End Sub

    ' Delete a folder
    Public Sub DeleteDirectory(ByVal Path As String)
        Dim Job As New DeleteJob(Path, DeleteJob.DeleteType.Folder)
        AddHandler Job.Success, AddressOf Failed
        _jobs.Add(Job)
        Job.Execute()
    End Sub

    ' ##### DELETE FEEDBACK ################################################################################

    ' Delete job was successful
    Private Sub Deleted(ByVal DeleteJob As DeleteJob)
        _jobs.Remove(DeleteJob)
    End Sub

    ' Delete job failed
    Private Sub Failed(ByVal DeleteJob As DeleteJob)
        _jobs.Remove(DeleteJob)
    End Sub

End Module
