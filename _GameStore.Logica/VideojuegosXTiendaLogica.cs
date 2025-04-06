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
// Capa lógica para manejar inventario (videojuegos por tienda).

using _GameStore.Entidades;
using _GameStore.Datos;

namespace _GameStore.Logica
{
    public class VideojuegosXTiendaLogica
    {
        private readonly VideojuegosXTiendaDatos datos = new VideojuegosXTiendaDatos();

        // Método para agregar inventario con validaciones
        public string AgregarInventario(VideojuegosXTiendaEntidad inventario)
        {
            if (inventario.Stock < 0)
            {
                return "El stock no puede ser negativo.";
            }

            var existente = datos.BuscarPorId(inventario.IdTienda, inventario.IdVideojuego);
            if (existente != null)
            {
                return "Ya existe un registro de inventario para este videojuego en esta tienda.";
            }

            bool agregado = datos.Agregar(inventario);
            return agregado ? "El inventario se ha registrado correctamente." : "No se pudo registrar el inventario.";
        }

        // Método para eliminar un registro del inventario por tienda y videojuego
        public string EliminarVideojuegoXTienda(int idTienda, int idVideojuego)
        {
            bool eliminado = datos.Eliminar(idTienda, idVideojuego);
            return eliminado ? "El registro del inventario ha sido eliminado correctamente." : "El inventario especificado no existe.";
        }

        // Método para buscar un inventario específico por tienda y videojuego
        public VideojuegosXTiendaEntidad BuscarInventario(int idTienda, int idVideojuego)
        {
            return datos.BuscarPorId(idTienda, idVideojuego);
        }

        // Método para obtener todo el inventario registrado
        public List<VideojuegosXTiendaEntidad> ObtenerTodoInventario()
        {
            return datos.ObtenerTodos();
        }

        // Método adicional para obtener el inventario específico de una tienda
        public List<VideojuegosXTiendaEntidad> ObtenerInventarioPorTienda(int idTienda)
        {
            return datos.ObtenerTodos()
                        .Where(i => i.IdTienda == idTienda)
                        .ToList();
        }

        // Método para actualizar stock
        public string ActualizarInventario(VideojuegosXTiendaEntidad inventario)
        {
            if (inventario.Stock < 0)
            {
                return "El stock no puede ser negativo.";
            }

            bool actualizado = datos.Actualizar(inventario);
            return actualizado ? "El inventario se ha actualizado correctamente." : "No se pudo actualizar el inventario.";
        }
    }
}