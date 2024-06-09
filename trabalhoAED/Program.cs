

using System;


class Program
{
    static void Main(string[] args)
    {
        // Criando uma instância de livro
        Livro livro = new Livro();
        livro.Titulo = "Dom Quixote";
        livro.Autor = "Miguel de Cervantes";
        livro.Genero = "Romance";
        livro.ClassificacaoIndicativa = 50; // Testando a classificação indicativa

        // Criando uma instância de pessoa
        Pessoa pessoa = new Pessoa();
        pessoa.Nome = "João";
        pessoa.Idade = 21;
        pessoa.Cpf = "161.776.997.58";
        pessoa.Endereco = "Rua professor virginio pereirar n100";

        Console.WriteLine(livro);
        Console.WriteLine("/////////////////////////////////");
        Console.WriteLine(pessoa);


        //Criando uma instância de empréstimo
        Emprestimo emprestimo = new Emprestimo();
        emprestimo.EmprestimoLivro(livro, pessoa);

        // Simulando a devolução do livro
        emprestimo.DevolucaoLivro(pessoa);
        Console.ReadLine();
    }
}
