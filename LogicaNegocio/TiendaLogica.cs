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

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.AccesoDatos;

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class TiendaLogica
    {
        private TiendaDatos tiendaDatos;
        private AdministradorDatos administradorDatos;

        // Constructor inicializa clases de acceso a datos
        public TiendaLogica()
        {
            tiendaDatos = new TiendaDatos();
            administradorDatos = new AdministradorDatos();
        }

        // Método para agregar una nueva tienda con validaciones
        public string AgregarTienda(TiendaEntidad tienda)
        {
            if (tiendaDatos.ExisteTienda(tienda.IdTienda))
            {
                return "Ya existe una tienda registrada con este ID.";
            }

            if (!administradorDatos.ExisteAdministrador(tienda.IdAdministrador))
            {
                return "El administrador asignado a esta tienda no existe.";
            }

            if (string.IsNullOrWhiteSpace(tienda.Nombre))
            {
                return "El nombre de la tienda es obligatorio.";
            }

            if (string.IsNullOrWhiteSpace(tienda.Direccion))
            {
                return "La dirección de la tienda es obligatoria.";
            }

            if (string.IsNullOrWhiteSpace(tienda.Telefono))
            {
                return "El teléfono de la tienda es obligatorio.";
            }

            bool agregado = tiendaDatos.AgregarTienda(tienda);

            if (agregado)
            {
                return "La tienda se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para eliminar una tienda por ID
        public string EliminarTienda(int idTienda)
        {
            TiendaEntidad tienda = tiendaDatos.BuscarPorId(idTienda);

            if (tienda == null)
            {
                return "La tienda con el ID especificado no existe.";
            }

            bool eliminado = tiendaDatos.EliminarTienda(idTienda);

            if (eliminado)
            {
                return "La tienda ha sido eliminada correctamente.";
            }
            else
            {
                return "Ocurrió un error al intentar eliminar la tienda.";
            }
        }

        // Método para buscar tienda por ID
        public TiendaEntidad BuscarTiendaPorId(int idTienda)
        {
            return tiendaDatos.BuscarPorId(idTienda);
        }

        // Método para obtener todas las tiendas registradas
        public TiendaEntidad[] ObtenerTodasTiendas()
        {
            return tiendaDatos.ObtenerTodos();
        }

        // Método adicional para obtener tiendas por administrador específico
        public TiendaEntidad[] ObtenerTiendasPorAdministrador(int idAdministrador)
        {
            return tiendaDatos.BuscarPorAdministrador(idAdministrador);
        }
    }
}