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
    public partial class FrmVistas : Form
    {
        private string cadenaConexion = "server=proyectofinal.c1oql5dp6oz0.us-east-1.rds.amazonaws.com;user=admin;pwd=admin2024;database=Respaldo;SslMode=none;";

        public FrmVistas()
        {
            InitializeComponent();
            CargarVistas();
            cmbVistas.SelectedIndexChanged += cmbVistas_SelectedIndexChanged;
        }

        private void CargarVistas()
        {
            string[] vistas = new string[]
            {
                "inventario_productos",
                "compras_por_cliente",
                "historial_ventas_tienda",
                "top_20_productos_tienda",
                "top_20_productos_pais",
                "top_5_tiendas_ventas_anio",
                "tiendas_coca_mas_que_pepsi",
                "top_3_productos_con_leche"
            };

            cmbVistas.DataSource = vistas;
        }

        private void cmbVistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVistas.SelectedItem != null)
            {
                string vistaSeleccionada = cmbVistas.SelectedItem.ToString();
                MostrarVistaEnGrid(vistaSeleccionada);
            }
        }

        private void MostrarVistaEnGrid(string vista)
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = $"SELECT * FROM {vista};";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dgvVistas.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar vista: " + ex.Message);
                }
            }
        }

        private void FrmVistas_Load(object sender, EventArgs e)
        {

        }
    }
}
