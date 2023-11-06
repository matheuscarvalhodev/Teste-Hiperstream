# Projeto de Processamento de Faturas em C#

## Descrição do Projeto

Este projeto é uma aplicação de linha de comando em C# que lê um arquivo de entrada contendo dados de faturas de clientes fictícios. A aplicação aplica regras específicas aos dados e gera arquivos de saída no formato CSV, de acordo com as regras estabelecidas.

### Critérios de Aceitação

1. A aplicação é capaz de ler o arquivo de entrada em formato .txt e processá-lo corretamente.
2. A aplicação valida os registros de faturas, removendo os registros com CEP inválido de acordo com as regras especificadas:
   - Máximo de 8 caracteres
   - Mínimo de 7 caracteres
   - Todos os caracteres devem ser numéricos
   - CEPs zerados também não são considerados válidos (ex. 00000000).
3. A aplicação separa os registros de faturas com valor zero e os grava em um arquivo .csv separado.
4. Os registros de saída são agrupados com base no número de páginas de faturas, seguindo as diretrizes estabelecidas:
   - Um arquivo é criado para registros com até 6 páginas.
   - Um arquivo é criado para registros com até 12 páginas.
   - Um arquivo é criado para registros com mais de 12 páginas.
5. Os arquivos de saída são gerados no formato .csv e seguem o layout especificado: "NomeCliente;EnderecoCompleto;ValorFatura;NumeroPaginas".
6. Um arquivo .csv separado é gerado para as faturas com valor zero, independentemente do número de páginas.
7. A aplicação é otimizada em termos de desempenho e segue as boas práticas de código limpo.
8. A aplicação inclui documentação para facilitar a depuração e testes por pessoas não familiarizadas com a linguagem C#.

## Motivação da Escolha da Linguagem

Optei por usar a linguagem C# devido à sua forte tipagem estática, facilidade de desenvolvimento e suporte à criação de aplicativos de linha de comando. Além disso, a linguagem C# é amplamente utilizada na indústria e possui uma grande comunidade de desenvolvedores, o que facilita a resolução de problemas e a colaboração. E obviamente, por ser a linguagem utilizada pela empresa, dessa forma, mostrando dominio na linguagem.

## Entrega

Você pode encontrar o código-fonte deste projeto no link do repositorio [repositório do GitHub](https://github.com/matheuscarvalhodev/Teste-Hiperstream). Se quiser, compartilhe o link do projeto para que possa ajudar outros Devs!

## Instruções para Execução

Para executar este projeto, siga as etapas abaixo:

1. Clone o repositório para o seu computador:

   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git

2. Navegue até o diretório do projeto
    ```bash
    cd nome-do-seu-projeto

Certifique-se de usar o nome do diretório onde o projeto foi clonado.

3. Compile e execute o projeto:
    ```bash
    dotnet run

Certifique-se de ter o .NET SDK instalado em seu sistema para compilar e executar o projeto
