Public Class Login

    Private _user As String
    Private _password As String

    Public ReadOnly Property User As String
        Get
            Return _user
        End Get
    End Property

    Public ReadOnly Property Password As String
        Get
            Return _password
        End Get
    End Property

    Public Sub New(ByRef User As String, ByRef Password As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _user = User
        _password = Password
    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        _user = txt_user.Text
        _password = txt_password.Text
        If chk_save.Checked Then
            My.Settings.NexusUser = _user
            My.Settings.NexusPassword = _password
            My.Settings.Save()
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class