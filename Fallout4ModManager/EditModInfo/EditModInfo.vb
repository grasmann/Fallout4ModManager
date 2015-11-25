Public Class EditModInfo

    Private _installedmod As InstalledMod

    Public Sub New(ByVal InstalledMod As InstalledMod)
        InitializeComponent()
        _installedmod = InstalledMod
    End Sub

    Private Sub EditModInfo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            Dim xmldoc As New Xml.XmlDocument
            Dim node As Xml.XmlNode
            xmldoc.Load(Directories.ModCache + "/" + _installedmod.Info)
            node = xmldoc.GetElementsByTagName("Info")(0)
            TextBox1.Text = node.Attributes("Name").Value
            TextBox2.Text = node.Attributes("Version").Value
            TextBox3.Text = node.Attributes("ID").Value
            If Not node.Attributes.ItemOf("Category") Is Nothing Then
                txt_category.Text = node.Attributes("Category").Value
            End If            
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.OK
        'Dim Path As String = String.Empty
        'Dim xmldoc As New Xml.XmlDocument
        'Dim node As Xml.XmlNode

        Dim Name As String
        Dim ID As Integer
        Dim Version As String
        Dim Category As String

        Try            
            ID = Val(TextBox3.Text)
        Catch ex As Exception
            MsgBox("The mod ID has to be a number.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End Try
        Name = TextBox1.Text
        Version = TextBox2.Text
        Category = txt_category.Text

        '' Edit modcache file
        'Path = Directories.ModCache + "/" + _installedmod.Info
        'xmldoc.Load(Path)
        'node = xmldoc.GetElementsByTagName("Info")(0)
        'node.Attributes("Name").Value = Name
        'node.Attributes("Version").Value = Version
        'node.Attributes("ID").Value = ID.ToString
        'node.Attributes("Category").Value = Category
        'xmldoc.Save(Path)
        '' Edit mod file
        'Path = Directories.Mods + "/" + _installedmod.Info
        'If My.Computer.FileSystem.FileExists(Path) Then
        '    xmldoc.Load(Path)
        '    node = xmldoc.GetElementsByTagName("Info")(0)
        '    node.Attributes("Name").Value = Name
        '    node.Attributes("Version").Value = Version
        '    node.Attributes("ID").Value = ID.ToString
        '    node.Attributes("Category").Value = Category
        '    xmldoc.Save(Path)
        'End If

        _installedmod.UpdateInfoFiles(Name, ID, Version, Category)
        '' Mod values
        '_installedmod.UpdateInfo(Name, ID, Version, Category)

    End Sub

    Private Sub EditModInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = System.Drawing.Icon.FromHandle(My.Resources.info.GetHicon)
    End Sub

End Class