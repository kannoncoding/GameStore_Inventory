using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// UNED
// Curso de Programación Avanzada
// Proyecto: 45GAMES4U - Administración de Inventario de Videojuegos
// Jorge Luis Arias Melendez
// 1er Cuatrimestre 2025
// Clase que representa la relación entre tiendas y videojuegos (Inventario).

namespace _GameStore.Entidades
{
    public class VideojuegosXTiendaEntidad
    {
        // Identificador de la tienda
        public int IdTienda { get; set; }

        // Identificador del videojuego
        public int IdVideojuego { get; set; }

        // Cantidad de unidades disponibles en la tienda
        public int Stock { get; set; }

        // Constructor sin parámetros
        public VideojuegosXTiendaEntidad() { }

        // Constructor con parámetros
        public VideojuegosXTiendaEntidad(int idTienda, int idVideojuego, int stock)
        {
            IdTienda = idTienda;
            IdVideojuego = idVideojuego;
            Stock = stock;
        }
    }
}
