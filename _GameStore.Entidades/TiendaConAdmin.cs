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
// Descripción: Clase auxiliar para mostrar tiendas con nombre de administrador

namespace _GameStore.Entidades
{
    public class TiendaConAdmin
    {
        public int IdTienda { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NombreAdministrador { get; set; }
    }
}