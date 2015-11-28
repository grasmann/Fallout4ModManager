Imports System.ComponentModel

Public Class InstalledPlugins
    Inherits List(Of InstalledPlugin)

    Private _readonly_plugins() As String = {"fallout4.esm"}
    Private _plugin_files() As String = {"*.esp", "*.esm"}

    ' ##### EVENTS #######################################################################################################################

    Public Event PluginsCleared()
    Public Event PluginFound(ByVal InstalledPlugin As InstalledPlugin)

    ' ##### LOAD #######################################################################################################################

    ' Reload plugins
    Public Sub Reload()
        Log.Log(String.Format("{0}Reloading plugins ...", vbCrLf))
        Me.Clear()
        RaiseEvent PluginsCleared()
        LoadPlugins()
    End Sub

    ' Load plugins
    Private Sub LoadPlugins()
        Log.Log("Loading plugins ...")
        Dim Plugins As List(Of String) = FindPlugins()
        Dim ActivePlugins As List(Of String) = FindActivePlugins()
        ' Iterate Active
        For Each Plugin As String In ActivePlugins
            If Plugins.Contains(Plugin) Or Plugin.ToLower = "fallout4.esm" Then
                LoadPlugin(Plugin.Filename, True)
            End If
        Next
        ' Non-Active
        For Each Plugin As String In Plugins
            If Not ListContains(Plugin.Filename) Then
                LoadPlugin(Plugin.Filename, False)
            End If
        Next
        Log.Log(String.Format("Plugins loaded. {0} total; {1} active.", Plugins.Count, ActivePlugins.Count, vbCrLf))
    End Sub

    ' Load plugin
    Private Sub LoadPlugin(ByVal Name As String, ByVal Active As Boolean)
        Dim InstalledPlugin As New InstalledPlugin(Name, True, _readonly_plugins.Contains(Name.ToLower))
        Me.Add(InstalledPlugin)
        RaiseEvent PluginFound(InstalledPlugin)
    End Sub

    ' ##### FILES #######################################################################################################################

    ' Find plugins
    Public Function FindPlugins() As List(Of String)
        Log.Log("Searching for plugins ...")
        Dim Plugins As New List(Of String)
        Dim Files As List(Of String) = _
            My.Computer.FileSystem.GetFiles(Directories.Data, _
                                            FileIO.SearchOption.SearchTopLevelOnly, _
                                            _plugin_files).ToList
        For Each Plugin As String In Files
            Plugins.Add(Plugin)
        Next
        Log.Log(String.Format("{0} plugins found.", Plugins.Count))
        Return Plugins
    End Function

    ' Get active plugins
    Public Function FindActivePlugins() As List(Of String)
        Log.Log("Searching for active plugins ...")
        Dim Plugins As New List(Of String)
        If Files.Exists(Files.Pluginstxt) = True Then
            Using reader As New System.IO.StreamReader(Files.Pluginstxt)
                While Not reader.EndOfStream
                    Dim Plugin As String = reader.ReadLine
                    If Not Left(Plugin, 1) = "#" Then Plugins.Add(Plugin)
                End While
                reader.Close()
            End Using
        End If
        Log.Log(String.Format("{0} active plugins found.", Plugins.Count))
        Return Plugins
    End Function

    ' ##### HELP #######################################################################################################################

    ' Contains name
    Private Function ListContains(ByVal Name As String) As Boolean
        For Each Plugin As InstalledPlugin In Me
            If Plugin.Name = Name Then Return True
        Next
        Return False
    End Function

End Class
