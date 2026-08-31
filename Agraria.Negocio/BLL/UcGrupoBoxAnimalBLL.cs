using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Negocio.BLL;

namespace Agraria.Negocio.BLL
{
    public class UcGrupoBoxAnimalBLL
    {
        private readonly AvesBLL _bllAves = new AvesBLL();
        private readonly ColmenasBLL _bllColmenas = new ColmenasBLL();
        private readonly EngordeBLL _bllEngorde = new EngordeBLL();
        private readonly CarneBLL _bllCarne = new CarneBLL();
        private readonly LecheBLL _bllLeche = new LecheBLL();

        public UcGrupoBoxAnimalDTO ObtenerTotales(string nombrePagina)
        {
            string low = nombrePagina.ToLower();
            var dto = new UcGrupoBoxAnimalDTO { NombrePagina = nombrePagina };

            try
            {
                if (low.Contains("colmena"))
                {
                    var (colmenas, miel) = _bllColmenas.TotalesColmenas(nombrePagina);
                    dto.CantidadActual = colmenas;
                    dto.CantidadProducida = miel;
                }
                else if (low.Contains("engorde") || low.Contains("pollo"))
                {
                    var (actual, producido) = _bllEngorde.TotalesEngorde(nombrePagina);
                    dto.CantidadActual = actual;
                    dto.CantidadProducida = producido;
                }
                else if (low.Contains("carne") || low.Contains("cerdo"))
                {
                    var (activos, producidos) = _bllCarne.TotalesCarne(nombrePagina);
                    dto.CantidadActual = activos;
                    dto.CantidadProducida = producidos;
                }
                else if (low.Contains("leche"))
                {
                    var (activos, litros) = _bllLeche.TotalesLeche(nombrePagina);
                    dto.CantidadActual = activos;
                    dto.CantidadProducida = litros;
                }
                else
                {
                    // Por defecto, asumimos Huevos
                    var (aves, huevos) = _bllAves.Totales(nombrePagina);
                    dto.CantidadActual = aves;
                    dto.CantidadProducida = huevos;
                }
            }
            catch
            {
                dto.CantidadActual = 0;
                dto.CantidadProducida = 0;
            }

            return dto;
        }
    }
}
