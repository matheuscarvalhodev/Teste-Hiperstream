using TesteHiperstream.Entidades;
using TesteHiperstream.Interfaces;

namespace TesteHiperstream.Aplicacao
{
    public class GravarCliente : IGravarClienteRepository
    {
        private readonly string projectPath;

        public GravarCliente()
        {
            projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        }

        public void GravarClienteCsv(List<Cliente> listaCliente)
        {
            try
            {
                var faturas = CriaFatura(listaCliente);

                SalvarFaturasEmArquivo(faturas, "ClienteComValorZerado.csv", c => c.ValorFatura == 0);
                SalvarFaturasEmArquivo(faturas, "FaturasComAteSeisPaginas.csv", c => c.NumeroPaginas <= 6 && c.ValorFatura != 0);
                SalvarFaturasEmArquivo(faturas, "FaturasComAteDozePaginas.csv", c => c.NumeroPaginas > 6 && c.NumeroPaginas <= 12 && c.ValorFatura != 0);
                SalvarFaturasEmArquivo(faturas, "FaturasComMaisDozePaginas.csv", c => c.NumeroPaginas > 12 && c.ValorFatura != 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar os arquivos CSV: {ex.Message}");
            }
        }

        private List<Fatura> CriaFatura(List<Cliente> clientes)
        {
            List<Fatura> fatura = clientes
            .Select(cliente => new Fatura
            {
                NomeCliente = cliente.Nome,
                EnderecoCompleto = $"Rua: {cliente.Endereco} | Bairro: {cliente.Bairro} | Cidade: {cliente.Cidade}-{cliente.Estado} | CEP: {cliente.CEP}",
                NumeroPaginas = cliente.NumeroPaginas,
                ValorFatura = cliente.Valor
            })
            .ToList();

            return fatura;
        }

        private void SalvarFaturasEmArquivo(List<Fatura> faturas, string nomeArquivo, Func<Fatura, bool> filtro)
        {
            string outputPath = Path.Combine(projectPath, "Data", "Output");
            var faturasFiltradas = faturas.Where(filtro);
            var linhasCsv = faturasFiltradas.Select(cliente => (string)cliente).ToList();
            linhasCsv.Insert(0, "NomeCliente,EnderecoCompleto,ValorFatura,NumeroPaginas");

            try
            {

                File.WriteAllLines(Path.Combine(outputPath, nomeArquivo), linhasCsv);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao salvar o arquivo CSV: {ex.Message}");
            }
        }
    }
}
