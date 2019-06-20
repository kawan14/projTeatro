using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projTeatro
{
    class Teatro
    {
        #region atributos
        private Lugar[,] lugares;
        private double[] precos;
        #endregion

        #region propriedades
        public Lugar[,] Lugares //readonly
        {
            get { return this.lugares; }
        }

        public double[] Precos //readonly
        {
            get { return this.precos; }
        }
        #endregion

        #region construtor
        public Teatro(double preco1, double preco2, double preco3)
        {
            this.lugares = new Lugar[15, 40];
            this.precos = new double[3];
            this.precos[0] = preco1;
            this.precos[1] = preco2;
            this.precos[2] = preco3;
            for (int fila = 0; fila < 15; ++fila)
                for (int pilha = 0; pilha < 40; ++pilha)
                    this.lugares[fila, pilha] = new Lugar();
        }
        #endregion

        #region metodos
        public bool reservar(int fila, int poltrona, bool meiaEntrada)
        {
            bool podeReservar;
            podeReservar = !this.lugares[fila - 1, poltrona - 1].Ocupado;
            if (podeReservar)
            {
                lugares[fila - 1, poltrona - 1].Ocupado = true;
                lugares[fila - 1, poltrona - 1].MeiaEntrada = meiaEntrada;
            }
            return podeReservar;
        }
    
        public int qtdeOcupados()
        {
            int qtde;
            qtde = 0;
            foreach (Lugar lugar in this.lugares)
                if (lugar.Ocupado) 
                    qtde++;
            return qtde;
        }

        public double valorBilheteria()
        {
            double valor;
            valor = 0;
            for (int fila = 0; fila < 15; ++fila)
                for (int pilha = 0; pilha < 40; ++pilha)
                    if (this.lugares[fila, pilha].Ocupado)
                        valor += (this.lugares[fila, pilha].MeiaEntrada) ? precos[fila / 5] / 2 : precos[fila / 5];
            return valor;
        }
        #endregion
    }
}
