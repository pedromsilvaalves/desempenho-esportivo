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
    public class PosicaoFactory : IPosicaoFactory
    {
        #region Membros

        private readonly Dictionary<int, PosicaoModel> posicoes = new Dictionary<int, PosicaoModel>()
        {
            { 1, new PosicaoModel()
                {
                    nomPosicao = "Goleiro",
                    categoria = "Defensivo"
                }
            },
            { 2, new PosicaoModel()
                {
                    nomPosicao = "Defesa",
                    categoria = "Defensivo"
                }
            },
            { 3, new PosicaoModel()
                {
                    nomPosicao = "Meio Campo Defensivo",
                    categoria = "Defensivo"
                }
            },
            { 4, new PosicaoModel()
                {
                    nomPosicao = "Meio Campo Ofensivo",
                    categoria = "Ofensivo"
                }
            },
            { 5, new PosicaoModel()
                {
                    nomPosicao = "Atacante",
                    categoria = "Ofensivo"
                }
            }
        };

        #endregion

        #region Métodos

        public ICriavel Criar(int codPosicao)
        {
            return new Posicao(posicoes[codPosicao]);
        }

        #endregion
    }
}
