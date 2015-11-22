Public Class About

    ' ##### INIT ####################################################################################

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = System.Drawing.Icon.FromHandle(My.Resources.info.GetHicon)
        lbl_version.Text = Fallout4ModManager.Update.Version
        If UpdateAvailable Then
            lbl_update.Visible = True
            btn_update.Visible = True
        Else
            lbl_update.Visible = False
            btn_update.Visible = False
        End If
    End Sub

    ' ##### BUTTONS #################################################################################

    Private Sub lnk_me_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_me.LinkClicked
        Process.Start("http://www.nexusmods.com/fallout4/users/127805/?")
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Process.Start("http://www.nexusmods.com/fallout4/mods/495")
    End Sub

End Class