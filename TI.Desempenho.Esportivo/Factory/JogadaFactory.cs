using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Factory.Interface;
using TI.Desempenho.Esportivo.Model;
using TI.Desempenho.Esportivo.Service;
using TI.Desempenho.Esportivo.Service.Interface;

namespace TI.Desempenho.Esportivo.Factory
{
    public class JogadaFactory : ICriarFactory
    {
        #region Membros

        private Dictionary<int,JogadaModel> jogadas = new Dictionary<int, JogadaModel>()
        {
            { 1, new JogadaModel()
                {
                    nomJogada = "Jogo sem sofrer gol",
                    pontosJogada = 7
                }
            },
            { 2, new JogadaModel()
                {
                    nomJogada = "Defesa dificil",
                    pontosJogada = 3
                }
            },
            { 3, new JogadaModel()
                {
                    nomJogada = "Gol contra",
                    pontosJogada = 1
                }
            },
            { 4, new JogadaModel()
                {
                    nomJogada = "Cartão Amarelo",
                    pontosJogada = 1
                }
            },
            { 5, new JogadaModel()
                {
                    nomJogada = "Falta cometida",
                    pontosJogada = 1
                }
            },
            { 6, new JogadaModel()
                {
                    nomJogada = "Gol",
                    pontosJogada = 1
                }
            },
            { 7, new JogadaModel()
                {
                    nomJogada = "Finalização na trave",
                    pontosJogada = 1
                }
            },
            { 8, new JogadaModel()
                {
                    nomJogada = "Finalização para fora",
                    pontosJogada = 1
                }
            },
            { 9, new JogadaModel()
                {
                    nomJogada = "Pênalti perdido",
                    pontosJogada = 1
                }
            },
            { 10, new JogadaModel()
                {
                    nomJogada = "Passe errado",
                    pontosJogada = 1
                }
            },
            { 11, new JogadaModel()
                {
                    nomJogada = "Defesa de pênalti",
                    pontosJogada = 1
                }
            },
            { 12, new JogadaModel()
                {
                    nomJogada = "Roubada de bola",
                    pontosJogada = 1
                }
            },
            { 13, new JogadaModel()
                {
                    nomJogada = "Cartão vermelho",
                    pontosJogada = 1
                }
            },
            { 14, new JogadaModel()
                {
                    nomJogada = "Gol sofrido",
                    pontosJogada = 1
                }
            },
            { 15, new JogadaModel()
                {
                    nomJogada = "Assistência",
                    pontosJogada = 1
                }
            },
            { 16, new JogadaModel()
                {
                    nomJogada = "Finalização defendida",
                    pontosJogada = 1
                }
            },
            { 17, new JogadaModel()
                {
                    nomJogada = "Falta sofrida",
                    pontosJogada = 1
                }
            },
            { 18, new JogadaModel()
                {
                    nomJogada = "Impedimento",
                    pontosJogada = 1
                }
            }
        };

        #endregion

        #region Métodos

        public ICriavel Criar(int codJogada)
        {
            var jogada = jogadas[codJogada];
            jogada.multiplicador = GetMultiplicador(codJogada, "Default");
            return new Jogada(jogada);
        }

        public ICriavel Criar(int codJogada, String posicao)
        {
            var jogada = jogadas[codJogada];
            jogada.multiplicador = GetMultiplicador(codJogada, posicao);
            return new Jogada(jogada);
        }

        private float GetMultiplicador(int codJogada, String posicao)
        {
            switch (posicao)
            {
                case "Goleiro":
                    switch (codJogada)
                    {
                        default:
                            return 1F;
                    }

                case "Defesa":
                    switch (codJogada)
                    {
                        default:
                            return 1F;
                    }

                case "Meio Campo Defensivo":
                    switch (codJogada)
                    {
                        default:
                            return 1F;
                    }

                case "Meio Campo Ofensivo":
                    switch (codJogada)
                    {
                        default:
                            return 1F;
                    }

                case "Atacante":
                    switch (codJogada)
                    {
                        default:
                            return 1F;
                    }

                default:
                    return 1F;
            }
        }

        #endregion
    }
}
