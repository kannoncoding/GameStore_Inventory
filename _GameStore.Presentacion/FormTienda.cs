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

using _GameStore.Entidades;
using _GameStore.Logica;
using _GameStore.Datos;

namespace _GameStore.Presentacion
{
    public partial class FormTienda : Form
    {
        private TiendaLogica tiendaLogica = new TiendaLogica();
        private AdministradorLogica logicaAdmin = new AdministradorLogica();


        public FormTienda()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdTienda.Text, out int id))
                {
                    MessageBox.Show("Por favor, ingrese un número válido para el ID.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TiendaEntidad nuevaTienda = new TiendaEntidad
                {
                    IdTienda = id,
                    Nombre = txtNombreTienda.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    IdAdministrador = 0 // Por ahora queda sin asignar
                };

                string mensaje = tiendaLogica.AgregarTienda(nuevaTienda);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje.Contains("registrado"))
                {
                    LimpiarCampos();
                    CargarTiendas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarTiendas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdTienda.Text, out int id))
                {
                    MessageBox.Show("Por favor, seleccione una tienda válida para eliminar.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro que desea eliminar esta tienda?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes) return;

                string mensaje = tiendaLogica.EliminarTienda(id);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje.Contains("eliminada"))
                {
                    LimpiarCampos();
                    CargarTiendas();
                }
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

        private void CargarTiendas()
        {
            try
            {
                var tiendas = tiendaLogica.ObtenerTodasTiendas();
                var admins = logicaAdmin.ObtenerTodosLosAdministradores(); // este método debe devolver una lista

                var tiendasConAdmin = tiendas.Select(t => new TiendaConAdmin
                {
                    IdTienda = t.IdTienda,
                    Nombre = t.Nombre,
                    Direccion = t.Direccion,
                    Telefono = t.Telefono,
                    NombreAdministrador = admins.FirstOrDefault(a => a.IdAdministrador == t.IdAdministrador)?.Nombre ?? "(Sin asignar)"
                }).ToList();

                dgvTiendas.DataSource = null;
                dgvTiendas.AutoGenerateColumns = false;
                dgvTiendas.ReadOnly = true;
                dgvTiendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTiendas.Columns.Clear();

                dgvTiendas.Columns.Add("IdTienda", "Código");
                dgvTiendas.Columns["IdTienda"].DataPropertyName = "IdTienda";

                dgvTiendas.Columns.Add("Nombre", "Nombre");
                dgvTiendas.Columns["Nombre"].DataPropertyName = "Nombre";

                dgvTiendas.Columns.Add("Direccion", "Dirección");
                dgvTiendas.Columns["Direccion"].DataPropertyName = "Direccion";

                dgvTiendas.Columns.Add("Telefono", "Teléfono");
                dgvTiendas.Columns["Telefono"].DataPropertyName = "Telefono";

                dgvTiendas.Columns.Add("NombreAdministrador", "Administrador");
                dgvTiendas.Columns["NombreAdministrador"].DataPropertyName = "NombreAdministrador";

                dgvTiendas.DataSource = tiendasConAdmin;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tiendas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTiendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvTiendas.Rows[e.RowIndex];

                txtIdTienda.Text = fila.Cells["IdTienda"].Value.ToString();
                txtNombreTienda.Text = fila.Cells["Nombre"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
            }
        }

        private void FormTienda_Load(object sender, EventArgs e)
        {
            CargarTiendas();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdTienda.Text, out int id))
                {
                    MessageBox.Show("Por favor, ingrese un ID válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TiendaEntidad tienda = new TiendaEntidad
                {
                    IdTienda = id,
                    Nombre = txtNombreTienda.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    IdAdministrador = 0 // Por ahora se deja sin asignar
                };

                string mensaje = tiendaLogica.ActualizarTienda(tienda);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (mensaje.Contains("actualizada"))
                {
                    LimpiarCampos();
                    CargarTiendas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }



}