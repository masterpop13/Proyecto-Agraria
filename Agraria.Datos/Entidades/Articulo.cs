using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Entidades
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public int IdTipoMedida { get; set; }
        public decimal? Precio { get; set; }   // <-- CAMBIO: nullable
        public DateTime FechaIngreso { get; set; }
        public int IdTipoEntorno { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaEgreso { get; set; }

        public bool Estado { get; set; }
    }
}
