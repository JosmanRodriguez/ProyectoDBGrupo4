namespace ProyectoDBGrupo_4
{
    partial class FrmPrincipal
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
            this.btnTablas = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnVistas = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVendedor = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTiendaProducto = new System.Windows.Forms.Button();
            this.btnProductoVendedor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTablas
            // 
            this.btnTablas.Location = new System.Drawing.Point(81, 28);
            this.btnTablas.Name = "btnTablas";
            this.btnTablas.Size = new System.Drawing.Size(78, 36);
            this.btnTablas.TabIndex = 0;
            this.btnTablas.Text = "Tiendas";
            this.btnTablas.UseVisualStyleBackColor = true;
            this.btnTablas.Click += new System.EventHandler(this.btnTablas_Click);
            // 
            // btnSP
            // 
            this.btnSP.Location = new System.Drawing.Point(279, 28);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(158, 56);
            this.btnSP.TabIndex = 1;
            this.btnSP.Text = "Procedimientos Almacenados";
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnVistas
            // 
            this.btnVistas.Location = new System.Drawing.Point(530, 37);
            this.btnVistas.Name = "btnVistas";
            this.btnVistas.Size = new System.Drawing.Size(107, 56);
            this.btnVistas.TabIndex = 2;
            this.btnVistas.Text = "Vistas";
            this.btnVistas.UseVisualStyleBackColor = true;
            this.btnVistas.Click += new System.EventHandler(this.btnVistas_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.Location = new System.Drawing.Point(81, 70);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(75, 34);
            this.btnProducto.TabIndex = 3;
            this.btnProducto.Text = "Productos";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Formularios Base de Datos";
            // 
            // btnVendedor
            // 
            this.btnVendedor.Location = new System.Drawing.Point(81, 116);
            this.btnVendedor.Name = "btnVendedor";
            this.btnVendedor.Size = new System.Drawing.Size(75, 31);
            this.btnVendedor.TabIndex = 5;
            this.btnVendedor.Text = "Vendedores";
            this.btnVendedor.UseVisualStyleBackColor = true;
            this.btnVendedor.Click += new System.EventHandler(this.btnVendedor_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(81, 153);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(75, 34);
            this.btnClientes.TabIndex = 6;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.Location = new System.Drawing.Point(81, 193);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(75, 34);
            this.btnFactura.TabIndex = 7;
            this.btnFactura.Text = "Factura";
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Detalle_Factura";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTiendaProducto
            // 
            this.btnTiendaProducto.Location = new System.Drawing.Point(67, 275);
            this.btnTiendaProducto.Name = "btnTiendaProducto";
            this.btnTiendaProducto.Size = new System.Drawing.Size(97, 37);
            this.btnTiendaProducto.TabIndex = 9;
            this.btnTiendaProducto.Text = "Tienda_Producto";
            this.btnTiendaProducto.UseVisualStyleBackColor = true;
            this.btnTiendaProducto.Click += new System.EventHandler(this.btnTiendaProducto_Click);
            // 
            // btnProductoVendedor
            // 
            this.btnProductoVendedor.Location = new System.Drawing.Point(57, 318);
            this.btnProductoVendedor.Name = "btnProductoVendedor";
            this.btnProductoVendedor.Size = new System.Drawing.Size(117, 29);
            this.btnProductoVendedor.TabIndex = 10;
            this.btnProductoVendedor.Text = "Producto_Vendedor";
            this.btnProductoVendedor.UseVisualStyleBackColor = true;
            this.btnProductoVendedor.Click += new System.EventHandler(this.btnProductoVendedor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Stored Procedures";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Reportes (Vistas)";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProductoVendedor);
            this.Controls.Add(this.btnTiendaProducto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnVendedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProducto);
            this.Controls.Add(this.btnVistas);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.btnTablas);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTablas;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Button btnVistas;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVendedor;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTiendaProducto;
        private System.Windows.Forms.Button btnProductoVendedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}