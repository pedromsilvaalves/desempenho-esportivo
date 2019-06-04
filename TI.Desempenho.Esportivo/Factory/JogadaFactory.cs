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
    public class JogadaFactory : IJogadaFactory
    {
        #region Membros

        private int[] jogadasDefensivas = { 1, 2, 3, 4, 5, 11, 12, 13, 14 };

        private Dictionary<int,JogadaModel> jogadas = new Dictionary<int, JogadaModel>()
        {
            { 1, new JogadaModel()
                {
                    nomJogada = "Jogo sem sofrer gol",
                    pontosJogada = 5
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
                    pontosJogada = -5
                }
            },
            { 4, new JogadaModel()
                {
                    nomJogada = "Cartão Amarelo",
                    pontosJogada = -2
                }
            },
            { 5, new JogadaModel()
                {
                    nomJogada = "Falta cometida",
                    pontosJogada = -0.5F
                }
            },
            { 6, new JogadaModel()
                {
                    nomJogada = "Gol",
                    pontosJogada = 8
                }
            },
            { 7, new JogadaModel()
                {
                    nomJogada = "Finalização na trave",
                    pontosJogada = 3
                }
            },
            { 8, new JogadaModel()
                {
                    nomJogada = "Finalização para fora",
                    pontosJogada = 0.8F
                }
            },
            { 9, new JogadaModel()
                {
                    nomJogada = "Pênalti perdido",
                    pontosJogada = -4
                }
            },
            { 10, new JogadaModel()
                {
                    nomJogada = "Passe errado",
                    pontosJogada = -0.3F
                }
            },
            { 11, new JogadaModel()
                {
                    nomJogada = "Defesa de pênalti",
                    pontosJogada = 7
                }
            },
            { 12, new JogadaModel()
                {
                    nomJogada = "Roubada de bola",
                    pontosJogada = 1.5F
                }
            },
            { 13, new JogadaModel()
                {
                    nomJogada = "Cartão vermelho",
                    pontosJogada = -5F
                }
            },
            { 14, new JogadaModel()
                {
                    nomJogada = "Gol sofrido",
                    pontosJogada = -2F
                }
            },
            { 15, new JogadaModel()
                {
                    nomJogada = "Assistência",
                    pontosJogada = 5
                }
            },
            { 16, new JogadaModel()
                {
                    nomJogada = "Finalização defendida",
                    pontosJogada = 1.2F
                }
            },
            { 17, new JogadaModel()
                {
                    nomJogada = "Falta sofrida",
                    pontosJogada = 0.5F
                }
            },
            { 18, new JogadaModel()
                {
                    nomJogada = "Impedimento",
                    pontosJogada = -0.5F
                }
            }
        };

        #endregion

        #region Métodos

        public ICriavel Criar(int codJogada, String categoria, int idPartida)
        {
            var jogada = jogadas[codJogada];
            jogada.multiplicador = GetMultiplicador(codJogada, categoria);
            jogada.idPartida = idPartida;
            return new Jogada(jogada);
        }

        private float GetMultiplicador(int codJogada, String categoria)
        {
            switch (categoria)
            {
                case "Defensivo":
                    if (jogadasDefensivas.Contains(codJogada))
                        return 1F;
                    return 2F;
                case "Ofensivo":
                    if (jogadasDefensivas.Contains(codJogada))
                        return 2F;
                    return 1F;
                default:
                    return 1F;
            }
        }

        #endregion
    }
}
