using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _GameStore.Entidades;
using Microsoft.Data.SqlClient;

// UNED
// Curso de Programación Avanzada
// Proyecto: 45GAMES4U - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre
// Clase de acceso a datos para gestionar el inventario de videojuegos por tienda.

namespace _GameStore.Datos
{
    public class VideojuegosXTiendaDatos
    {
        // Agregar registro al inventario
        public bool Agregar(VideojuegosXTiendaEntidad entidad)
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "INSERT INTO Inventario (IdTienda, IdVideojuego, Stock) VALUES (@IdTienda, @IdVideojuego, @Stock)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@IdTienda", entidad.IdTienda);
                    cmd.Parameters.AddWithValue("@IdVideojuego", entidad.IdVideojuego);
                    cmd.Parameters.AddWithValue("@Stock", entidad.Stock);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // Obtener todos los registros de inventario
        public List<VideojuegosXTiendaEntidad> ObtenerTodos()
        {
            List<VideojuegosXTiendaEntidad> lista = new List<VideojuegosXTiendaEntidad>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT IdTienda, IdVideojuego, Stock FROM Inventario";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new VideojuegosXTiendaEntidad
                        {
                            IdTienda = Convert.ToInt32(reader["IdTienda"]),
                            IdVideojuego = Convert.ToInt32(reader["IdVideojuego"]),
                            Stock = Convert.ToInt32(reader["Stock"])
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error al consultar inventario: " + ex.Message);
                }
            }

            return lista;
        }

        // Buscar inventario por tienda y videojuego
        public VideojuegosXTiendaEntidad BuscarPorId(int idTienda, int idVideojuego)
        {
            VideojuegosXTiendaEntidad item = null;

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT IdTienda, IdVideojuego, Stock FROM Inventario WHERE IdTienda = @IdTienda AND IdVideojuego = @IdVideojuego";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdTienda", idTienda);
                cmd.Parameters.AddWithValue("@IdVideojuego", idVideojuego);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        item = new VideojuegosXTiendaEntidad
                        {
                            IdTienda = Convert.ToInt32(reader["IdTienda"]),
                            IdVideojuego = Convert.ToInt32(reader["IdVideojuego"]),
                            Stock = Convert.ToInt32(reader["Stock"])
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error al buscar inventario: " + ex.Message);
                }
            }

            return item;
        }

        // Actualizar stock
        public bool Actualizar(VideojuegosXTiendaEntidad entidad)
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "UPDATE Inventario SET Stock = @Stock WHERE IdTienda = @IdTienda AND IdVideojuego = @IdVideojuego";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Stock", entidad.Stock);
                    cmd.Parameters.AddWithValue("@IdTienda", entidad.IdTienda);
                    cmd.Parameters.AddWithValue("@IdVideojuego", entidad.IdVideojuego);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // Eliminar registro
        public bool Eliminar(int idTienda, int idVideojuego)
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "DELETE FROM Inventario WHERE IdTienda = @IdTienda AND IdVideojuego = @IdVideojuego";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@IdTienda", idTienda);
                    cmd.Parameters.AddWithValue("@IdVideojuego", idVideojuego);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
