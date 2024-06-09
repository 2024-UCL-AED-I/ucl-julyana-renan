using System;

class Livro
{
    private string titulo;
    private string autor;
    private string genero;
    private int classificacaoIndicativa;

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Autor
    {
        get { return autor; }
        set { autor = value; }
    }

    public string Genero
    {
        get { return genero; }
        set { genero = value; }
    }

    public int ClassificacaoIndicativa
    {
        get { return classificacaoIndicativa; }
        set
        {
            if (value >= 18)
            {
                classificacaoIndicativa = 18;
            }
            else
            {
                classificacaoIndicativa = value;
            }
        }
    }

    public override string ToString ()
    {
        return $" Titulo: {this.titulo}\n Autor: {this.Autor}.\n Genero: {this.Genero}.\n Classificacao indicativa: {this.classificacaoIndicativa} anos.\n";

    }
 }
