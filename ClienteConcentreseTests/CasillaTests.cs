using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClienteConcentrese;

namespace ClienteConcentreseTests
{
    [TestClass]
    public class CasillaTests
    {
        [TestMethod]
        public void EstadoInicial_Es_Oculta()
        {
            // Arrange
            int esperado = Casilla.OCULTA;
            int numero = 1;
            int valor = 2;
            string imagen = "imagen";

            // Act
            Casilla casilla = new Casilla(numero, valor, imagen);

            // Assert
            Assert.AreEqual(esperado, casilla.Estado);
        }

        [TestMethod]
        public void AlSeleccionar_EstadoEs_Visible()
        {
            // Arrange
            int esperado = Casilla.VISIBLE;
            int numero = 1;
            int valor = 2;
            string imagen = "imagen";
            Casilla casilla = new Casilla(numero, valor, imagen);

            // Act
            casilla.Seleccionar();

            // Assert
            Assert.AreEqual(esperado, casilla.Estado);
        }

        [TestMethod]
        public void AlOcultar_EstadoEs_Oculta()
        {
            // Arrange
            int esperado = Casilla.OCULTA;
            int numero = 1;
            int valor = 2;
            string imagen = "imagen";
            Casilla casilla = new Casilla(numero, valor, imagen);

            // Act
            casilla.Ocultar();

            // Assert
            Assert.AreEqual(esperado, casilla.Estado);
        }

        [TestMethod]
        public void AlDescubrir_EstadoEs_Descubierta()
        {
            // Arrange
            int esperado = Casilla.DESCUBIERTA;
            int numero = 1;
            int valor = 2;
            string imagen = "imagen";
            Casilla casilla = new Casilla(numero, valor, imagen);

            // Act
            casilla.Descubrir();

            // Assert
            Assert.AreEqual(esperado, casilla.Estado);
        }

        [TestMethod]
        public void EsParejaDe_OtraCasilla_ConElMismoValor()
        {
            // Arrage
            int numero1 = 1;
            int numero2 = 2;
            string imagen = "imagen";
            int valor = 5;
            Casilla casilla1 = new Casilla(numero1, valor, imagen);
            Casilla casilla2 = new Casilla(numero2, valor, imagen);

            // Act
            bool actual = casilla1.EsParejaDe(casilla2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void No_EsParejaDe_OtraCasilla_ConDiferenteValor()
        {
            // Arrage
            int numero1 = 1;
            int numero2 = 2;
            string imagen = "imagen";
            int valor1 = 5;
            int valor2 = 7;
            Casilla casilla1 = new Casilla(numero1, valor1, imagen);
            Casilla casilla2 = new Casilla(numero2, valor2, imagen);

            // Act
            bool actual = casilla1.EsParejaDe(casilla2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Propiedades_Son_Correcas_Cuando_SeCrea()
        {
            // Arrage
            int numero = 1;
            string imagen = "imagen";
            int valor = 5;

            // Act
            Casilla casilla = new Casilla(numero, valor, imagen);

            // Assert
            Assert.AreEqual(numero, casilla.Numero, "El numero de la casilla no es el esperado");
            Assert.AreEqual(valor, casilla.Valor);
            Assert.AreEqual(imagen, casilla.Imagen);
        }
    }
}
