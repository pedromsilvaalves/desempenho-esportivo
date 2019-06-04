using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Factory;
using TI.Desempenho.Esportivo.Model;
using TI.Desempenho.Esportivo.Service.Interface;

namespace TI.Desempenho.Esportivo.Service
{
    public class Jogador
    {
        #region Membros

        private JogadaFactory _jogadaFactory;
        private PosicaoFactory _posicaoFactory;

        private string _nome;
        private Posicao _posicao;
        private int _numCamisa;
        private List<Jogada> _jogadas;

        #endregion

        #region Getters/Setters

        public string nome
        {
            get { return _nome; }
            private set
            {
                if (value.Length != 0)
                    _nome = value;
                else
                    _nome = "Joaozin Perna de Pau";
            }
        }

        public Posicao posicao
        {
            get { return _posicao; }
            private set { _posicao = value; }
        }

        public int camisa
        {
            get { return _numCamisa; }
            private set
            {
                if (value > 0)
                    _numCamisa = value;
                else
                {
                    Random rnd = new Random();
                    _numCamisa = rnd.Next(1, 200);
                }
            }
        }

        #endregion

        #region Construtor

        private void init(String nome, int posicao, int camisa)
        {
            _jogadaFactory = new JogadaFactory();
            _posicaoFactory = new PosicaoFactory();

            this.nome = nome;
            this.posicao = (Posicao)_posicaoFactory.Criar(posicao);
            this.camisa = camisa;
        }

        public Jogador(String nome, int posicao, int camisa)
        {
            this.init(nome, posicao, camisa);
        }

        #endregion

        public bool AddJogada(int codJogada, int idPartida)
        {
            var numJogadasAnterior = this._jogadas.Count;
            this._jogadas.Add((Jogada)_jogadaFactory.Criar(codJogada, this.posicao.categoria, idPartida));
            if (!(numJogadasAnterior == this._jogadas.Count))
                return true;
            return false;
        }
    }
}
