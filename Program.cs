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
        string filePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\Data\\Input\\base_hi.txt";

        IObterClienteRepository clienteRepository = new ObterCliente();
        IGravarClienteRepository gravarRepository = new GravarCliente();

        List<Cliente> clientes = clienteRepository.LerClientesDoArquivo(filePath);

        gravarRepository.GravarClienteCsv(clientes);

    }
}
