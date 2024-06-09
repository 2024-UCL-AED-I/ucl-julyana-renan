

using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {

        List<Livro> books = new List<Livro>();

        Livro livro = new Livro();

        Cadastrarbooks(books);



        Console.WriteLine(books);




        // Criando uma instância de livro
       // Livro livro = new Livro();
       // Console.WriteLine("Digite o Titulo do Livro:");
       // livro.Titulo = "Dom Quixote";
       // livro.Autor = "Miguel de Cervantes";
       // livro.Genero = "Romance";
       // livro.ClassificacaoIndicativa = 50; // Testando a classificação indicativa









        // Criando uma instância de pessoa
        //Pessoa pessoa = new Pessoa();
        //pessoa.Nome = "João";
        //pessoa.Idade = 21;
        //pessoa.Cpf = "161.776.997.58";
        //pessoa.Endereco = "Rua professor virginio pereirar n100";
        //
        //Console.WriteLine("/////////////////////////////////");
        //Console.WriteLine(pessoa);









        // Criando uma instância de empréstimo
        //Emprestimo emprestimo = new Emprestimo();
        //emprestimo.EmprestimoLivro(livro, pessoa);

        // Simulando a devolução do livro
        //emprestimo.DevolucaoLivro();
        Console.ReadLine();
    }
}
