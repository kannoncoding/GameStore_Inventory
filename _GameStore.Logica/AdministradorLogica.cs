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
// Capa lógica para manejar administradores.

using _GameStore.Entidades;
using _GameStore.Datos;

namespace _GameStore.Logica
{
    public class AdministradorLogica
    {
        private readonly AdministradorDatos datos = new AdministradorDatos();
        private readonly TiendaDatos tiendaDatos = new TiendaDatos();

        public string AgregarAdministrador(AdministradorEntidad admin)
        {
            if (string.IsNullOrWhiteSpace(admin.Identificacion))
                return "La identificación es obligatoria.";

            if (string.IsNullOrWhiteSpace(admin.Nombre) || string.IsNullOrWhiteSpace(admin.Apellido))
                return "Nombre y apellido son obligatorios.";

            if (string.IsNullOrWhiteSpace(admin.Correo))
                return "El correo electrónico es obligatorio.";

            // Validar duplicado por ID o Identificación
            var lista = datos.ObtenerTodos();
            if (lista.Any(a => a.IdAdministrador == admin.IdAdministrador))
                return "Ya existe un administrador registrado con este ID.";

            if (lista.Any(a => a.Identificacion == admin.Identificacion))
                return "Ya existe un administrador registrado con esta identificación.";

            // Verificar si la tienda existe
            var tienda = tiendaDatos.BuscarPorId(admin.IdTienda);
            if (tienda == null)
                return "La tienda seleccionada no existe.";

            // Validar si la tienda ya tiene administrador
            var todos = datos.ObtenerTodos();
            if (todos.Any(a => a.IdTienda == admin.IdTienda))
                return "Esta tienda ya tiene un administrador asignado.";

            bool exito = datos.Agregar(admin);

            return exito
                ? "El administrador se ha registrado correctamente y se ha asignado a la tienda."
                : "No se pudo registrar el administrador.";
        }

        public string ActualizarAdministrador(AdministradorEntidad admin)
        {
            if (string.IsNullOrWhiteSpace(admin.Identificacion))
                return "La identificación es obligatoria.";

            if (string.IsNullOrWhiteSpace(admin.Nombre) || string.IsNullOrWhiteSpace(admin.Apellido))
                return "Nombre y apellido son obligatorios.";

            if (string.IsNullOrWhiteSpace(admin.Correo))
                return "El correo electrónico es obligatorio.";

            var existente = datos.BuscarPorId(admin.IdAdministrador);
            if (existente == null)
                return "El administrador no existe.";

            // Validar si se quiere reasignar a una tienda ya ocupada por otro admin
            var otrosAdmins = datos.ObtenerTodos()
                                   .Where(a => a.IdAdministrador != admin.IdAdministrador)
                                   .ToList();

            if (otrosAdmins.Any(a => a.IdTienda == admin.IdTienda))
                return "Otra tienda ya tiene un administrador asignado.";

            bool exito = datos.Actualizar(admin);

            return exito
                ? "El administrador se ha actualizado correctamente."
                : "No se pudo actualizar el administrador.";
        }

        public string EliminarAdministrador(int id)
        {
            var existente = datos.BuscarPorId(id);
            if (existente == null)
                return "El administrador con el ID especificado no existe.";

            bool exito = datos.Eliminar(id);

            return exito
                ? "El administrador ha sido eliminado correctamente."
                : "No se pudo eliminar el administrador.";
        }

        public AdministradorEntidad BuscarAdministradorPorId(int id)
        {
            return datos.BuscarPorId(id);
        }

        public List<AdministradorEntidad> ObtenerTodosLosAdministradores()
        {
            return datos.ObtenerTodos();
        }

        public AdministradorEntidad BuscarPorIdentificacion(string identificacion)
        {
            return datos.ObtenerTodos().FirstOrDefault(a => a.Identificacion == identificacion);
        }
    }
}