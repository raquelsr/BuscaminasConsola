using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasConsola.Modelo
{
    class Tablero
    {
        /// <summary>
        /// [][] filas y columnas pueden ser diferentes
        /// [,] filas y columnas del mismo numero
        /// </summary>

        private Casilla [,] casillas;
        private int fils;
        private int cols;

        public Tablero(int f, int c)
        {
            this.fils = f+2;
            this.cols = c+2;
           
            // El tablero tiene un borde 
            this.casillas = new Casilla[fils, cols];

            for (int i = 0; i < fils; i++)
                for (int j = 0; j < cols; j++)
                    this.casillas[i, j] = new Casilla();

            //Poner unos en el borde

            this.ponUnosBorde();
            this.ponBombas();
        }

        private void ponUnosBorde()
        {
            for (int j = 0; j < cols; j++)
            {
                this.casillas[0, j].sumaUno();
                this.casillas[fils - 1, j].sumaUno();
            }

            for (int i = 0; i < fils; i++)
            {
                this.casillas[i, 0].sumaUno();
                this.casillas[i, cols - 1].sumaUno();
            }
        }

        private void ponBombas()
        {
            Random rnd = new Random();
             for (int i = 1; i < fils-1; i++)
                for (int j = 1; j < cols-1; j++)
                    if (rnd.Next(100)<60)
                    {
                        this.casillas[i,j].ponBomba();
                        this.sumaUnosAlrededor(i, j);
                    }
        }

        private void sumaUnosAlrededor(int i, int j)
        {
            for (int f = i - 1; f <= i + 1; f++)
                for (int c = j - 1; c <= j + 1; c++)
                    this.casillas[f, c].sumaUno();
        }

        public override string ToString()
        {
            string msg = "";

            for (int i = 1; i < fils - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                    msg += casillas[i, j] + " ";
                msg += "\n";
            }
           
            return msg;
        }

        internal void levanta(int f, int c)
        {
            this.casillas[f, c].levanta();
            //Levantar las de alrededor si es vacia

            if (!this.casillas[f,c].esBomba() && 
                this.casillas[f,c].esVacia())
            {
                for (int i = f - 1; i <= f + 1; i++)
                    for (int j = c - 1; j <= c + 1; j++)
                        if (!this.casillas[i, j].estaLevantada())
                            levanta(i, j);
            }
        }
    }
}
