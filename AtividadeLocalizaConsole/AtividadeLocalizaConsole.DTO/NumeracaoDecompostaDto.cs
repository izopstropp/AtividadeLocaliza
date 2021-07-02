using System;
using System.Collections.Generic;

namespace AtividadeLocalizaConsole.DTO
{
    public class NumeracaoDecompostaDto
    {
        public long NumeroEntrada { get; set; }
        public IEnumerable<long> NumerosDivisores { get; set; }
        public IEnumerable<long> DivisoresPrimos { get; set; }
        public string mensagem { get; set; }
    }
}
