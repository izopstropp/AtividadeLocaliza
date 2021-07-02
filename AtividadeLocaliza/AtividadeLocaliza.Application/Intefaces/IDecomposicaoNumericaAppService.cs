using AtividadeLocaliza.Application.ViewModel;
using System.Threading.Tasks;

namespace AtividadeLocaliza.Application.Intefaces
{
    public interface IDecomposicaoNumericaAppService
    {
        Task<NumeroDecompostoViewModel> RealizarDecomposicaoNumero(long baseNumerica);
    }
}
