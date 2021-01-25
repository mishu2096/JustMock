using System;
using System.Collections.Generic;
using System.Linq;

namespace Just
{
    internal class Persona
    {
      
        public bool ObtuvoEtradas { get{ return Entradas != null && Entradas.Any(); }}

        public  List<string>Entradas { get; set; }

        internal void CompraEntradas(Cine cine, int cantidadEntradas, string pelicula)
        {
           var butacasLibres = cine.ButacasLibres(pelicula);
           if (cine.ButacasLibres(pelicula) >= cantidadEntradas)
            {
              
                Entradas = cine.Descargar(pelicula, cantidadEntradas);
               // ObtuvoEtradas = true;
            }
            else
            {
                Entradas = cine.Descargar(pelicula, butacasLibres);

            }
           
        }
        // ObtuvoEtradas = false;
        internal void CompraEntradas(Cine cine, int cantidadEntradas, string pelicula,ImodeloCompra modeloCompra)
        {
            Entradas = modeloCompra.Comprar(cine, cantidadEntradas, pelicula);
        }



    }
}