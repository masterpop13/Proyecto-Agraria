using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System;
using System.Collections.Generic;

namespace Agraria.Negocio.BLL
{
    public class RegistroFertilidadCarneBLL
    {
        public void GuardarMonta(string nombre, string madre, string padre, DateTime fechaMonta, DateTime fechaParto)
            => RegistroFertilidadCarneDAL.GuardarMonta(nombre, madre, padre, fechaMonta, fechaParto);

        public void GuardarNacimiento(string nombre, string madre, string padre, DateTime fechaParto,
                                      int hembras, int machos, int total)
            => RegistroFertilidadCarneDAL.GuardarNacimiento(nombre, madre, padre, fechaParto, hembras, machos, total);

        public List<RegistroFertilidadCarneDTO> ListarRegistrosFertilidad(string nombre)
        {
            return RegistroFertilidadCarneDAL.ListarRegistrosFertilidad(nombre);
        }
    }
}
