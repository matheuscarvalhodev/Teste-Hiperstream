using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHiperstream.Entidades;

namespace TesteHiperstream.Interfaces
{
    public interface IGravarClienteRepository
    {
        void GravarClienteCsv(List<Cliente> listaCliente);
    }
}
