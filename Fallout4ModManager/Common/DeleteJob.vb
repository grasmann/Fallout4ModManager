Imports System.Timers

Public Class DeleteJob

    Public Enum DeleteType
        File
        Folder
    End Enum

    ' Attributes
    Private _path As String
    Private _type As DeleteType
    Private _retry As Integer
    ' Timer
    Private WithEvents _timer As Timer
    Private Const _wait As Integer = 1000
    Private Const _retries As Integer = 10

    ' ##### EVENTS ################################################################################

    Public Event Success(ByVal DeleteJob As DeleteJob)
    Public Event Failed(ByVal DeleteJob As DeleteJob)

    ' ##### CONSTRUCTOR ################################################################################

    ' Create new delete job
    Public Sub New(ByVal Path As String, ByVal Type As DeleteType)
        Log.Log(String.Format("Initializing delete job for '{0}' ...", Path))
        _path = Path
        _type = Type
        _timer = New Timer(_wait)
    End Sub

    ' ##### START DELETE PROCESS ################################################################################

    ' Start
    Public Sub Execute()
        Log.Log(String.Format("Starting delete job for '{0}' ...", _path))
        TryDelete()
        _timer.Enabled = True
    End Sub

    ' ##### DELETE PROCESS ################################################################################

    ' Timer event
    Private Sub _timer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles _timer.Elapsed
        TryDelete()
    End Sub

    ' Try to delete file
    Private Sub TryDelete()
        Try
            Log.Log(String.Format("Trying to delete '{0}' ...", _path))
            _timer.Enabled = False
            Select Case _type
                Case DeleteType.File
                    If My.Computer.FileSystem.FileExists(_path) Then
                        My.Computer.FileSystem.DeleteFile(_path)
                        RaiseEvent Success(Me)
                    End If
                Case DeleteType.Folder
                    If My.Computer.FileSystem.DirectoryExists(_path) Then
                        My.Computer.FileSystem.DeleteDirectory(_path, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        RaiseEvent Success(Me)
                    End If
            End Select
            Log.Log(String.Format("'{0}' deleted successfully.", _path))
        Catch ex As Exception
            If _retry < _retries Then
                Log.Log(String.Format("Delete job for '{0}' failed {1} time(s).", _path, _retry + 1))
                _retry += 1
                _timer.Enabled = True
                Debug.Print(ex.Message)
            Else
                MsgBox(String.Format("'{0}'{1} couldn't be deleted after 10 retries.", _path, vbCrLf), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Delete Error")
            End If
        End Try
    End Sub

End Class
