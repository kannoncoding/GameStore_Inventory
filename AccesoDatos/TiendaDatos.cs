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
// Clase de acceso a datos para almacenar información de tiendas.

using _45GAMES4U_Inventario.Entidad;

namespace _45GAMES4U_Inventario.AccesoDatos
{
    public class TiendaDatos
    {
        // Arreglo para almacenar tiendas
        private TiendaEntidad[] tiendas;
        private int contador;

        // Constructor inicializa arreglo y contador
        public TiendaDatos()
        {
            tiendas = new TiendaEntidad[50];
            contador = 0;
        }

        // Método para agregar una tienda
        public bool AgregarTienda(TiendaEntidad nuevaTienda)
        {
            if (contador < tiendas.Length)
            {
                tiendas[contador++] = nuevaTienda;
                return true; // Agregada con éxito
            }
            else
            {
                return false; // Arreglo lleno
            }
        }

        // Método para buscar tienda por IdTienda
        public TiendaEntidad BuscarPorId(int idTienda)
        {
            for (int i = 0; i < contador; i++)
            {
                if (tiendas[i].IdTienda == idTienda)
                {
                    return tiendas[i];
                }
            }
            return null; // Tienda no encontrada
        }

        // Método para validar si existe una tienda por su Id
        public bool ExisteTienda(int idTienda)
        {
            for (int i = 0; i < contador; i++)
            {
                if (tiendas[i].IdTienda == idTienda)
                {
                    return true; // Tienda existe
                }
            }
            return false; // No existe
        }

        // Método para obtener todas las tiendas registradas
        public TiendaEntidad[] ObtenerTodos()
        {
            TiendaEntidad[] resultado = new TiendaEntidad[contador];
            Array.Copy(tiendas, resultado, contador);
            return resultado;
        }

        // Método adicional para buscar tiendas por Administrador (IdAdministrador)
        public TiendaEntidad[] BuscarPorAdministrador(int idAdministrador)
        {
            int cantidadEncontrada = 0;

            for (int i = 0; i < contador; i++)
            {
                if (tiendas[i].IdAdministrador == idAdministrador)
                {
                    cantidadEncontrada++;
                }
            }

            TiendaEntidad[] resultado = new TiendaEntidad[cantidadEncontrada];
            int indiceResultado = 0;

            for (int i = 0; i < contador; i++)
            {
                if (tiendas[i].IdAdministrador == idAdministrador)
                {
                    resultado[indiceResultado++] = tiendas[i];
                }
            }

            return resultado;
        }

        // Método para eliminar una tienda por IdTienda
        public bool EliminarTienda(int idTienda)
        {
            for (int i = 0; i < contador; i++)
            {
                if (tiendas[i].IdTienda == idTienda)
                {
                    // Desplazar tiendas restantes
                    for (int j = i; j < contador - 1; j++)
                    {
                        tiendas[j] = tiendas[j + 1];
                    }

                    tiendas[contador - 1] = null;
                    contador--;
                    return true; // Eliminada con éxito
                }
            }
            return false; // Tienda no encontrada
        }
    }
}