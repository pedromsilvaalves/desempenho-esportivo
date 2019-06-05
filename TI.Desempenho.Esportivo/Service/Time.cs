using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.Desempenho.Esportivo.Service
{
    class Time
    {

        #region Membros

        private static int numJogador = 0;
        private String _nome;
        private Jogador[] _jogadores;

        #endregion

        #region Getters/Setters

        public String nome
        {
            get { return _nome; }
            set
            {
                if (value.Length != 0)
                    _nome = value;
                else
                    throw new ArgumentException(String.Format("{0} não é um nome de time válido", _nome));

            }
        }

        public Jogador[] jogadores
        {
            get { return _jogadores; }
            set
            {
                if (value.Length == 44)
                    _jogadores = value;
                else
                    throw new ArgumentException(String.Format("{0} quantidade de jogadores inválida", _jogadores));
            }
        }

        #endregion

        #region Construtor

        private void init(String nome)
        {
            this.nome = nome;
            this.jogadores = new Jogador[44];
        }

        public Time(String nome)
        {
            this.init(nome);
        }

        #endregion

        #region Metodos

        public void addJogador(String nome, int posicao, int camisa)
        {
            if (numJogador < 44)
            {
                Jogador aux = new Jogador(nome, posicao, camisa);
                this.jogadores[numJogador] = aux;
                numJogador++;
            }
        }

        #endregion
    }
}
