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

using GameStore_Inventory.Entidad;
using GameStore_Inventory.AccesoDatos;

namespace GameStore_Inventory.LogicaNegocio
{
    public class VideojuegosXTiendaLogica
    {
        // Método para agregar inventario con validaciones
        public string AgregarInventario(VideojuegosXTiendaEntidad inventario)
        {
            for (int i = 0; i < DatosInventario.contadorInventario; i++)
            {
                if (DatosInventario.inventario[i].IdTienda == inventario.IdTienda &&
                    DatosInventario.inventario[i].IdVideojuego == inventario.IdVideojuego)
                {
                    return "Ya existe un registro de inventario para este videojuego en esta tienda.";
                }
            }

            bool tiendaExiste = DatosInventario.tiendas
                .Any(t => t != null && t.IdTienda == inventario.IdTienda);

            if (!tiendaExiste)
            {
                return "La tienda especificada no existe.";
            }

            bool videojuegoExiste = DatosInventario.videojuegos
                .Any(v => v != null && v.IdVideojuego == inventario.IdVideojuego);

            if (!videojuegoExiste)
            {
                return "El videojuego especificado no existe.";
            }

            if (inventario.Stock < 0)
            {
                return "El stock no puede ser negativo.";
            }

            if (DatosInventario.contadorInventario < DatosInventario.inventario.Length)
            {
                DatosInventario.inventario[DatosInventario.contadorInventario] = inventario;
                DatosInventario.contadorInventario++;
                return "El inventario se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para eliminar un registro del inventario por tienda y videojuego
        public string EliminarVideojuegoXTienda(int idTienda, int idVideojuego)
        {
            for (int i = 0; i < DatosInventario.contadorInventario; i++)
            {
                if (DatosInventario.inventario[i].IdTienda == idTienda &&
                    DatosInventario.inventario[i].IdVideojuego == idVideojuego)
                {
                    for (int j = i; j < DatosInventario.contadorInventario - 1; j++)
                    {
                        DatosInventario.inventario[j] = DatosInventario.inventario[j + 1];
                    }

                    DatosInventario.inventario[DatosInventario.contadorInventario - 1] = null;
                    DatosInventario.contadorInventario--;
                    return "El registro del inventario ha sido eliminado correctamente.";
                }
            }
            return "El inventario especificado no existe.";
        }

        // Método para buscar un inventario específico por tienda y videojuego
        public VideojuegosXTiendaEntidad BuscarInventario(int idTienda, int idVideojuego)
        {
            return DatosInventario.inventario
                .FirstOrDefault(i => i != null && i.IdTienda == idTienda && i.IdVideojuego == idVideojuego);
        }

        // Método para obtener todo el inventario registrado
        public VideojuegosXTiendaEntidad[] ObtenerTodoInventario()
        {
            VideojuegosXTiendaEntidad[] lista = new VideojuegosXTiendaEntidad[DatosInventario.contadorInventario];
            Array.Copy(DatosInventario.inventario, lista, DatosInventario.contadorInventario);
            return lista;
        }

        // Método adicional para obtener el inventario específico de una tienda
        public VideojuegosXTiendaEntidad[] ObtenerInventarioPorTienda(int idTienda)
        {
            return DatosInventario.inventario
                .Where(i => i != null && i.IdTienda == idTienda)
                .ToArray();
        }
    }
}