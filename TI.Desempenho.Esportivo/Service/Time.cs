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
                    _nome = "Time Juntados pelas Forcas do Acaso";
            }
        }

        public Jogador[] jogadores
        {
            get { return _jogadores; }
            set
            {
                if (value.Length == 44)
                    _jogadores = value;
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
            else 
            {
                var contador = 0;
                foreach (var jogador in this.jogadores)
                {
                    if (jogador == null)
                    {
                        Jogador novoJogador = new Jogador(nome, posicao, camisa);
                        this.jogadores[contador] = novoJogador;
                        return;
                    }
                    contador++;
                }
            }
        }

        public void RemoverJogador(string nome)
        {

            for (int i = 0; i < this.jogadores.Length; i++)
            {
                if (this.jogadores[i] != null)
                {
                    if (nome == this.jogadores[i].nome)
                    {
                        jogadores[i] = null;
                    }
                }
            }
        }

        public double PontosTotaisTime()
        {
            double pontosTotais = 0;
            foreach(var jogador in jogadores)
            {
                if (jogador != null)
                {
                    pontosTotais += jogador.pontosTotais();
                }
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

            foreach (var jogador in _jogadores)
            {
                if (jogador != null)
                {
                    if (jogador.pontosTotais() == media)
                    {
                        relatorio.Add(new AvaliacaoJogadorModel()
                        {
                            nome = jogador.nome,
                            numCamisa = jogador.camisa,
                            nomPosicao = jogador.posicao.nomPosicao,
                            pontos = jogador.pontosTotais(),
                            status = "Dentro da média."
                        });
                    } else 
                    if (jogador.pontosTotais() < media)
                    {
                        relatorio.Add(new AvaliacaoJogadorModel()
                        {
                            nome = jogador.nome,
                            numCamisa = jogador.camisa,
                            nomPosicao = jogador.posicao.nomPosicao,
                            pontos = jogador.pontosTotais(),
                            status = "Abaixo da média."
                        });
                    } else
                    if (jogador.pontosTotais() > media)
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
            }
            return relatorio;
        }

        public Jogador ProcurarJogadorMaiorPontuacao()
        {
            Jogador jogadorMaiorPontuacao = null;
            double maiorPontuacao = double.MinValue;
            foreach(var jogador in _jogadores)
            {
                if (jogador != null)
                {
                    if (jogador.pontosTotais() > maiorPontuacao)
                    {
                        jogadorMaiorPontuacao = jogador;
                        maiorPontuacao = jogador.pontosTotais();
                    }
                }
                
            }
            return jogadorMaiorPontuacao;
        }

        #endregion
    }
}
