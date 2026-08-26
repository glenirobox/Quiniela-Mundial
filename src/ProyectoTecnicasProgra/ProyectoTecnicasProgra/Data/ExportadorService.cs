using System.Text;
using ProyectoTecnicasProgra.Models;

namespace ProyectoTecnicasProgra.Data
{
    /// <summary>
    /// Servicio encargado de generar archivos CSV a partir de listas de datos del sistema.
    /// </summary>
    public class ExportadorService
    {
        /// <summary>
        /// Genera el contenido en formato CSV con la tabla de posiciones de la quiniela.
        /// </summary>
        /// <param name="posiciones">Lista de datos de posiciones a exportar.</param>
        /// <returns>Arreglo de bytes listo para su descarga.</returns>
        public byte[] GenerarCsvPosiciones(IEnumerable<dynamic> posiciones)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Posicion,Usuario,Puntos");

            int pos = 1;
            foreach (var item in posiciones)
            {
                sb.AppendLine($"{pos},{item.Nombre},{item.Puntos}");
                pos++;
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}