using AtividadeLocalizaConsole.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AtividadeLocaliza.DAL
{
    public class DecompositorNumericoDAL : IDecompositorNumericoDAL
    {
        private readonly IConfiguration _configurarion;
        public DecompositorNumericoDAL(IConfiguration configurarion)
        {
            _configurarion = configurarion;
        }
        public async Task<NumeracaoDecompostaDto> ObterNumeroDecomposto(long numeroBase)
        {
            NumeracaoDecompostaDto numeracaoDecomposta = null;
            var retry = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(3, retryAttempt =>
            {
                var timeToWait = TimeSpan.FromSeconds(2);
                Console.WriteLine($"Aguardando resposta do servidor.");
                return timeToWait;
            });


            await retry.ExecuteAsync(async () =>
             {
                 HttpClient cliente = new HttpClient();
                 var response = await cliente.GetAsync(string.Concat(_configurarion["EnderecoAPIAtividadeLocaliza"], numeroBase));
                 numeracaoDecomposta = JsonConvert.DeserializeObject<NumeracaoDecompostaDto>(await response.Content.ReadAsStringAsync());
             });

            return numeracaoDecomposta;

        }
    }
}