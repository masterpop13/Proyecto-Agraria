using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class PreguntaSeguridadBLL
    {
        private PreguntaSeguridadDAL _dal;

        public PreguntaSeguridadBLL()
        {
            _dal = new PreguntaSeguridadDAL();
        }

        public List<PreguntaSeguridadDTO> ObtenerPreguntas()
        {
            return _dal.ObtenerPreguntas();
        }
    }
}