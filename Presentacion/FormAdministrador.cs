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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                AdministradorEntidad nuevoAdmin = new AdministradorEntidad
                {
                    IdAdministrador = int.Parse(txtIdAdministrador.Text),
                    Identificacion = txtIdAdministrador.Text,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text
                };

                administradorLogica.AgregarAdministrador(nuevoAdmin);
                MessageBox.Show("Administrador registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
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
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtIdAdministrador.Focus();
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {

        }
    }
}
