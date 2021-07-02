using AtividadeLocaliza.Domain.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLocaliza.DecomposicaoNumerica.ParametrosTeste
{
    class DeveRetornarNumerosDivisiveisPrimosParameters : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[]
            {
                new ValorBase
                {
                     Valor = 264324
                },
                new NumeracaoDecomposta
                {
                  NumeroEntrada = 264324,
                  NumerosDivisores= new List<long>(new long[] {1, 2, 3, 4, 6, 12, 22027, 44054, 66081, 88108, 264324}),
                  DivisoresPrimos = new List<long>(new long[] { 1, 2, 3, 22027})
                }
            };

            yield return new object[]
            {
                new ValorBase
                {
                    Valor = 45
                },
                new NumeracaoDecomposta
                {
                    NumeroEntrada = 45,
                    NumerosDivisores= new List<long>(new long[] { 1, 3, 5, 9, 15, 45}),
                    DivisoresPrimos = new List<long>(new long[] { 1, 3, 5})
                }
            };

            yield return new object[]
               {
                    new ValorBase
                    {
                        Valor = 5446
                    },
                    new NumeracaoDecomposta
                    {
                        NumeroEntrada = 5446,
                        NumerosDivisores= new List<long>(new long[] { 1, 2, 7, 14, 389, 778, 5446}),
                        DivisoresPrimos = new List<long>(new long[] {1, 2, 7, 389 })
                    }
               };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValorBase
    {
        public long Valor { get; set; }

    }
}
