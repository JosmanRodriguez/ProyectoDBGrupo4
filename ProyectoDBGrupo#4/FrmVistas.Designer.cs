namespace ProyectoDBGrupo_4
{
    partial class FrmVistas
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
            this.cmbVistas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVistas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistas)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVistas
            // 
            this.cmbVistas.FormattingEnabled = true;
            this.cmbVistas.Location = new System.Drawing.Point(40, 97);
            this.cmbVistas.Name = "cmbVistas";
            this.cmbVistas.Size = new System.Drawing.Size(121, 21);
            this.cmbVistas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Reportes(Vistas):";
            // 
            // dgvVistas
            // 
            this.dgvVistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistas.Location = new System.Drawing.Point(183, 97);
            this.dgvVistas.Name = "dgvVistas";
            this.dgvVistas.Size = new System.Drawing.Size(444, 254);
            this.dgvVistas.TabIndex = 2;
            // 
            // FrmVistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvVistas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVistas);
            this.Name = "FrmVistas";
            this.Text = "FrmVistas";
            this.Load += new System.EventHandler(this.FrmVistas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVistas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvVistas;
    }
}