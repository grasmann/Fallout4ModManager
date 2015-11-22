<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.lbl_madeby = New System.Windows.Forms.Label()
        Me.lnk_me = New System.Windows.Forms.LinkLabel()
        Me.lbl_update = New System.Windows.Forms.Label()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.Location = New System.Drawing.Point(193, 12)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(334, 33)
        Me.lbl_title.TabIndex = 1
        Me.lbl_title.Text = "Fallout 4 Mod Manager"
        '
        'lbl_version
        '
        Me.lbl_version.AutoSize = True
        Me.lbl_version.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_version.Location = New System.Drawing.Point(194, 45)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(65, 25)
        Me.lbl_version.TabIndex = 2
        Me.lbl_version.Text = "1.0.2"
        '
        'lbl_madeby
        '
        Me.lbl_madeby.AutoSize = True
        Me.lbl_madeby.Location = New System.Drawing.Point(420, 142)
        Me.lbl_madeby.Name = "lbl_madeby"
        Me.lbl_madeby.Size = New System.Drawing.Size(48, 13)
        Me.lbl_madeby.TabIndex = 3
        Me.lbl_madeby.Text = "Made by"
        '
        'lnk_me
        '
        Me.lnk_me.AutoSize = True
        Me.lnk_me.LinkArea = New System.Windows.Forms.LinkArea(0, 8)
        Me.lnk_me.Location = New System.Drawing.Point(474, 142)
        Me.lnk_me.Name = "lnk_me"
        Me.lnk_me.Size = New System.Drawing.Size(53, 13)
        Me.lnk_me.TabIndex = 4
        Me.lnk_me.TabStop = True
        Me.lnk_me.Text = "grasmann"
        '
        'lbl_update
        '
        Me.lbl_update.AutoSize = True
        Me.lbl_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_update.Location = New System.Drawing.Point(244, 93)
        Me.lbl_update.Name = "lbl_update"
        Me.lbl_update.Size = New System.Drawing.Size(185, 20)
        Me.lbl_update.TabIndex = 5
        Me.lbl_update.Text = "An update is available"
        '
        'btn_update
        '
        Me.btn_update.Image = Global.Fallout4ModManager.My.Resources.Resources.download
        Me.btn_update.Location = New System.Drawing.Point(435, 84)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(92, 36)
        Me.btn_update.TabIndex = 6
        Me.btn_update.Text = "Download"
        Me.btn_update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Fallout4ModManager.My.Resources.Resources.Raoul_duke
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 143)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 174)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.lbl_update)
        Me.Controls.Add(Me.lnk_me)
        Me.Controls.Add(Me.lbl_madeby)
        Me.Controls.Add(Me.lbl_version)
        Me.Controls.Add(Me.lbl_title)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents lbl_version As System.Windows.Forms.Label
    Friend WithEvents lbl_madeby As System.Windows.Forms.Label
    Friend WithEvents lnk_me As System.Windows.Forms.LinkLabel
    Friend WithEvents lbl_update As System.Windows.Forms.Label
    Friend WithEvents btn_update As System.Windows.Forms.Button
End Class
