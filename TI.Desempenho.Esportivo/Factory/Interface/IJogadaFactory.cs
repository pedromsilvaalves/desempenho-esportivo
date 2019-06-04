using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Service.Interface;

namespace TI.Desempenho.Esportivo.Factory.Interface
{
    public interface IJogadaFactory
    {
        ICriavel Criar(int codJogada, String categoria, int idPartida);
    }
}
    