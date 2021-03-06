﻿using System;
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
            private set { _nomPosicao = value; }
        }
        public String categoria
        {
            get { return _categoria; }
            private set { _categoria = value; }
        }


        #endregion

        #region Construtor

        public Posicao(PosicaoModel posicaoModel)
        {
            this.nomPosicao = posicaoModel.nomPosicao;
            this.categoria = posicaoModel.categoria;
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
