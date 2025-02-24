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
        // Método para agregar nuevo administrador con validaciones
        public string AgregarAdministrador(AdministradorEntidad admin)
        {
            // Validar duplicado por ID
            for (int i = 0; i < DatosInventario.contadorAdministradores; i++)
            {
                if (DatosInventario.administradores[i].IdAdministrador == admin.IdAdministrador)
                {
                    return "Ya existe un administrador registrado con este ID.";
                }

                if (DatosInventario.administradores[i].Identificacion == admin.Identificacion)
                {
                    return "Ya existe un administrador registrado con esta identificación.";
                }
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

            if (DatosInventario.contadorAdministradores < DatosInventario.administradores.Length)
            {
                DatosInventario.administradores[DatosInventario.contadorAdministradores] = admin;
                DatosInventario.contadorAdministradores++;
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
            for (int i = 0; i < DatosInventario.contadorAdministradores; i++)
            {
                if (DatosInventario.administradores[i].IdAdministrador == id)
                {
                    // Eliminar desplazando hacia atrás
                    for (int j = i; j < DatosInventario.contadorAdministradores - 1; j++)
                    {
                        DatosInventario.administradores[j] = DatosInventario.administradores[j + 1];
                    }

                    DatosInventario.administradores[DatosInventario.contadorAdministradores - 1] = null;
                    DatosInventario.contadorAdministradores--;
                    return "El administrador ha sido eliminado correctamente.";
                }
            }
            return "El administrador con el ID especificado no existe.";
        }

        // Método para buscar administrador por ID
        public AdministradorEntidad BuscarAdministradorPorId(int id)
        {
            return DatosInventario.administradores
                .FirstOrDefault(a => a != null && a.IdAdministrador == id);
        }

        // Método para obtener todos los administradores registrados
        public AdministradorEntidad[] ObtenerTodosAdministradores()
        {
            AdministradorEntidad[] lista = new AdministradorEntidad[DatosInventario.contadorAdministradores];
            Array.Copy(DatosInventario.administradores, lista, DatosInventario.contadorAdministradores);
            return lista;
        }

        // Método adicional para buscar por identificación personal
        public AdministradorEntidad BuscarPorIdentificacion(string identificacion)
        {
            return DatosInventario.administradores
                .FirstOrDefault(a => a != null && a.Identificacion == identificacion);
        }
    }
}