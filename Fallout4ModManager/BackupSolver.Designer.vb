<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackupSolver
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbl_info = New System.Windows.Forms.Label()
        Me.dgv_files = New System.Windows.Forms.DataGridView()
        Me.or_restore = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.or_delete = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.or_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestoreAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ok = New System.Windows.Forms.Button()
        CType(Me.dgv_files, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_info
        '
        Me.lbl_info.Location = New System.Drawing.Point(0, 0)
        Me.lbl_info.Name = "lbl_info"
        Me.lbl_info.Size = New System.Drawing.Size(712, 34)
        Me.lbl_info.TabIndex = 0
        Me.lbl_info.Text = "Backup files were found." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select the ones you want to restore."
        Me.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv_files
        '
        Me.dgv_files.AllowUserToAddRows = False
        Me.dgv_files.AllowUserToDeleteRows = False
        Me.dgv_files.AllowUserToResizeRows = False
        Me.dgv_files.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_files.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgv_files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_files.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.or_restore, Me.or_delete, Me.or_name})
        Me.dgv_files.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv_files.Location = New System.Drawing.Point(0, 37)
        Me.dgv_files.MultiSelect = False
        Me.dgv_files.Name = "dgv_files"
        Me.dgv_files.RowHeadersVisible = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_files.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_files.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.dgv_files.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_files.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgv_files.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_files.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_files.Size = New System.Drawing.Size(712, 421)
        Me.dgv_files.TabIndex = 1
        '
        'or_restore
        '
        Me.or_restore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.or_restore.HeaderText = "Restore"
        Me.or_restore.Name = "or_restore"
        Me.or_restore.Width = 50
        '
        'or_delete
        '
        Me.or_delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.or_delete.HeaderText = "Delete"
        Me.or_delete.Name = "or_delete"
        Me.or_delete.Width = 44
        '
        'or_name
        '
        Me.or_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.or_name.HeaderText = "File"
        Me.or_name.Name = "or_name"
        Me.or_name.ReadOnly = True
        Me.or_name.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.or_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestoreAllToolStripMenuItem, Me.DeleteAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 48)
        '
        'RestoreAllToolStripMenuItem
        '
        Me.RestoreAllToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.ok
        Me.RestoreAllToolStripMenuItem.Name = "RestoreAllToolStripMenuItem"
        Me.RestoreAllToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.RestoreAllToolStripMenuItem.Text = "Restore All"
        '
        'DeleteAllToolStripMenuItem
        '
        Me.DeleteAllToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.deinstall
        Me.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem"
        Me.DeleteAllToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.DeleteAllToolStripMenuItem.Text = "Delete All"
        '
        'btn_ok
        '
        Me.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_ok.Image = Global.Fallout4ModManager.My.Resources.Resources.ok
        Me.btn_ok.Location = New System.Drawing.Point(637, 459)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(75, 36)
        Me.btn_ok.TabIndex = 2
        Me.btn_ok.Text = "Ok"
        Me.btn_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'BackupSolver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 495)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.dgv_files)
        Me.Controls.Add(Me.lbl_info)
        Me.Name = "BackupSolver"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Backup Solver"
        CType(Me.dgv_files, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_info As System.Windows.Forms.Label
    Friend WithEvents dgv_files As System.Windows.Forms.DataGridView
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents or_restore As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents or_delete As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents or_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestoreAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
