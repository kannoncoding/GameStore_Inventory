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

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.LogicaNegocio;

namespace _45GAMES4U_Inventario.Presentacion
{
    public partial class FormAdministrador : Form
    {
        private AdministradorLogica administradorLogica = new AdministradorLogica();

        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void CargarComboTienda()
        {
            // Obtener todas las tiendas de la lógica de negocios
            TiendaLogica tiendaLogica = new TiendaLogica();
            TiendaEntidad[] tiendas = tiendaLogica.ObtenerTodasTiendas();

            cmbTienda.DataSource = tiendas;
            cmbTienda.DisplayMember = "Nombre"; // Mostrar el nombre de la tienda
            cmbTienda.ValueMember = "IdTienda"; // Guardar el ID de la tienda
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdAdministrador.Text, out int idAdmin))
                {
                    MessageBox.Show("El ID del administrador debe ser un número.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre y el apellido.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                // Obtener la tienda seleccionada
                TiendaEntidad tiendaSeleccionada = (TiendaEntidad)cmbTienda.SelectedItem;

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

                string mensaje = administradorLogica.AgregarAdministrador(nuevoAdmin);
                MessageBox.Show(mensaje, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje == "El administrador se ha registrado correctamente.")
                {
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAdministradores.DataSource = administradorLogica.ObtenerTodosAdministradores();
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
                int id = int.Parse(txtIdAdministrador.Text);
                administradorLogica.EliminarAdministrador(id);
                MessageBox.Show("Administrador eliminado exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtIdAdministrador.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtIdAdministrador.Focus();
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            CargarComboTienda();
        }
    }
}