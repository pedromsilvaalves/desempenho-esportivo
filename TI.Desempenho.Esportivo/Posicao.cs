using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.Desempenho.Esportivo
{
    class Posicao
    {
        #region Membros

        private readonly Dictionary<int, String> posicoes = new Dictionary<int, string>()
        {
            { 1, "Goleiro" },
            { 2, "Defesa" },
            { 3, "Meio Campo Defensivo" },
            { 4, "Meio Campo Ofensivo" },
            { 5, "Atacante" }
        };
        private int _idPosicao;
        private String _nomPosicao;
        private String _categoria;
       
        #endregion

        #region Getters/Setters

        public int idPosicao
        {
            get { return _idPosicao; }
            set
            {
                if (posicoes.ContainsKey(value))
                    _idPosicao = value;
                else
                    _idPosicao = 1;
            }
        }

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

        private void ConfigCategoria(int idPosicao)
        {
            switch (idPosicao)
            {
                case 1:
                    this.categoria = "Defensivo";
                    break;
                case 2:
                    this.categoria = "Defensivo";
                    break;
                case 3:
                    this.categoria = "Defensivo";
                    break;
                case 4:
                    this.categoria = "Ofensivo";
                    break;
                case 5:
                    this.categoria = "Ofensivo";
                    break;
            }
        }

        private void init(int idPosicao)
        {
            this.idPosicao = idPosicao;
            this.nomPosicao = posicoes[idPosicao];
            ConfigCategoria(idPosicao);
        }

        public Posicao()
        {
            this.init(1);
        }

        /// <summary>
        /// { 1, "Goleiro" },
        /// { 2, "Defesa" },
        /// { 3, "Meio Campo Defensivo" },
        /// { 4, "Meio Campo Ofensivo" },
        /// { 5, "Atacante" }
        /// </summary>
        /// <param name="idPosicao">Key (int)</param>
        public Posicao(int idPosicao)
        {
            this.init(idPosicao);
        }

        #endregion
    }
}
