using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProyectoDBGrupo_4
{
    public partial class FrmProductoVendedor : Form
    {
        private string cadenaConexion = "server=proyectofinal.c1oql5dp6oz0.us-east-1.rds.amazonaws.com;user=admin;pwd=admin2024;database=Respaldo;SslMode=none;";
        public FrmProductoVendedor()
        {
            InitializeComponent();
            CargarProductos();
            CargarVendedores();
        }

        private void CargarProductos()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT UPC, nombre FROM PRODUCTO";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    cmbProducto.DisplayMember = "nombre";
                    cmbProducto.ValueMember = "UPC";
                    cmbProducto.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message);
                }
            }
        }

        private void CargarVendedores()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT id, CONCAT(nombre1, ' ', nombre2, ' ', apellido1, ' ', apellido2) AS vendedor FROM VENDEDOR";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    cmbVendedor.DisplayMember = "vendedor";
                    cmbVendedor.ValueMember = "id";
                    cmbVendedor.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar vendedores: " + ex.Message);
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string productoUPC = cmbProducto.SelectedValue.ToString();
            int vendedorId = (int)cmbVendedor.SelectedValue;

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO PRODUCTO_VENDEDOR (producto_UPC, vendedor_id) VALUES (@productoUPC, @vendedorId)";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@productoUPC", productoUPC);
                cmd.Parameters.AddWithValue("@vendedorId", vendedorId);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto-Vendedor insertado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar Producto-Vendedor: " + ex.Message);
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
                string query = "SELECT * FROM PRODUCTO_VENDEDOR";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dgvProductoVendedor.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer datos: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string productoUPC = cmbProducto.SelectedValue.ToString();
            int vendedorId = (int)cmbVendedor.SelectedValue;

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM PRODUCTO_VENDEDOR WHERE producto_UPC = @productoUPC AND vendedor_id = @vendedorId";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@productoUPC", productoUPC);
                cmd.Parameters.AddWithValue("@vendedorId", vendedorId);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto-Vendedor eliminado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar Producto-Vendedor: " + ex.Message);
                }
            }
        }
    }
}
