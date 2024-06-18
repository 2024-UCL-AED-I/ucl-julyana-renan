using System;
using System.IO;
using System.Text;

class Emprestimo
{
    private Livro livro;
    private Pessoa cliente;
    private DateTime dataEmprestimo;
    private DateTime dataDevolucao;

    public void EmprestimoLivro(Livro livro, Pessoa cliente)
    {


        string emprestimoPath = "..\\..\\..\\bancoDeDados\\Emprestimo.txt";
        string clientePath = ( "..\\..\\..\\bancoDeDados\\Clientes.txt");
        string livroPath = "..\\..\\..\\bancoDeDados\\Livros.txt";

        // Verificar se o cliente está registrado
        bool clienteRegistrado = false;
        using (StreamReader sr = new StreamReader(clientePath, Encoding.UTF8))
        {        
            while (!sr.EndOfStream)
            {
                string linha = sr.ReadLine();

                string[] dados = linha.Split(';');

                if (dados.Length > 3 && dados[2] == cliente.Cpf)
                {
                    clienteRegistrado = true;
                    break;
                }
            }
        }

        if (!clienteRegistrado)
        {
            Console.WriteLine("Cliente não registrado. Empréstimo não permitido.");
            return;
        }

        // Verificar se o livro está registrado
        bool livroRegistrado = false;
        using (StreamReader sr = new StreamReader(livroPath, Encoding.UTF8))
        {
            string linha;

            while (!sr.EndOfStream)
            {
                linha = sr.ReadLine();
                
                string[] dados = linha.Split(';');
                if (dados.Length > 0 && dados[0] == livro.Titulo)
                {
                    livroRegistrado = true;
                    break;
                }
            }
        }

        if (!livroRegistrado)
        {
            Console.WriteLine("Livro não registrado. Empréstimo não permitido.");
            return;
        }

        string filePath = "..\\..\\..\\bancoDeDados\\Emprestimo.txt";


        // Verificar se o cliente já tem um livro alugado
        bool clienteJaTemLivro = false;
        if (File.Exists(emprestimoPath))
        {
            using (StreamReader sr = new StreamReader(emprestimoPath, Encoding.UTF8))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');
                    if (dados.Length > 3 && dados[3] == cliente.Cpf)
                    {
                        clienteJaTemLivro = true;
                        break;
                    }
                }
            }
        }

        if (clienteJaTemLivro)
        {
            Console.WriteLine($"{cliente.Nome} já possui um livro alugado. Por favor, verifique.");
            return;
        }

        // Registrar o empréstimo
        using (StreamWriter sw = new StreamWriter(emprestimoPath, true, Encoding.UTF8))
        {
            this.livro = livro;
            this.cliente = cliente;
            dataEmprestimo = DateTime.Now;
            dataDevolucao = dataEmprestimo.AddDays(14); // Considerando 14 dias para um empréstimo

            string linha = ($"{cliente.Nome};{cliente.Endereco};{cliente.Idade};{cliente.Cpf};{livro.Titulo};{livro.Autor};{livro.Genero};{livro.ClassificacaoIndicativa};{dataEmprestimo};{dataDevolucao}");

            sw.WriteLine(linha);

            string caminhoArquivo = "..\\..\\..\\bancoDeDados\\Emprestimo.txt";
            //File.AppendAllText(caminhoArquivo, linha + Environment.NewLine);
        }

        Console.WriteLine($"Empréstimo adicionado com sucesso. O livro deve ser devolvido em {dataDevolucao}");
    }


    public void DevolucaoLivro(Pessoa pessoa)
    {
        string filePath = "..\\..\\..\\bancoDeDados\\Emprestimo.txt";
        bool livroDevolvido = false;

        // Ler todas as linhas do arquivo e armazená-las em uma lista
        var linhas = new List<string>(File.ReadAllLines(filePath, Encoding.UTF8));

        for (int i = 0; i < linhas.Count; i++)
        {
            string[] dados = linhas[i].Split(';');
            if (dados.Length > 3 && dados[3] == pessoa.Cpf)
            {
                DateTime dataDevolucao = DateTime.Parse(dados[9]);
                if (DateTime.Now <= dataDevolucao)
                {
                    Console.WriteLine("A devolução está dentro do prazo");
                }
                else
                {
                    TimeSpan diferencaDatas = DateTime.Now - dataDevolucao;
                    Console.WriteLine($"A devolução está {diferencaDatas.Days} dias fora do prazo");
                    double multa = 1.50 + diferencaDatas.Days * 0.5;
                    Console.WriteLine($"Sua multa totaliza R${multa:F2} reais");
                    Console.WriteLine("Digite 1 para indicar que a multa foi paga ou qualquer outro caractere para sair");
                    if (int.Parse(Console.ReadLine()) != 1)
                    {
                        return;
                    }
                }

                // Remover a linha do arquivo após a devolução
                linhas.RemoveAt(i);
                livroDevolvido = true;
                break;
            }
        }

        if (livroDevolvido)
        {
            // Reescrever o arquivo sem a linha do empréstimo devolvido
            File.WriteAllLines(filePath, linhas, Encoding.UTF8);
            Console.WriteLine($"A devolução de {livro.Titulo} foi concluída com sucesso!");
        }
        else
        {
            Console.WriteLine($"{pessoa.Nome} não possui nenhum livro alugado.");
        }
    }
}
