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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCodigoTipo.Text, out int id))
                {
                    MessageBox.Show("Por favor, ingrese un ID válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TipoVideojuegoEntidad tipo = new TipoVideojuegoEntidad
                {
                    IdTipoVideojuego = id,
                    Nombre = txtNombreTipo.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };

                string mensaje = tipoLogica.ActualizarTipo(tipo);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje.Contains("actualizado correctamente"))
                {
                    dgvTiposVideojuego.DataSource = tipoLogica.ObtenerTodosTipos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTiposVideojuego.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un tipo de videojuego para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obtener el ID desde la fila seleccionada
                int id = Convert.ToInt32(dgvTiposVideojuego.SelectedRows[0].Cells["IdTipoVideojuego"].Value);

                // Confirmación con el usuario
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este tipo de videojuego?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                // Llamar a la lógica para eliminar
                string mensaje = tipoLogica.EliminarTipoPorId(id);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la tabla si se eliminó correctamente
                if (mensaje.Contains("eliminado correctamente"))
                {
                    dgvTiposVideojuego.DataSource = tipoLogica.ObtenerTodosTipos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvTiposVideojuego_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse que no sea header
            {
                DataGridViewRow fila = dgvTiposVideojuego.Rows[e.RowIndex];

                txtCodigoTipo.Text = fila.Cells["IdTipoVideojuego"].Value.ToString();
                txtNombreTipo.Text = fila.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
            }
        }


        private void FormTipoVideojuego_Load(object sender, EventArgs e)
        {
            txtNombreTipo.Focus();
        }

        
    }
}