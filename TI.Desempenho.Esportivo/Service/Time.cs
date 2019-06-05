using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Model;

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

        public void AddJogador(String nome, int posicao, int camisa)
        {
            if (numJogador < 44)
            {
                Jogador novoJogador = new Jogador(nome, posicao, camisa);
                this.jogadores[numJogador] = novoJogador;
                numJogador++;
            }
        }

        public double PontosTotaisTime()
        {
            double pontosTotais = 0;
            foreach(var jogador in jogadores)
            {
                pontosTotais += jogador.pontosTotais();
            }
            return pontosTotais;
        }

        public double MediaPontosTime()
        {
            if(numJogador != 0)
                return PontosTotaisTime() / numJogador;
            return 0;
        }

        public List<AvaliacaoJogadorModel> RelatorioJogadores()
        {
            var relatorio = new List<AvaliacaoJogadorModel>();
            var media = MediaPontosTime();

            foreach(var jogador in _jogadores)
            {
                if(jogador.pontosTotais() == media)
                {
                    relatorio.Add(new AvaliacaoJogadorModel()
                    {
                        nome = jogador.nome,
                        numCamisa = jogador.camisa,
                        nomPosicao = jogador.posicao.nomPosicao,
                        pontos = jogador.pontosTotais(),
                        status = "Dentro da média."
                    });
                }
                else if(jogador.pontosTotais() < media)
                {
                    relatorio.Add(new AvaliacaoJogadorModel()
                    {
                        nome = jogador.nome,
                        numCamisa = jogador.camisa,
                        nomPosicao = jogador.posicao.nomPosicao,
                        pontos = jogador.pontosTotais(),
                        status = "Abaixo da média."
                    });
                }
                else
                {
                    relatorio.Add(new AvaliacaoJogadorModel()
                    {
                        nome = jogador.nome,
                        numCamisa = jogador.camisa,
                        nomPosicao = jogador.posicao.nomPosicao,
                        pontos = jogador.pontosTotais(),
                        status = "Acima da média."
                    });
                }
            }
            return relatorio;
        }

        public Jogador ProcurarJogadorMaiorPontuacao()
        {
            Jogador jogadorMaiorPontuacao = null;
            double maiorPontuacao = double.MinValue;
            foreach(var jogador in _jogadores)
            {
                if(jogador.pontosTotais() > maiorPontuacao)
                {
                    jogadorMaiorPontuacao = jogador;
                    maiorPontuacao = jogador.pontosTotais();
                }
            }
            return jogadorMaiorPontuacao;
        }

        #endregion
    }
}
