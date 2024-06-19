using System;
using System.Collections.Generic;


class Program
{

    static void Main(string[] args)
    {
        List<Livro> livros = new List<Livro>();
        List<Pessoa> clientes = new List<Pessoa>();
        List<Emprestimo> emprestimos = new List<Emprestimo>();

        string emprestimoPath = "..\\..\\..\\bancoDeDados\\Emprestimo.txt";
        string clientePath = ("..\\..\\..\\bancoDeDados\\Clientes.txt");
        string livroPath = "..\\..\\..\\bancoDeDados\\Livros.txt";

        if (File.Exists(livroPath))
        {
            string[] linhasLivros = File.ReadAllLines(livroPath);
            foreach (string linha in linhasLivros)
            {
                string[] dados = linha.Split(';');
                Livro livro = new Livro
                {
                    Titulo = dados[0],
                    Autor = dados[1],
                    Genero = dados[2],
                    ClassificacaoIndicativa = int.Parse(dados[3])
                };
                livros.Add(livro);
            }
        }

        if (File.Exists(clientePath))
        {
            string[] linhasClientes = File.ReadAllLines(clientePath);
            foreach (string linha in linhasClientes)
            {
                string[] dados = linha.Split(';');
                if (dados.Length >= 4) // Verifica se há pelo menos 4 elementos
                {
                    Pessoa cliente = new Pessoa
                    {
                        Nome = dados[0],
                        Idade = int.Parse(dados[1]),
                        Cpf = dados[2],
                        Endereco = dados[3],
                    };
                    clientes.Add(cliente);
                }
            }
        }

        if (File.Exists(emprestimoPath))
        {
            string[] linhasClientes = File.ReadAllLines(emprestimoPath);
            foreach (string linha in linhasClientes)
            {
                string[] dados = linha.Split(';');
                Pessoa randall = new Pessoa
                {
                    Nome = dados[0],
                    Idade = int.Parse(dados[2]),
                    Cpf = dados[3],
                    Endereco = dados[1],
                };


                Livro classico = new Livro
                {
                    Titulo = dados[4],
                    Autor = dados[5],
                    Genero = dados[6],
                    ClassificacaoIndicativa = int.Parse(dados[7]),
                };

                Emprestimo emprestimo = new Emprestimo
                {
                    Cliente = randall,
                    Livro = classico,
                    DataEmprestimo = DateTime.Parse(dados[8]),
                    DataDevolucao = DateTime.Parse(dados[9]),
                };
                emprestimos.Add(emprestimo);
            }
        }




        string opcao = "";

        while (opcao != "0")
        {
            Console.Clear();
            Console.WriteLine("=====================================================");
            Console.WriteLine("===                Opcões do Sistema              ===");
            Console.WriteLine("=====================================================");
            Console.WriteLine("0 - Sair.");
            Console.WriteLine("1 - Cadastrar Cliente.");
            Console.WriteLine("2 - Cadastrar Livro.");
            Console.WriteLine("3 - Alugar um Livro.");
            Console.WriteLine("4 - Devolver um Livro.");
            Console.WriteLine("5 - Relatório Livros Alugados.");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    return;
                case "1":
                    Pessoa pessoa = new Pessoa();
                    Console.WriteLine("Informe o nome do cliente:");
                    pessoa.Nome = Console.ReadLine();
                    Console.WriteLine("Informe o endereço do cliente:");
                    pessoa.Endereco = Console.ReadLine();
                    Console.WriteLine("Informe a idade do cliente:");
                    pessoa.Idade = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o CPF do cliente:");
                    pessoa.Cpf = Console.ReadLine();
                    clientes.Add(pessoa);
                    if (pessoa.Cpf != null)
                    {
                        Pessoa.EscreverEmArquivo(pessoa);
                        Console.WriteLine("\nCliente Cadastrado! Pressione qualquer tecla para continuar.");
                    }
                    else
                    {
                        Console.WriteLine("\nErro ao Cadastrado cliente! Pressione qualquer tecla para continuar.");
                    }
                    Console.ReadKey();
                    break;

                case "2":
                    Livro livro = new Livro();
                    Console.WriteLine("Informe o título do livro:");
                    livro.Titulo = Console.ReadLine();
                    Console.WriteLine("Informe o autor do livro:");
                    livro.Autor = Console.ReadLine();
                    Console.WriteLine("Informe o gênero do livro:");
                    livro.Genero = Console.ReadLine();
                    Console.WriteLine("Informe a Classificacao Indicativa do livro:");
                    livro.ClassificacaoIndicativa = int.Parse(Console.ReadLine());
                    livros.Add(livro);
                    Livro.EscreverEmArquivo(livro);

                    Console.WriteLine("\nLivro Cadastrado! Pressione qualquer teclar continuar.");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine("Informe o título do livro:");
                    string tituloLivro = Console.ReadLine();
                    Livro livrinho = livros.Find(l => l.Titulo == tituloLivro);

                    if (livrinho == null)
                    {
                        Console.WriteLine("Livro não encontrado. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Informe o CPF do cliente:");
                    string cpfCliente = Console.ReadLine();
                    Pessoa cliente = clientes.Find(c => c.Cpf == cpfCliente);

                    if (cliente == null)
                    {
                        Console.WriteLine("Cliente não encontrado. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        return;
                    }
                    Emprestimo novoEmprestimo = new Emprestimo
                    {
                        Cliente = cliente,
                        Livro = livrinho,
                        DataEmprestimo = DateTime.Now,
                        DataDevolucao = DateTime.Now.AddDays(14) // Exemplo de 14 dias para devolução
                    };

                    novoEmprestimo.EmprestimoLivro(livrinho, cliente);
                    Console.WriteLine("Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.WriteLine("Informe o CPF do cliente:");
                    string cpfClientinho = Console.ReadLine();
                    Pessoa clientinho = clientes.Find(c => c.Cpf == cpfClientinho);

                    if (clientinho == null)
                    {
                        Console.WriteLine("Cliente não encontrado. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        return;
                    }
                    Emprestimo devolveEmprestimo = new Emprestimo
                    {
                        Cliente = clientinho,
                        //Livro = ,
                        //DataEmprestimo = DateTime.Now,
                        //DataDevolucao = DateTime.Now.AddDays(14) // Exemplo de 14 dias para devolução
                    };
                    devolveEmprestimo.DevolucaoLivro(clientinho);
                    Console.WriteLine("Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;

                case "5":
                    Emprestimo.RelatorioLivrosAlugados();
                    Console.WriteLine("Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}