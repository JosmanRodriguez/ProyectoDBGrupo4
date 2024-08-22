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
    public partial class FrmTiendaProducto : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public FrmTiendaProducto()
        {
            InitializeComponent();
            CargarTiendas();
            CargarProductos();
        }

        private void CargarTiendas()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT id FROM TIENDA";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    cmbTiendaId.DataSource = dt;
                    cmbTiendaId.DisplayMember = "id";
                    cmbTiendaId.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar tiendas: " + ex.Message);
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
            int tiendaId = (int)cmbTiendaId.SelectedValue;
            string productoUPC = cmbProductoUPC.SelectedValue.ToString();

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO TIENDA_PRODUCTO (tienda_id, producto_UPC) VALUES (@tienda_id, @producto_UPC)";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@tienda_id", tiendaId);
                cmd.Parameters.AddWithValue("@producto_UPC", productoUPC);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro de tienda-producto insertado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar registro de tienda-producto: " + ex.Message);
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
                string query = "SELECT * FROM TIENDA_PRODUCTO";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dgvTiendaProducto.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer datos: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int tiendaId = (int)cmbTiendaId.SelectedValue;
            string productoUPC = cmbProductoUPC.SelectedValue.ToString();

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM TIENDA_PRODUCTO WHERE tienda_id = @tienda_id AND producto_UPC = @producto_UPC";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@tienda_id", tiendaId);
                cmd.Parameters.AddWithValue("@producto_UPC", productoUPC);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro de tienda-producto eliminado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar registro de tienda-producto: " + ex.Message);
                }
            }
        }
    }
}
