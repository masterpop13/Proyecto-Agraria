using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class ColmenasBLL
    {
        public void GuardarIngresoColmenas(string nombre, int cantidad, DateTime fecha)
            => ColmenasDAL.InsertarIngresoColmenas(nombre, cantidad, fecha);

        public void GuardarIngresoMiel(string nombre, int cantidad, DateTime fecha)
            => ColmenasDAL.InsertarIngresoMiel(nombre, cantidad, fecha);

        public void EnviarMielAIndustria(string nombre, int cantidad, DateTime fecha, int idTipoEntorno, string responsable, int idTipoMedida)
            => ColmenasDAL.EnviarMielAIndustria(nombre, cantidad, fecha, idTipoEntorno, responsable, idTipoMedida);

        public List<ColmenaDTO> ListarPorNombre(string nombrePagina)
        {
            return ColmenasDAL.ListarPorNombre(nombrePagina);
        }
        public void MarcarMielEnviada(string nombrePagina, int cantidadAEnviar)
            => ColmenasDAL.MarcarMielEnviada(nombrePagina, cantidadAEnviar);

        public int ObtenerColmenasDisponibles(string nombre)
            => ColmenasDAL.ObtenerColmenasDisponibles(nombre);

        public int ObtenerDisponibles(string nombre)
            => ColmenasDAL.ObtenerTotalesActivos(nombre);

        public void GuardarRetiroColmenas(string nombre, int cantidad, DateTime fecha)
            => ColmenasDAL.InsertarRetiroColmenas(nombre, cantidad, fecha);

        public (int colmenas, int miel) TotalesColmenas(string nombrePagina)
             => ColmenasDAL.TotalesPorPagina(nombrePagina);

    }
}
