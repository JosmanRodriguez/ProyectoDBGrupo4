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
    public partial class FrmCliente : Form
    {
        private string cadenaConexion = "server=proyectofinal.c1oql5dp6oz0.us-east-1.rds.amazonaws.com;user=admin;pwd=admin2024;database=Respaldo;SslMode=none;";

        public FrmCliente()
        {
            InitializeComponent();
            configurarDataGridView();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string nombre1 = txtNombre1.Text;
            string nombre2 = txtNombre2.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string correoElectronico = txtCorreoElectronico.Text;

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO CLIENTE (id, nombre1, nombre2, apellido1, apellido2, correoElectronico) VALUES (@id, @nombre1, @nombre2, @apellido1, @apellido2, @correoElectronico)";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre1", nombre1);
                cmd.Parameters.AddWithValue("@nombre2", nombre2);
                cmd.Parameters.AddWithValue("@apellido1", apellido1);
                cmd.Parameters.AddWithValue("@apellido2", apellido2);
                cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente insertado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar cliente: " + ex.Message);
                }
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            LeerDatos();
        }
        private void configurarDataGridView()
        {
            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
        private void LeerDatos()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM CLIENTE";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dgvCliente.DataSource = dt;
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
            string nombre1 = txtNombre1.Text;
            string nombre2 = txtNombre2.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string correoElectronico = txtCorreoElectronico.Text;

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE CLIENTE SET nombre1 = @nombre1, nombre2 = @nombre2, apellido1 = @apellido1, apellido2 = @apellido2, correoElectronico = @correoElectronico WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre1", nombre1);
                cmd.Parameters.AddWithValue("@nombre2", nombre2);
                cmd.Parameters.AddWithValue("@apellido1", apellido1);
                cmd.Parameters.AddWithValue("@apellido2", apellido2);
                cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente actualizado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM CLIENTE WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente eliminado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
        }
    }
}
