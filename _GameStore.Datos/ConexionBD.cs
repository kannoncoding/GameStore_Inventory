// UNED
// Curso de Programación Avanzada
// Proyecto: GameStore - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre
// Descripción: Clase que establece la conexión con la base de datos BD_GameStore en SQL Server

using System;
using Microsoft.Data.SqlClient;

namespace _GameStore.Datos
{
    public class ConexionBD
    {
        private readonly string cadenaConexion =
            "Server=KANNONDESKPC\\SQLEXPRESS;Database=BD_GameStore;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al establecer la conexión con la base de datos BD_GameStore.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al establecer la conexión con la base de datos.", ex);
            }
        }
    }
}
