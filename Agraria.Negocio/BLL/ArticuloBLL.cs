using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Entidades;
using Agraria.Datos.DTO;
using Agraria.Datos;


namespace Agraria.Negocio
{
    public class ArticuloBLL
    {
        private ArticuloDAL dal = new ArticuloDAL();

        public void AgregarArticulo(Articulo articulo)
        {
            dal.InsertarArticulo(articulo);
        }

        public void Modificar(Articulo articulo)
        {
            dal.Modificar(articulo);
        }

        public List<ArticuloDTO> ListarArticulos(string filtro = "")
        {
            return dal.ObtenerArticulos(filtro);
        }

        public int ObtenerStock(int idArticulo)
        {
            return ArticuloDAL.ObtenerStock(idArticulo);
        }
        public List<InsumoDTO> ObtenerInsumosAgrupados()
        {
            return dal.ObtenerInsumosAgrupados();
        }

        public void InsertarDesdeLeche(string nombreProducto, decimal cantidad, DateTime fechaEnviado, string responsable)
        {
            ArticuloDAL.InsertarDesdeLeche(nombreProducto, cantidad, fechaEnviado, responsable);
        }
    }
}

