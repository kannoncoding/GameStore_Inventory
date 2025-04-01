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
// Clase de entidad para representar un videojuego.

namespace GameStore_Inventory.Entidad
{
    public class VideojuegoEntidad
    {
        // Identificador único del videojuego
        public int IdVideojuego { get; set; }

        // Nombre del videojuego
        public string Nombre { get; set; }

        // Descripción breve del videojuego
        public string Descripcion { get; set; }

        // Plataforma en la que está disponible (Ejemplo: PC, Xbox, PlayStation)
        public string Plataforma { get; set; }

        // Precio del videojuego
        public decimal Precio { get; set; }

        // Relación con el tipo de videojuego (Ejemplo: Acción, RPG)
        public int IdTipoVideojuego { get; set; }

        // Clasificación por edad (Ejemplo: E, T, M)
        public string ClasificacionEdad { get; set; }

        // Constructor sin parámetros
        public VideojuegoEntidad() { }

        // Constructor con parámetros
        public VideojuegoEntidad(int idVideojuego, string nombre, string descripcion,
                                 string plataforma, decimal precio, int idTipoVideojuego,
                                 string clasificacionEdad)
        {
            IdVideojuego = idVideojuego;
            Nombre = nombre;
            Descripcion = descripcion;
            Plataforma = plataforma;
            Precio = precio;
            IdTipoVideojuego = idTipoVideojuego;
            ClasificacionEdad = clasificacionEdad;
           
        }
    }
}
