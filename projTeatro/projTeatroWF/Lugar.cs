using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projTeatro
{
    class Lugar
    {
        #region atributos
        private bool ocupado;
        private bool meiaEntrada;
        #endregion

        #region propriedades
        public bool Ocupado { get => ocupado; set => ocupado = value; }
        public bool MeiaEntrada { get => meiaEntrada; set => meiaEntrada = value; }
        #endregion

        #region construtores
        public Lugar(bool ocupado, bool meiaEntrada)
        {
            this.Ocupado = ocupado;
            this.MeiaEntrada = meiaEntrada;
        }
        public Lugar() : this(false, false) { }

        #endregion
    }
}
