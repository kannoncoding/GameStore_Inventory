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
// Clase de acceso a datos para almacenar inventario (videojuegos por tienda).

using _45GAMES4U_Inventario.Entidad;

namespace _45GAMES4U_Inventario.AccesoDatos
{
    public class VideojuegosXTiendaDatos
    {
        // Arreglo para almacenar inventarios
        private VideojuegosXTiendaEntidad[] inventarios;
        private int contador;

        // Constructor inicializa arreglo y contador
        public VideojuegosXTiendaDatos()
        {
            inventarios = new VideojuegosXTiendaEntidad[100]; // Puede ser mayor según necesidad
            contador = 0;
        }

        // Método para agregar registro de inventario
        public bool AgregarInventario(VideojuegosXTiendaEntidad nuevoInventario)
        {
            if (contador < inventarios.Length)
            {
                inventarios[contador++] = nuevoInventario;
                return true; // Agregado con éxito
            }
            else
            {
                return false; // Arreglo lleno
            }
        }

        // Método para buscar registro por IdTienda e IdVideojuego
        public VideojuegosXTiendaEntidad BuscarInventario(int idTienda, int idVideojuego)
        {
            for (int i = 0; i < contador; i++)
            {
                if (inventarios[i].IdTienda == idTienda && inventarios[i].IdVideojuego == idVideojuego)
                {
                    return inventarios[i];
                }
            }
            return null; // Registro no encontrado
        }

        // Método para verificar existencia de inventario por IdTienda e IdVideojuego
        public bool ExisteInventario(int idTienda, int idVideojuego)
        {
            for (int i = 0; i < contador; i++)
            {
                if (inventarios[i].IdTienda == idTienda && inventarios[i].IdVideojuego == idVideojuego)
                {
                    return true; // Inventario ya existe
                }
            }
            return false; // No existe
        }

        // Método para obtener todo el inventario registrado
        public VideojuegosXTiendaEntidad[] ObtenerTodos()
        {
            VideojuegosXTiendaEntidad[] resultado = new VideojuegosXTiendaEntidad[contador];
            Array.Copy(inventarios, resultado, contador);
            return resultado;
        }

        // Método adicional para obtener inventario por tienda
        public VideojuegosXTiendaEntidad[] ObtenerInventarioPorTienda(int idTienda)
        {
            int cantidadEncontrada = 0;

            for (int i = 0; i < contador; i++)
            {
                if (inventarios[i].IdTienda == idTienda)
                {
                    cantidadEncontrada++;
                }
            }

            VideojuegosXTiendaEntidad[] resultado = new VideojuegosXTiendaEntidad[cantidadEncontrada];
            int indiceResultado = 0;

            for (int i = 0; i < contador; i++)
            {
                if (inventarios[i].IdTienda == idTienda)
                {
                    resultado[indiceResultado++] = inventarios[i];
                }
            }

            return resultado;
        }
    }
}
