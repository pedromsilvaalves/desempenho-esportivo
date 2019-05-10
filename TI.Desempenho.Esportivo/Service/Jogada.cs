using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Model;

namespace TI.Desempenho.Esportivo.Service
{
    public class Jogada
    {
        #region Membros

        private JogadaModel _jogada;

        #endregion

        #region Getters/Setters

        public JogadaModel jogada
        {
            get { return _jogada; }
            set { _jogada = value; }
        }

        #endregion

        #region Construtor

        private void init(JogadaModel jogada)
        {
            this.jogada = jogada;
        }

        public Jogada()
        {
            this.init(new JogadaModel());
        }

        public Jogada(JogadaModel jogada)
        {
            this.init(jogada);
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            var result = String.Format("Jogada: {0}", this.jogada.nomJogada);

            return result;
        }

        #endregion
    }
}
