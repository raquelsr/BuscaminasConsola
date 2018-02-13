using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasConsola.Modelo
{
    class Casilla
    {

        private int valor;
        private bool bomba;
        private bool levantada;

        public Casilla()
        {
            this.valor = 0;
            this.bomba = false;
            this.levantada = false;
        }

        public override string ToString()
        {

            if (levantada)
            {
                if (bomba) return "B";
                else if (valor == 0) return "-";
                else return "" + valor;
            }
            else return "X";
          
        }

        public void ponBomba()
        {
            this.bomba = true;
        }

        internal void sumaUno()
        {
            this.valor++;
        }

        internal void levanta()
        {
            this.levantada = true;
        }

        internal bool esVacia()
        {
            return (valor == 0);
        }

        internal bool esBomba()
        {
            return this.bomba;
        }

        internal bool estaLevantada()
        {
            return this.levantada;
        }
    }
}
 