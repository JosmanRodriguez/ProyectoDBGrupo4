namespace ProyectoDBGrupo_4
{
    partial class FrmProcedimientosAlmacenados
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
            this.richTextBoxCodigo = new System.Windows.Forms.RichTextBox();
            this.cmbProcedimientos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxCodigo
            // 
            this.richTextBoxCodigo.Location = new System.Drawing.Point(305, 23);
            this.richTextBoxCodigo.Name = "richTextBoxCodigo";
            this.richTextBoxCodigo.Size = new System.Drawing.Size(410, 266);
            this.richTextBoxCodigo.TabIndex = 1;
            this.richTextBoxCodigo.Text = "";
            // 
            // cmbProcedimientos
            // 
            this.cmbProcedimientos.FormattingEnabled = true;
            this.cmbProcedimientos.Location = new System.Drawing.Point(57, 72);
            this.cmbProcedimientos.Name = "cmbProcedimientos";
            this.cmbProcedimientos.Size = new System.Drawing.Size(121, 21);
            this.cmbProcedimientos.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lista de Procedimientos Almacenados:";
            // 
            // FrmProcedimientosAlmacenados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProcedimientos);
            this.Controls.Add(this.richTextBoxCodigo);
            this.Name = "FrmProcedimientosAlmacenados";
            this.Text = "FrmProcedimientosAlmacenados";
            this.Load += new System.EventHandler(this.FrmProcedimientosAlmacenados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBoxCodigo;
        private System.Windows.Forms.ComboBox cmbProcedimientos;
        private System.Windows.Forms.Label label1;
    }
}