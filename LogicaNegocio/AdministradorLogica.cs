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

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.AccesoDatos;

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class AdministradorLogica
    {
        private AdministradorDatos administradorDatos;

        // Constructor inicializa clase de acceso a datos
        public AdministradorLogica()
        {
            administradorDatos = new AdministradorDatos();
        }

        // Método para agregar nuevo administrador con validaciones
        public string AgregarAdministrador(AdministradorEntidad admin)
        {
            if (administradorDatos.ExisteAdministrador(admin.IdAdministrador))
            {
                return "Ya existe un administrador registrado con este ID.";
            }

            if (administradorDatos.BuscarPorIdentificacion(admin.Identificacion) != null)
            {
                return "Ya existe un administrador registrado con esta identificación.";
            }

            if (string.IsNullOrWhiteSpace(admin.Identificacion))
            {
                return "La identificación es obligatoria.";
            }

            if (string.IsNullOrWhiteSpace(admin.Nombre) || string.IsNullOrWhiteSpace(admin.Apellido))
            {
                return "Nombre y apellido son obligatorios.";
            }

            if (string.IsNullOrWhiteSpace(admin.Correo))
            {
                return "El correo electrónico es obligatorio.";
            }

            bool agregado = administradorDatos.AgregarAdministrador(admin);

            if (agregado)
            {
                return "El administrador se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para eliminar un administrador por ID
        public string EliminarAdministrador(int id)
        {
            AdministradorEntidad admin = administradorDatos.BuscarPorId(id);

            if (admin == null)
            {
                return "El administrador con el ID especificado no existe.";
            }

            bool eliminado = administradorDatos.EliminarAdministrador(id);

            if (eliminado)
            {
                return "El administrador ha sido eliminado correctamente.";
            }
            else
            {
                return "Ocurrió un error al intentar eliminar el administrador.";
            }
        }

        // Método para buscar administrador por ID
        public AdministradorEntidad BuscarAdministradorPorId(int id)
        {
            return administradorDatos.BuscarPorId(id);
        }

        // Método para obtener todos los administradores registrados
        public AdministradorEntidad[] ObtenerTodosAdministradores()
        {
            return administradorDatos.ObtenerTodos();
        }

        // Método adicional para buscar por identificación personal
        public AdministradorEntidad BuscarPorIdentificacion(string identificacion)
        {
            return administradorDatos.BuscarPorIdentificacion(identificacion);
        }
    }
}