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

using _GameStore.Entidades;
using _GameStore.Datos;

namespace _GameStore.Logica
{
    public class ClienteLogica
    {
        private readonly ClienteDatos datos = new ClienteDatos();

        // Método para agregar cliente con validaciones
        public string AgregarCliente(ClienteEntidad cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Identificacion))
                return "La identificación del cliente es obligatoria.";

            if (string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Apellido))
                return "El nombre y apellido del cliente son obligatorios.";

            if (string.IsNullOrWhiteSpace(cliente.Correo))
                return "El correo electrónico es obligatorio.";

            // Validar si el ID o la identificación ya existen
            var existentes = ObtenerTodosClientes();

            if (existentes.Exists(c => c.IdCliente == cliente.IdCliente))
                return "Ya existe un cliente registrado con este ID.";

            if (existentes.Exists(c => c.Identificacion == cliente.Identificacion))
                return "Ya existe un cliente registrado con esta identificación.";

            cliente.FechaRegistro = DateTime.Now;

            bool agregado = datos.Agregar(cliente);
            return agregado
                ? "El cliente se ha registrado correctamente."
                : "No se pudo registrar el cliente.";
        }

        // Método para eliminar un cliente
        public string EliminarCliente(int idCliente)
        {
            bool eliminado = datos.Eliminar(idCliente);
            return eliminado
                ? "El cliente ha sido eliminado correctamente."
                : "No se pudo eliminar el cliente. Verifique que exista.";
        }

        // Método para actualizar un cliente
        public string ActualizarCliente(ClienteEntidad cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Identificacion))
                return "La identificación es obligatoria.";

            if (string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Apellido))
                return "El nombre y apellido son obligatorios.";

            if (string.IsNullOrWhiteSpace(cliente.Correo))
                return "El correo electrónico es obligatorio.";

            bool actualizado = datos.Actualizar(cliente);
            return actualizado
                ? "El cliente se ha actualizado correctamente."
                : "No se pudo actualizar el cliente.";
        }

        // Buscar cliente por ID
        public ClienteEntidad BuscarClientePorId(int idCliente)
        {
            return datos.BuscarPorId(idCliente);
        }

        // Obtener todos los clientes registrados
        public List<ClienteEntidad> ObtenerTodosClientes()
        {
            return datos.ObtenerTodos();
        }

        // Buscar por identificación
        public ClienteEntidad BuscarClientePorIdentificacion(string identificacion)
        {
            return datos.ObtenerTodos()
                        .Find(c => c.Identificacion == identificacion);
        }
    }
}