using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Model;
using TI.Desempenho.Esportivo.Service;

namespace TI.Desempenho.Esportivo.Factory
{
    public static class JogadaFactory
    {

        //{ 1, "Jogo sem sofrer gol" },
        //{ 2, "Defesa dificil" },
        //{ 3, "Gol contra" },
        //{ 4, "Cartão Amarelo" },
        //{ 5, "Falta cometida" },
        //{ 6, "Gol" },
        //{ 7, "Finalização na trave" },
        //{ 8, "Finalização para fora" },
        //{ 9, "Pênalti perdido" },
        //{ 10, "Passe errado" },
        //{ 11, "Defesa de pênalti" },
        //{ 12, "Roubada de bola" },
        //{ 13, "Cartão vermelho" },
        //{ 14, "Gol sofrido" },
        //{ 15, "Assistência" },
        //{ 16, "Finalização defendida" },
        //{ 17, "Falta sofrida" },
        //{ 18, "Impedimento" }

        private static IEnumerable<JogadaModel> jogadas = new List<JogadaModel>()
        {
            new JogadaModel()
            {
                idJogada = 1,
                nomJogada = "Jogo sem sofrer gol",
                pntJogada = 1
            },
        };

        public static Jogada CriarJogada(int codJogada)
        {
            // return new Jogada(jogadas.);
            return new Jogada();
        }
    }
}
