namespace JournalTrace.View
{
    partial class FormDrive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listbDrives = new System.Windows.Forms.ListBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbFormat = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.lbRoot = new System.Windows.Forms.Label();
            this.lbTotalSize = new System.Windows.Forms.Label();
            this.lbTotalFree = new System.Windows.Forms.Label();
            this.btSelect = new System.Windows.Forms.Button();
            this.pnlDriveInfo = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTotalSizeV = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTotalFreeV = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbRootV = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbFormatV = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTypeV = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbNameV = new System.Windows.Forms.Label();
            this.lbWaiting = new System.Windows.Forms.Label();
            this.pnlDriveInfo.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbDrives
            // 
            this.listbDrives.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbDrives.FormattingEnabled = true;
            this.listbDrives.ItemHeight = 18;
            this.listbDrives.Location = new System.Drawing.Point(0, 0);
            this.listbDrives.Name = "listbDrives";
            this.listbDrives.Size = new System.Drawing.Size(79, 166);
            this.listbDrives.TabIndex = 0;
            this.listbDrives.SelectedIndexChanged += new System.EventHandler(this.listbDrives_SelectedIndexChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(3, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(33, 13);
            this.lbName.TabIndex = 1;
            this.lbName.Tag = "name";
            this.lbName.Text = "name";
            // 
            // lbFormat
            // 
            this.lbFormat.AutoSize = true;
            this.lbFormat.Location = new System.Drawing.Point(3, 0);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(36, 13);
            this.lbFormat.TabIndex = 2;
            this.lbFormat.Tag = "format";
            this.lbFormat.Text = "format";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(3, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(27, 13);
            this.lbType.TabIndex = 3;
            this.lbType.Tag = "type";
            this.lbType.Text = "type";
            // 
            // lbRoot
            // 
            this.lbRoot.AutoSize = true;
            this.lbRoot.Location = new System.Drawing.Point(3, 0);
            this.lbRoot.Name = "lbRoot";
            this.lbRoot.Size = new System.Drawing.Size(25, 13);
            this.lbRoot.TabIndex = 4;
            this.lbRoot.Tag = "root";
            this.lbRoot.Text = "root";
            // 
            // lbTotalSize
            // 
            this.lbTotalSize.AutoSize = true;
            this.lbTotalSize.Location = new System.Drawing.Point(3, 0);
            this.lbTotalSize.Name = "lbTotalSize";
            this.lbTotalSize.Size = new System.Drawing.Size(48, 13);
            this.lbTotalSize.TabIndex = 6;
            this.lbTotalSize.Tag = "totalsize";
            this.lbTotalSize.Text = "total size";
            // 
            // lbTotalFree
            // 
            this.lbTotalFree.AutoSize = true;
            this.lbTotalFree.Location = new System.Drawing.Point(3, 0);
            this.lbTotalFree.Name = "lbTotalFree";
            this.lbTotalFree.Size = new System.Drawing.Size(80, 13);
            this.lbTotalFree.TabIndex = 7;
            this.lbTotalFree.Tag = "totalfreespace";
            this.lbTotalFree.Text = "total free space";
            // 
            // btSelect
            // 
            this.btSelect.Location = new System.Drawing.Point(4, 138);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(176, 23);
            this.btSelect.TabIndex = 8;
            this.btSelect.Tag = "select";
            this.btSelect.Text = "Select";
            this.btSelect.UseVisualStyleBackColor = true;
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // pnlDriveInfo
            // 
            this.pnlDriveInfo.Controls.Add(this.flowLayoutPanel3);
            this.pnlDriveInfo.Controls.Add(this.flowLayoutPanel4);
            this.pnlDriveInfo.Controls.Add(this.flowLayoutPanel5);
            this.pnlDriveInfo.Controls.Add(this.flowLayoutPanel6);
            this.pnlDriveInfo.Controls.Add(this.flowLayoutPanel7);
            this.pnlDriveInfo.Controls.Add(this.flowLayoutPanel1);
            this.pnlDriveInfo.Controls.Add(this.btSelect);
            this.pnlDriveInfo.Location = new System.Drawing.Point(84, 1);
            this.pnlDriveInfo.Name = "pnlDriveInfo";
            this.pnlDriveInfo.Size = new System.Drawing.Size(187, 164);
            this.pnlDriveInfo.TabIndex = 9;
            this.pnlDriveInfo.Visible = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lbTotalSize);
            this.flowLayoutPanel3.Controls.Add(this.lbTotalSizeV);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(6, 114);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(171, 17);
            this.flowLayoutPanel3.TabIndex = 11;
            // 
            // lbTotalSizeV
            // 
            this.lbTotalSizeV.AutoSize = true;
            this.lbTotalSizeV.Location = new System.Drawing.Point(57, 0);
            this.lbTotalSizeV.Name = "lbTotalSizeV";
            this.lbTotalSizeV.Size = new System.Drawing.Size(55, 13);
            this.lbTotalSizeV.TabIndex = 7;
            this.lbTotalSizeV.Text = "total sizeV";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.lbTotalFree);
            this.flowLayoutPanel4.Controls.Add(this.lbTotalFreeV);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(6, 96);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(171, 17);
            this.flowLayoutPanel4.TabIndex = 11;
            // 
            // lbTotalFreeV
            // 
            this.lbTotalFreeV.AutoSize = true;
            this.lbTotalFreeV.Location = new System.Drawing.Point(89, 0);
            this.lbTotalFreeV.Name = "lbTotalFreeV";
            this.lbTotalFreeV.Size = new System.Drawing.Size(25, 13);
            this.lbTotalFreeV.TabIndex = 8;
            this.lbTotalFreeV.Text = "tfsV";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.lbRoot);
            this.flowLayoutPanel5.Controls.Add(this.lbRootV);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(6, 24);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(171, 17);
            this.flowLayoutPanel5.TabIndex = 11;
            // 
            // lbRootV
            // 
            this.lbRootV.AutoSize = true;
            this.lbRootV.Location = new System.Drawing.Point(34, 0);
            this.lbRootV.Name = "lbRootV";
            this.lbRootV.Size = new System.Drawing.Size(32, 13);
            this.lbRootV.TabIndex = 5;
            this.lbRootV.Text = "rootV";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.lbFormat);
            this.flowLayoutPanel6.Controls.Add(this.lbFormatV);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(6, 50);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(171, 17);
            this.flowLayoutPanel6.TabIndex = 11;
            // 
            // lbFormatV
            // 
            this.lbFormatV.AutoSize = true;
            this.lbFormatV.Location = new System.Drawing.Point(45, 0);
            this.lbFormatV.Name = "lbFormatV";
            this.lbFormatV.Size = new System.Drawing.Size(43, 13);
            this.lbFormatV.TabIndex = 3;
            this.lbFormatV.Text = "formatV";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.lbType);
            this.flowLayoutPanel7.Controls.Add(this.lbTypeV);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(6, 68);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(171, 17);
            this.flowLayoutPanel7.TabIndex = 11;
            // 
            // lbTypeV
            // 
            this.lbTypeV.AutoSize = true;
            this.lbTypeV.Location = new System.Drawing.Point(36, 0);
            this.lbTypeV.Name = "lbTypeV";
            this.lbTypeV.Size = new System.Drawing.Size(34, 13);
            this.lbTypeV.TabIndex = 4;
            this.lbTypeV.Text = "typeV";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbName);
            this.flowLayoutPanel1.Controls.Add(this.lbNameV);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(171, 17);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // lbNameV
            // 
            this.lbNameV.AutoSize = true;
            this.lbNameV.Location = new System.Drawing.Point(42, 0);
            this.lbNameV.Name = "lbNameV";
            this.lbNameV.Size = new System.Drawing.Size(40, 13);
            this.lbNameV.TabIndex = 2;
            this.lbNameV.Text = "nameV";
            // 
            // lbWaiting
            // 
            this.lbWaiting.AutoSize = true;
            this.lbWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWaiting.Location = new System.Drawing.Point(166, 64);
            this.lbWaiting.Name = "lbWaiting";
            this.lbWaiting.Size = new System.Drawing.Size(25, 24);
            this.lbWaiting.TabIndex = 10;
            this.lbWaiting.Text = "...";
            // 
            // FormDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 166);
            this.Controls.Add(this.pnlDriveInfo);
            this.Controls.Add(this.lbWaiting);
            this.Controls.Add(this.listbDrives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDrive";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "formdrive";
            this.Text = "Drive selection";
            this.Load += new System.EventHandler(this.FormDrive_Load);
            this.pnlDriveInfo.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbDrives;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbFormat;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbRoot;
        private System.Windows.Forms.Label lbTotalSize;
        private System.Windows.Forms.Label lbTotalFree;
        private System.Windows.Forms.Button btSelect;
        private System.Windows.Forms.Panel pnlDriveInfo;
        private System.Windows.Forms.Label lbWaiting;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbTotalSizeV;
        private System.Windows.Forms.Label lbTotalFreeV;
        private System.Windows.Forms.Label lbRootV;
        private System.Windows.Forms.Label lbFormatV;
        private System.Windows.Forms.Label lbTypeV;
        private System.Windows.Forms.Label lbNameV;
    }
}