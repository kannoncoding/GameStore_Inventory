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
// Clase de entidad para representar los tipos de videojuegos.

namespace _GameStore.Entidades
{
    public class TipoVideojuegoEntidad
    {
        // Identificador del tipo de videojuego
        public int IdTipoVideojuego { get; set; }

        // Nombre del tipo de videojuego (Ejemplo: Acción, RPG, Aventura)
        public string Nombre { get; set; } = string.Empty;

        // Descripción opcional del tipo de videojuego
        public string Descripcion { get; set; } = string.Empty;

        // Constructor sin parámetros
        public TipoVideojuegoEntidad() { }

        // Constructor con parámetros
        public TipoVideojuegoEntidad(int idTipo, string nombre, string descripcion)
        {
            IdTipoVideojuego = idTipo;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
