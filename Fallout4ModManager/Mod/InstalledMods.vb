Imports System.Xml
Imports System.ComponentModel

Public Class InstalledMods
    Inherits List(Of InstalledMod)

    Public Event ModFound(ByVal InstalledMod As InstalledMod)
    Public Event ModChanged(ByVal InstalledMod As InstalledMod)
    Public Event ModUninstalled(ByVal InstalledMod As InstalledMod)
    Public Event UpdateFound(ByVal InstalledMod As InstalledMod)

    ' ##### FUNCTIONS ##########################################################################################

    Public Sub AddMod(ByVal InstalledMod As InstalledMod)
        Me.Add(InstalledMod)
        RaiseEvent ModFound(InstalledMod)
    End Sub

    Public Function GetByInfo(ByVal Info As String) As InstalledMod
        For Each InstalledMod As InstalledMod In Me
            If InstalledMod.Info = Info Then Return InstalledMod
        Next
        Return Nothing
    End Function

    Public Sub Reload()
        Me.Clear()
        LoadMods()
    End Sub

    ' ##### EVENTS ##########################################################################################

    Private Sub ModUpdateFound(ByVal InstalledMod As InstalledMod)
        RaiseEvent UpdateFound(InstalledMod)
    End Sub

    Private Sub ModWasChanged(ByVal InstalledMod As InstalledMod)
        RaiseEvent ModChanged(InstalledMod)
    End Sub

    Private Sub ModWasUninstalled(ByVal InstalledMod As InstalledMod)
        RaiseEvent ModUninstalled(InstalledMod)
    End Sub

    ' ##### LOAD ##########################################################################################

    Private Sub LoadMods()
        Dim modfile As XmlDocument
        Dim node As XmlNode
        Dim Name As String
        Dim Version As String
        Dim ID As String
        Dim Active As Boolean
        Dim InstalledMod As InstalledMod
        ' Installed Mods
        Dim ActiveMods As List(Of String) = Files.FindActiveMods
        Dim InstalledMods As List(Of String) = Files.InstalledMods
        For Each InsMod As String In InstalledMods
            Try
                ' Open xml
                modfile = New XmlDocument
                modfile.Load(Directories.ModCache + "/" + InsMod)
                ' Read
                node = modfile.GetElementsByTagName("Info")(0)
                Name = node.Attributes("Name").Value
                Version = node.Attributes("Version").Value
                ID = node.Attributes("ID").Value
                Active = ActiveMods.Contains(InsMod)
                ' Add
                InstalledMod = New InstalledMod(Name, ID, Version, Active, InsMod)
                AddHandler InstalledMod.UpdateFound, AddressOf ModUpdateFound
                AddHandler InstalledMod.Changed, AddressOf ModWasChanged
                AddHandler InstalledMod.Uninstalled, AddressOf ModWasUninstalled
                Me.Add(InstalledMod)
                ' Event
                RaiseEvent ModFound(InstalledMod)
            Catch ex As Exception
                Debug.Print("List Mods 2: " + ex.Message)
            End Try
        Next
        ' Legacy Mods
        Dim InstalledLegacyMods As List(Of String) = Files.InstalledLegacyMods
        Dim ActiveLegacyMods As List(Of String) = Files.FindActiveLegacyMods
        For Each InsMod As String In InstalledLegacyMods
            Name = Microsoft.VisualBasic.Left(InsMod, InStrRev(InsMod, ".", Len(InsMod) - 4) - 1)
            Active = ActiveLegacyMods.Contains(InsMod)
            ' Add
            InstalledMod = New InstalledMod(Name, 0, "N/A", Active, InsMod, True)
            Me.Add(InstalledMod)
            ' Event
            RaiseEvent ModFound(InstalledMod)
        Next
    End Sub

End Class
