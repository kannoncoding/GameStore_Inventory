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
// Formulario para gestionar el Inventario de Videojuegos por Tienda

using GameStore_Inventory.Entidad;
using GameStore_Inventory.LogicaNegocio;

namespace GameStore_Inventory.Presentacion
{
    public partial class FormInventario : Form
    {
        private VideojuegosXTiendaLogica inventarioLogica = new VideojuegosXTiendaLogica();
        private TiendaLogica tiendaLogica = new TiendaLogica();
        private VideojuegoLogica videojuegoLogica = new VideojuegoLogica();

        public FormInventario()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            cmbTienda.DataSource = tiendaLogica.ObtenerTodasTiendas();
            cmbTienda.DisplayMember = "Nombre";
            cmbTienda.ValueMember = "IdTienda";

            cmbVideojuego.DataSource = videojuegoLogica.ObtenerTodosVideojuegos();
            cmbVideojuego.DisplayMember = "Nombre";
            cmbVideojuego.ValueMember = "IdVideojuego";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                VideojuegosXTiendaEntidad nuevoInventario = new VideojuegosXTiendaEntidad
                {
                    IdTienda = (int)cmbTienda.SelectedValue,
                    IdVideojuego = (int)cmbVideojuego.SelectedValue,
                    Stock = int.Parse(txtCantidad.Text)
                };

                string resultado = inventarioLogica.AgregarInventario(nuevoInventario);
                MessageBox.Show(resultado, "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("El stock debe ser un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                dgvInventario.DataSource = inventarioLogica.ObtenerTodoInventario();
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
                int idTienda = (int)cmbTienda.SelectedValue;
                int idVideojuego = (int)cmbVideojuego.SelectedValue;

                inventarioLogica.EliminarVideojuegoXTienda(idTienda, idVideojuego);
                MessageBox.Show("Inventario eliminado exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cmbTienda.SelectedIndex = -1;
            cmbVideojuego.SelectedIndex = -1;
            txtCantidad.Clear();
            cmbTienda.Focus();
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {

        }
    }
}