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
// Formulario de menú principal que permite acceder a cada formulario del sistema.

using Microsoft.Data.SqlClient;
using _GameStore.Datos;

namespace _GameStore.Presentacion
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnTipoVideojuego_Click(object sender, EventArgs e)
        {
            FormTipoVideojuego frm = new FormTipoVideojuego();
            frm.ShowDialog();
        }

        private void btnVideojuego_Click(object sender, EventArgs e)
        {
            FormVideojuego frm = new FormVideojuego();
            frm.ShowDialog();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            FormAdministrador frm = new FormAdministrador();
            frm.ShowDialog();
        }

        private void btnTienda_Click(object sender, EventArgs e)
        {
            FormTienda frm = new FormTienda();
            frm.ShowDialog();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FormCliente frm = new FormCliente();
            frm.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FormInventario frm = new FormInventario();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(
                    "Server=KANNONDESKPC\\SQLEXPRESS;Database=BD_GameStore;Trusted_Connection=True;TrustServerCertificate=True;"))
                {
                    conexion.Open();
                    MessageBox.Show("✅ Conectado a la base 'BD_GameStore' correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al conectar con el servidor SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
