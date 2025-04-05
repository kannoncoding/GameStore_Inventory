using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _GameStore.Entidades;


// UNED
// Curso de Programación Avanzada
// Proyecto: 45GAMES4U - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre
// Descripción: Clase estática para almacenar arreglos de entidades compartidos en toda la aplicación.

namespace _GameStore.AccesoDatos
{
    public static class DatosInventario
    {
        // Arreglo para Tipos de Videojuegos
        public static TipoVideojuegoEntidad[] tiposVideojuegos = new TipoVideojuegoEntidad[50];
        public static int contadorTiposVideojuegos = 0;

        // Arreglo para Videojuegos
        public static VideojuegoEntidad[] videojuegos = new VideojuegoEntidad[100];
        public static int contadorVideojuegos = 0;

        // Arreglo para Administradores
        public static AdministradorEntidad[] administradores = new AdministradorEntidad[20];
        public static int contadorAdministradores = 0;

        // Arreglo para Tiendas
        public static TiendaEntidad[] tiendas = new TiendaEntidad[20];
        public static int contadorTiendas = 0;

        // Arreglo para Clientes
        public static ClienteEntidad[] clientes = new ClienteEntidad[100];
        public static int contadorClientes = 0;

        // Arreglo para Inventario (Videojuegos por Tienda)
        public static VideojuegosXTiendaEntidad[] inventario = new VideojuegosXTiendaEntidad[200];
        public static int contadorInventario = 0;
    }
}
