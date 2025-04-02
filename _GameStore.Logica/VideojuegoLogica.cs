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

using GameStore_Inventory.Entidad;
using GameStore_Inventory.AccesoDatos;

namespace GameStore_Inventory.LogicaNegocio
{
    public class VideojuegoLogica
    {
        // Método para agregar un nuevo videojuego con validaciones
        public string AgregarVideojuego(VideojuegoEntidad videojuego)
        {
            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(videojuego.Nombre))
            {
                return "El nombre del videojuego no puede estar vacío.";
            }

            // Validar que el precio sea mayor a cero
            if (videojuego.Precio <= 0)
            {
                return "El precio debe ser mayor que cero.";
            }

            // Validar que la plataforma no esté vacía
            if (string.IsNullOrWhiteSpace(videojuego.Plataforma))
            {
                return "Debe especificar la plataforma del videojuego.";
            }

            // Validar que la clasificación por edad no esté vacía
            if (string.IsNullOrWhiteSpace(videojuego.ClasificacionEdad))
            {
                return "Debe indicar la clasificación por edad del videojuego.";
            }

            // Validar si el ID ya existe
            for (int i = 0; i < DatosInventario.contadorVideojuegos; i++)
            {
                if (DatosInventario.videojuegos[i].IdVideojuego == videojuego.IdVideojuego)
                {
                    return "Ya existe un videojuego registrado con este ID.";
                }
            }

            // Validar si el Nombre ya existe (sin distinguir mayúsculas y minúsculas)
            for (int i = 0; i < DatosInventario.contadorVideojuegos; i++)
            {
                if (DatosInventario.videojuegos[i].Nombre.Equals(videojuego.Nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return "Ya existe un videojuego con este nombre.";
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

            // Verificar si hay espacio en el arreglo
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
