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
    public partial class FrmVendedor : Form
    {
        private string cadenaConexion = "server=proyectofinal.c1oql5dp6oz0.us-east-1.rds.amazonaws.com;user=admin;pwd=admin2024;database=Respaldo;SslMode=none;";

        public FrmVendedor()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string nombre1 = txtNombre1.Text;
            string nombre2 = txtNombre2.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO VENDEDOR (id, nombre1, nombre2, apellido1, apellido2) VALUES (@id, @nombre1, @nombre2, @apellido1, @apellido2)";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre1", nombre1);
                cmd.Parameters.AddWithValue("@nombre2", nombre2);
                cmd.Parameters.AddWithValue("@apellido1", apellido1);
                cmd.Parameters.AddWithValue("@apellido2", apellido2);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendedor insertado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar vendedor: " + ex.Message);
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
                string query = "SELECT * FROM VENDEDOR";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dgvVendedor.DataSource = dt;
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

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE VENDEDOR SET nombre1 = @nombre1, nombre2 = @nombre2, apellido1 = @apellido1, apellido2 = @apellido2 WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre1", nombre1);
                cmd.Parameters.AddWithValue("@nombre2", nombre2);
                cmd.Parameters.AddWithValue("@apellido1", apellido1);
                cmd.Parameters.AddWithValue("@apellido2", apellido2);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendedor actualizado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar vendedor: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM VENDEDOR WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendedor eliminado con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar vendedor: " + ex.Message);
                }
            }
        }
    }
}
