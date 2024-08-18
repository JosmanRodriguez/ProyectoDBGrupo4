using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDBGrupo_4
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnTablas_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmTienda
            FrmTienda frmTienda = new FrmTienda();

            // Mostrar el formulario FrmTienda
            frmTienda.Show();

            // Opcional: Cerrar el formulario principal si no lo necesitas más
            // this.Close();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario
            FrmProducto frmProducto = new FrmProducto();

            // Mostrar el formulario FrmTienda
            frmProducto.Show();

            // Opcional: Cerrar el formulario principal si no lo necesitas más
            // this.Close();
        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario
            FrmVendedor frmVendedor = new FrmVendedor();

            // Mostrar el formulario
            frmVendedor.Show();

            // Opcional: Cerrar el formulario principal si no se necesitas más
            // this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();

            // Mostrar el formulario
            frmCliente.Show();

            // Opcional: Cerrar el formulario principal si no se necesitas más
            // this.Close();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            FrmFactura frmFactura = new FrmFactura();

            // Mostrar el formulario
            frmFactura.Show();

            // Opcional: Cerrar el formulario principal si no se necesitas más
            // this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDetalleFactura frmDetalleFactura = new FrmDetalleFactura();

            // Mostrar el formulario
            frmDetalleFactura.Show();

            // Opcional: Cerrar el formulario principal si no se necesitas más
            // this.Close();
        }

        private void btnTiendaProducto_Click(object sender, EventArgs e)
        {
            FrmTiendaProducto frmTiendaProducto = new FrmTiendaProducto();

            // Mostrar el formulario
            frmTiendaProducto.Show();

            // Opcional: Cerrar el formulario principal si no se necesitas más
            // this.Close();
        }

        private void btnProductoVendedor_Click(object sender, EventArgs e)
        {
            FrmProductoVendedor frmProductoVendedor = new FrmProductoVendedor();

            // Mostrar el formulario
            frmProductoVendedor.Show();

            // Opcional: Cerrar el formulario principal si no se necesitas más
            // this.Close();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            FrmProcedimientosAlmacenados frmProcedimientosAlmacenados = new FrmProcedimientosAlmacenados();

            // Mostrar el formulario
            frmProcedimientosAlmacenados.Show();

            // Opcional: Cerrar el formulario principal si no se necesitas más
            // this.Close();
        }

        private void btnVistas_Click(object sender, EventArgs e)
        {
            FrmVistas frmVistas = new FrmVistas();

            // Mostrar el formulario
            frmVistas.Show();

            // Opcional: Cerrar el formulario principal si no se necesitas más
            // this.Close();
        }
    }
}
