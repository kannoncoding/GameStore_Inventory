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
        private TipoVideojuegoDatos tipoVideojuegoDatos;

        // Constructor inicializa la clase de acceso a datos
        public TipoVideojuegoLogica()
        {
            tipoVideojuegoDatos = new TipoVideojuegoDatos();
        }

        // Método para agregar un nuevo tipo de videojuego con validaciones
        public string AgregarTipoVideojuego(TipoVideojuegoEntidad tipo)
        {
            // Validar que no exista un tipo con el mismo ID
            if (tipoVideojuegoDatos.ExisteTipo(tipo.IdTipoVideojuego))
            {
                return "Ya existe un tipo de videojuego con este ID.";
            }

            // Validación que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(tipo.Nombre))
            {
                return "El nombre del tipo de videojuego no puede estar vacío.";
            }

            bool agregado = tipoVideojuegoDatos.AgregarTipoVideojuego(tipo);

            if (agregado)
            {
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
            return tipoVideojuegoDatos.BuscarPorId(id);
        }

        // Método para obtener todos los tipos
        public TipoVideojuegoEntidad[] ObtenerTodosTipos()
        {
            return tipoVideojuegoDatos.ObtenerTodos();
        }
    }
}
