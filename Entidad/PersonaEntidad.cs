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
// Clase base para representar una persona.

namespace _45GAMES4U_Inventario.Entidad
{
    public class PersonaEntidad
    {
        // Identificación de la persona (cédula, pasaporte, etc.)
        public string Identificacion { get; set; }

        // Nombre de la persona
        public string Nombre { get; set; }

        // Apellido de la persona
        public string Apellido { get; set; }

        // Teléfono de contacto
        public string Telefono { get; set; }

        // Correo electrónico de la persona
        public string Correo { get; set; }

        // Constructor sin parámetros
        public PersonaEntidad() { }

        // Constructor con parámetros
        public PersonaEntidad(string identificacion, string nombre, string apellido, string telefono, string correo)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
        }
    }
}
