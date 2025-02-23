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
// Clase de acceso a datos para almacenar videojuegos.

using _45GAMES4U_Inventario.Entidad;

namespace _45GAMES4U_Inventario.AccesoDatos
{
    public class VideojuegoDatos
    {
        // Arreglo para almacenar videojuegos
        private VideojuegoEntidad[] videojuegos;
        private int contador;

        // Constructor inicializa el arreglo y contador
        public VideojuegoDatos()
        {
            videojuegos = new VideojuegoEntidad[50];
            contador = 0;
        }

        // Método para agregar un nuevo videojuego
        public bool AgregarVideojuego(VideojuegoEntidad nuevoVideojuego)
        {
            if (contador < videojuegos.Length)
            {
                videojuegos[contador++] = nuevoVideojuego;
                return true; // Agregado con éxito
            }
            else
            {
                return false; // Arreglo lleno
            }
        }

        // Método para buscar videojuego por IdVideojuego
        public VideojuegoEntidad BuscarPorId(int idVideojuego)
        {
            for (int i = 0; i < contador; i++)
            {
                if (videojuegos[i].IdVideojuego == idVideojuego)
                {
                    return videojuegos[i];
                }
            }
            return null; // No encontrado
        }

        // Método para verificar existencia por IdVideojuego
        public bool ExisteVideojuego(int idVideojuego)
        {
            for (int i = 0; i < contador; i++)
            {
                if (videojuegos[i].IdVideojuego == idVideojuego)
                {
                    return true; // Ya existe
                }
            }
            return false; // No existe
        }

        // Método para obtener todos los videojuegos almacenados
        public VideojuegoEntidad[] ObtenerTodos()
        {
            VideojuegoEntidad[] resultado = new VideojuegoEntidad[contador];
            Array.Copy(videojuegos, resultado, contador);
            return resultado;
        }

        // Método adicional para buscar videojuegos por TipoVideojuego
        public VideojuegoEntidad[] BuscarPorTipo(int idTipoVideojuego)
        {
            int cantidadEncontrada = 0;
            for (int i = 0; i < contador; i++)
            {
                if (videojuegos[i].IdTipoVideojuego == idTipoVideojuego)
                {
                    cantidadEncontrada++;
                }
            }

            VideojuegoEntidad[] resultado = new VideojuegoEntidad[cantidadEncontrada];
            int indiceResultado = 0;

            for (int i = 0; i < contador; i++)
            {
                if (videojuegos[i].IdTipoVideojuego == idTipoVideojuego)
                {
                    resultado[indiceResultado++] = videojuegos[i];
                }
            }

            return resultado;
        }
    }
}
