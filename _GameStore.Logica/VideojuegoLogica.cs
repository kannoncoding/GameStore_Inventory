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

using _GameStore.Entidades;
using _GameStore.Datos;

namespace _GameStore.Logica
{
    public class VideojuegoLogica
    {
        public string AgregarVideojuego(VideojuegoEntidad videojuego)
        {
            if (string.IsNullOrWhiteSpace(videojuego.Nombre))
                return "El nombre del videojuego no puede estar vacío.";

            if (videojuego.Precio <= 0)
                return "El precio debe ser mayor que cero.";

            if (string.IsNullOrWhiteSpace(videojuego.Plataforma))
                return "Debe especificar la plataforma del videojuego.";

            if (string.IsNullOrWhiteSpace(videojuego.ClasificacionEdad))
                return "Debe indicar la clasificación por edad del videojuego.";

            try
            {
                VideojuegoDatos datos = new VideojuegoDatos();

                // Verificar si ya existe un videojuego con ese ID
                var existente = datos.BuscarPorId(videojuego.IdVideojuego);
                if (existente != null)
                    return "Ya existe un videojuego registrado con este ID.";

                // Verificar si ya existe un videojuego con ese nombre (sin importar mayúsculas/minúsculas)
                var lista = datos.ObtenerTodos();
                if (lista.Any(v => v.Nombre.Equals(videojuego.Nombre, StringComparison.OrdinalIgnoreCase)))
                    return "Ya existe un videojuego con este nombre.";

                // Validar existencia de TipoVideojuego en la base de datos
                TipoVideojuegoDatos tipoDatos = new TipoVideojuegoDatos();
                var tipo = tipoDatos.BuscarPorId(videojuego.IdTipoVideojuego);
                if (tipo == null)
                    return "El tipo de videojuego seleccionado no existe.";

                bool exito = datos.Agregar(videojuego);
                return exito
                    ? "El videojuego se ha registrado correctamente."
                    : "No se pudo registrar el videojuego.";
            }
            catch (Exception ex)
            {
                return "Error al registrar el videojuego: " + ex.Message;
            }
        }

        public string ActualizarVideojuego(VideojuegoEntidad videojuego)
        {
            if (string.IsNullOrWhiteSpace(videojuego.Nombre))
                return "El nombre del videojuego no puede estar vacío.";

            if (videojuego.Precio <= 0)
                return "El precio debe ser mayor que cero.";

            if (string.IsNullOrWhiteSpace(videojuego.Plataforma))
                return "Debe especificar la plataforma del videojuego.";

            if (string.IsNullOrWhiteSpace(videojuego.ClasificacionEdad))
                return "Debe indicar la clasificación por edad del videojuego.";

            try
            {
                VideojuegoDatos datos = new VideojuegoDatos();
                var existente = datos.BuscarPorId(videojuego.IdVideojuego);
                if (existente == null)
                    return "No se encontró el videojuego con ese ID.";

                // También podrías validar existencia de tipo si lo deseas
                TipoVideojuegoDatos tipoDatos = new TipoVideojuegoDatos();
                var tipo = tipoDatos.BuscarPorId(videojuego.IdTipoVideojuego);
                if (tipo == null)
                    return "El tipo de videojuego seleccionado no existe.";

                bool exito = datos.Actualizar(videojuego);
                return exito
                    ? "El videojuego se ha actualizado correctamente."
                    : "No se pudo actualizar el videojuego.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el videojuego: " + ex.Message;
            }
        }

        public string EliminarVideojuegoPorId(int id)
        {
            try
            {
                VideojuegoDatos datos = new VideojuegoDatos();
                var existente = datos.BuscarPorId(id);
                if (existente == null)
                    return "No se encontró un videojuego con ese ID.";

                bool exito = datos.Eliminar(id);
                return exito
                    ? "El videojuego se ha eliminado correctamente."
                    : "No se pudo eliminar el videojuego.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el videojuego: " + ex.Message;
            }
        }

        public VideojuegoEntidad BuscarVideojuegoPorId(int id)
        {
            VideojuegoDatos datos = new VideojuegoDatos();
            return datos.BuscarPorId(id);
        }

        public List<VideojuegoEntidad> ObtenerTodosVideojuegos()
        {
            VideojuegoDatos datos = new VideojuegoDatos();
            return datos.ObtenerTodos();
        }

        public List<VideojuegoEntidad> ObtenerVideojuegosPorTipo(int idTipo)
        {
            VideojuegoDatos datos = new VideojuegoDatos();
            var todos = datos.ObtenerTodos();
            return todos.Where(v => v.IdTipoVideojuego == idTipo).ToList();
        }
    }
}
