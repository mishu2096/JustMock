using System;
using System.Collections.Generic;
using System.Text;

namespace Just
{
    public abstract class Cine
    {
        public abstract int ButacasLibres(string pelicula);
        public abstract List<string> Descargar(string pelicula, int cantidadEntradas);
        public abstract List<string> DescargarTicket(string pelicula, int cantidadEntradas);

    }
}
