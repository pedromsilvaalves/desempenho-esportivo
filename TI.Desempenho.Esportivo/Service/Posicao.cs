using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Model;
using TI.Desempenho.Esportivo.Service.Interface;

namespace TI.Desempenho.Esportivo.Service 
{
    public class Posicao : ICriavel
    {
        #region Membros

        private String _nomPosicao;
        private String _categoria;

        #endregion

        #region Getters/Setters

        public String nomPosicao
        {
            get { return _nomPosicao; }
            set { _nomPosicao = value; }
        }
        public String categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }


        #endregion

        #region Construtor

        private void init(PosicaoModel posicaoModel)
        {
            this.nomPosicao = posicaoModel.nomPosicao;
            this.categoria = posicaoModel.categoria;
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
            return String.Format("Posicao {0} da categoria {1}", this.nomPosicao, this.categoria);
        }

        #endregion
    }
}
