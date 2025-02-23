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
// Capa lógica para manejar videojuegos.

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.AccesoDatos;

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class VideojuegoLogica
    {
        private VideojuegoDatos videojuegoDatos;
        private TipoVideojuegoDatos tipoVideojuegoDatos;

        // Constructor inicializa clases de acceso a datos
        public VideojuegoLogica()
        {
            videojuegoDatos = new VideojuegoDatos();
            tipoVideojuegoDatos = new TipoVideojuegoDatos();
        }

        // Método para agregar un nuevo videojuego con validaciones
        public string AgregarVideojuego(VideojuegoEntidad videojuego)
        {
            // Validar duplicado
            if (videojuegoDatos.ExisteVideojuego(videojuego.IdVideojuego))
            {
                return "Ya existe un videojuego registrado con este ID.";
            }

            // Validar existencia del tipo de videojuego
            if (!tipoVideojuegoDatos.ExisteTipo(videojuego.IdTipoVideojuego))
            {
                return "El tipo de videojuego seleccionado no existe.";
            }

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(videojuego.Nombre))
            {
                return "El nombre del videojuego no puede estar vacío.";
            }

            if (videojuego.Precio <= 0)
            {
                return "El precio debe ser mayor que cero.";
            }

            if (string.IsNullOrWhiteSpace(videojuego.Plataforma))
            {
                return "Debe especificar la plataforma del videojuego.";
            }

            if (string.IsNullOrWhiteSpace(videojuego.ClasificacionEdad))
            {
                return "Debe indicar la clasificación por edad del videojuego.";
            }

            bool agregado = videojuegoDatos.AgregarVideojuego(videojuego);

            if (agregado)
            {
                return "El videojuego se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para buscar videojuego por ID
        public VideojuegoEntidad BuscarVideojuegoPorId(int id)
        {
            return videojuegoDatos.BuscarPorId(id);
        }

        // Método para obtener todos los videojuegos registrados
        public VideojuegoEntidad[] ObtenerTodosVideojuegos()
        {
            return videojuegoDatos.ObtenerTodos();
        }

        // Método adicional para obtener videojuegos por tipo específico
        public VideojuegoEntidad[] ObtenerVideojuegosPorTipo(int idTipo)
        {
            return videojuegoDatos.BuscarPorTipo(idTipo);
        }
    }
}
