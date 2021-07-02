using AtividadeLocaliza.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeLocaliza.Domain.Interfaces.Services
{
    public interface IDecomposicaoNumericaService
    {
        Task<NumeracaoDecomposta> DecomporNumero(long numeroBase);
    }
}
