Imports System.Xml
Imports System.ComponentModel

Public Class InstalledMods
    Inherits List(Of InstalledMod)

    Private WithEvents mod_solver As ModSolver

    Public Event ModFound(ByVal InstalledMod As InstalledMod)
    Public Event ModChanged(ByVal InstalledMod As InstalledMod)
    Public Event ModUpdated(ByVal InstalledMod As InstalledMod)
    Public Event ModUninstalled(ByVal InstalledMod As InstalledMod)
    Public Event UpdateFound(ByVal InstalledMod As InstalledMod)

    ' ##### FUNCTIONS ##########################################################################################

    Public Function InstallMod(ByVal Archive As String) As Windows.Forms.DialogResult
        mod_solver = New ModSolver(Archive)
        Return mod_solver.ShowDialog()
    End Function

    Private Sub mod_solver_ModInstalled(InstalledMod As InstalledMod) Handles mod_solver.ModInstalled
        AddMod(InstalledMod)
    End Sub

    Public Sub AddMod(ByVal InstalledMod As InstalledMod)
        Me.Add(InstalledMod)
        AddHandler InstalledMod.UpdateFound, AddressOf ModUpdateFound
        AddHandler InstalledMod.Changed, AddressOf ModWasChanged
        AddHandler InstalledMod.Uninstalled, AddressOf ModWasUninstalled
        AddHandler InstalledMod.Update, AddressOf ModWasUpdated
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
        Me.Remove(InstalledMod)
    End Sub

    Private Sub ModWasUpdated(ByVal InstalledMod As InstalledMod)
        RaiseEvent ModUpdated(InstalledMod)
    End Sub

    ' ##### LOAD ##########################################################################################

    Private Sub LoadMods()
        Dim modfile As XmlDocument
        Dim node As XmlNode
        Dim Name As String
        Dim Category As String = String.Empty
        Dim Hash As String = String.Empty
        Dim Version As String
        Dim ID As String
        Dim Active As Boolean
        Dim InstalledMod As InstalledMod
        ' Installed Mods
        Dim ActiveMods As List(Of String) = Files.FindActiveMods
        Dim InstalledMods As List(Of String) = Files.InstalledMods
        For Each InsMod As String In InstalledMods
            Category = String.Empty
            Try
                ' Open xml
                modfile = New XmlDocument
                modfile.Load(Directories.ModCache + "/" + InsMod)
                ' Read
                node = modfile.GetElementsByTagName("Info")(0)
                Name = node.Attributes("Name").Value
                If Not node.Attributes.ItemOf("Category") Is Nothing Then
                    Category = node.Attributes("Category").Value
                End If
                If node.Attributes.ItemOf("Hash") Is Nothing Then
                    Hash = Fallout4ModManager.InstalledMods.NewHash
                    Dim attr As XmlAttribute = modfile.CreateAttribute("Hash")
                    attr.Value = Hash
                    node.Attributes.Append(attr)
                    modfile.Save(Directories.ModCache + "/" + InsMod)
                    modfile.Load(Directories.ModCache + "/" + InsMod)
                Else
                    Hash = node.Attributes("Hash").Value
                End If
                Version = node.Attributes("Version").Value
                ID = node.Attributes("ID").Value
                Active = ActiveMods.Contains(InsMod)
                ' Add
                InstalledMod = New InstalledMod(Name, ID, Version, Active, InsMod, , Category, Hash)
                AddHandler InstalledMod.UpdateFound, AddressOf ModUpdateFound
                AddHandler InstalledMod.Changed, AddressOf ModWasChanged
                AddHandler InstalledMod.Uninstalled, AddressOf ModWasUninstalled
                AddHandler InstalledMod.Update, AddressOf ModWasUpdated
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

    Public Shared Function NewHash() As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As String = String.Empty
        For i As Integer = 1 To 32
            Dim idx As Integer = r.Next(0, 35)
            sb += s.Substring(idx, 1)
        Next
        Return sb.ToString()
    End Function

End Class
