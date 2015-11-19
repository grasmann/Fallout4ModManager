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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manager))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.esp_active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.esp_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.esp_path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_mods = New System.Windows.Forms.DataGridView()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.mods_active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.mods_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mods_txt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mods_warning = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_about = New System.Windows.Forms.Button()
        Me.btn_play = New System.Windows.Forms.Button()
        Me.btn_install = New System.Windows.Forms.Button()
        Me.btn_down = New System.Windows.Forms.Button()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.btn_deactivate = New System.Windows.Forms.Button()
        Me.btn_activate = New System.Windows.Forms.Button()
        Me.btn_deinstall = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_mods, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_deactivate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_activate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_deinstall)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_mods)
        Me.SplitContainer1.Size = New System.Drawing.Size(1002, 462)
        Me.SplitContainer1.SplitterDistance = 450
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.DataGridView1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView3)
        Me.SplitContainer2.Size = New System.Drawing.Size(450, 462)
        Me.SplitContainer2.SplitterDistance = 328
        Me.SplitContainer2.TabIndex = 7
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.esp_active, Me.esp_name, Me.esp_path})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.MenuText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.Location = New System.Drawing.Point(0, 16)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(411, 312)
        Me.DataGridView1.TabIndex = 7
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
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView3.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView3.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.MenuText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView3.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridView3.Location = New System.Drawing.Point(0, 16)
        Me.DataGridView3.MultiSelect = False
        Me.DataGridView3.Name = "DataGridView3"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridView3.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView3.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataGridView3.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView3.Size = New System.Drawing.Size(450, 114)
        Me.DataGridView3.TabIndex = 6
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
        Me.dgv_mods.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mods_active, Me.mods_name, Me.mods_txt, Me.mods_warning})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.MenuText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_mods.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_mods.GridColor = System.Drawing.SystemColors.Control
        Me.dgv_mods.Location = New System.Drawing.Point(1, 0)
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
        Me.dgv_mods.Size = New System.Drawing.Size(510, 462)
        Me.dgv_mods.TabIndex = 3
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(213, 1)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(714, 34)
        Me.ProgressBar1.TabIndex = 10
        '
        'mods_active
        '
        Me.mods_active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.mods_active.HeaderText = "Active"
        Me.mods_active.Name = "mods_active"
        Me.mods_active.ReadOnly = True
        Me.mods_active.Width = 43
        '
        'mods_name
        '
        Me.mods_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.mods_name.HeaderText = "Installed Mods"
        Me.mods_name.Name = "mods_name"
        Me.mods_name.ReadOnly = True
        Me.mods_name.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mods_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'mods_txt
        '
        Me.mods_txt.HeaderText = "Textfile"
        Me.mods_txt.Name = "mods_txt"
        Me.mods_txt.ReadOnly = True
        Me.mods_txt.Visible = False
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
        Me.mods_warning.Width = 5
        '
        'Button1
        '
        Me.Button1.Image = Global.Fallout4ModManager.My.Resources.Resources.settings
        Me.Button1.Location = New System.Drawing.Point(132, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 36)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Settings"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_about
        '
        Me.btn_about.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_about.Image = Global.Fallout4ModManager.My.Resources.Resources.info
        Me.btn_about.Location = New System.Drawing.Point(928, 0)
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(75, 36)
        Me.btn_about.TabIndex = 8
        Me.btn_about.Text = "About"
        Me.btn_about.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_about.UseVisualStyleBackColor = True
        '
        'btn_play
        '
        Me.btn_play.Image = Global.Fallout4ModManager.My.Resources.Resources.play
        Me.btn_play.Location = New System.Drawing.Point(69, 0)
        Me.btn_play.Name = "btn_play"
        Me.btn_play.Size = New System.Drawing.Size(63, 36)
        Me.btn_play.TabIndex = 4
        Me.btn_play.Text = "Play"
        Me.btn_play.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
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
        Me.btn_install.UseVisualStyleBackColor = True
        '
        'btn_down
        '
        Me.btn_down.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_down.Enabled = False
        Me.btn_down.Image = Global.Fallout4ModManager.My.Resources.Resources.down
        Me.btn_down.Location = New System.Drawing.Point(411, 52)
        Me.btn_down.Name = "btn_down"
        Me.btn_down.Size = New System.Drawing.Size(36, 36)
        Me.btn_down.TabIndex = 10
        Me.btn_down.UseVisualStyleBackColor = True
        '
        'btn_up
        '
        Me.btn_up.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_up.Enabled = False
        Me.btn_up.Image = Global.Fallout4ModManager.My.Resources.Resources.up
        Me.btn_up.Location = New System.Drawing.Point(411, 16)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(36, 36)
        Me.btn_up.TabIndex = 9
        Me.btn_up.UseVisualStyleBackColor = True
        '
        'btn_deactivate
        '
        Me.btn_deactivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_deactivate.Image = Global.Fallout4ModManager.My.Resources.Resources.deactivate
        Me.btn_deactivate.Location = New System.Drawing.Point(512, 35)
        Me.btn_deactivate.Name = "btn_deactivate"
        Me.btn_deactivate.Size = New System.Drawing.Size(36, 36)
        Me.btn_deactivate.TabIndex = 6
        Me.btn_deactivate.UseVisualStyleBackColor = True
        '
        'btn_activate
        '
        Me.btn_activate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_activate.Image = Global.Fallout4ModManager.My.Resources.Resources.ok
        Me.btn_activate.Location = New System.Drawing.Point(512, -1)
        Me.btn_activate.Name = "btn_activate"
        Me.btn_activate.Size = New System.Drawing.Size(36, 36)
        Me.btn_activate.TabIndex = 5
        Me.btn_activate.UseVisualStyleBackColor = True
        '
        'btn_deinstall
        '
        Me.btn_deinstall.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_deinstall.Image = Global.Fallout4ModManager.My.Resources.Resources.deinstall
        Me.btn_deinstall.Location = New System.Drawing.Point(512, 77)
        Me.btn_deinstall.Name = "btn_deinstall"
        Me.btn_deinstall.Size = New System.Drawing.Size(36, 36)
        Me.btn_deinstall.TabIndex = 4
        Me.btn_deinstall.UseVisualStyleBackColor = True
        '
        'Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 520)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_about)
        Me.Controls.Add(Me.btn_play)
        Me.Controls.Add(Me.btn_install)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_mods, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn_install As System.Windows.Forms.Button
    Friend WithEvents btn_play As System.Windows.Forms.Button
    Friend WithEvents dgv_mods As System.Windows.Forms.DataGridView
    Friend WithEvents btn_deinstall As System.Windows.Forms.Button
    Friend WithEvents btn_about As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents esp_active As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents esp_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents esp_path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_down As System.Windows.Forms.Button
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_deactivate As System.Windows.Forms.Button
    Friend WithEvents btn_activate As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents mods_active As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents mods_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mods_txt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mods_warning As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
