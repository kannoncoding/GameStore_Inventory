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
        public static SqlConnection ObtenerConexion()
        {
            string cadena = "Server=KANNONDESKPC\\SQLEXPRESS;Database=BD_GameStore;Trusted_Connection=True;TrustServerCertificate=True;";
            return new SqlConnection(cadena);
        }
    }
}
