using System;

class Emprestimo
{
    private Livro livro;
    private Pessoa cliente;
    private DateTime dataEmprestimo;
    private DateTime dataDevolucao;

    public void EmprestimoLivro(Livro livro, Pessoa cliente)
    {
        this.livro = livro;
        this.cliente = cliente;
        dataEmprestimo = DateTime.Now;
        dataDevolucao = dataEmprestimo.AddDays(14); // considerando 14 dias para um empréstimo
    }

    public void DevolucaoLivro()
    {
        if (DateTime.Now <= dataDevolucao)
        {
            Console.WriteLine("A devolução está dentro do prazo");
            // Aqui você pode adicionar a lógica para remover o empréstimo da lista, se necessário
        }
        else
        {
            TimeSpan diferencaDatas = DateTime.Now - dataDevolucao;
            Console.WriteLine($"A devolução está {diferencaDatas.Days} dias fora do prazo");
        }
    }
}