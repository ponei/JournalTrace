namespace JournalTrace.View.Layout
{
    partial class TreeLayout
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.datagDirectoryChanges = new System.Windows.Forms.DataGridView();
            this.treeUSNDirectories = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.datagDirectoryChanges)).BeginInit();
            this.SuspendLayout();
            // 
            // datagDirectoryChanges
            // 
            this.datagDirectoryChanges.AllowUserToDeleteRows = false;
            this.datagDirectoryChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagDirectoryChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagDirectoryChanges.Location = new System.Drawing.Point(297, 3);
            this.datagDirectoryChanges.Name = "datagDirectoryChanges";
            this.datagDirectoryChanges.ReadOnly = true;
            this.datagDirectoryChanges.RowHeadersVisible = false;
            this.datagDirectoryChanges.Size = new System.Drawing.Size(469, 352);
            this.datagDirectoryChanges.TabIndex = 9;
            this.datagDirectoryChanges.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagDirectoryChanges_CellMouseDown);
            // 
            // treeUSNDirectories
            // 
            this.treeUSNDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeUSNDirectories.Location = new System.Drawing.Point(3, 3);
            this.treeUSNDirectories.Name = "treeUSNDirectories";
            this.treeUSNDirectories.Size = new System.Drawing.Size(288, 352);
            this.treeUSNDirectories.TabIndex = 8;
            this.treeUSNDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeUSNDirectories_AfterSelect);
            // 
            // TreeLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.datagDirectoryChanges);
            this.Controls.Add(this.treeUSNDirectories);
            this.Name = "TreeLayout";
            this.Size = new System.Drawing.Size(769, 358);
            ((System.ComponentModel.ISupportInitialize)(this.datagDirectoryChanges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagDirectoryChanges;
        private System.Windows.Forms.TreeView treeUSNDirectories;
    }
}
