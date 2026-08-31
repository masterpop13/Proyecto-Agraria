using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Datos.Entidades;
using System.Text.Json;

namespace Agraria.Datos.DAL
{
    public class TabConfigDAL
    {
        private static string filePath = "tabs.json";

        public static List<TabConfig> CargarTabs()
        {
            if (!File.Exists(filePath))
                return new List<TabConfig>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TabConfig>>(json) ?? new List<TabConfig>();
        }

        public static void GuardarTabs(List<TabConfig> tabs)
        {
            string json = JsonSerializer.Serialize(tabs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }


        //////////////////////////////animales ///////////////////////
        ///
        public static List<TabConfig> CargarTabs(string filePath = "tabs.json")
        {
            if (!File.Exists(filePath))
                return new List<TabConfig>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TabConfig>>(json) ?? new List<TabConfig>();
        }

        public static void GuardarTabs(List<TabConfig> tabs, string filePath = "tabs.json")
        {
            string json = JsonSerializer.Serialize(tabs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
