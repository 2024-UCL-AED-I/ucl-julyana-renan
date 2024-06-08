using System;

using DateTime; //olhar como chamar a bibli data

class Emprestimo
{

    private Livro livro;
    private Pessoa cliente;
    private DateTime dataEmprestimo;
    private DateTime dataDevolucao;

    public Emprestimo(Livro livro, Pessoa cliente)
    {

        this.livro = livro;
        this.cliente = cliente;
        //dataEmprestimo = DateTime.Now();
        dataEmprestimo = DateTime(2024, 06, 01);
        dataDevolucao = dataEmprestimo.AddDays(14); //considerando 14 dias para um emprestimo


    }

    public devolucaoLivro()
    {

        if (DateTime.Compare(DateTime.Now(), dataDevolucao) <= 0)
        {

            Console.WriteLine("A devolução está dentro do prazo");

            //tirar emprestimo da lista?
        }

        else
        {

            TimeSpan difencaDatas = DateTime.Now().Subtract(dataDevolucao);
            Console.WriteLine($"A devolução está {diferencaDatas} dias fora do prazo");
        }

    }

}