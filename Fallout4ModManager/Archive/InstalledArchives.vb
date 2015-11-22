Public Class InstalledArchives
    Inherits List(Of InstalledArchive)

    Private archives_default As New List(Of String) _
        ({"Fallout4 - Textures1.ba2", "Fallout4 - Textures2.ba2", "Fallout4 - Textures3.ba2", "Fallout4 - Textures4.ba2", "Fallout4 - Textures5.ba2", _
          "Fallout4 - Textures6.ba2", "Fallout4 - Textures7.ba2", "Fallout4 - Textures8.ba2", "Fallout4 - Textures9.ba2", "Fallout4 - Startup.ba2", _
          "Fallout4 - Shaders.ba2", "Fallout4 - Interface.ba2", "Fallout4 - Animations.ba2", "Fallout4 - Interface.ba2", "Fallout4 - Materials.ba2", _
          "Fallout4 - Meshes.ba2", "Fallout4 - MeshesExtra.ba2", "Fallout4 - Misc.ba2", "Fallout4 - Shaders.ba2", "Fallout4 - Sounds.ba2", _
          "Fallout4 - Startup.ba2", "Fallout4 - Voices.ba2"})

    Public Event ArchiveFound(ByVal InstalledArchive As InstalledArchive)

    Public Sub Reload()
        Me.Clear()
        LoadArchives()
    End Sub

    Private Sub LoadArchives()
        Dim Archives As List(Of String) = Files.FindArchives
        Dim ActiveArchvies As List(Of String) = Files.ActiveArchives
        Dim InstalledArchive As InstalledArchive
        ' Iterate
        For Each Archive As String In Archives
            If Not archives_default.Contains(Archive.Filename) Then
                InstalledArchive = New InstalledArchive(Archive.Filename, ActiveArchives.Contains(Archive.Filename))
                Me.Add(InstalledArchive)
                RaiseEvent ArchiveFound(InstalledArchive)
            End If
        Next
    End Sub

End Class
