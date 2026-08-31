using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;

namespace Agraria.Negocio.BLL
{
    public class AvesBLL
    {
        public void GuardarIngresoAves(string nombre, int cantidad, DateTime fecha)
            => AvesDAL.InsertIngresoAves(nombre, cantidad, fecha);

        public void GuardarHuevos(string nombre, int huevos, DateTime fecha)
            => AvesDAL.InsertHuevos(nombre, huevos, fecha);

        public void GuardarRetiroAves(string nombre, int retiradas, DateTime fecha)
            => AvesDAL.InsertRetiroAves(nombre, retiradas, fecha);

        public List<AvesDTO> ListarPorNombre(string nombre)
            => AvesDAL.ListarPorNombre(nombre);

        public (int totalAvesActuales, int totalHuevos) Totales(string nombre)
            => AvesDAL.ObtenerTotalesPorNombre(nombre);

        public void EnviarHuevosAIndustria(string nombreProducto, int cantidad, DateTime fecha, int idTipoEntorno, string responsable, int idTipoMedida = 2)
            => AvesDAL.EnviarHuevosAIndustria(nombreProducto, cantidad, fecha, idTipoEntorno, responsable, idTipoMedida);
        public int ObtenerTotalHuevosActivos(string nombre)
        {
            return AvesDAL.ObtenerTotalHuevosActivos(nombre);
        }

            public (int total, int huevos) TotalesHuevos(string nombrePagina)
                => AvesDAL.TotalesPorPagina(nombrePagina);
  

}
}
