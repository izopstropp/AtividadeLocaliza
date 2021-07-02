using AtividadeLocaliza.Application.ViewModel;
using AtividadeLocaliza.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLocaliza.Application.Mapper
{
    public class NumeracaoMapper
    {
        public static NumeroDecompostoViewModel MapperToView(NumeracaoDecomposta numeroComposto)
        {
            return new NumeroDecompostoViewModel()
            {
                DivisoresPrimos = numeroComposto.DivisoresPrimos,
                NumerosDivisores = numeroComposto.NumerosDivisores,
                NumeroEntrada = numeroComposto.NumeroEntrada
            };
        }
    }
}
