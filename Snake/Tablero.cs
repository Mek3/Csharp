using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Tablero
    {
        public int TamTablero_x { get; set; }
        public int TamTablero_y { get; set; }
        public Serpiente serpiente { get; set; }
        public Presa presa { get; set; }
        public Jugador jugador { get; set; }

        public int[,] Mattablero { get; set; } = new int[10, 25];

        public Tablero(int tam_x, int tam_y)
        {

            this.Mattablero = new int[tam_x, tam_y];
            this.TamTablero_x = tam_x;
            this.TamTablero_y = tam_y;

            this.presa = new Presa(new Coordenadas());
            this.jugador = new Jugador();
           
            inicializarSerpiente();



            DibujarTablero();
        }

        public void inicializarSerpiente()
        {
            int eje_x = TamTablero_x / 2;
            int eje_y = TamTablero_y / 2;

            Coordenadas coordenadas = new Coordenadas();

            coordenadas.X_Inicio = eje_x;
            coordenadas.Y_Inicio = eje_y + 1;
            coordenadas.X_Fin= eje_x;
            coordenadas.Y_Fin= eje_y - 1;

            this.serpiente = new Serpiente(coordenadas);

        }

        public void DibujarMarco()
        {
            for (int x = 0; x < TamTablero_x; x++)
            {
                Mattablero[x, 0] = '#';
                Mattablero[x, TamTablero_y - 1] = '#';
            }

            for (int y = 0; y < TamTablero_y; y++)
            {
                Mattablero[0, y] = '#';
                Mattablero[TamTablero_x - 1, y] = '#';
            }
        }


        public void DibujarTablero()
        {
            DibujarMarco();
            DibujarPresa();
            DibujarSerpiente();

            for (int x = 1; x < TamTablero_x - 1; x++)
            {
                for (int y = 1; y < TamTablero_y - 1; y++)
                {
                    if (Mattablero[x, y] != '*' && Mattablero[x, y] != '=' && Mattablero[x, y] != '<')
                        Mattablero[x, y] = ' ';
                }
            }
        }

        public void DibujarTableroEnPantalla()
        {
            for (int x = 0; x < TamTablero_x; x++)
            {
                for (int y = 0; y < TamTablero_y; y++)
                {
                    Console.Write((char)Mattablero[x, y]);
                }

                Console.WriteLine();
            }
        }

        public void DibujarPresa()
        {
            Random rand_x = new Random();
            Random rand_y = new Random();

            int x = rand_x.Next(1, TamTablero_x - 1);
            int y = rand_y.Next(1, TamTablero_y - 1);

            Coordenadas coordenadas = new Coordenadas(x, y, x, y);

            presa.coordenadas = coordenadas;

            Mattablero[x, y] = '*';
        }

        public void DibujarSerpiente()
        {
            //Mattablero[serpiente.coordenadas.X_Inicio, serpiente.coordenadas.Y_Inicio] = '<';
            //Mattablero[serpiente.coordenadas.X_Inicio, serpiente.coordenadas.Y_Inicio] = '=';
            //Mattablero[serpiente.coordenadas.X_Inicio, serpiente.coordenadas.Y_Inicio] = '=';
        }


    }
}