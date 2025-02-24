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

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.LogicaNegocio;

namespace _45GAMES4U_Inventario.Presentacion
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
                TipoVideojuegoEntidad nuevoTipo = new TipoVideojuegoEntidad
                {
                    IdTipoVideojuego = int.Parse(txtCodigoTipo.Text),
                    Descripcion = txtDescripcion.Text
                };

                tipoLogica.AgregarTipoVideojuego(nuevoTipo);
                MessageBox.Show("El tipo de videojuego ha sido registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un número válido para el ID del tipo de videojuego.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtCodigoTipo.Clear();
            txtDescripcion.Clear();
            txtCodigoTipo.Focus();
        }

        private void FormTipoVideojuego_Load(object sender, EventArgs e)
        {

        }
    }
}