using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLocaliza.Domain.DTO
{
    public class NumeracaoDecomposta
    {
        public long NumeroEntrada { get; set; }
        public IEnumerable<long> NumerosDivisores { get; set; }
        public IEnumerable<long> DivisoresPrimos { get; set; }
    }
}
