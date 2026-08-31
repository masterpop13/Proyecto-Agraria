using Agraria.Datos.DAL;
using Agraria.DTO;
using Agraria.Entidades;
using System;
using System.Data;

namespace Agraria.Negocio.BLL
{
    public class LecheBLL
    {
        public void Insertar(Leche leche)
        {
            LecheDAL.Insertar(leche);
        }

            public List<LecheDTO> Listar(string nombrePagina)
            {
                return LecheDAL.Listar(nombrePagina);
            }
        

        public void ActualizarEstado(string numeroAnimal, bool nuevoEstado, DateTime fechaFallecido)
        {
            LecheDAL.ActualizarEstado(numeroAnimal, nuevoEstado, fechaFallecido);
        }

        public DataTable BuscarPorNumeroAnimal(string numero, string nombrePagina)
        {
            return LecheDAL.BuscarPorNumeroAnimal(numero, nombrePagina);
        }

      //  public (int animalesActivos, decimal litros) TotalesLeche(string nombrePagina)
      //  {
     //      return LecheDAL.TotalesLeche(nombrePagina);
      //  }
        public void MarcarEnviados(string nombrePagina)
        {
            LecheDAL.MarcarEnviados(nombrePagina);
        }

        public (int total, decimal litros) TotalesLeche(string nombrePagina)
         => LecheDAL.TotalesPorPagina(nombrePagina);
    }
}
