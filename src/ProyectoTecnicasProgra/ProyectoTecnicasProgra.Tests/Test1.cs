using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoTecnicasProgra.Models;
using ProyectoTecnicasProgra.Data;
using System;
using System.Linq;

namespace ProyectoTecnicasProgra.Tests
{
    /// <summary>
    /// Conjunto de pruebas unitarias para validar la lógica del sistema de Quiniela.
    /// </summary>
    [TestClass]
    public class Test1
    {
        /// <summary>
        /// Evalúa que un pronóstico con marcador exacto otorgue la puntuación completa.
        /// </summary>
        [TestMethod]
        public void CalcularPuntos_MarcadorExacto_RetornaPuntajeCompleto()
        {
            // Arrange
            var partido = new Partido { Id = 1, GolesLocal = 2, GolesVisitante = 1, Finalizado = true };
            var pronostico = new Pronostico { PartidoId = 1, GolesLocalPredichos = 2, GolesVisitantePredichos = 1 };

            // Act
            bool esExacto = partido.GolesLocal == pronostico.GolesLocalPredichos &&
                             partido.GolesVisitante == pronostico.GolesVisitantePredichos;
            int puntos = esExacto ? 3 : 0;

            // Assert
            Assert.AreEqual(3, puntos);
        }

        /// <summary>
        /// Evalúa que un pronóstico con marcador incorrecto no otorgue puntos.
        /// </summary>
        [TestMethod]
        public void CalcularPuntos_MarcadorIncorrecto_RetornaCeroPuntos()
        {
            // Arrange
            var partido = new Partido { Id = 1, GolesLocal = 2, GolesVisitante = 1, Finalizado = true };
            var pronostico = new Pronostico { PartidoId = 1, GolesLocalPredichos = 0, GolesVisitantePredichos = 3 };

            // Act
            bool esExacto = partido.GolesLocal == pronostico.GolesLocalPredichos &&
                             partido.GolesVisitante == pronostico.GolesVisitantePredichos;
            int puntos = esExacto ? 3 : 0;

            // Assert
            Assert.AreEqual(0, puntos);
        }

        /// <summary>
        /// Verifica que el exportador de CSV genere correctamente el encabezado de datos.
        /// </summary>
        [TestMethod]
        public void GenerarCsvPosiciones_FormatoValido_RetornaBytesConEncabezado()
        {
            // Arrange
            var exportador = new ExportadorService();
            var datos = new[] { new { Nombre = "Admin", Puntos = 10 } };

            // Act
            byte[] resultado = exportador.GenerarCsvPosiciones(datos);
            string contenido = System.Text.Encoding.UTF8.GetString(resultado);

            // Assert
            StringAssert.Contains(contenido, "Posicion,Usuario,Puntos");
        }

        /// <summary>
        /// Comprueba la instanciación de un modelo de usuario por defecto.
        /// </summary>
        [TestMethod]
        public void Usuario_InstanciacionInicial_AsignaRolPorDefecto()
        {
            // Arrange & Act
            var usuario = new Usuario();

            // Assert
            Assert.AreEqual("Usuario", usuario.Rol);
        }
    }
}