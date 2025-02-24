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
// Clase de acceso a datos para almacenar administradores.

using _45GAMES4U_Inventario.Entidad;

namespace _45GAMES4U_Inventario.AccesoDatos
{
    public class AdministradorDatos
    {
        // Arreglo para almacenar administradores
        private AdministradorEntidad[] administradores;
        private int contador;

        // Constructor que inicializa el arreglo y el contador
        public AdministradorDatos()
        {
            administradores = new AdministradorEntidad[50];
            contador = 0;
        }

        // Método para agregar un administrador
        public bool AgregarAdministrador(AdministradorEntidad nuevoAdministrador)
        {
            if (contador < administradores.Length)
            {
                administradores[contador++] = nuevoAdministrador;
                return true; // Agregado con éxito
            }
            else
            {
                return false; // Arreglo lleno
            }
        }

        // Método para buscar administrador por IdAdministrador
        public AdministradorEntidad BuscarPorId(int idAdministrador)
        {
            for (int i = 0; i < contador; i++)
            {
                if (administradores[i].IdAdministrador == idAdministrador)
                {
                    return administradores[i];
                }
            }
            return null; // No encontrado
        }

        // Método para validar existencia del administrador por Id
        public bool ExisteAdministrador(int idAdministrador)
        {
            for (int i = 0; i < contador; i++)
            {
                if (administradores[i].IdAdministrador == idAdministrador)
                {
                    return true; // Administrador encontrado
                }
            }
            return false; // Administrador no encontrado
        }

        // Método para obtener todos los administradores registrados
        public AdministradorEntidad[] ObtenerTodos()
        {
            AdministradorEntidad[] resultado = new AdministradorEntidad[contador];
            Array.Copy(administradores, resultado, contador);
            return resultado;
        }

        // Método adicional para buscar administrador por Identificación (cédula, DNI, etc.)
        public AdministradorEntidad BuscarPorIdentificacion(string identificacion)
        {
            for (int i = 0; i < contador; i++)
            {
                if (administradores[i].Identificacion == identificacion)
                {
                    return administradores[i];
                }
            }
            return null; // No encontrado
        }

        // Método para eliminar administrador por IdAdministrador
        public bool EliminarAdministrador(int idAdministrador)
        {
            for (int i = 0; i < contador; i++)
            {
                if (administradores[i].IdAdministrador == idAdministrador)
                {
                    // Mover elementos hacia atrás para mantener el arreglo continuo
                    for (int j = i; j < contador - 1; j++)
                    {
                        administradores[j] = administradores[j + 1];
                    }

                    administradores[contador - 1] = null;
                    contador--;
                    return true; // Eliminado con éxito
                }
            }
            return false; // No encontrado
        }
    }
}