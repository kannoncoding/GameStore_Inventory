// UNED
// Curso de Programación Avanzada
// Proyecto: GameStore - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre
// Descripción: Clase que establece la conexión con la base de datos local SQL Server Express (BD_GameStore)


using System;
using Microsoft.Data.SqlClient;

namespace _GameStore.Datos
{
    public class ConexionBD
    {
        // Cadena de conexión a la base de datos local SQL Server Express
        private readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS;Database=BD_GameStore;Trusted_Connection=True;";

        // Método público para obtener una conexión abierta
        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); // Abre la conexión inmediatamente
                return conexion; // Devuelve la conexión abierta
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
