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
// Clase de acceso a datos para almacenar clientes.

using _45GAMES4U_Inventario.Entidad;

namespace _45GAMES4U_Inventario.AccesoDatos
{
    public class ClienteDatos
    {
        // Arreglo para almacenar clientes
        private ClienteEntidad[] clientes;
        private int contador;

        // Constructor inicializa arreglo y contador
        public ClienteDatos()
        {
            clientes = new ClienteEntidad[50];
            contador = 0;
        }

        // Método para agregar un cliente
        public bool AgregarCliente(ClienteEntidad nuevoCliente)
        {
            if (contador < clientes.Length)
            {
                clientes[contador++] = nuevoCliente;
                return true; // Cliente agregado correctamente
            }
            else
            {
                return false; // Arreglo lleno
            }
        }

        // Método para buscar cliente por IdCliente
        public ClienteEntidad BuscarPorId(int idCliente)
        {
            for (int i = 0; i < contador; i++)
            {
                if (clientes[i].IdCliente == idCliente)
                {
                    return clientes[i];
                }
            }
            return null; // Cliente no encontrado
        }

        // Método para verificar existencia de cliente por Id
        public bool ExisteCliente(int idCliente)
        {
            for (int i = 0; i < contador; i++)
            {
                if (clientes[i].IdCliente == idCliente)
                {
                    return true; // Cliente ya existe
                }
            }
            return false; // Cliente no existe
        }

        // Método para obtener todos los clientes almacenados
        public ClienteEntidad[] ObtenerTodos()
        {
            ClienteEntidad[] resultado = new ClienteEntidad[contador];
            Array.Copy(clientes, resultado, contador);
            return resultado;
        }

        // Método adicional para buscar clientes por Identificación (cédula, DNI, etc.)
        public ClienteEntidad BuscarPorIdentificacion(string identificacion)
        {
            for (int i = 0; i < contador; i++)
            {
                if (clientes[i].Identificacion == identificacion)
                {
                    return clientes[i];
                }
            }
            return null; // Cliente no encontrado
        }
    }
}
