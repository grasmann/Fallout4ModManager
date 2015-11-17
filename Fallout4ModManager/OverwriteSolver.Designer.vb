<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OverwriteSolver
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.or_overwrite = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.or_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.or_extracted_path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.or_target_path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.or_backup = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.or_overwrite, Me.or_name, Me.or_extracted_path, Me.or_target_path, Me.or_backup})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(784, 429)
        Me.DataGridView1.TabIndex = 0
        '
        'or_overwrite
        '
        Me.or_overwrite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.or_overwrite.HeaderText = "Overwrite"
        Me.or_overwrite.Name = "or_overwrite"
        Me.or_overwrite.ReadOnly = True
        Me.or_overwrite.Width = 58
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
        'or_extracted_path
        '
        Me.or_extracted_path.HeaderText = "extracted_path"
        Me.or_extracted_path.Name = "or_extracted_path"
        Me.or_extracted_path.ReadOnly = True
        Me.or_extracted_path.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.or_extracted_path.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.or_extracted_path.Visible = False
        '
        'or_target_path
        '
        Me.or_target_path.HeaderText = "target_path"
        Me.or_target_path.Name = "or_target_path"
        Me.or_target_path.ReadOnly = True
        Me.or_target_path.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.or_target_path.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.or_target_path.Visible = False
        '
        'or_backup
        '
        Me.or_backup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.or_backup.HeaderText = "Create Backup"
        Me.or_backup.Name = "or_backup"
        Me.or_backup.ReadOnly = True
        Me.or_backup.Width = 84
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(-3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(787, 34)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Some files already exist." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please select files to overwrite."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Image = Global.Fallout4ModManager.My.Resources.Resources.deinstall
        Me.Button2.Location = New System.Drawing.Point(673, 468)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 36)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancel"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Image = Global.Fallout4ModManager.My.Resources.Resources.ok
        Me.Button1.Location = New System.Drawing.Point(603, 468)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 36)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Ok"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OverwriteSolver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 504)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "OverwriteSolver"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Overwrite Solver"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents or_overwrite As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents or_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents or_extracted_path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents or_target_path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents or_backup As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
