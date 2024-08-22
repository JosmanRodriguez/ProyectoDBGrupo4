using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProyectoDBGrupo_4
{
    public partial class FrmDetalleFactura : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public FrmDetalleFactura()
        {
            InitializeComponent();
            CargarFacturas();
            CargarProductos();
        }
        private void CargarFacturas()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT numero FROM FACTURA";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    cmbFacturaNumero.DataSource = dt;
                    cmbFacturaNumero.DisplayMember = "numero";
                    cmbFacturaNumero.ValueMember = "numero";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar facturas: " + ex.Message);
                }
            }
        }
        private void CargarProductos()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT UPC FROM PRODUCTO";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    cmbProductoUPC.DataSource = dt;
                    cmbProductoUPC.DisplayMember = "UPC";
                    cmbProductoUPC.ValueMember = "UPC";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message);
                }
            }
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            int facturaNumero = (int)cmbFacturaNumero.SelectedValue;
            string productoUPC = cmbProductoUPC.SelectedValue.ToString();
            int cantidad = int.Parse(txtCantidad.Text);

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO DETALLE_FACTURA (id, factura_numero, producto_UPC, cantidad) VALUES (@id, @factura_numero, @producto_UPC, @cantidad)";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@factura_numero", facturaNumero);
                cmd.Parameters.AddWithValue("@producto_UPC", productoUPC);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Detalle de factura insertado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar detalle de factura: " + ex.Message);
                }
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            LeerDatos();
        }
        private void LeerDatos()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM DETALLE_FACTURA";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dgvDetalleFactura.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer datos: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            int facturaNumero = (int)cmbFacturaNumero.SelectedValue;
            string productoUPC = cmbProductoUPC.SelectedValue.ToString();
            int cantidad = int.Parse(txtCantidad.Text);

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE DETALLE_FACTURA SET factura_numero = @factura_numero, producto_UPC = @producto_UPC, cantidad = @cantidad WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@factura_numero", facturaNumero);
                cmd.Parameters.AddWithValue("@producto_UPC", productoUPC);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Detalle de factura actualizado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar detalle de factura: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM DETALLE_FACTURA WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Detalle de factura eliminado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar detalle de factura: " + ex.Message);
                }
            }
        }
    }
}
