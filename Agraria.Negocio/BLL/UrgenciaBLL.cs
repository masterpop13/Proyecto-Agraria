using Agraria.Datos.DAL;
using System.Collections.Generic;

namespace Agraria.Negocio.BLL
{
    public class UrgenciaBLL
    {
        public void Agregar(string mensaje)
        {
            UrgenciaDAL.Insertar(mensaje);
        }

        public List<string> ObtenerMensajesDelDia()
        {
            return UrgenciaDAL.ObtenerMensajesDelDia();
        }

        public bool HayMensajes()
        {
            return UrgenciaDAL.HayMensajesDelDia();
        }
    }
}
