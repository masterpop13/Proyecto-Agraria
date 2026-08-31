using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class ArticulosPañolDTO
    {
        public int IdArtPañol { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Entorno { get; set; }
        public string Responsable { get; set; }
        public bool Estado { get; set; }
    }
}
