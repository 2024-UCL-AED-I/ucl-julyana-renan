

using System;
using System.Collections.Generic;


class Program
{

    static void Main(string[] args)
    {


        List<Livro> livros = new List<Livro>();
        List<Pessoa> clientes = new List<Pessoa>();
        Emprestimo emprestimo = new Emprestimo();

            string opcao = "";

            while (opcao != "0")
            {
                Console.Clear();
                Console.WriteLine("===============================1======================");
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
                        Pessoa.EscreverEmArquivo(pessoa);
                        Console.WriteLine("\nCliente Cadastrado! Pressione qualquer tecla para continuar.");
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

                        emprestimo.EmprestimoLivro(livrinho, cliente);
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

                        emprestimo.DevolucaoLivro(clientinho);
                        Console.WriteLine("Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case "5":
                    //funcao imprime relatorio

                    default:
                        Console.WriteLine("Opção Inválida! Pressione qualquer teclar para tentar novamente:");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
