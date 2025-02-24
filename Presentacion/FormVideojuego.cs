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
                VideojuegoEntidad nuevoVideojuego = new VideojuegoEntidad
                {
                    IdVideojuego = int.Parse(txtIdVideojuego.Text),
                    Nombre = txtNombre.Text,
                    IdTipoVideojuego = (int)cmbTipoVideojuego.SelectedValue,
                    Plataforma = txtPlataforma.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    ClasificacionEdad = cmbClasificacionEdad.SelectedItem.ToString()
                };

                videojuegoLogica.AgregarVideojuego(nuevoVideojuego);
                MessageBox.Show("El videojuego ha sido registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifica que el código y precio sean numéricos.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
