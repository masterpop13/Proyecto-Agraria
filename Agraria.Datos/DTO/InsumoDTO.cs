using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{

    public class InsumoDTO
    {
        public int IdInsumoRepresentativo { get; set; }
        public string NombreProducto { get; set; }
        public decimal StockTotal { get; set; }
        public int IdTipoMedida { get; set; }
        public string NombreTipoMedida { get; set; }  // se llena con join a TipoMedida
    }



}
