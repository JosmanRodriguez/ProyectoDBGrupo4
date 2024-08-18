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
    public partial class FrmProcedimientosAlmacenados : Form
    {
        private string cadenaConexion = "server=proyectofinal.c1oql5dp6oz0.us-east-1.rds.amazonaws.com;user=admin;pwd=admin2024;database=Respaldo;SslMode=none;";

        public FrmProcedimientosAlmacenados()
        {
            InitializeComponent();
            CargarProcedimientos();
            cmbProcedimientos.SelectedIndexChanged += ComboBoxProcedimientos_SelectedIndexChanged;
        }
        private void CargarProcedimientos()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SHOW PROCEDURE STATUS WHERE Db = 'Respaldo';";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    cmbProcedimientos.DisplayMember = "Name";
                    cmbProcedimientos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar procedimientos: " + ex.Message);
                }
            }
        }
        private void ComboBoxProcedimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProcedimientos.SelectedItem != null)
            {
                string procedimiento = ((DataRowView)cmbProcedimientos.SelectedItem)["Name"].ToString();
                MostrarCodigoProcedimiento(procedimiento);
            }
        }

        private void MostrarCodigoProcedimiento(string procedimiento)
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = $"SHOW CREATE PROCEDURE {procedimiento};";
                MySqlCommand cmd = new MySqlCommand(query, myCon);

                try
                {
                    myCon.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBoxCodigo.Text = reader["Create Procedure"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar código del procedimiento: " + ex.Message);
                }
            }
        }
        private void FrmProcedimientosAlmacenados_Load(object sender, EventArgs e)
        {

        }
    }
}
