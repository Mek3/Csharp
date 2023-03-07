//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

//namespace Snake
//{
//    public  class Dibujo
//    {
//        public void DibujarMarco(int TamTablero_x, int TamTablero_y)
//        {
//            for (int x = 0; x < TamTablero_x; x++)
//            {
//                Mattablero[x, 0] = '#';
//                Mattablero[x, TamTablero_y - 1] = '#';
//            }

//            for (int y = 0; y < TamTablero_y; y++)
//            {
//                Mattablero[0, y] = '#';
//                Mattablero[TamTablero_x - 1, y] = '#';
//            }
//        }

//        public void DibujarTablero()
//        {
//            DibujarMarco();
//            DibujarPresa();
//            DibujarSerpiente();

//            for (int x = 1; x < TamTablero_x - 1; x++)
//            {
//                for (int y = 1; y < TamTablero_y - 1; y++)
//                {
//                    if (Mattablero[x, y] != '*' && Mattablero[x, y] != '=' && Mattablero[x, y] != '<')
//                        Mattablero[x, y] = ' ';
//                }
//            }
//        }

//        public void DibujarTableroEnPantalla(int TamTablero_x, int TamTablero_y)
//        {
//            for (int x = 0; x < TamTablero_x; x++)
//            {
//                for (int y = 0; y < TamTablero_y; y++)
//                {
//                    Console.Write((char)Mattablero[x, y]);
//                }

//                Console.WriteLine();
//            }
//        }

//        public void DibujarPresa(int TamTablero_x, int TamTablero_y)
//        {
//            Random rand_x = new Random();
//            Random rand_y = new Random();

//            int x = rand_x.Next(1, TamTablero_x - 1);
//            int y = rand_y.Next(1, TamTablero_y - 1);

//            Coordenadas coordenadas = new Coordenadas(x, y, x, y);

//            presa.coordenadas = coordenadas;

//            Mattablero[x, y] = '*';
//        }

//        public void DibujarSerpiente(int TamTablero_x, int TamTablero_y)
//        {
//            int eje_x = TamTablero_x / 2;
//            int eje_y = TamTablero_y / 2;

//            Mattablero[eje_x, eje_y - 1] = '<';
//            Mattablero[eje_x, eje_y] = '=';
//            Mattablero[eje_x, eje_y + 1] = '=';
//        }
//    }
//}
