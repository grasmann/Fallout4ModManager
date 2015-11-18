Public Class About

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.nexusmods.com/fallout4/users/127805/?")
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = System.Drawing.Icon.FromHandle(My.Resources.info.GetHicon)
        Label2.Text = Fallout4ModManager.Update.Version
        If UpdateAvailable Then
            Label4.Visible = True
            Button1.Visible = True
        Else
            Label4.Visible = False
            Button1.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("http://www.nexusmods.com/fallout4/mods/495")
    End Sub

End Class