using System;
using System.Collections.Generic;
using System.Linq;

namespace Agraria.Negocio.Helpers
{
    public static class UrgenciaService
    {
        private static List<(DateTime Fecha, string Mensaje)> _mensajes = new();

        // Guarda un mensaje con fecha actual
        public static void AgregarMensaje(string mensaje)
        {
            _mensajes.Add((DateTime.Now, mensaje));
            LimpiarMensajesViejos();
        }

        // Devuelve todos los mensajes acumulados del día
        public static List<string> ObtenerMensajesDelDia()
        {
            LimpiarMensajesViejos();
            return _mensajes
                .Where(m => m.Fecha.Date == DateTime.Now.Date)
                .Select(m => m.Mensaje)
                .ToList();
        }

        // Elimina los mensajes de días anteriores
        private static void LimpiarMensajesViejos()
        {
            _mensajes = _mensajes
                .Where(m => m.Fecha.Date == DateTime.Now.Date)
                .ToList();
        }

        // Saber si hay mensajes activos
        public static bool HayMensajes() => ObtenerMensajesDelDia().Any();
    }
}
