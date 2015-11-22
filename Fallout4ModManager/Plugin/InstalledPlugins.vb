Imports System.ComponentModel

Public Class InstalledPlugins
    Inherits List(Of InstalledPlugin)

    Private _readonly_plugins() As String = {"fallout4.esm"}

    Public Event PluginFound(ByVal InstalledPlugin As InstalledPlugin)

    Public Sub Reload()
        Me.Clear()
        LoadPlugins()
    End Sub

    Private Sub LoadPlugins()
        Dim Plugins As List(Of String) = Files.FindPlugins
        Dim ActivePlugins As List(Of String) = Files.GetActivePlugins
        Dim Name As String
        Dim Read_Only As Boolean
        Dim InstalledPlugin As InstalledPlugin
        ' Iterate Active
        For Each Esp As String In ActivePlugins
            If EspsContain(Plugins, Esp) Or Esp.ToLower = "fallout4.esm" Then
                Name = Esp.Filename
                Read_Only = _readonly_plugins.Contains(Esp.Filename.ToLower)
                InstalledPlugin = New InstalledPlugin(Name, True, Read_Only)
                Me.Add(InstalledPlugin)
                RaiseEvent PluginFound(InstalledPlugin)
            End If
        Next
        ' Non-Active
        For Each Esp As String In Plugins
            If Not ListContains(Esp.Filename) Then
                Name = Esp.Filename
                Read_Only = _readonly_plugins.Contains(Esp.Filename.ToLower)
                InstalledPlugin = New InstalledPlugin(Name, False, Read_Only)
                Me.Add(InstalledPlugin)
                RaiseEvent PluginFound(InstalledPlugin)
            End If
        Next
    End Sub

    Private Function EspsContain(ByVal Plugins As List(Of String), ByVal Name As String) As Boolean
        For Each Plugin As String In Plugins
            If Plugin.Filename = Name Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function ListContains(ByVal Name As String) As Boolean
        For Each Plugin As InstalledPlugin In Me
            If Plugin.Name = Name Then Return True
        Next
        Return False
    End Function

End Class
