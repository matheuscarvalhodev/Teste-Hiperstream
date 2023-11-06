using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TesteHiperstream.Entidades
{
    public class Fatura
    {

        public string NomeCliente { get; set; } = string.Empty;
        public string EnderecoCompleto { get; set; } = string.Empty;
        public decimal ValorFatura { get; set; }
        public int NumeroPaginas { get; set; }

        public static implicit operator string(Fatura fatura) => $"{fatura.NomeCliente},{fatura.EnderecoCompleto.Replace(","," | ")},{fatura.ValorFatura},{fatura.NumeroPaginas}";
    }
}
