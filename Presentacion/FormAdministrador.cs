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

using GameStore_Inventory.Entidad;
using GameStore_Inventory.LogicaNegocio;

namespace GameStore_Inventory.Presentacion
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
        }

        // Método para cargar las tiendas en el ComboBox
        private void CargarComboTienda()
        {
            TiendaEntidad[] tiendas = tiendaLogica.ObtenerTodasTiendas(); // Obtener tiendas
            cmbTienda.DataSource = tiendas; // Asignar datos al ComboBox
            cmbTienda.DisplayMember = "Nombre"; // Mostrar el nombre de la tienda
            cmbTienda.ValueMember = "IdTienda"; // Guardar el ID de la tienda
            cmbTienda.SelectedIndex = -1; // Para que inicie sin selección
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
            try
            {
                dgvAdministradores.DataSource = administradorLogica.ObtenerTodosAdministradores(); // Obtener datos y mostrarlos en DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}