using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace Just
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CompraticketsButacka()
        {
            int cantidadEntradas = 2;
            string pelicula = "La Vida es Bella";
            var cine = Mock.Create<Cine>();
            cine.Arrange(cine1 => cine1.ButacasLibres(pelicula)).Returns(20);
            cine.Arrange(cine1 => cine1.Descargar(pelicula, cantidadEntradas)).Returns(new List<string> { "E1", "E2" });



            Persona persona = new Persona();
            persona.CompraEntradas(cine, cantidadEntradas, pelicula);

           
            Assert.IsTrue(persona.ObtuvoEtradas);
         
            cine.Assert(cine1 => cine1.ButacasLibres(pelicula));
            cine.Assert(cine1 => cine1.Descargar(pelicula, cantidadEntradas));

        }
        [TestMethod]
        public void noCompraticketsButacka()
        {
            int cantidadEntradas = 2;
            string pelicula = "La Vida es Bella";
            var cine = Mock.Create<Cine>();
            cine.Arrange(cine1 => cine1.ButacasLibres(pelicula)).Returns(0);
           



            Persona persona = new Persona();
            persona.CompraEntradas(cine, cantidadEntradas, pelicula);


            Assert.IsFalse(persona.ObtuvoEtradas);

            cine.Assert(cine1 => cine1.ButacasLibres(pelicula));

        }
        [TestMethod]
        public void noCompraticketsButackaSoloUnaPersona()
        {
            int cantidadEntradas = 6;
            int entradaDisponible = 5;
            string pelicula = "La Vida es Bella";
            var cine = Mock.Create<Cine>();
            cine.Arrange(cine1 => cine1.ButacasLibres(pelicula)).Returns(entradaDisponible);
            cine.Arrange(cine1 => cine1.Descargar(pelicula, 5)).Returns(new List<string> { "E1","E2","E3","E4","E5"});



            Persona persona = new Persona();
            persona.CompraEntradas(cine, cantidadEntradas, pelicula);


            Assert.IsTrue(persona.ObtuvoEtradas);
            Assert.AreEqual(entradaDisponible,persona.Entradas.Count );

            cine.Assert(cine1 => cine1.ButacasLibres(pelicula));
            cine.Assert(cine1 => cine1.Descargar(pelicula, entradaDisponible));

        }

        [TestMethod]
        public void DadoQueNoHayLasEntradasQueQuieroComproUna()
        {
            int cantidadEntradas = 7;
            int entradaDisponible = 5;
            int entradasEsperadas = 1;
            string pelicula = "La Vida es Bella";

            var cine = Mock.Create<Cine>();
            cine.Arrange(cine1 => cine1.ButacasLibres(pelicula)).Returns(entradaDisponible);
            cine.Arrange(cine1 => cine1.DescargarTicket(pelicula, entradasEsperadas)).Returns(new List<string> { "E1" });

            var modeloCompra = Mock.Create<ImodeloCompra>();
            modeloCompra.Arrange(m => m.Comprar(cine, cantidadEntradas, pelicula)).Returns(new List<string> { "E1" });


            Persona persona = new Persona();
            persona.CompraEntradas(cine, cantidadEntradas, pelicula,modeloCompra);


            Assert.IsTrue(persona.ObtuvoEtradas);
            Assert.AreEqual(entradasEsperadas,persona.Entradas.Count);

            cine.Assert(cine1 => cine1.ButacasLibres(pelicula));
            cine.Assert(cine1 => cine1.Descargar(pelicula,entradasEsperadas));
            modeloCompra.Assert(m => m.Comprar(cine, cantidadEntradas, pelicula));

        }
    }
}
