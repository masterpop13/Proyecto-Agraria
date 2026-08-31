using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Agraria.Datos.Entidades;

namespace Agraria.Datos.DAL
{
    public class GrupoBoxDAL
    {
        private static string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grupoBox.json");

        public static void Guardar(List<GrupoBoxInfo> lista)
        {
            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, json);
        }

        public static List<GrupoBoxInfo> Cargar()
        {
            if (!File.Exists(rutaArchivo))
                return new List<GrupoBoxInfo>();

            string json = File.ReadAllText(rutaArchivo);
            return JsonSerializer.Deserialize<List<GrupoBoxInfo>>(json) ?? new List<GrupoBoxInfo>();
        }
    }
}
