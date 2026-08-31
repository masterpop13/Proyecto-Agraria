using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Agraria.Negocio.BLL
{
    public class CarneBLL
    {
        public bool ExisteNumeroAnimal(string numero) => CarneDAL.ExisteNumeroAnimal(numero);
        public bool AnimalActivoExiste(string numero) => CarneDAL.AnimalActivoExiste(numero);

        public void GuardarProduccion(string nombre, int idBox, string numero, string sexo, DateTime fecha)
            => CarneDAL.GuardarProduccion(nombre, idBox, numero, sexo, fecha);

        public void EnviarAnimalIndustria(string nombre, int idBox, string numero, DateTime fecha, int cantidad, string responsable)
            => CarneDAL.EnviarAnimalIndustria(nombre, idBox, numero, fecha, cantidad, responsable);

       // public List<CarneDTO> ListarCarne(string nombrePagina) => CarneDAL.ListarCarne(nombrePagina);
        public List<CarneDTO> ListarMadres(string nombrePagina) => CarneDAL.ListarMadres(nombrePagina);
        public List<CarneDTO> ListarPadres(string nombrePagina) => CarneDAL.ListarPadres(nombrePagina);

        //  public int TotalesCarne(string nombrePagina)
        //   {
        //       return CarneDAL.TotalesCarne(nombrePagina);
        //   }

        public List<CarneDTO> ListarCarne(string nombrePagina)
        {
            return CarneDAL.ListarPorNombre(nombrePagina);
        }

        //  public (int totalActivos, int totalProducido) TotalesCarne(string nombrePagina)
        //      => CarneDAL.TotalesPorPagina(nombrePagina);
        //
        public bool AnimalActivoExiste(string nombrePagina, string numeroAnimal)
            => CarneDAL.AnimalActivoExiste(nombrePagina, numeroAnimal);

        public void MarcarEnviado(string nombrePagina, string numeroAnimal, DateTime fechaEgreso)
            => CarneDAL.MarcarEnviado(nombrePagina, numeroAnimal, fechaEgreso);


        public bool ExisteAnimalPorNombre(string nombrePagina, string numero)
        {
            return CarneDAL.ExisteAnimalPorNombre(nombrePagina, numero);
        }

        public void RetirarAnimal(string nombrePagina, int idBox, string numero, DateTime fechaRetiro)
        {
            CarneDAL.RetirarAnimal(nombrePagina, idBox, numero, fechaRetiro);
        }

    

        public (int total, decimal producido) TotalesCarne(string nombrePagina)
           => CarneDAL.TotalesPorPagina(nombrePagina);

        public List<CarneDTO> ListarAnimalesActivos(string nombrePagina)
        {
            return CarneDAL.ListarAnimalesActivos(nombrePagina);
        }

    }
}
