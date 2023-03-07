using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    public class Coordenadas
    {

        public int X_Inicio { get; set; } = 2;
        public int Y_Inicio { get; set; } = 2;
        public int X_Fin { get; set; } = 2;
        public int Y_Fin { get; set; } = 2;

        public Coordenadas(int x_inicio, int y_inicio, int x_fin, int y_fin)
        {
            X_Inicio = x_inicio;
            Y_Inicio = y_inicio;
            X_Fin = x_fin;
            Y_Fin = y_fin;
        }

        public Coordenadas() { }

    }
}