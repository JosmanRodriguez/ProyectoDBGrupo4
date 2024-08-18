namespace ProyectoDBGrupo_4
{
    partial class FrmTiendaProducto
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
            this.cmbTiendaId = new System.Windows.Forms.ComboBox();
            this.cmbProductoUPC = new System.Windows.Forms.ComboBox();
            this.dgvTiendaProducto = new System.Windows.Forms.DataGridView();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnLeer = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiendaProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tienda Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Producto UPC";
            // 
            // cmbTiendaId
            // 
            this.cmbTiendaId.FormattingEnabled = true;
            this.cmbTiendaId.Location = new System.Drawing.Point(42, 43);
            this.cmbTiendaId.Name = "cmbTiendaId";
            this.cmbTiendaId.Size = new System.Drawing.Size(121, 21);
            this.cmbTiendaId.TabIndex = 2;
            // 
            // cmbProductoUPC
            // 
            this.cmbProductoUPC.FormattingEnabled = true;
            this.cmbProductoUPC.Location = new System.Drawing.Point(42, 119);
            this.cmbProductoUPC.Name = "cmbProductoUPC";
            this.cmbProductoUPC.Size = new System.Drawing.Size(121, 21);
            this.cmbProductoUPC.TabIndex = 3;
            // 
            // dgvTiendaProducto
            // 
            this.dgvTiendaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiendaProducto.Location = new System.Drawing.Point(341, 43);
            this.dgvTiendaProducto.Name = "dgvTiendaProducto";
            this.dgvTiendaProducto.Size = new System.Drawing.Size(262, 150);
            this.dgvTiendaProducto.TabIndex = 4;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(292, 246);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 5;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnLeer
            // 
            this.btnLeer.Location = new System.Drawing.Point(395, 246);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(75, 23);
            this.btnLeer.TabIndex = 6;
            this.btnLeer.Text = "Leer";
            this.btnLeer.UseVisualStyleBackColor = true;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(489, 246);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmTiendaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLeer);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.dgvTiendaProducto);
            this.Controls.Add(this.cmbProductoUPC);
            this.Controls.Add(this.cmbTiendaId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTiendaProducto";
            this.Text = "FrmTiendaProducto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiendaProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTiendaId;
        private System.Windows.Forms.ComboBox cmbProductoUPC;
        private System.Windows.Forms.DataGridView dgvTiendaProducto;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnLeer;
        private System.Windows.Forms.Button btnEliminar;
    }
}