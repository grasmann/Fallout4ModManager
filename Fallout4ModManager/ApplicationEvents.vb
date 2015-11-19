Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            Fallout4ModManager.Log.CloseWriter()
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            If e.CommandLine.Count > 0 Then
                ProcessCommandLine(e.CommandLine.ToList)
            End If
        End Sub

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            If e.CommandLine.Count > 0 Then
                ProcessCommandLine(e.CommandLine.ToList)
            End If
        End Sub

        Private Sub ProcessCommandLine(ByVal CommandLine As List(Of String))
            If CommandLine.Count > 0 Then
                If My.Computer.FileSystem.FileExists(CommandLine(0)) Then
                    If Files.ValidExtension(CommandLine(0)) Then
                        Dim solve As New ModSolver(CommandLine(0))
                        solve.ShowDialog()
                    End If
                Else
                    If Left(CommandLine(0), 4) = "nxm:" Then
                        'Debug.Print("http://www.nexusmods.com/fallout4/download/" + CommandLine(0).Filename)
                        'Manager._downloads.Downloads.Add(New ModDownload(CommandLine(0)))
                        Manager.Downloads.AddDownload(New ModDownload(CommandLine(0)))
                    Else
                        If CommandLine(0) = "-log" Then
                            Manager.CreateLog = True
                        End If
                    End If
                End If
            End If
        End Sub
    End Class

End Namespace

