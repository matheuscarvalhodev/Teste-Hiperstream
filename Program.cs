using System;
using System.Collections.Generic;
using System.IO;
using TesteHiperstream.Aplicacao;
using TesteHiperstream.Entidades;
using TesteHiperstream.Interfaces;

public class Program
{

    public static void Main(string[] args)
    {
        string inputPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\Data\\Input\\base_hi.txt";

        string outputPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

        IObterClienteRepository clienteRepository = new ObterCliente();
        IGravarClienteRepository gravarRepository = new GravarCliente();

        List<Cliente> clientes = clienteRepository.LerClientesDoArquivo(inputPath);

        gravarRepository.GravarClienteCsv(clientes, outputPath);

        Console.WriteLine($"Arquivos CSV gerados na pasta: {outputPath+ "\\Data\\Output"}");

    }
}
