namespace IntegracaoBancos
{
    partial class ConfiguraçãoSistema
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelServidor = new System.Windows.Forms.Label();
            this.textBoxServidor = new System.Windows.Forms.TextBox();
            this.textBoxBanco = new System.Windows.Forms.TextBox();
            this.labelBanco = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.labelSenha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IntegracaoBancos.Properties.Resources.LogoEscolarManager;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelServidor
            // 
            this.labelServidor.AutoSize = true;
            this.labelServidor.Location = new System.Drawing.Point(21, 75);
            this.labelServidor.Name = "labelServidor";
            this.labelServidor.Size = new System.Drawing.Size(94, 13);
            this.labelServidor.TabIndex = 1;
            this.labelServidor.Text = "Nome Do Servidor";
            // 
            // textBoxServidor
            // 
            this.textBoxServidor.Location = new System.Drawing.Point(21, 104);
            this.textBoxServidor.Name = "textBoxServidor";
            this.textBoxServidor.Size = new System.Drawing.Size(366, 20);
            this.textBoxServidor.TabIndex = 2;
            // 
            // textBoxBanco
            // 
            this.textBoxBanco.Location = new System.Drawing.Point(21, 173);
            this.textBoxBanco.Name = "textBoxBanco";
            this.textBoxBanco.Size = new System.Drawing.Size(366, 20);
            this.textBoxBanco.TabIndex = 4;
            // 
            // labelBanco
            // 
            this.labelBanco.AutoSize = true;
            this.labelBanco.Location = new System.Drawing.Point(21, 144);
            this.labelBanco.Name = "labelBanco";
            this.labelBanco.Size = new System.Drawing.Size(86, 13);
            this.labelBanco.TabIndex = 3;
            this.labelBanco.Text = "Nome Do Banco";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(21, 241);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(366, 20);
            this.textBoxUsuario.TabIndex = 6;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(21, 212);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(49, 13);
            this.labelUsuario.TabIndex = 5;
            this.labelUsuario.Text = "Usuario :";
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(21, 313);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(366, 20);
            this.textBoxSenha.TabIndex = 8;
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(21, 284);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(44, 13);
            this.labelSenha.TabIndex = 7;
            this.labelSenha.Text = "Senha :";
            // 
            // ConfiguraçãoSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 508);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textBoxBanco);
            this.Controls.Add(this.labelBanco);
            this.Controls.Add(this.textBoxServidor);
            this.Controls.Add(this.labelServidor);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ConfiguraçãoSistema";
            this.Text = "ConfiguraçãoSistema";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelServidor;
        private System.Windows.Forms.TextBox textBoxServidor;
        private System.Windows.Forms.TextBox textBoxBanco;
        private System.Windows.Forms.Label labelBanco;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Label labelSenha;
    }
}