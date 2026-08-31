using Agraria.Datos.DAL;
using Agraria.Datos.Entidades;
using Agraria.Entidades;
using System.Collections.Generic;

namespace Agraria.Negocio.BLL
{
    public class AlimentoBLL
    {
        public void Agregar(Alimento alimento)
        {
            AlimentoDAL.Insertar(alimento);
        }

        public void Modificar(Alimento alimento)
        {
            AlimentoDAL.Modificar(alimento);
        }

        public List<Alimento> Listar(string filtro = "")
        {
            return AlimentoDAL.Listar(filtro);
        }
    }
}
