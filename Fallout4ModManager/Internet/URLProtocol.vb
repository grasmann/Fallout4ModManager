Imports Microsoft.Win32

Module URLProtocol

    Public Sub Register()
        Try
            Dim Key As RegistryKey = Registry.ClassesRoot.OpenSubKey("nxm")
            If Not IsNothing(Key) Then
                Dim icon As RegistryKey = Key.OpenSubKey("DefaultIcon", True)
                icon.SetValue("", Application.ExecutablePath + ",0")
                Dim command As RegistryKey = Key.OpenSubKey("shell\open\command", True)
                command.SetValue("", """" + Application.ExecutablePath + """" + """%1""")
            Else
                Dim nxm As RegistryKey = Registry.ClassesRoot.CreateSubKey("nxm")
                nxm.SetValue("", "URL:Nexus Mod")
                nxm.SetValue("URL Protocol", "")
                Dim icon As RegistryKey = nxm.CreateSubKey("DefaultIcon")
                icon.SetValue("", Application.ExecutablePath + ",0")
                Dim shell As RegistryKey = nxm.CreateSubKey("shell")
                Dim open As RegistryKey = shell.CreateSubKey("open")
                Dim command As RegistryKey = open.CreateSubKey("command")
                command.SetValue("", """" + Application.ExecutablePath + """" + """%1""")
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

End Module
