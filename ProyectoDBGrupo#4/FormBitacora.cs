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
    public partial class FormBitacora : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public FormBitacora()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarBitacora();
        }

        private void MostrarBitacora()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM bitacora";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer datos: " + ex.Message);
                }
            }

        }
    }
}
