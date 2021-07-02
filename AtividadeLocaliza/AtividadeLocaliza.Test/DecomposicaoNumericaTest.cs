using AtividadeLocaliza.Domain.DTO;
using AtividadeLocaliza.Domain.Interfaces.Services;
using AtividadeLocaliza.Domain.Services;
using AtividadeLocaliza.DecomposicaoNumerica.ParametrosTeste;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace AtividadeLocaliza.ParametrosTest
{
    public class DecomposicaoNumericaTest
    {
        public IDecomposicaoNumericaService _decomposicaoNumericaService;
        public DecomposicaoNumericaTest()
        {
             _decomposicaoNumericaService = new DecomposicaoNumericaService(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
        }

        [Theory]
        [ClassData(typeof(DeveRetornarNumerosDivisiveisPrimosParameters))]
        public void Deve_Retornar_Numeros_Divisiveis_Primos(ValorBase valorBase, NumeracaoDecomposta resultadoEsperado)
        {
           var resultadoDecomposicao = _decomposicaoNumericaService.DecomporNumero(valorBase.Valor);
           var resultadoDecomposicaoConvertido = JsonConvert.SerializeObject(resultadoDecomposicao.Result);
           var resultadoEsperadoConvertido = JsonConvert.SerializeObject(resultadoEsperado);
            Assert.Equal(resultadoEsperadoConvertido, resultadoDecomposicaoConvertido);
        }
    }
}
