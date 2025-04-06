using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _GameStore.Datos;


// UNED
// Curso de Programación Avanzada
// Proyecto: 45GAMES4U - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre
// Formulario para gestionar Videojuegos con Clasificación por Edad


using _GameStore.Entidades;
using _GameStore.Logica;

namespace _GameStore.Presentacion
{
    public partial class FormVideojuego : Form
    {
        private VideojuegoLogica videojuegoLogica = new VideojuegoLogica();
        private TipoVideojuegoLogica tipoVideojuegoLogica = new TipoVideojuegoLogica();

        public FormVideojuego()
        {
            InitializeComponent();

        }

        private void CargarComboTipos()
        {
            try
            {
                TipoVideojuegoDatos tipoDatos = new TipoVideojuegoDatos();
                var lista = tipoDatos.ObtenerTodos();

                cmbTipoVideojuego.DataSource = lista;
                cmbTipoVideojuego.DisplayMember = "Nombre";       // Lo que se muestra
                cmbTipoVideojuego.ValueMember = "IdTipoVideojuego"; // Lo que se usa internamente
                cmbTipoVideojuego.SelectedIndex = -1; // Para que no aparezca ninguno seleccionado al cargar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de videojuegos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarComboClasificacion()
        {
            cmbClasificacionEdad.Items.Clear();
            cmbClasificacionEdad.Items.Add("E");
            cmbClasificacionEdad.Items.Add("E10+");
            cmbClasificacionEdad.Items.Add("T");
            cmbClasificacionEdad.Items.Add("M");
            cmbClasificacionEdad.Items.Add("AO");
            cmbClasificacionEdad.SelectedIndex = -1;

            cmbClasificacionEdad.SelectedIndexChanged -= cmbClasificacionEdad_SelectedIndexChanged;
            cmbClasificacionEdad.SelectedIndexChanged += cmbClasificacionEdad_SelectedIndexChanged;


            // Asignar el ToolTip inicial (vacío o el predeterminado)
            toolTipClasificacion.SetToolTip(cmbClasificacionEdad, "Seleccione una clasificación por edad.");
        }

        private void cmbClasificacionEdad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClasificacionEdad.SelectedItem != null &&
                descripcionesClasificacion.TryGetValue(cmbClasificacionEdad.SelectedItem.ToString(), out string descripcion))
            {
                toolTipClasificacion.SetToolTip(cmbClasificacionEdad, descripcion);
            }
            else
            {
                toolTipClasificacion.SetToolTip(cmbClasificacionEdad, "Seleccione una clasificación por edad.");
            }
        }



        private ToolTip toolTipClasificacion = new ToolTip();
        private Dictionary<string, string> descripcionesClasificacion = new Dictionary<string, string>
            {
                { "E", "Todos los públicos" },
                { "E10+", "Mayores de 10 años" },
                { "T", "Adolescentes" },
                { "M", "Mayores de 17 años" },
                { "AO", "Solo para adultos" }
            };


        private void CargarVideojuegos()
        {
            try
            {
                dgvVideojuegos.DataSource = null; // Limpia cualquier binding anterior
                dgvVideojuegos.AutoGenerateColumns = false;
                dgvVideojuegos.ReadOnly = true;
                dgvVideojuegos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvVideojuegos.Columns.Clear();
                dgvVideojuegos.Columns.Add("IdVideojuego", "Código");
                dgvVideojuegos.Columns["IdVideojuego"].DataPropertyName = "IdVideojuego";

                dgvVideojuegos.Columns.Add("Nombre", "Nombre");
                dgvVideojuegos.Columns["Nombre"].DataPropertyName = "Nombre";

                dgvVideojuegos.Columns.Add("Descripcion", "Descripción");
                dgvVideojuegos.Columns["Descripcion"].DataPropertyName = "Descripcion";

                dgvVideojuegos.Columns.Add("Plataforma", "Plataforma");
                dgvVideojuegos.Columns["Plataforma"].DataPropertyName = "Plataforma";

                dgvVideojuegos.Columns.Add("Precio", "Precio");
                dgvVideojuegos.Columns["Precio"].DataPropertyName = "Precio";

                dgvVideojuegos.Columns.Add("IdTipoVideojuego", "Tipo");
                dgvVideojuegos.Columns["IdTipoVideojuego"].DataPropertyName = "IdTipoVideojuego";

                dgvVideojuegos.Columns.Add("ClasificacionEdad", "Clasificación");
                dgvVideojuegos.Columns["ClasificacionEdad"].DataPropertyName = "ClasificacionEdad";

                dgvVideojuegos.DataSource = videojuegoLogica.ObtenerTodosVideojuegos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los videojuegos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVideojuegos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvVideojuegos.Rows[e.RowIndex];

                txtIdVideojuego.Text = fila.Cells["IdVideojuego"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                txtPlataforma.Text = fila.Cells["Plataforma"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                cmbTipoVideojuego.SelectedValue = Convert.ToInt32(fila.Cells["IdTipoVideojuego"].Value);
                cmbClasificacionEdad.Text = fila.Cells["ClasificacionEdad"].Value.ToString();
            }
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

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
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

                // Solo limpiar y recargar si el registro fue exitoso
                if (mensaje == "El videojuego se ha registrado correctamente.")
                {
                    LimpiarCampos();
                    CargarVideojuegos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarVideojuegos();
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
            CargarComboTipos();
            CargarComboClasificacion();
            CargarVideojuegos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdVideojuego.Text, out int id))
                {
                    MessageBox.Show("Por favor, ingrese un ID válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("Por favor, ingrese un precio válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VideojuegoEntidad videojuego = new VideojuegoEntidad
                {
                    IdVideojuego = id,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Plataforma = txtPlataforma.Text.Trim(),
                    Precio = precio,
                    IdTipoVideojuego = (int)cmbTipoVideojuego.SelectedValue,
                    ClasificacionEdad = cmbClasificacionEdad.Text
                };

                string mensaje = videojuegoLogica.ActualizarVideojuego(videojuego);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje.Contains("actualizado correctamente"))
                {
                    CargarVideojuegos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdVideojuego.Text, out int id))
                {
                    MessageBox.Show("Por favor, seleccione un videojuego válido para eliminar.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro que desea eliminar este videojuego?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                string mensaje = videojuegoLogica.EliminarVideojuegoPorId(id);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje.Contains("eliminado correctamente"))
                {
                    CargarVideojuegos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
