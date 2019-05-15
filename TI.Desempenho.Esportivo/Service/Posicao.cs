using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Model;

namespace TI.Desempenho.Esportivo.Service
{
    public class Posicao
    {
        #region Membros

        private PosicaoModel _posicao;

        #endregion

        #region Getters/Setters

        public PosicaoModel posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }

        #endregion

        #region Construtor

        private void init(PosicaoModel posicaoModel)
        {
            this.posicao = posicaoModel;
        }

        public Posicao()
        {
            this.init(new PosicaoModel());
        }

        public Posicao(PosicaoModel posicaoModel)
        {
            this.init(posicaoModel);
        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return String.Format("Posicao {0} da categoria {1}", this.posicao.nomPosicao, this.posicao.categoria);
        }

        #endregion
    }
}
