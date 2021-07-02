using AtividadeLocaliza.Domain.DTO;
using AtividadeLocaliza.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtividadeLocaliza.Domain.Services
{
    public class DecomposicaoNumericaService : IDecomposicaoNumericaService
    {
        private readonly IConfiguration _configuration;
        public DecomposicaoNumericaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<NumeracaoDecomposta> DecomporNumero(long numeroBase)
        {
            var numerosDivisores = await ObterNumerosDivisiveisAsync(numeroBase);
            var numerosPrimos = await ObterNumerosPrimosAsync(numerosDivisores);

            return new NumeracaoDecomposta
            {
                NumeroEntrada = numeroBase,
                NumerosDivisores = numerosDivisores.OrderBy(x => x),
                DivisoresPrimos = numerosPrimos.OrderBy(x => x)
            };
        }
        private Task<List<long>> ObterNumerosDivisiveisAsync(long numeroBase)
        {
            var quantidadeThreadsDecompositor = _configuration.GetValue<int>("VariaveisConfiguracoesDinamicas:QuantidadeThreadsDecompositor");

            ConcurrentBag<long> numerosDivisiveis = new ConcurrentBag<long>();
            long numeroLimiteDivisor = (long)Math.Ceiling(Convert.ToDecimal(numeroBase / 2));

            Parallel.For(1, numeroLimiteDivisor, new ParallelOptions() { MaxDegreeOfParallelism = quantidadeThreadsDecompositor }, i =>
                {
                    if (numeroBase % i == 0)
                    {
                        numerosDivisiveis.Add(i);
                    }
                });
            numerosDivisiveis.Add(numeroBase);

            return Task.FromResult(numerosDivisiveis.ToList());
        }

        private Task<List<long>> ObterNumerosPrimosAsync(List<long> numerosDivisores)
        {

            List<long> numerosPrimos = new List<long>();
            foreach (var numero in numerosDivisores)
            {
                bool isNumeroPrimo = true;
                for (long i = 2; i <= numero; i++)
                {
                    if (numero % i == 0 && numero != i)
                    {
                        isNumeroPrimo = false;
                        break;
                    }
                }
                if (isNumeroPrimo)
                    numerosPrimos.Add(numero);

            }
            return Task.FromResult(numerosPrimos);
        }
    }
}
