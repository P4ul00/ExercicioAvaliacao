namespace ExercicioAvaliacao
{
    partial class PesquisaTelefones
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdTelefone = new System.Windows.Forms.TextBox();
            this.cmbPesquisarNome = new System.Windows.Forms.ComboBox();
            this.dgwTelefones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTelefones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome : ";
            // 
            // txtIdTelefone
            // 
            this.txtIdTelefone.Enabled = false;
            this.txtIdTelefone.Location = new System.Drawing.Point(128, 36);
            this.txtIdTelefone.Name = "txtIdTelefone";
            this.txtIdTelefone.Size = new System.Drawing.Size(50, 20);
            this.txtIdTelefone.TabIndex = 2;
            // 
            // cmbPesquisarNome
            // 
            this.cmbPesquisarNome.FormattingEnabled = true;
            this.cmbPesquisarNome.Location = new System.Drawing.Point(128, 69);
            this.cmbPesquisarNome.Name = "cmbPesquisarNome";
            this.cmbPesquisarNome.Size = new System.Drawing.Size(310, 21);
            this.cmbPesquisarNome.TabIndex = 3;
            // 
            // dgwTelefones
            // 
            this.dgwTelefones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTelefones.Location = new System.Drawing.Point(65, 108);
            this.dgwTelefones.Name = "dgwTelefones";
            this.dgwTelefones.Size = new System.Drawing.Size(373, 145);
            this.dgwTelefones.TabIndex = 4;
            // 
            // PesquisaTelefones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 338);
            this.Controls.Add(this.dgwTelefones);
            this.Controls.Add(this.cmbPesquisarNome);
            this.Controls.Add(this.txtIdTelefone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PesquisaTelefones";
            this.Text = "PesquisaTelefones";
            this.Load += new System.EventHandler(this.PesquisaTelefones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTelefones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdTelefone;
        private System.Windows.Forms.ComboBox cmbPesquisarNome;
        private System.Windows.Forms.DataGridView dgwTelefones;
    }
}