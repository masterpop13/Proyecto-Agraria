using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Agraria.Negocio.BLL
{
    public class EngordeBLL
    {
        // Ingreso inicial
        public void GuardarIngresoPollos(string nombre, int idBox, DateTime fecha, int cantidad)
            => EngordeDAL.GuardarIngresoPollos(nombre, idBox, fecha, cantidad);

        // Actualizaciones (progreso del engorde)
        public void GuardarRegistroEngorde(string nombre, int idBox, DateTime fecha, int cantidad,
                                           int semanas, decimal peso, int idAlimento, decimal alimentoDia)
            => EngordeDAL.GuardarRegistroEngorde(nombre, idBox, fecha, cantidad, semanas, peso, idAlimento, alimentoDia);

        public List<EngordeDTO> Listar(string nombrePagina)
            => EngordeDAL.Listar(nombrePagina);


        public List<EngordeDTO> BuscarPorBox(int idBox)
            => EngordeDAL.BuscarPorBox(idBox);
        public int ObtenerUltimaCantidadDisponible(int idBox)
        {
            return EngordeDAL.ObtenerUltimaCantidadDisponible(idBox);
        }
      //  public (int total, int ultimo) TotalesEngorde(string nombrePagina)
      //  {
      //      return EngordeDAL.TotalesEngorde(nombrePagina);
      //  }

        public DataTable ListarPorNombre(string nombrePagina)
    => EngordeDAL.ListarPorNombre(nombrePagina);

       // public (int totalActual, int totalProducido) TotalesEngorde(string nombrePagina)
        //    => EngordeDAL.TotalesPorPagina(nombrePagina);



        public (int total, decimal producido) TotalesEngorde(string nombrePagina)
            => EngordeDAL.TotalesPorPagina(nombrePagina);


    }
}
