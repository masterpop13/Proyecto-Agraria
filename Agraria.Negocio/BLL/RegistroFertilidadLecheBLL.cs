using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Negocio.BLL
{
    public class RegistroFertilidadLecheBLL
    {
        public void Insertar(RegistroFertilidadLeche registro)
        {
            RegistroFertilidadLecheDAL.Insertar(registro);
        }

            public List<RegistroFertilidadLecheDTO> Listar(string nombrePagina)
            {
                return RegistroFertilidadLecheDAL.Listar(nombrePagina);
            }


            public DataTable Buscar(string texto, string nombrePagina)
        {
            return RegistroFertilidadLecheDAL.Buscar(texto, nombrePagina);
        }

    }
}
