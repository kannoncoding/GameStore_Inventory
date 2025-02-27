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
// Clase que representa a un administrador, heredando de PersonaEntidad.

namespace _45GAMES4U_Inventario.Entidad
{
    public class AdministradorEntidad : PersonaEntidad
    {
        // Identificador único del administrador
        public int IdAdministrador { get; set; }

        // Identificador de la tienda asignada
        public int IdTienda { get; set; } 

        // Constructor sin parámetros
        public AdministradorEntidad() : base() { }

        // Constructor con parámetros
        public AdministradorEntidad(int idAdministrador, string identificacion, string nombre,
                                    string apellido, string telefono, string correo, int idTienda)
            : base(identificacion, nombre, apellido, telefono, correo)
        {
            IdAdministrador = idAdministrador;
            IdTienda = idTienda;
        }
    }
}