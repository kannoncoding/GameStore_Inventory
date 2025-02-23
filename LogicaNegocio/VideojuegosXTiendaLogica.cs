﻿using System;
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

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.AccesoDatos;

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class VideojuegosXTiendaLogica
    {
        private VideojuegosXTiendaDatos inventarioDatos;
        private VideojuegoDatos videojuegoDatos;
        private TiendaDatos tiendaDatos;

        // Constructor inicializa clases de acceso a datos
        public VideojuegosXTiendaLogica()
        {
            inventarioDatos = new VideojuegosXTiendaDatos();
            videojuegoDatos = new VideojuegoDatos();
            tiendaDatos = new TiendaDatos();
        }

        // Método para agregar inventario con validaciones
        public string AgregarInventario(VideojuegosXTiendaEntidad inventario)
        {
            // Validar duplicado del inventario
            if (inventarioDatos.ExisteInventario(inventario.IdTienda, inventario.IdVideojuego))
            {
                return "Ya existe un registro de inventario para este videojuego en esta tienda.";
            }

            // Validar existencia previa de la tienda
            if (!tiendaDatos.ExisteTienda(inventario.IdTienda))
            {
                return "La tienda especificada no existe.";
            }

            // Validar existencia previa del videojuego
            if (!videojuegoDatos.ExisteVideojuego(inventario.IdVideojuego))
            {
                return "El videojuego especificado no existe.";
            }

            // Validar que el stock sea positivo
            if (inventario.Stock < 0)
            {
                return "El stock no puede ser negativo.";
            }

            bool agregado = inventarioDatos.AgregarInventario(inventario);

            if (agregado)
            {
                return "El inventario se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para buscar un inventario específico por tienda y videojuego
        public VideojuegosXTiendaEntidad BuscarInventario(int idTienda, int idVideojuego)
        {
            return inventarioDatos.BuscarInventario(idTienda, idVideojuego);
        }

        // Método para obtener todo el inventario registrado
        public VideojuegosXTiendaEntidad[] ObtenerTodoInventario()
        {
            return inventarioDatos.ObtenerTodos();
        }

        // Método adicional para obtener el inventario específico de una tienda
        public VideojuegosXTiendaEntidad[] ObtenerInventarioPorTienda(int idTienda)
        {
            return inventarioDatos.ObtenerInventarioPorTienda(idTienda);
        }
    }
}
