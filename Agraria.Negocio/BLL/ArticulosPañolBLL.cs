using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System.Collections.Generic;


namespace Agraria.Negocio.BLL
{
    public class ArticulosPañolBLL
    {
        private readonly ArticulosPañolDAL dal = new ArticulosPañolDAL();

        public void Agregar(ArticulosPañol art) => dal.Insertar(art);
        public void Modificar(ArticulosPañol art) => dal.Modificar(art);
        public void CambiarEstado(int id, bool estado) => dal.CambiarEstado(id, estado);
        public List<ArticulosPañolDTO> Listar(string filtro = "") => dal.Listar(filtro);
    }
}
