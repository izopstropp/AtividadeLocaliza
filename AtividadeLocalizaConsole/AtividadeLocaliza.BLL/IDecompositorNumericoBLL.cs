using AtividadeLocalizaConsole.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeLocaliza.BLL
{
    public interface INumeracaoBLL
    {
        Task<NumeracaoDecompostaDto> obterNumeroDecomposto(long numeroBase);
    }
}
