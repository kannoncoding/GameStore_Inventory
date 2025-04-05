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
// Clase que representa una tienda dentro de la cadena de videojuegos.

namespace _GameStore.Entidades
{
    public class TiendaEntidad
    {
        // Identificador único de la tienda
        public int IdTienda { get; set; }

        // Nombre de la tienda
        public string Nombre { get; set; }

        // Dirección de la tienda
        public string Direccion { get; set; }

        // Teléfono de la tienda
        public string Telefono { get; set; }

        // Identificador del administrador de la tienda
        public int IdAdministrador { get; set; }

        // Constructor sin parámetros
        public TiendaEntidad() { }

        // Constructor con parámetros
        public TiendaEntidad(int idTienda, string nombre, string direccion,
                             string telefono, int idAdministrador)
        {
            IdTienda = idTienda;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            IdAdministrador = idAdministrador;
        }
    }
}