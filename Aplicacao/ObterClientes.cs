using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TesteHiperstream.Entidades;
using TesteHiperstream.Interfaces;

namespace TesteHiperstream.Aplicacao
{
    public class ObterCliente : IObterClienteRepository
    {
        public List<Cliente> LerClientesDoArquivo(string filePath)
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Replace("\"", "");
                        string[] partes = line.Split(';');

                        if (partes.Length == 8)
                        {
                            string nome = partes[0].Trim();
                            string cepStr = partes[1].Trim().Replace(" ", "");
                            string endereco = partes[2].Trim();
                            string bairro = partes[3].Trim();
                            string cidade = partes[4].Trim();
                            string estado = partes[5].Trim();
                            string valorStr = partes[6].Trim().Replace(" ", "").Replace(",", ".");
                            string numeroPaginasStr = partes[7].Trim().Replace(" ", "");

                            bool containsOnlyZeros = Regex.IsMatch(cepStr, @"^0+$");
                            decimal valor = decimal.Parse(valorStr);
                            int numeroPaginas = int.Parse(numeroPaginasStr);
                            int cep = int.Parse(cepStr);


                            if (cepStr.Length < 7 || cepStr.Length > 8 || containsOnlyZeros)
                            {
                                continue;
                            }
                            else
                            {
                                var cliente = new Cliente {Nome = nome, CEP = cep, Endereco = endereco, Bairro = bairro, Cidade = cidade, Estado = estado, Valor = valor, NumeroPaginas = numeroPaginas };
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("O arquivo não foi encontrado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }

            return clientes;
        }
    }

}
