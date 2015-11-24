<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_user = New System.Windows.Forms.Label()
        Me.txt_user = New System.Windows.Forms.TextBox()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.chk_save = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lbl_user
        '
        Me.lbl_user.AutoSize = True
        Me.lbl_user.Location = New System.Drawing.Point(0, 3)
        Me.lbl_user.Name = "lbl_user"
        Me.lbl_user.Size = New System.Drawing.Size(55, 13)
        Me.lbl_user.TabIndex = 0
        Me.lbl_user.Text = "Username"
        '
        'txt_user
        '
        Me.txt_user.Location = New System.Drawing.Point(61, 0)
        Me.txt_user.Name = "txt_user"
        Me.txt_user.Size = New System.Drawing.Size(223, 20)
        Me.txt_user.TabIndex = 1
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.Location = New System.Drawing.Point(0, 25)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(53, 13)
        Me.lbl_password.TabIndex = 2
        Me.lbl_password.Text = "Password"
        '
        'txt_password
        '
        Me.txt_password.Location = New System.Drawing.Point(61, 22)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(223, 20)
        Me.txt_password.TabIndex = 3
        '
        'btn_login
        '
        Me.btn_login.Image = Global.Fallout4ModManager.My.Resources.Resources.internet
        Me.btn_login.Location = New System.Drawing.Point(143, 43)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(66, 36)
        Me.btn_login.TabIndex = 4
        Me.btn_login.Text = "Login"
        Me.btn_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_login.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Image = Global.Fallout4ModManager.My.Resources.Resources.deactivate
        Me.btn_cancel.Location = New System.Drawing.Point(209, 43)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 36)
        Me.btn_cancel.TabIndex = 5
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'chk_save
        '
        Me.chk_save.AutoSize = True
        Me.chk_save.Location = New System.Drawing.Point(61, 54)
        Me.chk_save.Name = "chk_save"
        Me.chk_save.Size = New System.Drawing.Size(51, 17)
        Me.chk_save.TabIndex = 6
        Me.chk_save.Text = "Save"
        Me.chk_save.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 79)
        Me.ControlBox = False
        Me.Controls.Add(Me.chk_save)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.txt_user)
        Me.Controls.Add(Me.lbl_user)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nexus Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_user As System.Windows.Forms.Label
    Friend WithEvents txt_user As System.Windows.Forms.TextBox
    Friend WithEvents lbl_password As System.Windows.Forms.Label
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents btn_login As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents chk_save As System.Windows.Forms.CheckBox
End Class
