<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manager
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manager))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.btn_down = New System.Windows.Forms.Button()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv_plugins = New System.Windows.Forms.DataGridView()
        Me.esp_active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.esp_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.esp_path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_archives = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.btn_fix_legacy = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_mods = New System.Windows.Forms.DataGridView()
        Me.mods_active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.mods_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mods_txt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mods_version = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.mods_warning = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mods_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mods_index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mods_update = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mods_context = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeactivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UninstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FixLegacyModToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_activate = New System.Windows.Forms.Button()
        Me.btn_deactivate = New System.Windows.Forms.Button()
        Me.btn_deinstall = New System.Windows.Forms.Button()
        Me.btn_dl_install = New System.Windows.Forms.Button()
        Me.btn_dl_delete = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgv_downloads = New System.Windows.Forms.DataGridView()
        Me.dls_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dls_speed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dls_done = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dls_path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dls_finished = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dls_context = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PauseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_pause = New System.Windows.Forms.Button()
        Me.btn_resume = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn_settings = New System.Windows.Forms.Button()
        Me.btn_about = New System.Windows.Forms.Button()
        Me.btn_play = New System.Windows.Forms.Button()
        Me.btn_install = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgv_plugins, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_archives, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgv_mods, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mods_context.SuspendLayout()
        CType(Me.dgv_downloads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dls_context.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 37)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(979, 472)
        Me.SplitContainer1.SplitterDistance = 439
        Me.SplitContainer1.TabIndex = 2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.btn_down)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btn_up)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgv_plugins)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgv_archives)
        Me.SplitContainer2.Size = New System.Drawing.Size(439, 472)
        Me.SplitContainer2.SplitterDistance = 335
        Me.SplitContainer2.TabIndex = 7
        '
        'btn_down
        '
        Me.btn_down.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_down.Enabled = False
        Me.btn_down.Image = Global.Fallout4ModManager.My.Resources.Resources.down
        Me.btn_down.Location = New System.Drawing.Point(400, 51)
        Me.btn_down.Name = "btn_down"
        Me.btn_down.Size = New System.Drawing.Size(36, 36)
        Me.btn_down.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btn_down, "Move down in load order")
        Me.btn_down.UseVisualStyleBackColor = True
        '
        'btn_up
        '
        Me.btn_up.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_up.Enabled = False
        Me.btn_up.Image = Global.Fallout4ModManager.My.Resources.Resources.up
        Me.btn_up.Location = New System.Drawing.Point(400, 15)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(36, 36)
        Me.btn_up.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.btn_up, "Move up in load order")
        Me.btn_up.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Plugins"
        '
        'dgv_plugins
        '
        Me.dgv_plugins.AllowUserToAddRows = False
        Me.dgv_plugins.AllowUserToDeleteRows = False
        Me.dgv_plugins.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_plugins.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_plugins.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_plugins.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgv_plugins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_plugins.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.esp_active, Me.esp_name, Me.esp_path})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.MenuText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_plugins.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_plugins.GridColor = System.Drawing.SystemColors.Control
        Me.dgv_plugins.Location = New System.Drawing.Point(0, 16)
        Me.dgv_plugins.MultiSelect = False
        Me.dgv_plugins.Name = "dgv_plugins"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_plugins.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_plugins.RowHeadersVisible = False
        Me.dgv_plugins.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.dgv_plugins.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_plugins.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgv_plugins.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_plugins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_plugins.Size = New System.Drawing.Size(400, 319)
        Me.dgv_plugins.TabIndex = 7
        '
        'esp_active
        '
        Me.esp_active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.esp_active.HeaderText = "Active"
        Me.esp_active.Name = "esp_active"
        Me.esp_active.Width = 43
        '
        'esp_name
        '
        Me.esp_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.esp_name.HeaderText = "Name"
        Me.esp_name.Name = "esp_name"
        Me.esp_name.ReadOnly = True
        Me.esp_name.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.esp_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'esp_path
        '
        Me.esp_path.HeaderText = "Path"
        Me.esp_path.Name = "esp_path"
        Me.esp_path.ReadOnly = True
        Me.esp_path.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Archives"
        '
        'dgv_archives
        '
        Me.dgv_archives.AllowUserToAddRows = False
        Me.dgv_archives.AllowUserToDeleteRows = False
        Me.dgv_archives.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_archives.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_archives.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_archives.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgv_archives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_archives.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.MenuText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_archives.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_archives.GridColor = System.Drawing.SystemColors.Control
        Me.dgv_archives.Location = New System.Drawing.Point(0, 16)
        Me.dgv_archives.MultiSelect = False
        Me.dgv_archives.Name = "dgv_archives"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_archives.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_archives.RowHeadersVisible = False
        Me.dgv_archives.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.dgv_archives.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_archives.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgv_archives.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_archives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_archives.Size = New System.Drawing.Size(439, 117)
        Me.dgv_archives.TabIndex = 6
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Active"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 43
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Path"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.btn_refresh)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btn_fix_legacy)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgv_mods)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btn_activate)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btn_deactivate)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btn_deinstall)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.btn_dl_install)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btn_dl_delete)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgv_downloads)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btn_pause)
        Me.SplitContainer3.Panel2.Controls.Add(Me.btn_resume)
        Me.SplitContainer3.Size = New System.Drawing.Size(536, 472)
        Me.SplitContainer3.SplitterDistance = 335
        Me.SplitContainer3.TabIndex = 7
        '
        'btn_refresh
        '
        Me.btn_refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refresh.Image = Global.Fallout4ModManager.My.Resources.Resources.refresh
        Me.btn_refresh.Location = New System.Drawing.Point(500, 123)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(36, 36)
        Me.btn_refresh.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btn_refresh, "Refresh mod list")
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'btn_fix_legacy
        '
        Me.btn_fix_legacy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_fix_legacy.Image = Global.Fallout4ModManager.My.Resources.Resources.clean
        Me.btn_fix_legacy.Location = New System.Drawing.Point(500, 87)
        Me.btn_fix_legacy.Name = "btn_fix_legacy"
        Me.btn_fix_legacy.Size = New System.Drawing.Size(36, 36)
        Me.btn_fix_legacy.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btn_fix_legacy, "Fix legacy mod")
        Me.btn_fix_legacy.UseVisualStyleBackColor = True
        Me.btn_fix_legacy.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Installed Mods"
        '
        'dgv_mods
        '
        Me.dgv_mods.AllowUserToAddRows = False
        Me.dgv_mods.AllowUserToDeleteRows = False
        Me.dgv_mods.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_mods.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_mods.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_mods.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgv_mods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_mods.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mods_active, Me.mods_name, Me.mods_txt, Me.mods_version, Me.mods_warning, Me.mods_id, Me.mods_index, Me.mods_update})
        Me.dgv_mods.ContextMenuStrip = Me.mods_context
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.MenuText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_mods.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_mods.GridColor = System.Drawing.SystemColors.Control
        Me.dgv_mods.Location = New System.Drawing.Point(1, 16)
        Me.dgv_mods.MultiSelect = False
        Me.dgv_mods.Name = "dgv_mods"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_mods.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgv_mods.RowHeadersVisible = False
        Me.dgv_mods.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.dgv_mods.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_mods.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgv_mods.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_mods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_mods.Size = New System.Drawing.Size(498, 319)
        Me.dgv_mods.TabIndex = 4
        '
        'mods_active
        '
        Me.mods_active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.mods_active.HeaderText = "Active"
        Me.mods_active.Name = "mods_active"
        Me.mods_active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.mods_active.Width = 62
        '
        'mods_name
        '
        Me.mods_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.mods_name.HeaderText = "Name"
        Me.mods_name.Name = "mods_name"
        Me.mods_name.ReadOnly = True
        Me.mods_name.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'mods_txt
        '
        Me.mods_txt.HeaderText = "Textfile"
        Me.mods_txt.Name = "mods_txt"
        Me.mods_txt.ReadOnly = True
        Me.mods_txt.Visible = False
        '
        'mods_version
        '
        Me.mods_version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.mods_version.HeaderText = "Version"
        Me.mods_version.Name = "mods_version"
        Me.mods_version.ReadOnly = True
        Me.mods_version.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.mods_version.Width = 67
        '
        'mods_warning
        '
        Me.mods_warning.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Red
        Me.mods_warning.DefaultCellStyle = DataGridViewCellStyle8
        Me.mods_warning.HeaderText = "Warning"
        Me.mods_warning.Name = "mods_warning"
        Me.mods_warning.ReadOnly = True
        Me.mods_warning.Visible = False
        '
        'mods_id
        '
        Me.mods_id.HeaderText = "ID"
        Me.mods_id.Name = "mods_id"
        Me.mods_id.ReadOnly = True
        Me.mods_id.Visible = False
        '
        'mods_index
        '
        Me.mods_index.HeaderText = "Index"
        Me.mods_index.Name = "mods_index"
        Me.mods_index.ReadOnly = True
        Me.mods_index.Visible = False
        '
        'mods_update
        '
        Me.mods_update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.mods_update.HeaderText = "Update"
        Me.mods_update.Name = "mods_update"
        Me.mods_update.ReadOnly = True
        Me.mods_update.Visible = False
        '
        'mods_context
        '
        Me.mods_context.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivateToolStripMenuItem, Me.DeactivateToolStripMenuItem, Me.ToolStripSeparator2, Me.UninstallToolStripMenuItem, Me.ToolStripSeparator3, Me.EditInfoToolStripMenuItem, Me.FixLegacyModToolStripMenuItem})
        Me.mods_context.Name = "mods_context"
        Me.mods_context.Size = New System.Drawing.Size(157, 126)
        '
        'ActivateToolStripMenuItem
        '
        Me.ActivateToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.ok
        Me.ActivateToolStripMenuItem.Name = "ActivateToolStripMenuItem"
        Me.ActivateToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ActivateToolStripMenuItem.Text = "Activate"
        '
        'DeactivateToolStripMenuItem
        '
        Me.DeactivateToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.deactivate
        Me.DeactivateToolStripMenuItem.Name = "DeactivateToolStripMenuItem"
        Me.DeactivateToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.DeactivateToolStripMenuItem.Text = "Deactivate"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(153, 6)
        '
        'UninstallToolStripMenuItem
        '
        Me.UninstallToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.deinstall
        Me.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem"
        Me.UninstallToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.UninstallToolStripMenuItem.Text = "Uninstall"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(153, 6)
        '
        'EditInfoToolStripMenuItem
        '
        Me.EditInfoToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.info
        Me.EditInfoToolStripMenuItem.Name = "EditInfoToolStripMenuItem"
        Me.EditInfoToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.EditInfoToolStripMenuItem.Text = "Edit Info"
        '
        'FixLegacyModToolStripMenuItem
        '
        Me.FixLegacyModToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.clean
        Me.FixLegacyModToolStripMenuItem.Name = "FixLegacyModToolStripMenuItem"
        Me.FixLegacyModToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.FixLegacyModToolStripMenuItem.Text = "Fix Legacy Mod"
        '
        'btn_activate
        '
        Me.btn_activate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_activate.Image = Global.Fallout4ModManager.My.Resources.Resources.ok
        Me.btn_activate.Location = New System.Drawing.Point(500, 15)
        Me.btn_activate.Name = "btn_activate"
        Me.btn_activate.Size = New System.Drawing.Size(36, 36)
        Me.btn_activate.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.btn_activate, "Activate mod")
        Me.btn_activate.UseVisualStyleBackColor = True
        Me.btn_activate.Visible = False
        '
        'btn_deactivate
        '
        Me.btn_deactivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_deactivate.Image = Global.Fallout4ModManager.My.Resources.Resources.deactivate
        Me.btn_deactivate.Location = New System.Drawing.Point(500, 16)
        Me.btn_deactivate.Name = "btn_deactivate"
        Me.btn_deactivate.Size = New System.Drawing.Size(36, 36)
        Me.btn_deactivate.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btn_deactivate, "Deactivate mod")
        Me.btn_deactivate.UseVisualStyleBackColor = True
        Me.btn_deactivate.Visible = False
        '
        'btn_deinstall
        '
        Me.btn_deinstall.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_deinstall.Image = Global.Fallout4ModManager.My.Resources.Resources.deinstall
        Me.btn_deinstall.Location = New System.Drawing.Point(500, 51)
        Me.btn_deinstall.Name = "btn_deinstall"
        Me.btn_deinstall.Size = New System.Drawing.Size(36, 36)
        Me.btn_deinstall.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.btn_deinstall, "Uninstall mod")
        Me.btn_deinstall.UseVisualStyleBackColor = True
        Me.btn_deinstall.Visible = False
        '
        'btn_dl_install
        '
        Me.btn_dl_install.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_dl_install.Image = Global.Fallout4ModManager.My.Resources.Resources.install
        Me.btn_dl_install.Location = New System.Drawing.Point(500, 16)
        Me.btn_dl_install.Name = "btn_dl_install"
        Me.btn_dl_install.Size = New System.Drawing.Size(36, 36)
        Me.btn_dl_install.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btn_dl_install, "Install mod")
        Me.btn_dl_install.UseVisualStyleBackColor = True
        Me.btn_dl_install.Visible = False
        '
        'btn_dl_delete
        '
        Me.btn_dl_delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_dl_delete.Image = Global.Fallout4ModManager.My.Resources.Resources.deinstall
        Me.btn_dl_delete.Location = New System.Drawing.Point(500, 88)
        Me.btn_dl_delete.Name = "btn_dl_delete"
        Me.btn_dl_delete.Size = New System.Drawing.Size(36, 36)
        Me.btn_dl_delete.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.btn_dl_delete, "Delete download")
        Me.btn_dl_delete.UseVisualStyleBackColor = True
        Me.btn_dl_delete.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Downloads"
        '
        'dgv_downloads
        '
        Me.dgv_downloads.AllowUserToAddRows = False
        Me.dgv_downloads.AllowUserToDeleteRows = False
        Me.dgv_downloads.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_downloads.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgv_downloads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_downloads.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgv_downloads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_downloads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dls_name, Me.dls_speed, Me.dls_done, Me.dls_path, Me.dls_finished})
        Me.dgv_downloads.ContextMenuStrip = Me.dls_context
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.MenuText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_downloads.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgv_downloads.GridColor = System.Drawing.SystemColors.Control
        Me.dgv_downloads.Location = New System.Drawing.Point(0, 16)
        Me.dgv_downloads.MultiSelect = False
        Me.dgv_downloads.Name = "dgv_downloads"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_downloads.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgv_downloads.RowHeadersVisible = False
        Me.dgv_downloads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.dgv_downloads.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_downloads.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgv_downloads.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgv_downloads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_downloads.Size = New System.Drawing.Size(499, 117)
        Me.dgv_downloads.TabIndex = 7
        '
        'dls_name
        '
        Me.dls_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dls_name.HeaderText = "Name"
        Me.dls_name.Name = "dls_name"
        Me.dls_name.ReadOnly = True
        Me.dls_name.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dls_speed
        '
        Me.dls_speed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dls_speed.HeaderText = "Speed"
        Me.dls_speed.Name = "dls_speed"
        Me.dls_speed.ReadOnly = True
        Me.dls_speed.Width = 63
        '
        'dls_done
        '
        Me.dls_done.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dls_done.HeaderText = "Done"
        Me.dls_done.Name = "dls_done"
        Me.dls_done.ReadOnly = True
        Me.dls_done.Width = 58
        '
        'dls_path
        '
        Me.dls_path.HeaderText = "Path"
        Me.dls_path.Name = "dls_path"
        Me.dls_path.ReadOnly = True
        Me.dls_path.Visible = False
        '
        'dls_finished
        '
        Me.dls_finished.HeaderText = "Finished"
        Me.dls_finished.Name = "dls_finished"
        Me.dls_finished.ReadOnly = True
        Me.dls_finished.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dls_finished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dls_finished.Visible = False
        '
        'dls_context
        '
        Me.dls_context.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstallToolStripMenuItem, Me.PauseToolStripMenuItem, Me.ResumeToolStripMenuItem, Me.ToolStripSeparator1, Me.DeleteToolStripMenuItem})
        Me.dls_context.Name = "dls_context"
        Me.dls_context.Size = New System.Drawing.Size(117, 98)
        '
        'InstallToolStripMenuItem
        '
        Me.InstallToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.install
        Me.InstallToolStripMenuItem.Name = "InstallToolStripMenuItem"
        Me.InstallToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.InstallToolStripMenuItem.Text = "Install"
        '
        'PauseToolStripMenuItem
        '
        Me.PauseToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.pause
        Me.PauseToolStripMenuItem.Name = "PauseToolStripMenuItem"
        Me.PauseToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.PauseToolStripMenuItem.Text = "Pause"
        '
        'ResumeToolStripMenuItem
        '
        Me.ResumeToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.play
        Me.ResumeToolStripMenuItem.Name = "ResumeToolStripMenuItem"
        Me.ResumeToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ResumeToolStripMenuItem.Text = "Resume"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(113, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.Fallout4ModManager.My.Resources.Resources.deinstall
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'btn_pause
        '
        Me.btn_pause.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_pause.Image = Global.Fallout4ModManager.My.Resources.Resources.pause
        Me.btn_pause.Location = New System.Drawing.Point(500, 52)
        Me.btn_pause.Name = "btn_pause"
        Me.btn_pause.Size = New System.Drawing.Size(36, 36)
        Me.btn_pause.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btn_pause, "Pause download")
        Me.btn_pause.UseVisualStyleBackColor = True
        Me.btn_pause.Visible = False
        '
        'btn_resume
        '
        Me.btn_resume.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_resume.Image = Global.Fallout4ModManager.My.Resources.Resources.play
        Me.btn_resume.Location = New System.Drawing.Point(500, 52)
        Me.btn_resume.Name = "btn_resume"
        Me.btn_resume.Size = New System.Drawing.Size(36, 36)
        Me.btn_resume.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btn_resume, "Resume download")
        Me.btn_resume.UseVisualStyleBackColor = True
        Me.btn_resume.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(150, 1)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(691, 34)
        Me.ProgressBar1.TabIndex = 10
        '
        'btn_settings
        '
        Me.btn_settings.Image = Global.Fallout4ModManager.My.Resources.Resources.settings
        Me.btn_settings.Location = New System.Drawing.Point(69, 0)
        Me.btn_settings.Name = "btn_settings"
        Me.btn_settings.Size = New System.Drawing.Size(80, 36)
        Me.btn_settings.TabIndex = 9
        Me.btn_settings.Text = "Settings"
        Me.btn_settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btn_settings, "Change program settings")
        Me.btn_settings.UseVisualStyleBackColor = True
        '
        'btn_about
        '
        Me.btn_about.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_about.Image = Global.Fallout4ModManager.My.Resources.Resources.info
        Me.btn_about.Location = New System.Drawing.Point(905, 0)
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(75, 36)
        Me.btn_about.TabIndex = 8
        Me.btn_about.Text = "About"
        Me.btn_about.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btn_about, "Open about dialog")
        Me.btn_about.UseVisualStyleBackColor = True
        '
        'btn_play
        '
        Me.btn_play.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_play.Image = Global.Fallout4ModManager.My.Resources.Resources.play
        Me.btn_play.Location = New System.Drawing.Point(842, 0)
        Me.btn_play.Name = "btn_play"
        Me.btn_play.Size = New System.Drawing.Size(63, 36)
        Me.btn_play.TabIndex = 4
        Me.btn_play.Text = "Play"
        Me.btn_play.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btn_play, "Start Fallout 4")
        Me.btn_play.UseVisualStyleBackColor = True
        '
        'btn_install
        '
        Me.btn_install.Image = Global.Fallout4ModManager.My.Resources.Resources.install
        Me.btn_install.Location = New System.Drawing.Point(0, 0)
        Me.btn_install.Name = "btn_install"
        Me.btn_install.Size = New System.Drawing.Size(69, 36)
        Me.btn_install.TabIndex = 3
        Me.btn_install.Text = "Install"
        Me.btn_install.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btn_install, "Install mod from file")
        Me.btn_install.UseVisualStyleBackColor = True
        '
        'Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 530)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btn_settings)
        Me.Controls.Add(Me.btn_about)
        Me.Controls.Add(Me.btn_play)
        Me.Controls.Add(Me.btn_install)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(611, 307)
        Me.Name = "Manager"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fallout 4 Mod Manager"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgv_plugins, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_archives, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgv_mods, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mods_context.ResumeLayout(False)
        CType(Me.dgv_downloads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dls_context.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn_install As System.Windows.Forms.Button
    Friend WithEvents btn_play As System.Windows.Forms.Button
    Friend WithEvents btn_about As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv_plugins As System.Windows.Forms.DataGridView
    Friend WithEvents esp_active As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents esp_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents esp_path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_down As System.Windows.Forms.Button
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Friend WithEvents dgv_archives As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_settings As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv_mods As System.Windows.Forms.DataGridView
    Friend WithEvents btn_activate As System.Windows.Forms.Button
    Friend WithEvents btn_deactivate As System.Windows.Forms.Button
    Friend WithEvents btn_deinstall As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgv_downloads As System.Windows.Forms.DataGridView
    Friend WithEvents btn_dl_delete As System.Windows.Forms.Button
    Friend WithEvents btn_dl_install As System.Windows.Forms.Button
    Friend WithEvents btn_pause As System.Windows.Forms.Button
    Friend WithEvents dls_context As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PauseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btn_resume As System.Windows.Forms.Button
    Friend WithEvents mods_context As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ActivateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeactivateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UninstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FixLegacyModToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_fix_legacy As System.Windows.Forms.Button
    Friend WithEvents mods_active As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents mods_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mods_txt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mods_version As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents mods_warning As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mods_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mods_index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mods_update As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dls_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dls_speed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dls_done As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dls_path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dls_finished As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btn_refresh As System.Windows.Forms.Button

End Class
