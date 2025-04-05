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
// Capa lógica para manejar tipos de videojuegos.

using _GameStore.Entidades;
using _GameStore.AccesoDatos;

namespace _GameStore.Logica
{
    public class TipoVideojuegoLogica
    {
        // Método para agregar un nuevo tipo de videojuego con validaciones
        public string AgregarTipoVideojuego(TipoVideojuegoEntidad tipo)
        {
            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(tipo.Nombre))
            {
                return "El nombre del tipo de videojuego no puede estar vacío.";
            }

            // Validar que la descripción no esté vacía
            if (string.IsNullOrWhiteSpace(tipo.Descripcion))
            {
                return "La descripción del tipo de videojuego no puede estar vacía.";
            }

            // Validar si el ID ya existe
            for (int i = 0; i < DatosInventario.contadorTiposVideojuegos; i++)
            {
                if (DatosInventario.tiposVideojuegos[i].IdTipoVideojuego == tipo.IdTipoVideojuego)
                {
                    return "Ya existe un tipo de videojuego con este ID.";
                }
            }

            // Validar si el Nombre ya existe (sin distinguir mayúsculas y minúsculas)
            for (int i = 0; i < DatosInventario.contadorTiposVideojuegos; i++)
            {
                if (DatosInventario.tiposVideojuegos[i].Nombre.Equals(tipo.Nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return "Ya existe un tipo de videojuego con este nombre.";
                }
            }

            // Verificar si hay espacio en el arreglo
            if (DatosInventario.contadorTiposVideojuegos < DatosInventario.tiposVideojuegos.Length)
            {
                DatosInventario.tiposVideojuegos[DatosInventario.contadorTiposVideojuegos] = tipo;
                DatosInventario.contadorTiposVideojuegos++;
                return "El tipo de videojuego se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para buscar un tipo por ID
        public TipoVideojuegoEntidad BuscarTipoPorId(int id)
        {
            for (int i = 0; i < DatosInventario.contadorTiposVideojuegos; i++)
            {
                if (DatosInventario.tiposVideojuegos[i].IdTipoVideojuego == id)
                {
                    return DatosInventario.tiposVideojuegos[i];
                }
            }
            return null;
        }

        // Método para obtener todos los tipos
        public TipoVideojuegoEntidad[] ObtenerTodosTipos()
        {
            TipoVideojuegoEntidad[] tipos = new TipoVideojuegoEntidad[DatosInventario.contadorTiposVideojuegos];
            Array.Copy(DatosInventario.tiposVideojuegos, tipos, DatosInventario.contadorTiposVideojuegos);
            return tipos;
        }
    }
}