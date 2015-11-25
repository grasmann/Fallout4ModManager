Imports System.Timers

Public Class DeleteJob

    Public Enum DeleteType
        File
        Folder
    End Enum

    Private _path As String
    Private _type As DeleteType
    Private _retry As Integer

    Private WithEvents _timer As Timer

    Private Const _wait As Integer = 1000
    Private Const _retries As Integer = 10

    Public Event Succuss(ByVal DeleteJob As DeleteJob)
    Public Event Failed(ByVal DeleteJob As DeleteJob)

    Public Sub New(ByVal Path As String, ByVal Type As DeleteType)
        _path = Path
        _type = Type
        _timer = New Timer(_wait)        
    End Sub

    Public Sub Execute()
        TryDelete()
        _timer.Enabled = True
    End Sub

    Private Sub TryDelete()
        Try
            _timer.Enabled = False
            Select Case _type
                Case DeleteType.File
                    If My.Computer.FileSystem.FileExists(_path) Then
                        My.Computer.FileSystem.DeleteFile(_path)
                        RaiseEvent Succuss(Me)
                    End If
                Case DeleteType.Folder
                    If My.Computer.FileSystem.DirectoryExists(_path) Then
                        My.Computer.FileSystem.DeleteDirectory(_path, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        RaiseEvent Succuss(Me)
                    End If
            End Select
        Catch ex As Exception
            If _retry < _retries Then
                _retry += 1
                _timer.Enabled = True
                Debug.Print(ex.Message)
            Else
                MsgBox("""" + _path + vbCrLf + " couldn't be deleted after 10 retries.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Delete Error")
            End If
        End Try
    End Sub

    Private Sub _timer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles _timer.Elapsed
        TryDelete()
    End Sub

End Class
