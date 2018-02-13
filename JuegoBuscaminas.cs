using BuscaminasConsola.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasConsola
{
    class JuegoBuscaminas
    {

        private Tablero tablero = new Tablero(6, 6);
        static void Main(string[] args)
        {
            JuegoBuscaminas juego = new JuegoBuscaminas();
            juego.jugar();
        }

        private void jugar()
        {
            /// visualizar tablero
            /// for leer fila y columna
            /// levantar fila y columna
            /// visualizar tablero        

            Console.WriteLine(tablero);

            for (int i =0; i<=5; i++)
            {
                Console.WriteLine("dime fila");
                int fila = Int32.Parse(Console.ReadLine());
                Console.WriteLine("dime colulmna");
                int col = Int32.Parse(Console.ReadLine());

                tablero.levanta(fila, col);

                Console.WriteLine("\n\n");
                Console.WriteLine(tablero);

            }
            Console.Read();
        }
    }
}
