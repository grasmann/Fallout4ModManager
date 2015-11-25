Public Module DeleteJobs

    Private _jobs As New List(Of DeleteJob)

    Public Sub DeleteFile(ByVal Path As String)
        Dim Job As New DeleteJob(Path, DeleteJob.DeleteType.File)
        AddHandler Job.Succuss, AddressOf Deleted
        _jobs.Add(Job)
        Job.Execute()
    End Sub

    Public Sub DeleteDirectory(ByVal Path As String)
        Dim Job As New DeleteJob(Path, DeleteJob.DeleteType.Folder)
        AddHandler Job.Succuss, AddressOf Failed
        _jobs.Add(Job)
        Job.Execute()
    End Sub

    Private Sub Deleted(ByVal DeleteJob As DeleteJob)
        _jobs.Remove(DeleteJob)
    End Sub

    Private Sub Failed(ByVal DeleteJob As DeleteJob)
        _jobs.Remove(DeleteJob)
    End Sub

End Module
