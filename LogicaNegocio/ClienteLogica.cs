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
// Capa lógica para manejar clientes.

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.AccesoDatos;
using System;

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class ClienteLogica
    {
        private ClienteDatos clienteDatos;

        // Constructor inicializa la clase de acceso a datos
        public ClienteLogica()
        {
            clienteDatos = new ClienteDatos();
        }

        // Método para agregar un nuevo cliente con validaciones
        public string AgregarCliente(ClienteEntidad cliente)
        {
            // Validar duplicado por IdCliente
            if (clienteDatos.ExisteCliente(cliente.IdCliente))
            {
                return "Ya existe un cliente registrado con este ID.";
            }

            // Validar duplicado por Identificación
            if (clienteDatos.BuscarPorIdentificacion(cliente.Identificacion) != null)
            {
                return "Ya existe un cliente registrado con esta identificación.";
            }

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(cliente.Identificacion))
            {
                return "La identificación del cliente es obligatoria.";
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                return "El nombre y apellido del cliente son obligatorios.";
            }

            if (string.IsNullOrWhiteSpace(cliente.Correo))
            {
                return "El correo electrónico es obligatorio.";
            }

            // Registrar la fecha actual al momento del registro
            cliente.FechaRegistro = DateTime.Now;

            bool agregado = clienteDatos.AgregarCliente(cliente);

            if (agregado)
            {
                return "El cliente se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para buscar cliente por ID
        public ClienteEntidad BuscarClientePorId(int idCliente)
        {
            return clienteDatos.BuscarPorId(idCliente);
        }

        // Método para obtener todos los clientes registrados
        public ClienteEntidad[] ObtenerTodosClientes()
        {
            return clienteDatos.ObtenerTodos();
        }

        // Método adicional para buscar clientes por identificación personal
        public ClienteEntidad BuscarClientePorIdentificacion(string identificacion)
        {
            return clienteDatos.BuscarPorIdentificacion(identificacion);
        }
    }
}
