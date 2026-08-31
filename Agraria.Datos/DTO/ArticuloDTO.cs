using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArticuloDTO
{
    [DisplayName("Codigo")]
    public int IdArticulo { get; set; }

    [DisplayName("Nombre del Producto")]
    public string NombreProducto { get; set; }
    public decimal Cantidad { get; set; }

    public int IdTipoMedida { get; set; }       // 👈 lo agregamos

    [DisplayName("Medicion")]
    public string TipoMedida { get; set; }
    public decimal? Precio { get; set; }

    [DisplayName("Fecha de Ingreso")]
    public DateTime FechaIngreso { get; set; }


    public int IdTipoEntorno { get; set; }      // 👈 lo agregamos

    [DisplayName("Tipo de Entorno")]
    public string TipoEntorno { get; set; }
    public string Responsable { get; set; }

    [DisplayName("Fecha de Egreso")]
    public DateTime FechaEgreso { get; set; }
    public bool Estado { get; set; }
}

