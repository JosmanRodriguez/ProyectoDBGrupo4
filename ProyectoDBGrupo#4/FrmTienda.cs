using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProyectoDBGrupo_4
{
    public partial class FrmTienda : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public FrmTienda()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            string id = txtID.Text;
            string nombre = txtNombre.Text;
            string ubicaciones = txtUbicacion.Text;
            string horario = txtHorario.Text;

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO TIENDA (id, nombre, ubicaciones, horario) VALUES (@id, @nombre, @ubicaciones, @horario)";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@ubicaciones", ubicaciones);
                cmd.Parameters.AddWithValue("@horario", horario);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tienda insertada con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar tienda: " + ex.Message);
                }
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            LeerDatos();
        }
        private void configurarDataGridView()
        {
            dgvTiendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTiendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
        private void LeerDatos()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM TIENDA";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dgvTiendas.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer datos: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string nombre = txtNombre.Text;
            string ubicaciones = txtUbicacion.Text;
            string horario = txtHorario.Text;

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE TIENDA SET nombre = @nombre, ubicaciones = @ubicaciones, horario = @horario WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@ubicaciones", ubicaciones);
                cmd.Parameters.AddWithValue("@horario", horario);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tienda actualizada con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar tienda: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM TIENDA WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tienda eliminada con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar tienda: " + ex.Message);
                }
            }
        }
    }
}
