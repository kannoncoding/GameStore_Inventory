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
// Capa lógica para manejar videojuegos.

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.AccesoDatos;

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class VideojuegoLogica
    {
        // Método para agregar un nuevo videojuego con validaciones
        public string AgregarVideojuego(VideojuegoEntidad videojuego)
        {
            // Validar duplicado
            for (int i = 0; i < DatosInventario.contadorVideojuegos; i++)
            {
                if (DatosInventario.videojuegos[i].IdVideojuego == videojuego.IdVideojuego)
                {
                    return "Ya existe un videojuego registrado con este ID.";
                }
            }

            // Validar existencia del tipo de videojuego
            bool tipoExiste = false;
            for (int i = 0; i < DatosInventario.contadorTiposVideojuegos; i++)
            {
                if (DatosInventario.tiposVideojuegos[i].IdTipoVideojuego == videojuego.IdTipoVideojuego)
                {
                    tipoExiste = true;
                    break;
                }
            }
            if (!tipoExiste)
            {
                return "El tipo de videojuego seleccionado no existe.";
            }

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(videojuego.Nombre))
            {
                return "El nombre del videojuego no puede estar vacío.";
            }

            if (videojuego.Precio <= 0)
            {
                return "El precio debe ser mayor que cero.";
            }

            if (string.IsNullOrWhiteSpace(videojuego.Plataforma))
            {
                return "Debe especificar la plataforma del videojuego.";
            }

            if (string.IsNullOrWhiteSpace(videojuego.ClasificacionEdad))
            {
                return "Debe indicar la clasificación por edad del videojuego.";
            }

            if (DatosInventario.contadorVideojuegos < DatosInventario.videojuegos.Length)
            {
                DatosInventario.videojuegos[DatosInventario.contadorVideojuegos] = videojuego;
                DatosInventario.contadorVideojuegos++;
                return "El videojuego se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para buscar videojuego por ID
        public VideojuegoEntidad BuscarVideojuegoPorId(int id)
        {
            for (int i = 0; i < DatosInventario.contadorVideojuegos; i++)
            {
                if (DatosInventario.videojuegos[i].IdVideojuego == id)
                    return DatosInventario.videojuegos[i];
            }
            return null;
        }

        // Método para obtener todos los videojuegos registrados
        public VideojuegoEntidad[] ObtenerTodosVideojuegos()
        {
            VideojuegoEntidad[] lista = new VideojuegoEntidad[DatosInventario.contadorVideojuegos];
            Array.Copy(DatosInventario.videojuegos, lista, DatosInventario.contadorVideojuegos);
            return lista;
        }

        // Método adicional para obtener videojuegos por tipo específico
        public VideojuegoEntidad[] ObtenerVideojuegosPorTipo(int idTipo)
        {
            VideojuegoEntidad[] resultado = DatosInventario.videojuegos
                .Where(v => v != null && v.IdTipoVideojuego == idTipo)
                .ToArray();

            return resultado;
        }
    }
}
