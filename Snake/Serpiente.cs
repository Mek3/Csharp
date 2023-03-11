
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
        public Coordenadas coordenadas { get; set; }

        public List<CeldaSerpiente> coordenasSerpiente { get; set; }

        public Serpiente(Coordenadas coordenadas, List<CeldaSerpiente> coordenasSerpiente)
        {
            this.coordenadas = coordenadas;
            this.coordenasSerpiente = coordenasSerpiente;
        }
    }

    public class CeldaSerpiente
    {
        public int x { get; set; }
        public int y { get; set; }

        public CeldaSerpiente()
        {
            
        }

        public CeldaSerpiente(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
    }
}