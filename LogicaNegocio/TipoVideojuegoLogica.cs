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

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.AccesoDatos;

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class TipoVideojuegoLogica
    {
        // Método para agregar un nuevo tipo de videojuego con validaciones
        public string AgregarTipoVideojuego(TipoVideojuegoEntidad tipo)
        {
            // Validar duplicados
            for (int i = 0; i < DatosInventario.contadorTiposVideojuegos; i++)
            {
                if (DatosInventario.tiposVideojuegos[i].IdTipoVideojuego == tipo.IdTipoVideojuego)
                {
                    return "Ya existe un tipo de videojuego con este ID.";
                }
            }

            // Validación que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(tipo.Descripcion))
            {
                return "La descripción del tipo de videojuego no puede estar vacía.";
            }

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