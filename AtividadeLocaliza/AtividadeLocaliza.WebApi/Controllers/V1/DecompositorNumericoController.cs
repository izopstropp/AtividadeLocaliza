using AtividadeLocaliza.Application.Intefaces;
using AtividadeLocaliza.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtividadeLocaliza.WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class DecompositorNumericoController : ControllerBase
    {
        private readonly IDecomposicaoNumericaAppService _decomposicaoNumericaAppService;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DecompositorNumericoController> _logger;

        public DecompositorNumericoController(IDecomposicaoNumericaAppService decomposicaoNumericaAppService, IMemoryCache memoryCache, IConfiguration configuration, ILogger<DecompositorNumericoController> logger)
        {
            _decomposicaoNumericaAppService = decomposicaoNumericaAppService;
            _memoryCache = memoryCache;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet("{baseNumerica:long:min(0)}")]
        public async Task<NumeroDecompostoViewModel> Get(long baseNumerica)
        {
            NumeroDecompostoViewModel numeroDecomposto = null;
            
            var tempoMinutosExpericaoCache = _configuration.GetValue<int>("VariaveisConfiguracoesDinamicas:TempoMinutosExpericaoCache");
            
            _logger.LogInformation($"Iniciando processo de decomposição numerica - {baseNumerica} - {DateTime.Now}  ");
            
            if (_memoryCache.TryGetValue(baseNumerica,out object numeroDecompostoObject))
            {
                numeroDecomposto = (NumeroDecompostoViewModel)numeroDecompostoObject;
            }
            else
            {
                numeroDecomposto = await _decomposicaoNumericaAppService.RealizarDecomposicaoNumero(baseNumerica);
                _memoryCache.Set(baseNumerica, numeroDecomposto, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(tempoMinutosExpericaoCache) });
            }
            _logger.LogInformation($"Finalizando processo de decomposição numerica - {baseNumerica} - {DateTime.Now}  ");

            return numeroDecomposto;
        }

    }
}
