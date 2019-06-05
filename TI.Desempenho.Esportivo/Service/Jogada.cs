using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Model;
using TI.Desempenho.Esportivo.Service.Interface;

namespace TI.Desempenho.Esportivo.Service
{
    public class Jogada : ICriavel
    {
        #region Membros

        private float _pontosJogada;
        private String _nomJogada;
        private float _multiplicador;
        private int _idPartida;

        #endregion

        #region Getters/Setters

        public float pontosJogada
        {
            get { return _pontosJogada; }
            private set { _pontosJogada = value; }
        }
        public float multiplicador
        {
            get { return _multiplicador; }
            private set { _multiplicador = value; }
        }
        public String nomJogada
        {
            get { return _nomJogada; }
            private set
            {
                if (value.Length != 0)
                    _nomJogada = value;
                else
                    throw new ArgumentException(String.Format("{0} não é um nome de jogada válido", _nomJogada));
            }
        }
        public int idPartida
        {
            get { return _idPartida; }
            private set
            {
                if (value != 0)
                    _idPartida = value;
                else
                    throw new ArgumentException(String.Format("{0} não é um número de partida válido", _idPartida));
            }
        }

        #endregion

        #region Construtor

        public Jogada(JogadaModel jogada)
        {
            this.multiplicador = jogada.multiplicador;
            this.nomJogada = jogada.nomJogada;
            this.pontosJogada = jogada.pontosJogada;
            this.idPartida = jogada.idPartida;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            var result = String.Format("Jogada {0} valendo {1} pontos na partida {2}", this.nomJogada, this.calcPontosJogada(), this.idPartida);

            return result;
        }

        public double calcPontosJogada()
        {
            return this.pontosJogada * this.multiplicador;
        }

        #endregion
    }
}
