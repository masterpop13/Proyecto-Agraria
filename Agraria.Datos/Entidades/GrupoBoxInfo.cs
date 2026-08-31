using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Datos.Entidades
{
    public class GrupoBoxInfo
    {
        public string NombrePagina { get; set; }      // Nombre de la pestaña/tabcontrol
        public string RutaImagen { get; set; }        // Ruta de imagen cargada
        public int CantidadPlantines { get; set; }    // Total plantines activos
        public int CantidadCosechados { get; set; }   // Total cosechados
    }
}
