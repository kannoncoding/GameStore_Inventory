using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using _GameStore.Entidades;

// UNED
// Curso de Programación Avanzada
// Proyecto: 45GAMES4U - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre
// Descripción: Clase de acceso a datos para el manejo de los videojuegos (CRUD)

namespace _GameStore.Datos
{
    public class VideojuegoDatos
    {

        /// Agrega un nuevo videojuego a la base de datos.
        public bool Agregar(VideojuegoEntidad videojuego)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"INSERT INTO Videojuego
                               (IdVideojuego, Nombre, Descripcion, Plataforma, Precio, IdTipoVideojuego, ClasificacionEdad)
                               VALUES 
                               (@IdVideojuego, @Nombre, @Descripcion, @Plataforma, @Precio, @IdTipoVideojuego, @ClasificacionEdad)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdVideojuego", videojuego.IdVideojuego);
                cmd.Parameters.AddWithValue("@Nombre", videojuego.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", (object)videojuego.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Plataforma", (object)videojuego.Plataforma ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", videojuego.Precio);
                cmd.Parameters.AddWithValue("@IdTipoVideojuego", videojuego.IdTipoVideojuego);
                cmd.Parameters.AddWithValue("@ClasificacionEdad", (object)videojuego.ClasificacionEdad ?? DBNull.Value);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el videojuego: " + ex.Message);
                    return false;
                }
            }
        }


        /// Obtiene todos los videojuegos registrados en la base de datos.
        public List<VideojuegoEntidad> ObtenerTodos()
        {
            List<VideojuegoEntidad> lista = new List<VideojuegoEntidad>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"SELECT 
                               IdVideojuego,
                               Nombre,
                               Descripcion,
                               Plataforma,
                               Precio,
                               IdTipoVideojuego,
                               ClasificacionEdad
                               FROM Videojuego";

                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        VideojuegoEntidad vj = new VideojuegoEntidad
                        {
                            IdVideojuego = Convert.ToInt32(reader["IdVideojuego"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"] != DBNull.Value
                                          ? reader["Descripcion"].ToString()
                                          : string.Empty,
                            Plataforma = reader["Plataforma"] != DBNull.Value
                                         ? reader["Plataforma"].ToString()
                                         : string.Empty,
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            IdTipoVideojuego = Convert.ToInt32(reader["IdTipoVideojuego"]),
                            ClasificacionEdad = reader["ClasificacionEdad"] != DBNull.Value
                                                ? reader["ClasificacionEdad"].ToString()
                                                : string.Empty
                        };
                        lista.Add(vj);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar videojuegos: " + ex.Message);
                }
            }

            return lista;
        }

        /// Busca un videojuego por su ID.
        public VideojuegoEntidad BuscarPorId(int id)
        {
            VideojuegoEntidad videojuego = null;

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"SELECT
                               IdVideojuego,
                               Nombre,
                               Descripcion,
                               Plataforma,
                               Precio,
                               IdTipoVideojuego,
                               ClasificacionEdad
                               FROM Videojuego
                               WHERE IdVideojuego = @IdVideojuego";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdVideojuego", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        videojuego = new VideojuegoEntidad
                        {
                            IdVideojuego = Convert.ToInt32(reader["IdVideojuego"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"] != DBNull.Value
                                          ? reader["Descripcion"].ToString()
                                          : string.Empty,
                            Plataforma = reader["Plataforma"] != DBNull.Value
                                         ? reader["Plataforma"].ToString()
                                         : string.Empty,
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            IdTipoVideojuego = Convert.ToInt32(reader["IdTipoVideojuego"]),
                            ClasificacionEdad = reader["ClasificacionEdad"] != DBNull.Value
                                                ? reader["ClasificacionEdad"].ToString()
                                                : string.Empty
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar videojuego: " + ex.Message);
                }
            }

            return videojuego;
        }

        /// Actualiza los datos de un videojuego existente.
        public bool Actualizar(VideojuegoEntidad videojuego)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"UPDATE Videojuego
                               SET 
                                Nombre = @Nombre,
                                Descripcion = @Descripcion,
                                Plataforma = @Plataforma,
                                Precio = @Precio,
                                IdTipoVideojuego = @IdTipoVideojuego,
                                ClasificacionEdad = @ClasificacionEdad
                               WHERE 
                                IdVideojuego = @IdVideojuego";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", videojuego.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", (object)videojuego.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Plataforma", (object)videojuego.Plataforma ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", videojuego.Precio);
                cmd.Parameters.AddWithValue("@IdTipoVideojuego", videojuego.IdTipoVideojuego);
                cmd.Parameters.AddWithValue("@ClasificacionEdad", (object)videojuego.ClasificacionEdad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdVideojuego", videojuego.IdVideojuego);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el videojuego: " + ex.Message);
                    return false;
                }
            }
        }

        /// Elimina un videojuego por su ID.
        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"DELETE FROM Videojuego
                               WHERE IdVideojuego = @IdVideojuego";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdVideojuego", id);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el videojuego: " + ex.Message);
                    return false;
                }
            }
        }
    }
}