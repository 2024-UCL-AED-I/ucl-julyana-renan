using System;

public class Pessoa
{
    private string nome;
    private string endereco;
    private int idade;
    private string cpf;

    //////////////////////////////////////////////////
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Endereco
    {
        get { return endereco; }
        set { endereco = value; }
    }

    public int Idade
    {
        get { return idade; }
        set
        {
            if (value > 0 && value < 120)
            {
                idade = value;
            }
        }
    }

    public string Cpf
    {
        get { return cpf; }
        set
        {
            if (ValidarCPF(value))
            {
                cpf = value;
            }
            else
            {
                console.WriteLine("CPF inválido.");
            }
        }
    }

    private static bool ValidarCPF(string cpf)
    {
        // Remove caracteres não numéricos
        cpf = cpf.Replace(".", "").Replace("-", "").Trim();

        // Verifica se o CPF tem 11 dígitos
        if (cpf.Length != 11)
            return false;

        // Verifica se todos os dígitos são iguais (caso inválido)
        bool todosDigitosIguais = true;
        for (int i = 1; i < cpf.Length && todosDigitosIguais; i++)
        {
            if (cpf[i] != cpf[0])
                todosDigitosIguais = false;
        }
        if (todosDigitosIguais)
            return false;

        // Calcula o primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
        {
            soma += (cpf[i] - '0') * (10 - i);
        }
        int primeiroDigitoVerificador = 11 - (soma % 11);
        if (primeiroDigitoVerificador >= 10)
            primeiroDigitoVerificador = 0;

        // Verifica o primeiro dígito verificador
        if (primeiroDigitoVerificador != (cpf[9] - '0'))
            return false;

        // Calcula o segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 10; i++)
        {
            soma += (cpf[i] - '0') * (11 - i);
        }
        int segundoDigitoVerificador = 11 - (soma % 11);
        if (segundoDigitoVerificador >= 10)
            segundoDigitoVerificador = 0;

        // Verifica o segundo dígito verificador
        if (segundoDigitoVerificador != (cpf[10] - '0'))
            return false;

        // Se passou por todas as verificações, o CPF é válido
        return true;
    }
}