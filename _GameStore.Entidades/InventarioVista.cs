using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GameStore.Entidades
{
    public class InventarioVista
    {
        public int IdTienda { get; set; }
        public string NombreTienda { get; set; }
        public int IdVideojuego { get; set; }
        public string NombreVideojuego { get; set; }
        public int Stock { get; set; }
    }

}
