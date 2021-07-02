using AtividadeLocaliza.Application.Intefaces;
using AtividadeLocaliza.Application.Mapper;
using AtividadeLocaliza.Application.ViewModel;
using AtividadeLocaliza.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace AtividadeLocaliza.Application.AppService
{
    public class DecomposicaoNumericaAppService : IDecomposicaoNumericaAppService
    {
        IDecomposicaoNumericaService _decomposicaoNumericaService;
        public DecomposicaoNumericaAppService(IDecomposicaoNumericaService decomposicaoNumericaService)
        {
            _decomposicaoNumericaService = decomposicaoNumericaService;
        }

        public async Task<NumeroDecompostoViewModel> RealizarDecomposicaoNumero(long baseNumerica)
        {
           return NumeracaoMapper.MapperToView(await _decomposicaoNumericaService.DecomporNumero(baseNumerica));      
        }


    }
}
