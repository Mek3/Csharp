using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{


    public class Presa
    {
        public int Puntos { get; set; }
        public Coordenadas coordenadas { get; set; }

        public Presa(Coordenadas coordenadas)
        {
            this.coordenadas = coordenadas;
        }
    }
}