using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeLocaliza.Domain.Interfaces.Repositories
{
    public interface IDecompositorNumericoRepository
    {
       Task<bool> SalvarNumeroDecomposto(long numero);
    }
}
