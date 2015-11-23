<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModSolver
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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node1")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node4")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node3", New System.Windows.Forms.TreeNode() {TreeNode7})
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node2", New System.Windows.Forms.TreeNode() {TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Data", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode9})
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.lbl_status_bad = New System.Windows.Forms.Label()
        Me.lbl_status_good = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_install = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.Location = New System.Drawing.Point(1, 36)
        Me.TreeView1.Name = "TreeView1"
        TreeNode6.Name = "Node1"
        TreeNode6.Text = "Node1"
        TreeNode7.Name = "Node4"
        TreeNode7.Text = "Node4"
        TreeNode8.Name = "Node3"
        TreeNode8.Text = "Node3"
        TreeNode9.Name = "Node2"
        TreeNode9.Text = "Node2"
        TreeNode10.Name = "Node0"
        TreeNode10.Text = "Data"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode10})
        Me.TreeView1.Size = New System.Drawing.Size(560, 457)
        Me.TreeView1.TabIndex = 0
        '
        'lbl_status_bad
        '
        Me.lbl_status_bad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_status_bad.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_status_bad.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status_bad.ForeColor = System.Drawing.Color.Red
        Me.lbl_status_bad.Location = New System.Drawing.Point(0, 496)
        Me.lbl_status_bad.Name = "lbl_status_bad"
        Me.lbl_status_bad.Size = New System.Drawing.Size(550, 39)
        Me.lbl_status_bad.TabIndex = 2
        Me.lbl_status_bad.Text = "Check Structure!"
        Me.lbl_status_bad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_status_good
        '
        Me.lbl_status_good.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_status_good.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_status_good.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status_good.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_status_good.Location = New System.Drawing.Point(0, 496)
        Me.lbl_status_good.Name = "lbl_status_good"
        Me.lbl_status_good.Size = New System.Drawing.Size(550, 39)
        Me.lbl_status_good.TabIndex = 3
        Me.lbl_status_good.Text = "Looking Good!"
        Me.lbl_status_good.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(151, 1)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(344, 34)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 4
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFolderToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(135, 26)
        '
        'NewFolderToolStripMenuItem
        '
        Me.NewFolderToolStripMenuItem.Name = "NewFolderToolStripMenuItem"
        Me.NewFolderToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.NewFolderToolStripMenuItem.Text = "New Folder"
        '
        'Button1
        '
        Me.Button1.Image = Global.Fallout4ModManager.My.Resources.Resources.help
        Me.Button1.Location = New System.Drawing.Point(496, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 36)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Help"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_install
        '
        Me.btn_install.Image = Global.Fallout4ModManager.My.Resources.Resources.install
        Me.btn_install.Location = New System.Drawing.Point(0, 0)
        Me.btn_install.Name = "btn_install"
        Me.btn_install.Size = New System.Drawing.Size(75, 36)
        Me.btn_install.TabIndex = 1
        Me.btn_install.Text = "Install"
        Me.btn_install.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_install.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Image = Global.Fallout4ModManager.My.Resources.Resources.deactivate
        Me.btn_cancel.Location = New System.Drawing.Point(75, 0)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 36)
        Me.btn_cancel.TabIndex = 6
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(562, 535)
        Me.Panel1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(562, 535)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please wait while the archive is being scanned."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ModSolver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 535)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btn_install)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.lbl_status_good)
        Me.Controls.Add(Me.lbl_status_bad)
        Me.Name = "ModSolver"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mod Solver"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents btn_install As System.Windows.Forms.Button
    Friend WithEvents lbl_status_bad As System.Windows.Forms.Label
    Friend WithEvents lbl_status_good As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
