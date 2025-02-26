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
// Formulario para gestionar Videojuegos con Clasificación por Edad


using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.LogicaNegocio;

namespace _45GAMES4U_Inventario.Presentacion
{
    public partial class FormVideojuego : Form
    {
        private VideojuegoLogica videojuegoLogica = new VideojuegoLogica();
        private TipoVideojuegoLogica tipoVideojuegoLogica = new TipoVideojuegoLogica();

        public FormVideojuego()
        {
            InitializeComponent();
            CargarComboTipos();
            CargarComboClasificacion();
        }

        private void CargarComboTipos()
        {
            cmbTipoVideojuego.DataSource = tipoVideojuegoLogica.ObtenerTodosTipos();
            cmbTipoVideojuego.DisplayMember = "Descripcion";
            cmbTipoVideojuego.ValueMember = "IdTipoVideojuego";
        }

        private void CargarComboClasificacion()
        {
            cmbClasificacionEdad.Items.Clear();
            cmbClasificacionEdad.Items.Add("Todos (E)");
            cmbClasificacionEdad.Items.Add("Mayores de 10 años (E10+)");
            cmbClasificacionEdad.Items.Add("Adolescentes (T)");
            cmbClasificacionEdad.Items.Add("Maduros (M)");
            cmbClasificacionEdad.Items.Add("Adultos (AO)");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el ID sea un número válido antes de la conversión
                if (!int.TryParse(txtIdVideojuego.Text, out int id))
                {
                    MessageBox.Show("Por favor, ingrese un número válido para el ID del videojuego.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtPrecio.Text, out int precio))
                {
                    MessageBox.Show("Por favor, ingrese un número válido para el precio del videojuego.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VideojuegoEntidad nuevoVideojuego = new VideojuegoEntidad
                {
                    IdVideojuego = id,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Plataforma = txtPlataforma.Text,
                    Precio = precio,
                    IdTipoVideojuego = (int)cmbTipoVideojuego.SelectedValue,
                    ClasificacionEdad = cmbClasificacionEdad.Text
                };

                // Llamar al método y capturar el mensaje de respuesta
                string mensaje = videojuegoLogica.AgregarVideojuego(nuevoVideojuego);

                // Mostrar el mensaje al usuario
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Solo limpiar si el registro fue exitoso
                if (mensaje == "El videojuego se ha registrado correctamente.")
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
                dgvVideojuegos.DataSource = videojuegoLogica.ObtenerTodosVideojuegos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtIdVideojuego.Clear();
            txtDescripcion.Clear();
            txtNombre.Clear();
            txtPlataforma.Clear();
            txtPrecio.Clear();
            cmbTipoVideojuego.SelectedIndex = -1;
            cmbClasificacionEdad.SelectedIndex = -1;
            txtIdVideojuego.Focus();
        }

        private void FormVideojuego_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
