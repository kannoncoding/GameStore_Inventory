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

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class ClienteLogica
    {
        // Método para agregar un nuevo cliente con validaciones
        public string AgregarCliente(ClienteEntidad cliente)
        {
            for (int i = 0; i < DatosInventario.contadorClientes; i++)
            {
                if (DatosInventario.clientes[i].IdCliente == cliente.IdCliente)
                {
                    return "Ya existe un cliente registrado con este ID.";
                }
                if (DatosInventario.clientes[i].Identificacion == cliente.Identificacion)
                {
                    return "Ya existe un cliente registrado con esta identificación.";
                }
            }

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

            cliente.FechaRegistro = DateTime.Now;

            if (DatosInventario.contadorClientes < DatosInventario.clientes.Length)
            {
                DatosInventario.clientes[DatosInventario.contadorClientes] = cliente;
                DatosInventario.contadorClientes++;

              return "El cliente se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }


        // Método para eliminar cliente por ID
        public string EliminarCliente(int idCliente)
        {
            for (int i = 0; i < DatosInventario.contadorClientes; i++)
            {
                if (DatosInventario.clientes[i].IdCliente == idCliente)
                {
                    for (int j = i; j < DatosInventario.contadorClientes - 1; j++)
                    {
                        DatosInventario.clientes[j] = DatosInventario.clientes[j + 1];
                    }

                    DatosInventario.clientes[DatosInventario.contadorClientes - 1] = null;
                    DatosInventario.contadorClientes--;
                    return "El cliente ha sido eliminado correctamente.";
                }
            }
            return "El cliente con el ID especificado no existe.";
        }

        // Método para buscar cliente por ID
        public ClienteEntidad BuscarClientePorId(int idCliente)
        {
            return DatosInventario.clientes
                .FirstOrDefault(c => c != null && c.IdCliente == idCliente);
        }

        // Método para obtener todos los clientes registrados
        public ClienteEntidad[] ObtenerTodosClientes()
        {
            if (DatosInventario.contadorClientes == 0)
            {
               
                return new ClienteEntidad[0]; // Retorna un arreglo vacío si no hay clientes
            }

            ClienteEntidad[] lista = new ClienteEntidad[DatosInventario.contadorClientes];
            Array.Copy(DatosInventario.clientes, lista, DatosInventario.contadorClientes);

            
            return lista;
        }

        // Método adicional para buscar clientes por identificación personal
        public ClienteEntidad BuscarClientePorIdentificacion(string identificacion)
        {
            return DatosInventario.clientes
                .FirstOrDefault(c => c != null && c.Identificacion == identificacion);
        }
    }
}