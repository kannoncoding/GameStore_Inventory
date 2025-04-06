using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// UNED
// Curso de Programación Avanzada
// Proyecto: 45GAMES4U - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre
// Formulario para gestionar Clientes

using _GameStore.Entidades;
using _GameStore.Logica;

namespace _GameStore.Presentacion
{
    public partial class FormCliente : Form
    {
        private ClienteLogica clienteLogica = new ClienteLogica();

        public FormCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(txtIdCliente.Text); // Capturar el ID del cliente

                ClienteEntidad nuevoCliente = new ClienteEntidad
                {
                    IdCliente = idCliente, // Se asigna el ID
                    Identificacion = txtIdCliente.Text, // También se usa como Identificación
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text
                };

                string mensaje = clienteLogica.AgregarCliente(nuevoCliente);

                MessageBox.Show(mensaje, mensaje.Contains("correctamente") ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    mensaje.Contains("correctamente") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (mensaje.Contains("correctamente"))
                {
                    LimpiarCampos();
                    ActualizarDataGridView(); // Actualizar la tabla
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifica que el ID sea numérico.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para actualizar la tabla de clientes después de registrar
        private void ActualizarDataGridView()
        {
            dgvClientes.DataSource = null;
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add("IdCliente", "ID");
            dgvClientes.Columns["IdCliente"].DataPropertyName = "IdCliente";

            dgvClientes.Columns.Add("Identificacion", "Identificación");
            dgvClientes.Columns["Identificacion"].DataPropertyName = "Identificacion";

            dgvClientes.Columns.Add("Nombre", "Nombre");
            dgvClientes.Columns["Nombre"].DataPropertyName = "Nombre";

            dgvClientes.Columns.Add("Apellido", "Apellido");
            dgvClientes.Columns["Apellido"].DataPropertyName = "Apellido";

            dgvClientes.Columns.Add("Telefono", "Teléfono");
            dgvClientes.Columns["Telefono"].DataPropertyName = "Telefono";

            dgvClientes.Columns.Add("Correo", "Correo");
            dgvClientes.Columns["Correo"].DataPropertyName = "Correo";

            dgvClientes.Columns.Add("FechaRegistro", "Fecha de Registro");
            dgvClientes.Columns["FechaRegistro"].DataPropertyName = "FechaRegistro";

            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvClientes.DataSource = clienteLogica.ObtenerTodosClientes();
        }


        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                txtIdCliente.Text = fila.Cells["IdCliente"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvClientes.DataSource = clienteLogica.ObtenerTodosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtIdCliente.Text);
                clienteLogica.EliminarCliente(id);
                MessageBox.Show("Cliente eliminado exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtIdCliente.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtIdCliente.Focus();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdCliente.Text, out int idCliente))
                {
                    MessageBox.Show("El ID debe ser un número válido.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClienteEntidad cliente = new ClienteEntidad
                {
                    IdCliente = idCliente,
                    Identificacion = txtIdCliente.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    FechaRegistro = DateTime.Now // O mantener su valor original si se está editando
                };

                string mensaje = clienteLogica.ActualizarCliente(cliente);

                MessageBox.Show(mensaje, mensaje.Contains("correctamente") ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    mensaje.Contains("correctamente") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (mensaje.Contains("correctamente"))
                {
                    LimpiarCampos();
                    ActualizarDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}