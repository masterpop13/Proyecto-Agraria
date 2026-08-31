using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.DTO
{
    public class IndustriaDTO
    {
        [DisplayName("ID Registro")]
        public int IdRegistroIndustria { get; set; }

        [DisplayName("Industria")]
        public int IdIndustria { get; set; }

        [DisplayName("Producto")]
        public string NombreProducto { get; set; }

        [DisplayName("Cantidad Producida")]
        public int CantidadProduccion { get; set; }

        [DisplayName("Fecha de Producción")]
        public DateTime FechaProduccion { get; set; }

        [DisplayName("Insumo")]
        public string NombreInsumo { get; set; }

        [DisplayName("Cantidad de Insumos")]
        public int CantidadInsumos { get; set; }
    }



}
