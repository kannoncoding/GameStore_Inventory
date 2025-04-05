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
// Capa lógica para manejar tipos de videojuegos.

using _GameStore.Entidades;
using _GameStore.Datos;

namespace _GameStore.Logica
{
    public class TipoVideojuegoLogica
    {
        // Método para agregar un nuevo tipo de videojuego con validaciones
        public string AgregarTipoVideojuego(TipoVideojuegoEntidad tipo)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(tipo.Nombre))
                return "El nombre del tipo de videojuego no puede estar vacío.";

            if (string.IsNullOrWhiteSpace(tipo.Descripcion))
                return "La descripción del tipo de videojuego no puede estar vacía.";

            try
            {
                TipoVideojuegoDatos datos = new TipoVideojuegoDatos();

                // Validar si ya existe por ID
                var existente = BuscarTipoPorId(tipo.IdTipoVideojuego);
                if (existente != null)
                {
                    return "Ya existe un tipo de videojuego con este ID.";
                }

                // Validar si ya existe por nombre
                var lista = datos.ObtenerTodos();
                bool nombreDuplicado = lista.Any(t => t.Nombre.Equals(tipo.Nombre, StringComparison.OrdinalIgnoreCase));
                if (nombreDuplicado)
                {
                    return "Ya existe un tipo de videojuego con este nombre.";
                }

                // Insertar en la base de datos
                bool exito = datos.Agregar(tipo);
                return exito
                    ? "El tipo de videojuego se ha registrado correctamente."
                    : "No se pudo registrar el tipo de videojuego.";
            }
            catch (Exception ex)
            {
                return "Error al registrar en la base de datos: " + ex.Message;
            }
        }


        // Método para buscar un tipo por ID
        public TipoVideojuegoEntidad? BuscarTipoPorId(int id)
        {
            TipoVideojuegoDatos datos = new TipoVideojuegoDatos();
            return datos.BuscarPorId(id);
        }


        // Método para obtener todos los tipos
        public TipoVideojuegoEntidad[] ObtenerTodosTipos()
        {
            TipoVideojuegoEntidad[] tipos = new TipoVideojuegoEntidad[DatosInventario.contadorTiposVideojuegos];
            Array.Copy(DatosInventario.tiposVideojuegos, tipos, DatosInventario.contadorTiposVideojuegos);
            return tipos;
        }
    }
}