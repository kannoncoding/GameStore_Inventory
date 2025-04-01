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
// Clase que representa a un cliente, heredando de PersonaEntidad.

namespace GameStore_Inventory.Entidad
{
    public class ClienteEntidad : PersonaEntidad
    {
        // Identificador único del cliente
        public int IdCliente { get; set; }

        // Fecha de registro del cliente
        public DateTime FechaRegistro { get; set; }

        // Constructor sin parámetros
        public ClienteEntidad() : base() { }

        // Constructor con parámetros
        public ClienteEntidad(int idCliente, string identificacion, string nombre,
                              string apellido, string telefono, string correo, DateTime fechaRegistro)
            : base(identificacion, nombre, apellido, telefono, correo)
        {
            IdCliente = idCliente;
            FechaRegistro = fechaRegistro;
        }
    }
}
