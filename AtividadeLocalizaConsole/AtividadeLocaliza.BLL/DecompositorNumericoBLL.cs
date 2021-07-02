using AtividadeLocaliza.DAL;
using AtividadeLocalizaConsole.DTO;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace AtividadeLocaliza.BLL
{
    public class DecompositorNumericoBLL : INumeracaoBLL
    {
        private readonly IDecompositorNumericoDAL _numeracaoDal1;
        public DecompositorNumericoBLL(IDecompositorNumericoDAL numeracaoDal1)
        {
            _numeracaoDal1 = numeracaoDal1;
        }
        public async Task<NumeracaoDecompostaDto> obterNumeroDecomposto(long numeroBase)
        {
            
            var numeroDecomposto = await _numeracaoDal1.ObterNumeroDecomposto(numeroBase);
            return numeroDecomposto;
        }
    }
}
