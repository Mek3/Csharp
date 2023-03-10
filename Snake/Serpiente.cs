
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Serpiente
    {
        public int Tamanyo { get; set; }
        public Coordenadas? coordenadas { get; set; }

        public Serpiente(Coordenadas coordenadas)
        {
            this.coordenadas = coordenadas;
        }

        public void mover(Coordenadas _coordenadas)
        {
            this.coordenadas = _coordenadas;
        }

       

    }
}