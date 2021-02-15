namespace JournalTrace.View.Info
{
    partial class UserSocialMedia
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbDesc = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.picDreamInCode = new System.Windows.Forms.PictureBox();
            this.picGithub = new System.Windows.Forms.PictureBox();
            this.picYoutube = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDreamInCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGithub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYoutube)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(2, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(172, 20);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "exemplo de nome";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDesc
            // 
            this.lbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesc.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbDesc.Location = new System.Drawing.Point(2, 18);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(172, 27);
            this.lbDesc.TabIndex = 2;
            this.lbDesc.Text = "exemplo de descricao meu deus descricao longa\r\n";
            this.lbDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.picDreamInCode);
            this.flowLayoutPanel1.Controls.Add(this.picGithub);
            this.flowLayoutPanel1.Controls.Add(this.picYoutube);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(179, -3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(166, 47);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // picDreamInCode
            // 
            this.picDreamInCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDreamInCode.Image = global::JournalTrace.Properties.Resources.dreamincode;
            this.picDreamInCode.Location = new System.Drawing.Point(3, 3);
            this.picDreamInCode.Name = "picDreamInCode";
            this.picDreamInCode.Size = new System.Drawing.Size(47, 47);
            this.picDreamInCode.TabIndex = 0;
            this.picDreamInCode.TabStop = false;
            this.picDreamInCode.Visible = false;
            this.picDreamInCode.Click += new System.EventHandler(this.picDreamInCode_Click);
            // 
            // picGithub
            // 
            this.picGithub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGithub.Image = global::JournalTrace.Properties.Resources.github;
            this.picGithub.Location = new System.Drawing.Point(56, 3);
            this.picGithub.Name = "picGithub";
            this.picGithub.Size = new System.Drawing.Size(47, 47);
            this.picGithub.TabIndex = 1;
            this.picGithub.TabStop = false;
            this.picGithub.Visible = false;
            this.picGithub.Click += new System.EventHandler(this.picGithub_Click);
            // 
            // picYoutube
            // 
            this.picYoutube.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picYoutube.Image = global::JournalTrace.Properties.Resources.youtube;
            this.picYoutube.Location = new System.Drawing.Point(109, 3);
            this.picYoutube.Name = "picYoutube";
            this.picYoutube.Size = new System.Drawing.Size(47, 47);
            this.picYoutube.TabIndex = 2;
            this.picYoutube.TabStop = false;
            this.picYoutube.Visible = false;
            this.picYoutube.Click += new System.EventHandler(this.picYoutube_Click);
            // 
            // UserSocialMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.lbName);
            this.Name = "UserSocialMedia";
            this.Size = new System.Drawing.Size(346, 47);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDreamInCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGithub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYoutube)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox picDreamInCode;
        private System.Windows.Forms.PictureBox picGithub;
        private System.Windows.Forms.PictureBox picYoutube;
    }
}
