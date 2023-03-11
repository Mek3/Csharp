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
            
            DibujarMarco();
            DibujarPresa();
            DibujarTablero();
            DibujarTableroEnPantalla();

        }
        public void inicializarSerpiente()
        {
            int eje_x = TamTablero_x / 2;
            int eje_y = TamTablero_y / 2;
            int tamSerpiente = 8;
            int mitadSerpiente = tamSerpiente / 2;

            Coordenadas coordenadas = new Coordenadas();

            coordenadas.X_Inicio = eje_x;
            coordenadas.Y_Inicio = eje_y - mitadSerpiente;
            coordenadas.X_Fin = eje_x;
            coordenadas.Y_Fin = eje_y + mitadSerpiente;// -1;

            List<CeldaSerpiente> celdasSerpiente = new List<CeldaSerpiente>();

            for (int i = mitadSerpiente; i > 0; i--)
            {
                celdasSerpiente.Add(new CeldaSerpiente(eje_x, eje_y - i));
            }

            celdasSerpiente.Add(new CeldaSerpiente(eje_x, eje_y));
            
            for (int i = 1; i < mitadSerpiente; i++) 
            {
                celdasSerpiente.Add(new CeldaSerpiente(eje_x, eje_y + i));
            }

            this.serpiente = new Serpiente(coordenadas, celdasSerpiente);

            DibujarSerpientePorDefecto();
        }
        public void vaciarTableroDeSerpiente()
        {
            for (int x = 1; x < TamTablero_x - 1; x++)
            {
                for (int y = 1; y < TamTablero_y - 1; y++)
                {
                    if (Mattablero[x, y] != '*')
                        Mattablero[x, y] = '-';
                }
            }
        }
        public void DibujarMarco()
        {
            for (int x = 0; x < TamTablero_x; x++)
            {
                Mattablero[x, 0] = '@';
                Mattablero[x, TamTablero_y - 1] = '@';
            }
            for (int y = 0; y < TamTablero_y; y++)
            {
                Mattablero[0, y] = '@';
                Mattablero[TamTablero_x - 1, y] = '@';
            }
        }
        public void DibujarTablero()
        {
            for (int x = 1; x < TamTablero_x - 1; x++)
            {
                for (int y = 1; y < TamTablero_y - 1; y++)
                {
                    if (Mattablero[x, y] != '#' && Mattablero[x, y] != '*'
                        && Mattablero[x, y] != '<' && Mattablero[x, y] != '>'
                        && Mattablero[x, y] != '^' && Mattablero[x, y] != 'v')
                        Mattablero[x, y] = '-';
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

        public void DibujarSerpientePorDefecto()
        {
            Mattablero[serpiente.coordenasSerpiente[0].x, serpiente.coordenasSerpiente[0].y] = '<';

            for (int i = 1; i < serpiente.coordenasSerpiente.Count; i++)
            {
                Mattablero[serpiente.coordenasSerpiente[i].x, serpiente.coordenasSerpiente[i].y] = '#';
            }
        }
        public void DibujarSerpiente(char direccion)
        {
            Mattablero[serpiente.coordenasSerpiente[0].x, serpiente.coordenasSerpiente[0].y] = direccion;

            for (int i = 1; i < serpiente.coordenasSerpiente.Count; i++)
            {
                Mattablero[serpiente.coordenasSerpiente[i].x, serpiente.coordenasSerpiente[i].y] = '#';
            }
        }
        public void moverSerpienteDerecha()
        {
            if (Mattablero[serpiente.coordenasSerpiente[0].x, serpiente.coordenasSerpiente[0].y] != '<') 
            { 
                int tamSerpiente = serpiente.coordenasSerpiente.Count - 1;
                vaciarTableroDeSerpiente();

                List<CeldaSerpiente> celdasSerpienteAux = new List<CeldaSerpiente>();
                celdasSerpienteAux.Add(new CeldaSerpiente(serpiente.coordenasSerpiente[0].x, serpiente.coordenasSerpiente[0].y + 1));

                for (int i = 0; i < tamSerpiente; i++)
                {
                    celdasSerpienteAux.Add(new CeldaSerpiente(serpiente.coordenasSerpiente[i].x,
                                                              serpiente.coordenasSerpiente[i].y));
                }

                serpiente.coordenasSerpiente = celdasSerpienteAux;

                serpiente.coordenadas.X_Inicio = serpiente.coordenasSerpiente[0].x;
                serpiente.coordenadas.Y_Inicio = serpiente.coordenasSerpiente[0].y;
                serpiente.coordenadas.X_Fin = serpiente.coordenasSerpiente[tamSerpiente].x;
                serpiente.coordenadas.Y_Fin = serpiente.coordenasSerpiente[tamSerpiente].y;

                DibujarSerpiente('>');
            }
        }
        public void moverSerpienteIzquierda()
        {

            if (Mattablero[serpiente.coordenasSerpiente[0].x, serpiente.coordenasSerpiente[0].y] != '>')
            {
                int tamSerpiente = serpiente.coordenasSerpiente.Count - 1;
                vaciarTableroDeSerpiente();

                List<CeldaSerpiente> celdasSerpienteAux = new List<CeldaSerpiente>();
                celdasSerpienteAux.Add(new CeldaSerpiente(serpiente.coordenasSerpiente[0].x, serpiente.coordenasSerpiente[0].y - 1));

                for (int i = 0; i < tamSerpiente; i++)
                {
                    celdasSerpienteAux.Add(new CeldaSerpiente(serpiente.coordenasSerpiente[i].x,
                                                              serpiente.coordenasSerpiente[i].y));
                }

                serpiente.coordenasSerpiente = celdasSerpienteAux;

                serpiente.coordenadas.X_Inicio = serpiente.coordenasSerpiente[0].x;
                serpiente.coordenadas.Y_Inicio = serpiente.coordenasSerpiente[0].y;
                serpiente.coordenadas.X_Fin = serpiente.coordenasSerpiente[tamSerpiente].x;
                serpiente.coordenadas.Y_Fin = serpiente.coordenasSerpiente[tamSerpiente].y;

                DibujarSerpiente('<');
            }
        }
        public void moverSerpienteArriba()
        {
            int tamSerpiente = serpiente.coordenasSerpiente.Count - 1;
            vaciarTableroDeSerpiente();

            List<CeldaSerpiente> celdasSerpienteAux = new List<CeldaSerpiente>();
            celdasSerpienteAux.Add(new CeldaSerpiente(serpiente.coordenasSerpiente[0].x-1, serpiente.coordenasSerpiente[0].y));

            for (int i = 0; i < tamSerpiente; i++)
            {

                celdasSerpienteAux.Add(new CeldaSerpiente(serpiente.coordenasSerpiente[i].x,
                                                          serpiente.coordenasSerpiente[i].y));

            }

            serpiente.coordenasSerpiente = celdasSerpienteAux;

            serpiente.coordenadas.X_Inicio = serpiente.coordenasSerpiente[0].x;
            serpiente.coordenadas.Y_Inicio = serpiente.coordenasSerpiente[0].y;
            serpiente.coordenadas.X_Fin = serpiente.coordenasSerpiente[tamSerpiente].x;
            serpiente.coordenadas.Y_Fin = serpiente.coordenasSerpiente[tamSerpiente].y;

            DibujarSerpiente('^');
        }
        public void moverSerpienteAbajo()
        {
            int tamSerpiente = serpiente.coordenasSerpiente.Count - 1;
            vaciarTableroDeSerpiente();

            List<CeldaSerpiente> celdasSerpienteAux = new List<CeldaSerpiente>();
            celdasSerpienteAux.Add(new CeldaSerpiente(serpiente.coordenasSerpiente[0].x + 1, serpiente.coordenasSerpiente[0].y));

            for (int i = 0; i < tamSerpiente; i++)
            {

                celdasSerpienteAux.Add(new CeldaSerpiente(serpiente.coordenasSerpiente[i].x,
                                                          serpiente.coordenasSerpiente[i].y));
            }

            serpiente.coordenasSerpiente = celdasSerpienteAux;

            serpiente.coordenadas.X_Inicio = serpiente.coordenasSerpiente[0].x;
            serpiente.coordenadas.Y_Inicio = serpiente.coordenasSerpiente[0].y;
            serpiente.coordenadas.X_Fin = serpiente.coordenasSerpiente[tamSerpiente].x;
            serpiente.coordenadas.Y_Fin = serpiente.coordenasSerpiente[tamSerpiente].y;

            DibujarSerpiente('v');
        }
        public void test()
        {

            Console.WriteLine("Arriba");
            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            moverSerpienteArriba();
            DibujarTableroEnPantalla();


            Console.WriteLine("Derecha");

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();


            Console.WriteLine("Abajo");

            moverSerpienteAbajo();
            DibujarTableroEnPantalla();

            moverSerpienteAbajo();
            DibujarTablero();
            DibujarTableroEnPantalla();

            moverSerpienteAbajo();
            DibujarTableroEnPantalla();

            moverSerpienteAbajo();
            DibujarTableroEnPantalla();

            Console.WriteLine("Izquierda");

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();







            Console.WriteLine("Derecha");

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            Console.WriteLine("Abajo");

            moverSerpienteAbajo();
            DibujarTableroEnPantalla();

            moverSerpienteAbajo();
            DibujarTablero();
            DibujarTableroEnPantalla();

            moverSerpienteAbajo();
            DibujarTableroEnPantalla();

            moverSerpienteAbajo();
            DibujarTableroEnPantalla();

            Console.WriteLine("Derecha");


            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            moverSerpienteDerecha();
            DibujarTableroEnPantalla();

            Console.WriteLine("Abajo");


            moverSerpienteAbajo();
            DibujarTableroEnPantalla();

            moverSerpienteAbajo();
            DibujarTableroEnPantalla();

            Console.WriteLine("Izquierda");

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            Console.WriteLine("Arriba");


            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            moverSerpienteArriba();
            DibujarTableroEnPantalla();

            Console.WriteLine("Izquierda");

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();

            moverSerpienteIzquierda();
            DibujarTableroEnPantalla();
        }
    }

    
}