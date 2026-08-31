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
    public class VegetalesBLL
    {
        public void Guardar(Vegetales entidad)
        {
            VegetalesDAL.Insertar(entidad);
        }

        public List<VegetalesDTO> ObtenerPorNombre(string nombre)
        {
            return VegetalesDAL.ObtenerPorNombre(nombre);
        }

        public void CambiarEstado(string nombre, bool estado)
        {
            VegetalesDAL.CambiarEstadoPorNombre(nombre, estado);
        }

        public void EnviarAIndustria(int cantidad, DateTime fechaEgreso, string nombreVegetal, int idTipoEntorno, string responsable)
        {
            VegetalesDAL.EnviarAIndustria(cantidad, fechaEgreso, nombreVegetal, idTipoEntorno, responsable);
        }

        public int ObtenerPlantinesActivosPorNombre(string nombre)
        {
            return VegetalesDAL.ObtenerPlantinesActivosPorNombre(nombre);
        }

        public int ObtenerCantidadActivaPorNombre(string nombre)
        {
            return VegetalesDAL.ObtenerCantidadActivaPorNombre(nombre);
        }



    }
}
