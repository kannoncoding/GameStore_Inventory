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
// Clase de acceso a datos para la entidad TipoVideojuegoEntidad.

using _45GAMES4U_Inventario.Entidad;

namespace _45GAMES4U_Inventario.AccesoDatos
{
    public class TipoVideojuegoDatos
    {
        // Arreglo para almacenar los tipos de videojuegos
        private TipoVideojuegoEntidad[] tiposVideojuego;
        private int contador;

        // Constructor inicializa arreglo y contador
        public TipoVideojuegoDatos()
        {
            tiposVideojuego = new TipoVideojuegoEntidad[50];
            contador = 0;
        }

        // Método para agregar un nuevo tipo de videojuego
        public bool AgregarTipoVideojuego(TipoVideojuegoEntidad nuevoTipo)
        {
            if (contador < tiposVideojuego.Length)
            {
                tiposVideojuego[contador++] = nuevoTipo;
                return true;
            }
            else
            {
                return false; // Arreglo lleno
            }
        }

        // Método para buscar un tipo de videojuego por Id
        public TipoVideojuegoEntidad BuscarPorId(int idTipo)
        {
            for (int i = 0; i < contador; i++)
            {
                if (tiposVideojuego[i].IdTipoVideojuego == idTipo)
                {
                    return tiposVideojuego[i];
                }
            }
            return null; // No encontrado
        }

        // Método para obtener todos los tipos registrados
        public TipoVideojuegoEntidad[] ObtenerTodos()
        {
            TipoVideojuegoEntidad[] resultado = new TipoVideojuegoEntidad[contador];
            Array.Copy(tiposVideojuego, resultado, contador);
            return resultado;
        }

        // Método para validar si existe un tipo con el mismo ID
        public bool ExisteTipo(int idTipo)
        {
            for (int i = 0; i < contador; i++)
            {
                if (tiposVideojuego[i].IdTipoVideojuego == idTipo)
                {
                    return true; // Ya existe
                }
            }
            return false; // No existe
        }
    }
}
