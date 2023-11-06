using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteHiperstream.Entidades
{
    public class Cliente
    {

        public string Nome { get; set; } = string.Empty;
        public int CEP { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int NumeroPaginas { get; set; }
    }
}
