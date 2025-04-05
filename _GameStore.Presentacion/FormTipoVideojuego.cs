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
// Formulario para gestionar los Tipos de Videojuegos

using _GameStore.Entidades;
using _GameStore.Logica;

namespace _GameStore.Presentacion
{
    public partial class FormTipoVideojuego : Form
    {
        private TipoVideojuegoLogica tipoLogica = new TipoVideojuegoLogica();

        public FormTipoVideojuego()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el ID sea un número válido antes de la conversión
                if (!int.TryParse(txtCodigoTipo.Text, out int id))
                {
                    MessageBox.Show("Por favor, ingrese un número válido para el ID del tipo de videojuego.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TipoVideojuegoEntidad nuevoTipo = new TipoVideojuegoEntidad
                {
                    IdTipoVideojuego = id,
                    Nombre = txtNombreTipo.Text,
                    Descripcion = txtDescripcion.Text
                };

                // Llamar al método y capturar el mensaje de respuesta
                string mensaje = tipoLogica.AgregarTipoVideojuego(nuevoTipo);

                // Mostrar el mensaje al usuario
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Solo limpiar si el registro fue exitoso
                if (mensaje == "El tipo de videojuego se ha registrado correctamente.")
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
                dgvTiposVideojuego.DataSource = tipoLogica.ObtenerTodosTipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtNombreTipo.Clear();
            txtCodigoTipo.Clear();
            txtDescripcion.Clear();
            txtCodigoTipo.Focus();
            txtNombreTipo.Focus();
        }

        private void FormTipoVideojuego_Load(object sender, EventArgs e)
        {
            txtNombreTipo.Focus();
        }
    }
}