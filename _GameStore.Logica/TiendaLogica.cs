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
// Capa lógica para manejar tiendas.

using _GameStore.Entidades;
using _GameStore.Datos;

namespace _GameStore.Logica
{
    public class TiendaLogica
    {
        private readonly TiendaDatos datos = new TiendaDatos();

        public string AgregarTienda(TiendaEntidad tienda)
        {
            if (string.IsNullOrWhiteSpace(tienda.Nombre))
                return "El nombre de la tienda es obligatorio.";

            if (string.IsNullOrWhiteSpace(tienda.Direccion))
                return "La dirección de la tienda es obligatoria.";

            if (string.IsNullOrWhiteSpace(tienda.Telefono))
                return "El teléfono de la tienda es obligatorio.";

            if (tienda.IdTienda <= 0)
                return "El ID de la tienda debe ser mayor que cero.";

            // Verificar duplicado por ID
            var existente = datos.BuscarPorId(tienda.IdTienda);
            if (existente != null)
                return "Ya existe una tienda registrada con este ID.";

            // Verificar duplicado por nombre
            var todas = datos.ObtenerTodas();
            if (todas.Any(t => t.Nombre.Equals(tienda.Nombre, StringComparison.OrdinalIgnoreCase)))
                return "Ya existe una tienda con este nombre.";

            bool exito = datos.Agregar(tienda);
            return exito
                ? "La tienda se ha registrado correctamente."
                : "No se pudo registrar la tienda.";
        }

        public string ActualizarTienda(TiendaEntidad tienda)
        {
            if (string.IsNullOrWhiteSpace(tienda.Nombre))
                return "El nombre de la tienda es obligatorio.";

            if (string.IsNullOrWhiteSpace(tienda.Direccion))
                return "La dirección de la tienda es obligatoria.";

            if (string.IsNullOrWhiteSpace(tienda.Telefono))
                return "El teléfono de la tienda es obligatorio.";

            if (tienda.IdTienda <= 0)
                return "Debe seleccionar una tienda válida para actualizar.";

            var existente = datos.BuscarPorId(tienda.IdTienda);
            if (existente == null)
                return "No se encontró una tienda con ese ID.";

            bool exito = datos.Actualizar(tienda);
            return exito
                ? "La tienda se ha actualizado correctamente."
                : "No se pudo actualizar la tienda.";
        }

        public string EliminarTienda(int idTienda)
        {
            if (idTienda <= 0)
                return "ID inválido para eliminar.";

            var existente = datos.BuscarPorId(idTienda);
            if (existente == null)
                return "La tienda con el ID especificado no existe.";

            bool exito = datos.Eliminar(idTienda);
            return exito
                ? "La tienda ha sido eliminada correctamente."
                : "No se pudo eliminar la tienda.";
        }

        public TiendaEntidad BuscarTiendaPorId(int idTienda)
        {
            return datos.BuscarPorId(idTienda);
        }

        public List<TiendaEntidad> ObtenerTodasTiendas()
        {
            return datos.ObtenerTodas();
        }

        public List<TiendaEntidad> ObtenerTiendasPorAdministrador(int idAdministrador)
        {
            return datos.ObtenerTodas()
                        .Where(t => t.IdAdministrador == idAdministrador)
                        .ToList();
        }
    }
}