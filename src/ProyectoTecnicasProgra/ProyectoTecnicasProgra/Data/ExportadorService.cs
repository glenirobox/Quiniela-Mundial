using System.Collections.Generic;
using System.Text;
using ProyectoTecnicasProgra.Models;

namespace ProyectoTecnicasProgra.Data
{
    /// <summary>
    /// Servicio encargado de exportar datos del sistema a formatos descargables.
    /// </summary>
    public class ExportadorService
    {
        /// <summary>
        /// Genera un archivo CSV codificado en bytes a partir de una colección de objetos.
        /// </summary>
        /// <param name="posiciones">Colección de datos de posiciones o usuarios.</param>
        /// <returns>Arreglo de bytes listo para descargar.</returns>
        public byte[] GenerarCsvPosiciones(IEnumerable<dynamic> posiciones)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Usuario,Rol");

            foreach (var item in posiciones)
            {
                if (item is Usuario u)
                {
                    sb.AppendLine($"{u.Username},{u.Rol}");
                }
                else
                {
                    sb.AppendLine($"{item}");
                }
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}