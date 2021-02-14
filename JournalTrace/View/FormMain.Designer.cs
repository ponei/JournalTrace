namespace JournalTrace
{
    partial class FormMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuForm = new System.Windows.Forms.MenuStrip();
            this.driveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portuguêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbStatusMain = new System.Windows.Forms.Label();
            this.lbStatusDesc = new System.Windows.Forms.Label();
            this.progbarStatus = new System.Windows.Forms.ProgressBar();
            this.lbCountAll = new System.Windows.Forms.Label();
            this.lbCountAllV = new System.Windows.Forms.Label();
            this.flowpInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.lbCountFirst = new System.Windows.Forms.Label();
            this.lbCountFirstV = new System.Windows.Forms.Label();
            this.lbCountFiles = new System.Windows.Forms.Label();
            this.lbCountFilesV = new System.Windows.Forms.Label();
            this.lbCountDirectories = new System.Windows.Forms.Label();
            this.lbCountDirectoriesV = new System.Windows.Forms.Label();
            this.cmsEntryInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entryInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuForm.SuspendLayout();
            this.flowpInfo.SuspendLayout();
            this.cmsEntryInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuForm
            // 
            this.menuForm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driveToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.layoutToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuForm.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuForm.Location = new System.Drawing.Point(0, 0);
            this.menuForm.Name = "menuForm";
            this.menuForm.Size = new System.Drawing.Size(706, 24);
            this.menuForm.TabIndex = 1;
            this.menuForm.Text = "menuStrip1";
            // 
            // driveToolStripMenuItem
            // 
            this.driveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.scanToolStripMenuItem});
            this.driveToolStripMenuItem.Name = "driveToolStripMenuItem";
            this.driveToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.driveToolStripMenuItem.Tag = "drive";
            this.driveToolStripMenuItem.Text = "Drive";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.selectToolStripMenuItem.Tag = "select";
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.scanToolStripMenuItem.Tag = "scan";
            this.scanToolStripMenuItem.Text = "Scan";
            this.scanToolStripMenuItem.Click += new System.EventHandler(this.scanToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Enabled = false;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Tag = "file";
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exportToolStripMenuItem.Tag = "export";
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // layoutToolStripMenuItem
            // 
            this.layoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoryTreeToolStripMenuItem,
            this.dataGridToolStripMenuItem});
            this.layoutToolStripMenuItem.Enabled = false;
            this.layoutToolStripMenuItem.Name = "layoutToolStripMenuItem";
            this.layoutToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.layoutToolStripMenuItem.Text = "Layout";
            // 
            // directoryTreeToolStripMenuItem
            // 
            this.directoryTreeToolStripMenuItem.CheckOnClick = true;
            this.directoryTreeToolStripMenuItem.Name = "directoryTreeToolStripMenuItem";
            this.directoryTreeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.directoryTreeToolStripMenuItem.Tag = "directorytree";
            this.directoryTreeToolStripMenuItem.Text = "Directory Tree";
            this.directoryTreeToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.directoryTreeToolStripMenuItem_CheckStateChanged);
            // 
            // dataGridToolStripMenuItem
            // 
            this.dataGridToolStripMenuItem.CheckOnClick = true;
            this.dataGridToolStripMenuItem.Name = "dataGridToolStripMenuItem";
            this.dataGridToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.dataGridToolStripMenuItem.Tag = "datagrid";
            this.dataGridToolStripMenuItem.Text = "Data Grid";
            this.dataGridToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.dataGridToolStripMenuItem_CheckStateChanged);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.portuguêsToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Tag = "language";
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckOnClick = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.englishToolStripMenuItem_CheckStateChanged);
            // 
            // portuguêsToolStripMenuItem
            // 
            this.portuguêsToolStripMenuItem.CheckOnClick = true;
            this.portuguêsToolStripMenuItem.Name = "portuguêsToolStripMenuItem";
            this.portuguêsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.portuguêsToolStripMenuItem.Text = "Português";
            this.portuguêsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.portuguêsToolStripMenuItem_CheckStateChanged);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.infoToolStripMenuItem.Tag = "info";
            this.infoToolStripMenuItem.Text = "Information";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // lbStatusMain
            // 
            this.lbStatusMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatusMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusMain.Location = new System.Drawing.Point(0, 144);
            this.lbStatusMain.Name = "lbStatusMain";
            this.lbStatusMain.Size = new System.Drawing.Size(706, 24);
            this.lbStatusMain.TabIndex = 10;
            this.lbStatusMain.Tag = "statustitle0";
            this.lbStatusMain.Text = "exemplo de status";
            this.lbStatusMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStatusDesc
            // 
            this.lbStatusDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusDesc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbStatusDesc.Location = new System.Drawing.Point(203, 168);
            this.lbStatusDesc.Name = "lbStatusDesc";
            this.lbStatusDesc.Size = new System.Drawing.Size(300, 59);
            this.lbStatusDesc.TabIndex = 12;
            this.lbStatusDesc.Tag = "statusdesc0";
            this.lbStatusDesc.Text = "exemplo de desc";
            this.lbStatusDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progbarStatus
            // 
            this.progbarStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progbarStatus.Location = new System.Drawing.Point(12, 230);
            this.progbarStatus.Name = "progbarStatus";
            this.progbarStatus.Size = new System.Drawing.Size(682, 23);
            this.progbarStatus.TabIndex = 13;
            // 
            // lbCountAll
            // 
            this.lbCountAll.AutoSize = true;
            this.lbCountAll.Location = new System.Drawing.Point(75, 0);
            this.lbCountAll.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCountAll.Name = "lbCountAll";
            this.lbCountAll.Size = new System.Drawing.Size(44, 13);
            this.lbCountAll.TabIndex = 1;
            this.lbCountAll.Tag = "countall";
            this.lbCountAll.Text = "countall";
            // 
            // lbCountAllV
            // 
            this.lbCountAllV.AutoSize = true;
            this.lbCountAllV.Location = new System.Drawing.Point(119, 0);
            this.lbCountAllV.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lbCountAllV.Name = "lbCountAllV";
            this.lbCountAllV.Size = new System.Drawing.Size(16, 13);
            this.lbCountAllV.TabIndex = 2;
            this.lbCountAllV.Text = "...";
            // 
            // flowpInfo
            // 
            this.flowpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowpInfo.Controls.Add(this.lbCountFirst);
            this.flowpInfo.Controls.Add(this.lbCountFirstV);
            this.flowpInfo.Controls.Add(this.lbCountAll);
            this.flowpInfo.Controls.Add(this.lbCountAllV);
            this.flowpInfo.Controls.Add(this.lbCountFiles);
            this.flowpInfo.Controls.Add(this.lbCountFilesV);
            this.flowpInfo.Controls.Add(this.lbCountDirectories);
            this.flowpInfo.Controls.Add(this.lbCountDirectoriesV);
            this.flowpInfo.Location = new System.Drawing.Point(1, 366);
            this.flowpInfo.Margin = new System.Windows.Forms.Padding(0);
            this.flowpInfo.Name = "flowpInfo";
            this.flowpInfo.Size = new System.Drawing.Size(643, 19);
            this.flowpInfo.TabIndex = 14;
            // 
            // lbCountFirst
            // 
            this.lbCountFirst.AutoSize = true;
            this.lbCountFirst.Location = new System.Drawing.Point(3, 0);
            this.lbCountFirst.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCountFirst.Name = "lbCountFirst";
            this.lbCountFirst.Size = new System.Drawing.Size(50, 13);
            this.lbCountFirst.TabIndex = 7;
            this.lbCountFirst.Tag = "countfirst";
            this.lbCountFirst.Text = "countfirst";
            // 
            // lbCountFirstV
            // 
            this.lbCountFirstV.AutoSize = true;
            this.lbCountFirstV.Location = new System.Drawing.Point(53, 0);
            this.lbCountFirstV.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbCountFirstV.Name = "lbCountFirstV";
            this.lbCountFirstV.Size = new System.Drawing.Size(16, 13);
            this.lbCountFirstV.TabIndex = 8;
            this.lbCountFirstV.Text = "...";
            // 
            // lbCountFiles
            // 
            this.lbCountFiles.AutoSize = true;
            this.lbCountFiles.Location = new System.Drawing.Point(146, 0);
            this.lbCountFiles.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCountFiles.Name = "lbCountFiles";
            this.lbCountFiles.Size = new System.Drawing.Size(52, 13);
            this.lbCountFiles.TabIndex = 3;
            this.lbCountFiles.Tag = "countfiles";
            this.lbCountFiles.Text = "countfiles";
            // 
            // lbCountFilesV
            // 
            this.lbCountFilesV.AutoSize = true;
            this.lbCountFilesV.Location = new System.Drawing.Point(198, 0);
            this.lbCountFilesV.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lbCountFilesV.Name = "lbCountFilesV";
            this.lbCountFilesV.Size = new System.Drawing.Size(16, 13);
            this.lbCountFilesV.TabIndex = 4;
            this.lbCountFilesV.Text = "...";
            // 
            // lbCountDirectories
            // 
            this.lbCountDirectories.AutoSize = true;
            this.lbCountDirectories.Location = new System.Drawing.Point(225, 0);
            this.lbCountDirectories.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCountDirectories.Name = "lbCountDirectories";
            this.lbCountDirectories.Size = new System.Drawing.Size(82, 13);
            this.lbCountDirectories.TabIndex = 5;
            this.lbCountDirectories.Tag = "countdirectories";
            this.lbCountDirectories.Text = "countdirectories";
            // 
            // lbCountDirectoriesV
            // 
            this.lbCountDirectoriesV.AutoSize = true;
            this.lbCountDirectoriesV.Location = new System.Drawing.Point(307, 0);
            this.lbCountDirectoriesV.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lbCountDirectoriesV.Name = "lbCountDirectoriesV";
            this.lbCountDirectoriesV.Size = new System.Drawing.Size(16, 13);
            this.lbCountDirectoriesV.TabIndex = 6;
            this.lbCountDirectoriesV.Text = "...";
            // 
            // cmsEntryInfo
            // 
            this.cmsEntryInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyValueToolStripMenuItem,
            this.entryInfoToolStripMenuItem,
            this.enterDirToolStripMenuItem});
            this.cmsEntryInfo.Name = "cmsEntryInfo";
            this.cmsEntryInfo.Size = new System.Drawing.Size(129, 70);
            // 
            // copyValueToolStripMenuItem
            // 
            this.copyValueToolStripMenuItem.Name = "copyValueToolStripMenuItem";
            this.copyValueToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.copyValueToolStripMenuItem.Text = "copyvalue";
            this.copyValueToolStripMenuItem.Click += new System.EventHandler(this.copyValueToolStripMenuItem_Click);
            // 
            // entryInfoToolStripMenuItem
            // 
            this.entryInfoToolStripMenuItem.Name = "entryInfoToolStripMenuItem";
            this.entryInfoToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.entryInfoToolStripMenuItem.Tag = "entryinfo";
            this.entryInfoToolStripMenuItem.Text = "entryinfo";
            this.entryInfoToolStripMenuItem.Click += new System.EventHandler(this.entryInfoToolStripMenuItem_Click);
            // 
            // enterDirToolStripMenuItem
            // 
            this.enterDirToolStripMenuItem.Name = "enterDirToolStripMenuItem";
            this.enterDirToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.enterDirToolStripMenuItem.Tag = "enterdir";
            this.enterDirToolStripMenuItem.Text = "enterdir";
            this.enterDirToolStripMenuItem.Click += new System.EventHandler(this.enterDirToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 383);
            this.Controls.Add(this.flowpInfo);
            this.Controls.Add(this.progbarStatus);
            this.Controls.Add(this.lbStatusDesc);
            this.Controls.Add(this.lbStatusMain);
            this.Controls.Add(this.menuForm);
            this.MainMenuStrip = this.menuForm;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JournalTrace";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.menuForm.ResumeLayout(false);
            this.menuForm.PerformLayout();
            this.flowpInfo.ResumeLayout(false);
            this.flowpInfo.PerformLayout();
            this.cmsEntryInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuForm;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Label lbStatusMain;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portuguêsToolStripMenuItem;
        private System.Windows.Forms.Label lbStatusDesc;
        private System.Windows.Forms.ProgressBar progbarStatus;
        private System.Windows.Forms.Label lbCountAll;
        private System.Windows.Forms.Label lbCountAllV;
        private System.Windows.Forms.FlowLayoutPanel flowpInfo;
        private System.Windows.Forms.Label lbCountFiles;
        private System.Windows.Forms.Label lbCountFilesV;
        private System.Windows.Forms.Label lbCountDirectories;
        private System.Windows.Forms.Label lbCountDirectoriesV;
        private System.Windows.Forms.Label lbCountFirst;
        private System.Windows.Forms.Label lbCountFirstV;
        private System.Windows.Forms.ContextMenuStrip cmsEntryInfo;
        private System.Windows.Forms.ToolStripMenuItem copyValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entryInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterDirToolStripMenuItem;
    }
}

