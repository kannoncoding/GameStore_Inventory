using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using _GameStore.Entidades;

// UNED
// Curso de Programación Avanzada
// Proyecto: 45GAMES4U - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre
// Descripción: Clase de acceso a datos para el manejo de los tipos de videojuegos (CRUD)
// Fecha: 2025

namespace _GameStore.Datos
{
    public class TipoVideojuegoDatos
    {
        public bool Agregar(TipoVideojuegoEntidad tipo)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "INSERT INTO TipoVideojuego (IdTipoVideojuego, Nombre, Descripcion) VALUES (@IdTipoVideojuego, @Nombre, @Descripcion)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdTipoVideojuego", tipo.IdTipoVideojuego);
                cmd.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el tipo: " + ex.Message);
                    return false;
                }
            }
        }

        public List<TipoVideojuegoEntidad> ObtenerTodos()
        {
            List<TipoVideojuegoEntidad> lista = new List<TipoVideojuegoEntidad>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT IdTipoVideojuego, Nombre, Descripcion FROM TipoVideojuego";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new TipoVideojuegoEntidad
                        {
                            IdTipoVideojuego = Convert.ToInt32(reader["IdTipoVideojuego"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar tipos: " + ex.Message);
                }
            }

            return lista;
        }

        public TipoVideojuegoEntidad BuscarPorId(int id)
        {
            TipoVideojuegoEntidad tipo = null;

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT IdTipoVideojuego, Nombre, Descripcion FROM TipoVideojuego WHERE IdTipoVideojuego = @IdTipoVideojuego";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdTipoVideojuego", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tipo = new TipoVideojuegoEntidad
                        {
                            IdTipoVideojuego = Convert.ToInt32(reader["IdTipoVideojuego"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString()
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar tipo: " + ex.Message);
                }
            }

            return tipo;
        }


        public bool Actualizar(TipoVideojuegoEntidad tipo)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "UPDATE TipoVideojuego SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion);
                cmd.Parameters.AddWithValue("@Id", tipo.IdTipoVideojuego);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar tipo: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "DELETE FROM TipoVideojuego WHERE IdTipoVideojuego = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar tipo: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
