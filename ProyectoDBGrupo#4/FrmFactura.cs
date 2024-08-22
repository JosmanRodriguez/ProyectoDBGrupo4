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

    public partial class FrmFactura : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public FrmFactura()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT id, CONCAT(nombre1, ' ', nombre2, ' ', apellido1, ' ', apellido2) AS nombreCompleto FROM CLIENTE";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);

                    cmbClientes.DisplayMember = "nombreCompleto"; // Muestra el nombre completo en el ComboBox
                    cmbClientes.ValueMember = "id"; // El valor asociado a cada ítem es el ID del cliente
                    cmbClientes.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message);
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int numero = int.Parse(txtNumero.Text);
            DateTime fecha = dtpFecha.Value;
            decimal subtotal = decimal.Parse(txtSubtotal.Text);
            decimal isv = decimal.Parse(txtISV.Text);
            decimal total = decimal.Parse(txtTotal.Text);
            int clienteId = (int)cmbClientes.SelectedValue; // Obtiene el ID del cliente seleccionado

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO FACTURA (numero, fecha, subtotal, ISV, TOTAL, cliente_id) VALUES (@numero, @fecha, @subtotal, @isv, @total, @cliente_id)";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@subtotal", subtotal);
                cmd.Parameters.AddWithValue("@isv", isv);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@cliente_id", clienteId);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Factura insertada con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar factura: " + ex.Message);
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
                string query = "SELECT * FROM FACTURA";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, myCon);
                DataTable dt = new DataTable();

                try
                {
                    myCon.Open();
                    adapter.Fill(dt);
                    dgvFactura.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer datos: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int numero = int.Parse(txtNumero.Text);
            DateTime fecha = dtpFecha.Value;
            decimal subtotal = decimal.Parse(txtSubtotal.Text);
            decimal isv = decimal.Parse(txtISV.Text);
            decimal total = decimal.Parse(txtTotal.Text);
            int clienteId = (int)cmbClientes.SelectedValue; // Obtiene el ID del cliente seleccionado

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE FACTURA SET fecha = @fecha, subtotal = @subtotal, ISV = @isv, TOTAL = @total, cliente_id = @cliente_id WHERE numero = @numero";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@subtotal", subtotal);
                cmd.Parameters.AddWithValue("@isv", isv);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@cliente_id", clienteId);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Factura actualizada con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar factura: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int numero = int.Parse(txtNumero.Text);

            using (MySqlConnection myCon = new MySqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM FACTURA WHERE numero = @numero";
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.Parameters.AddWithValue("@numero", numero);

                try
                {
                    myCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Factura eliminada con éxito");
                    LeerDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar factura: " + ex.Message);
                }
            }
        }
    }
}
