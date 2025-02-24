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
// Capa lógica para manejar tiendas.

using _45GAMES4U_Inventario.Entidad;
using _45GAMES4U_Inventario.AccesoDatos;

namespace _45GAMES4U_Inventario.LogicaNegocio
{
    public class TiendaLogica
    {
        // Método para agregar una nueva tienda con validaciones
        public string AgregarTienda(TiendaEntidad tienda)
        {
            // Validar duplicado por ID
            for (int i = 0; i < DatosInventario.contadorTiendas; i++)
            {
                if (DatosInventario.tiendas[i].IdTienda == tienda.IdTienda)
                {
                    return "Ya existe una tienda registrada con este ID.";
                }
            }

            if (string.IsNullOrWhiteSpace(tienda.Nombre))
            {
                return "El nombre de la tienda es obligatorio.";
            }

            if (string.IsNullOrWhiteSpace(tienda.Direccion))
            {
                return "La dirección de la tienda es obligatoria.";
            }

            if (string.IsNullOrWhiteSpace(tienda.Telefono))
            {
                return "El teléfono de la tienda es obligatorio.";
            }

            if (DatosInventario.contadorTiendas < DatosInventario.tiendas.Length)
            {
                DatosInventario.tiendas[DatosInventario.contadorTiendas] = tienda;
                DatosInventario.contadorTiendas++;
                return "La tienda se ha registrado correctamente.";
            }
            else
            {
                return "No se pueden ingresar más registros.";
            }
        }

        // Método para eliminar una tienda por ID
        public string EliminarTienda(int idTienda)
        {
            for (int i = 0; i < DatosInventario.contadorTiendas; i++)
            {
                if (DatosInventario.tiendas[i].IdTienda == idTienda)
                {
                    for (int j = i; j < DatosInventario.contadorTiendas - 1; j++)
                    {
                        DatosInventario.tiendas[j] = DatosInventario.tiendas[j + 1];
                    }

                    DatosInventario.tiendas[DatosInventario.contadorTiendas - 1] = null;
                    DatosInventario.contadorTiendas--;
                    return "La tienda ha sido eliminada correctamente.";
                }
            }
            return "La tienda con el ID especificado no existe.";
        }

        // Método para buscar tienda por ID
        public TiendaEntidad BuscarTiendaPorId(int idTienda)
        {
            return DatosInventario.tiendas
                .FirstOrDefault(t => t != null && t.IdTienda == idTienda);
        }

        // Método para obtener todas las tiendas registradas
        public TiendaEntidad[] ObtenerTodasTiendas()
        {
            TiendaEntidad[] lista = new TiendaEntidad[DatosInventario.contadorTiendas];
            Array.Copy(DatosInventario.tiendas, lista, DatosInventario.contadorTiendas);
            return lista;
        }

        // Método adicional para obtener tiendas por administrador específico
        public TiendaEntidad[] ObtenerTiendasPorAdministrador(int idAdministrador)
        {
            return DatosInventario.tiendas
                .Where(t => t != null && t.IdAdministrador == idAdministrador)
                .ToArray();
        }
    }
}