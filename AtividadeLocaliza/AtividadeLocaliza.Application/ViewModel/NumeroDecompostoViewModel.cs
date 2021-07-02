using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLocaliza.Application.ViewModel
{
    public class NumeroDecompostoViewModel
    {
        public long NumeroEntrada { get; set; }
        public IEnumerable<long> NumerosDivisores { get; set; }
        public IEnumerable<long> DivisoresPrimos { get; set; }
    }
}
