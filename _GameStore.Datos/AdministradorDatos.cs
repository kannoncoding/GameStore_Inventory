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
// 1er Cuatrimestre 2025
// Descripción: Acceso a datos para la entidad Administrador

namespace _GameStore.Datos
{
    public class AdministradorDatos
    {
        public bool Agregar(AdministradorEntidad admin)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                SqlTransaction transaccion = null;

                try
                {
                    conn.Open();
                    transaccion = conn.BeginTransaction();

                    // Insertar en Persona
                    string sqlPersona = @"INSERT INTO Persona 
                                          (Identificacion, Nombre, Apellido, Telefono, Correo) 
                                          VALUES 
                                          (@Identificacion, @Nombre, @Apellido, @Telefono, @Correo)";
                    SqlCommand cmdPersona = new SqlCommand(sqlPersona, conn, transaccion);
                    cmdPersona.Parameters.AddWithValue("@Identificacion", admin.Identificacion);
                    cmdPersona.Parameters.AddWithValue("@Nombre", admin.Nombre);
                    cmdPersona.Parameters.AddWithValue("@Apellido", admin.Apellido);
                    cmdPersona.Parameters.AddWithValue("@Telefono", admin.Telefono);
                    cmdPersona.Parameters.AddWithValue("@Correo", admin.Correo);
                    cmdPersona.ExecuteNonQuery();

                    // Insertar en Administrador
                    string sqlAdmin = @"INSERT INTO Administrador 
                                        (IdAdministrador, Identificacion, IdTienda) 
                                        VALUES 
                                        (@IdAdministrador, @Identificacion, @IdTienda)";
                    SqlCommand cmdAdmin = new SqlCommand(sqlAdmin, conn, transaccion);
                    cmdAdmin.Parameters.AddWithValue("@IdAdministrador", admin.IdAdministrador);
                    cmdAdmin.Parameters.AddWithValue("@Identificacion", admin.Identificacion);
                    cmdAdmin.Parameters.AddWithValue("@IdTienda", admin.IdTienda);
                    cmdAdmin.ExecuteNonQuery();

                    transaccion.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion?.Rollback();
                    MessageBox.Show("Error al agregar administrador: " + ex.Message);
                    return false;
                }
            }
        }

        public List<AdministradorEntidad> ObtenerTodos()
        {
            List<AdministradorEntidad> lista = new List<AdministradorEntidad>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"SELECT A.IdAdministrador, A.Identificacion, A.IdTienda, 
                                      P.Nombre, P.Apellido, P.Telefono, P.Correo
                               FROM Administrador A
                               INNER JOIN Persona P ON A.Identificacion = P.Identificacion";

                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new AdministradorEntidad
                        {
                            IdAdministrador = Convert.ToInt32(reader["IdAdministrador"]),
                            Identificacion = reader["Identificacion"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            IdTienda = Convert.ToInt32(reader["IdTienda"])
                        });
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener administradores: " + ex.Message);
                }
            }

            return lista;
        }

        public AdministradorEntidad BuscarPorId(int id)
        {
            AdministradorEntidad admin = null;

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"SELECT A.IdAdministrador, A.Identificacion, A.IdTienda, 
                                      P.Nombre, P.Apellido, P.Telefono, P.Correo
                               FROM Administrador A
                               INNER JOIN Persona P ON A.Identificacion = P.Identificacion
                               WHERE A.IdAdministrador = @IdAdministrador";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdAdministrador", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        admin = new AdministradorEntidad
                        {
                            IdAdministrador = Convert.ToInt32(reader["IdAdministrador"]),
                            Identificacion = reader["Identificacion"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            IdTienda = Convert.ToInt32(reader["IdTienda"])
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar administrador: " + ex.Message);
                }
            }

            return admin;
        }

        public bool Actualizar(AdministradorEntidad admin)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();

                    string sqlPersona = @"UPDATE Persona 
                                          SET Nombre = @Nombre, Apellido = @Apellido,
                                              Telefono = @Telefono, Correo = @Correo
                                          WHERE Identificacion = @Identificacion";

                    SqlCommand cmdPersona = new SqlCommand(sqlPersona, conn, trans);
                    cmdPersona.Parameters.AddWithValue("@Nombre", admin.Nombre);
                    cmdPersona.Parameters.AddWithValue("@Apellido", admin.Apellido);
                    cmdPersona.Parameters.AddWithValue("@Telefono", admin.Telefono);
                    cmdPersona.Parameters.AddWithValue("@Correo", admin.Correo);
                    cmdPersona.Parameters.AddWithValue("@Identificacion", admin.Identificacion);
                    cmdPersona.ExecuteNonQuery();

                    string sqlAdmin = @"UPDATE Administrador 
                                        SET IdTienda = @IdTienda
                                        WHERE IdAdministrador = @IdAdministrador";

                    SqlCommand cmdAdmin = new SqlCommand(sqlAdmin, conn, trans);
                    cmdAdmin.Parameters.AddWithValue("@IdTienda", admin.IdTienda);
                    cmdAdmin.Parameters.AddWithValue("@IdAdministrador", admin.IdAdministrador);
                    cmdAdmin.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans?.Rollback();
                    MessageBox.Show("Error al actualizar administrador: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();

                    string sqlIdent = "SELECT Identificacion FROM Administrador WHERE IdAdministrador = @IdAdministrador";
                    SqlCommand cmdIdent = new SqlCommand(sqlIdent, conn, trans);
                    cmdIdent.Parameters.AddWithValue("@IdAdministrador", id);
                    string identificacion = cmdIdent.ExecuteScalar()?.ToString();

                    string sqlDeleteAdmin = "DELETE FROM Administrador WHERE IdAdministrador = @IdAdministrador";
                    SqlCommand cmdDelAdmin = new SqlCommand(sqlDeleteAdmin, conn, trans);
                    cmdDelAdmin.Parameters.AddWithValue("@IdAdministrador", id);
                    cmdDelAdmin.ExecuteNonQuery();

                    string sqlDeletePersona = "DELETE FROM Persona WHERE Identificacion = @Identificacion";
                    SqlCommand cmdDelPersona = new SqlCommand(sqlDeletePersona, conn, trans);
                    cmdDelPersona.Parameters.AddWithValue("@Identificacion", identificacion);
                    cmdDelPersona.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans?.Rollback();
                    MessageBox.Show("Error al eliminar administrador: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
