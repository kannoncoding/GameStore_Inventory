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
// Formulario para gestionar Tiendas


using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.LogicaNegocio;

namespace _45GAMES4U_Inventario.Presentacion
{
    public partial class FormTienda : Form
    {
        private TiendaLogica tiendaLogica = new TiendaLogica();

        public FormTienda()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                TiendaEntidad nuevaTienda = new TiendaEntidad
                {
                    IdTienda = int.Parse(txtIdTienda.Text),
                    Nombre = txtNombreTienda.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text
                };

                tiendaLogica.AgregarTienda(nuevaTienda);
                MessageBox.Show("Tienda registrada exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifica que el código sea numérico.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                dgvTiendas.DataSource = tiendaLogica.ObtenerTodasTiendas();
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
                int id = int.Parse(txtIdTienda.Text);
                tiendaLogica.EliminarTienda(id);
                MessageBox.Show("Tienda eliminada exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtIdTienda.Clear();
            txtNombreTienda.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtIdTienda.Focus();
        }

        private void FormTienda_Load(object sender, EventArgs e)
        {

        }
    }
}