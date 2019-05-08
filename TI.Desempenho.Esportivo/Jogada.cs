using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.Desempenho.Esportivo
{
    class Jogada
    {
        #region Membros

        private readonly Dictionary<int, String> jogadas = new Dictionary<int, string>()
        {
            { 1, "Jogo sem sofrer gol" },
            { 2, "Defesa dificil" },
            { 3, "Gol contra" },
            { 4, "Cartão Amarelo" },
            { 5, "Falta cometida" },
            { 6, "Gol" },
            { 7, "Finalização na trave" },
            { 8, "Finalização para fora" },
            { 9, "Pênalti perdido" },
            { 10, "Passe errado" },
            { 11, "Defesa de pênalti" },
            { 12, "Roubada de bola" },
            { 13, "Cartão vermelho" },
            { 14, "Gol sofrido" },
            { 15, "Assistência" },
            { 16, "Finalização defendida" },
            { 17, "Falta sofrida" },
            { 18, "Impedimento" }
        };
        private int _idJogada;
        private String _nomJogada;

        #endregion

        #region Getters/Setters

        public int idJogada
        {
            get { return _idJogada; }
            set { _idJogada = value; }
        }

        public String nomJogada
        {
            get { return _nomJogada; }
            set { _nomJogada = value; }
        }

        #endregion

        #region Construtor

        private void init(int idJogada)
        {
            this.idJogada = idJogada;
            this.nomJogada = jogadas[idJogada];
        }

        public Jogada()
        {
            this.init(1);
        }

        /// <summary>
        ///    { 1, "Jogo sem sofrer gol" },
        ///    { 2, "Defesa dificil" },
        ///    { 3, "Gol contra" },
        ///    { 4, "Cartão Amarelo" },
        ///    { 5, "Falta cometida" },
        ///    { 6, "Gol" },
        ///    { 7, "Finalização na trave" },
        ///    { 8, "Finalização para fora" },
        ///    { 9, "Pênalti perdido" },
        ///    { 10, "Passe errado" },
        ///    { 11, "Defesa de pênalti" },
        ///    { 12, "Roubada de bola" },
        ///    { 13, "Cartão vermelho" },
        ///    { 14, "Gol sofrido" },
        ///    { 15, "Assistência" },
        ///    { 16, "Finalização defendida" },
        ///    { 17, "Falta sofrida" },
        ///    { 18, "Impedimento" },
        /// </summary>
        /// <param name="idJogada">Key (int)</param>
        public Jogada(int idJogada)
        {
            this.init(idJogada);
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            var result = String.Format("Jogada: {0}", this.nomJogada);

            return result;
        }

        #endregion
    }
}
