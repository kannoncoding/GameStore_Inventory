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
// 1er Cuatrimestre 2025
// Descripción: Acceso a datos para la entidad Tienda

namespace _GameStore.Datos
{
    public class TiendaDatos
    {
        public bool Agregar(TiendaEntidad tienda)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"INSERT INTO Tienda 
                               (IdTienda, Nombre, Direccion, Telefono, IdAdministrador) 
                               VALUES 
                               (@IdTienda, @Nombre, @Direccion, @Telefono, @IdAdministrador)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdTienda", tienda.IdTienda);
                cmd.Parameters.AddWithValue("@Nombre", tienda.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", tienda.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", (object)tienda.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdAdministrador", tienda.IdAdministrador == 0 ? DBNull.Value : tienda.IdAdministrador);


                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar la tienda: " + ex.Message);
                    return false;
                }
            }
        }

        public List<TiendaEntidad> ObtenerTodas()
        {
            List<TiendaEntidad> lista = new List<TiendaEntidad>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT IdTienda, Nombre, Direccion, Telefono, IdAdministrador FROM Tienda";

                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TiendaEntidad tienda = new TiendaEntidad
                        {
                            IdTienda = Convert.ToInt32(reader["IdTienda"]),
                            Nombre = reader["Nombre"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : string.Empty,
                            IdAdministrador = reader["IdAdministrador"] != DBNull.Value ? Convert.ToInt32(reader["IdAdministrador"]) : 0
                        };

                        lista.Add(tienda);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar tiendas: " + ex.Message);
                }
            }

            return lista;
        }

        public TiendaEntidad BuscarPorId(int id)
        {
            TiendaEntidad tienda = null;

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT IdTienda, Nombre, Direccion, Telefono, IdAdministrador FROM Tienda WHERE IdTienda = @IdTienda";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdTienda", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        tienda = new TiendaEntidad
                        {
                            IdTienda = Convert.ToInt32(reader["IdTienda"]),
                            Nombre = reader["Nombre"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : string.Empty,
                            IdAdministrador = reader["IdAdministrador"] != DBNull.Value ? Convert.ToInt32(reader["IdAdministrador"]) : 0
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar tienda: " + ex.Message);
                }
            }

            return tienda;
        }

        public bool Actualizar(TiendaEntidad tienda)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"UPDATE Tienda 
                               SET Nombre = @Nombre, 
                                   Direccion = @Direccion, 
                                   Telefono = @Telefono, 
                                   IdAdministrador = @IdAdministrador 
                               WHERE IdTienda = @IdTienda";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", tienda.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", tienda.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", (object)tienda.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IdAdministrador", tienda.IdAdministrador == 0 ? DBNull.Value : tienda.IdAdministrador);
                cmd.Parameters.AddWithValue("@IdTienda", tienda.IdTienda);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la tienda: " + ex.Message);
                    return false;
                }
            }

        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = "DELETE FROM Tienda WHERE IdTienda = @IdTienda";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdTienda", id);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la tienda: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
