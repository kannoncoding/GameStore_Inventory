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

using GameStore_Inventory.Entidad;
using GameStore_Inventory.LogicaNegocio;

namespace GameStore_Inventory.Presentacion
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
                // Validar que el ID sea un número válido antes de la conversión
                if (!int.TryParse(txtIdTienda.Text, out int id))
                {
                    MessageBox.Show("Por favor, ingrese un número válido para el ID de la tienda.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombreTienda = txtNombreTienda.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                // Crear la nueva tienda
                TiendaEntidad nuevaTienda = new TiendaEntidad
                {
                    IdTienda = id,
                    Nombre = nombreTienda,
                    Direccion = direccion,
                    Telefono = telefono
                };

                // Llamar al método y capturar el mensaje de respuesta
                string mensaje = tiendaLogica.AgregarTienda(nuevaTienda);

                // Mostrar el mensaje al usuario
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Solo limpiar si el registro fue exitoso
                if (mensaje == "La tienda se ha registrado correctamente.")
                {
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                TiendaEntidad[] tiendas = tiendaLogica.ObtenerTodasTiendas();

                if (tiendas.Length == 0)
                {
                    MessageBox.Show("No hay tiendas registradas.", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvTiendas.DataSource = null;  // Resetear DataGridView
                dgvTiendas.DataSource = tiendas;

                // Ajustar columnas
                dgvTiendas.AutoResizeColumns();
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