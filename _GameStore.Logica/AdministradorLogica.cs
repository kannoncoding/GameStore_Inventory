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

using GameStore_Inventory.Entidad;
using GameStore_Inventory.AccesoDatos;

namespace GameStore_Inventory.LogicaNegocio
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

            // Verificar si la tienda asignada existe
            TiendaEntidad tienda = null;
            for (int i = 0; i < DatosInventario.contadorTiendas; i++)
            {
                if (DatosInventario.tiendas[i].IdTienda == admin.IdTienda)
                {
                    tienda = DatosInventario.tiendas[i];
                    break;
                }
            }

            if (tienda == null)
            {
                return "La tienda seleccionada no existe.";
            }

            // Verificar si la tienda ya tiene un administrador asignado
            if (tienda.IdAdministrador != 0)
            {
                return "Esta tienda ya tiene un administrador asignado.";
            }

            if (DatosInventario.contadorAdministradores < DatosInventario.administradores.Length)
            {
                DatosInventario.administradores[DatosInventario.contadorAdministradores] = admin;
                DatosInventario.contadorAdministradores++;

                // **Asignar el administrador a la tienda**
                tienda.IdAdministrador = admin.IdAdministrador;

                return "El administrador se ha registrado correctamente y se ha asignado a la tienda.";
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