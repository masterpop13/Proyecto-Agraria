using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class Alimento
    {
        public int IdAlimento { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Cantidad { get; set; }
        public int IdTipoMedida { get; set; }
        public decimal Precio { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int IdTipoEntorno { get; set; }
        public int IdProveedor { get; set; }
        public bool Estado { get; set; }
    }
}
