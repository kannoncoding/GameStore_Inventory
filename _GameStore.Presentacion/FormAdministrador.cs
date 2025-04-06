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
// Formulario para gestionar Administradores de Tiendas

using _GameStore.Entidades;
using _GameStore.Logica;

namespace _GameStore.Presentacion
{
    public partial class FormAdministrador : Form
    {
        // Instancia de la lógica de negocio para manejar administradores
        private AdministradorLogica administradorLogica = new AdministradorLogica();
        // Instancia de la lógica de negocio para manejar tiendas
        private TiendaLogica tiendaLogica = new TiendaLogica();

        // Constructor del formulario
        public FormAdministrador()
        {
            InitializeComponent();
        }

        // Evento que se ejecuta al cargar el formulario
        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            CargarComboTienda(); // Cargar las tiendas en el ComboBox
            CargarAdministradores();
        }

        // Método para cargar las tiendas en el ComboBox
        private void CargarComboTienda()
        {
            try
            {
                var todasLasTiendas = tiendaLogica.ObtenerTodasTiendas();
                var administradores = administradorLogica.ObtenerTodosLosAdministradores();

                // Filtrar tiendas que aún no tienen administrador asignado
                var tiendasDisponibles = todasLasTiendas
                    .Where(t => !administradores.Any(a => a.IdTienda == t.IdTienda))
                    .ToList();

                cmbTienda.DataSource = tiendasDisponibles;
                cmbTienda.DisplayMember = "Nombre";
                cmbTienda.ValueMember = "IdTienda";
                cmbTienda.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tiendas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarAdministradores()
        {
            try
            {
                var admins = administradorLogica.ObtenerTodosLosAdministradores();
                dgvAdministradores.DataSource = null;
                dgvAdministradores.AutoGenerateColumns = false;
                dgvAdministradores.ReadOnly = true;
                dgvAdministradores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvAdministradores.Columns.Clear();

                dgvAdministradores.Columns.Add("IdAdministrador", "ID");
                dgvAdministradores.Columns["IdAdministrador"].DataPropertyName = "IdAdministrador";

                dgvAdministradores.Columns.Add("Nombre", "Nombre");
                dgvAdministradores.Columns["Nombre"].DataPropertyName = "Nombre";

                dgvAdministradores.Columns.Add("Apellido", "Apellido");
                dgvAdministradores.Columns["Apellido"].DataPropertyName = "Apellido";

                dgvAdministradores.Columns.Add("Telefono", "Teléfono");
                dgvAdministradores.Columns["Telefono"].DataPropertyName = "Telefono";

                dgvAdministradores.Columns.Add("Correo", "Correo");
                dgvAdministradores.Columns["Correo"].DataPropertyName = "Correo";

                dgvAdministradores.Columns.Add("Identificacion", "Identificación");
                dgvAdministradores.Columns["Identificacion"].DataPropertyName = "Identificacion";

                dgvAdministradores.Columns.Add("IdTienda", "ID Tienda");
                dgvAdministradores.Columns["IdTienda"].DataPropertyName = "IdTienda";

                dgvAdministradores.DataSource = admins;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para registrar un administrador
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el ID del administrador sea un número
                if (!int.TryParse(txtIdAdministrador.Text, out int idAdmin))
                {
                    MessageBox.Show("El ID del administrador debe ser un número.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que se ingresen el nombre y el apellido
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre y el apellido.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que se seleccione una tienda
                if (cmbTienda.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una tienda asignada.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar si el ID del administrador ya existe
                if (administradorLogica.BuscarAdministradorPorId(idAdmin) != null)
                {
                    MessageBox.Show("Ya existe un administrador con este ID.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la tienda seleccionada del ComboBox
                TiendaEntidad tiendaSeleccionada = (TiendaEntidad)cmbTienda.SelectedItem;

                // Crear un nuevo objeto de AdministradorEntidad con los datos ingresados
                AdministradorEntidad nuevoAdmin = new AdministradorEntidad
                {
                    IdAdministrador = idAdmin,
                    Identificacion = txtIdAdministrador.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    IdTienda = tiendaSeleccionada.IdTienda // Asignar la tienda
                };

                // Llamar a la lógica de negocio para registrar el administrador
                string mensaje = administradorLogica.AgregarAdministrador(nuevoAdmin);
                MessageBox.Show(mensaje, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos si el registro fue exitoso
                if (mensaje.Contains("registrado correctamente"))
                {
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para consultar todos los administradores
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarAdministradores();
        }

        // Evento para eliminar un administrador
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtIdAdministrador.Text, out int id))
                {
                    administradorLogica.EliminarAdministrador(id); // Llamar a la lógica para eliminar
                    MessageBox.Show("Administrador eliminado exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); // Limpiar los campos
                    CargarAdministradores();
                }
                else
                {
                    MessageBox.Show("Ingrese un ID válido para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para limpiar los campos del formulario
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Evento para cerrar el formulario
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAdministradores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAdministradores.Rows[e.RowIndex];

                txtIdAdministrador.Text = fila.Cells["IdAdministrador"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtIdAdministrador.Text = fila.Cells["Identificacion"].Value.ToString();

                // Buscar la tienda y asignarla al combo
                int idTienda = Convert.ToInt32(fila.Cells["IdTienda"].Value);
                cmbTienda.SelectedValue = idTienda;
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtIdAdministrador.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cmbTienda.SelectedIndex = -1; // Restablecer la selección del ComboBox
            txtIdAdministrador.Focus(); // Enfocar en el campo de ID
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdAdministrador.Text, out int idAdmin))
                {
                    MessageBox.Show("El ID del administrador debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AdministradorEntidad admin = new AdministradorEntidad
                {
                    IdAdministrador = idAdmin,
                    Identificacion = txtIdAdministrador.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    IdTienda = (int)cmbTienda.SelectedValue
                };

                string mensaje = administradorLogica.ActualizarAdministrador(admin);
                MessageBox.Show(mensaje, "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje.Contains("actualizado correctamente"))
                {
                    LimpiarCampos();
                    CargarAdministradores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}