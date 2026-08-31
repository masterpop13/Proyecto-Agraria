using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;


namespace Agraria.Negocio.BLL
{
    public class ProduccionVegetalBLL
    {
        public void Guardar(ProduccionVegetal entidad)
        {
            ProduccionVegetalDAL.Insertar(entidad);
        }

        public List<ProduccionVegetalDTO> ObtenerProduccion()
        {
            return ProduccionVegetalDAL.ObtenerTodo();
        }

        public int ObtenerSumPlantinesActivos()
        {
            return ProduccionVegetalDAL.SumarPlantinesActivos();
        }

        public int ObtenerSumAtadosActivos()
        {
            return ProduccionVegetalDAL.SumarAtadosActivos();
        }

        public List<int> ObtenerCantidadesAtadosDistinct()
        {
            return ProduccionVegetalDAL.ObtenerCantidadesAtadosDistinct();
        }
        public void EnviarAIndustria(int cantidadAtados, DateTime fechaEgreso, int idTipoEntorno, string responsable)
        {
            ProduccionVegetalDAL.EnviarAIndustria(cantidadAtados, fechaEgreso, idTipoEntorno, responsable);
        }
        public bool ResetearPlantinesActivos()
        {
            return ProduccionVegetalDAL.ResetearPlantinesActivos();
        }
    }
}
