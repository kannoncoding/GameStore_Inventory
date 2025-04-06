using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using _GameStore.Entidades;

// UNED
// Curso de Programación Avanzada
// Proyecto: 45GAMES4U - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre 2025
// Capa de acceso a datos para entidad Cliente

namespace _GameStore.Datos
{
    public class ClienteDatos
    {
        // Método para agregar un nuevo cliente
        public bool Agregar(ClienteEntidad cliente)
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();

                    // Insertar en Persona
                    string sqlPersona = @"INSERT INTO Persona (Identificacion, Nombre, Apellido, Telefono, Correo)
                                  VALUES (@Identificacion, @Nombre, @Apellido, @Telefono, @Correo)";
                    SqlCommand cmdPersona = new SqlCommand(sqlPersona, conn);
                    cmdPersona.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                    cmdPersona.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmdPersona.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmdPersona.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmdPersona.Parameters.AddWithValue("@Correo", cliente.Correo);

                    cmdPersona.ExecuteNonQuery();

                    // Insertar en Cliente
                    string sqlCliente = @"INSERT INTO Cliente (IdCliente, Identificacion, FechaRegistro)
                                  VALUES (@IdCliente, @Identificacion, @FechaRegistro)";
                    SqlCommand cmdCliente = new SqlCommand(sqlCliente, conn);
                    cmdCliente.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    cmdCliente.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                    cmdCliente.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);

                    return cmdCliente.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                // MOSTRALO para entender qué pasa
                MessageBox.Show("Error al registrar cliente: " + ex.Message);
                return false;
            }
        }

        // Método para eliminar un cliente por ID
        public bool Eliminar(int idCliente)
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "DELETE FROM Cliente WHERE IdCliente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // Método para actualizar un cliente
        public bool Actualizar(ClienteEntidad cliente)
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = @"UPDATE Cliente
                                   SET Identificacion = @Identificacion,
                                       FechaRegistro = @FechaRegistro
                                   WHERE IdCliente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                    cmd.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // Método para buscar cliente por ID
        public ClienteEntidad BuscarPorId(int idCliente)
        {
            ClienteEntidad cliente = null;

            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string sql = "SELECT * FROM Cliente WHERE IdCliente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        cliente = new ClienteEntidad
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Identificacion = reader["Identificacion"].ToString(),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                        };
                    }

                    reader.Close();
                }
            }
            catch
            {
                // Manejo silencioso
            }

            return cliente;
        }

        // Método para obtener todos los clientes
        public List<ClienteEntidad> ObtenerTodos()
        {
            List<ClienteEntidad> lista = new List<ClienteEntidad>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"SELECT c.IdCliente, c.Identificacion, c.FechaRegistro,
                              p.Nombre, p.Apellido, p.Telefono, p.Correo
                       FROM Cliente c
                       INNER JOIN Persona p ON c.Identificacion = p.Identificacion";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClienteEntidad cliente = new ClienteEntidad
                    {
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Identificacion = reader["Identificacion"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                    };

                    lista.Add(cliente);
                }

                reader.Close();
            }

            return lista;
        }

    }
}