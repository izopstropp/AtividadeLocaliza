using AtividadeLocalizaConsole.DTO;
using System.Threading.Tasks;

namespace AtividadeLocaliza.DAL
{
    public interface IDecompositorNumericoDAL
    {
         Task<NumeracaoDecompostaDto> ObterNumeroDecomposto(long numeroBase);
    }
}
