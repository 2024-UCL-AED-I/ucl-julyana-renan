class classeLivros
{
    private string titulo;
    private string autor;
    private string genero;
    private int classificacaoIndicativa;

//Matheus é brabo
    public string Titulo{
        get{ return titulo; }
        set{titulo = value;}
    }

    public string Autor{
        get{ return autor; }
        set{autor = value;}
    }

    public string Genero{
        get{ return genero; }
        set{ genero = value;}   
                /*public enum Genero{  temos q definir esses generos
            Romance,
            Acao,
            Terror,
            Ficcao Cientifica,
            Fantasia,   
            Suspense,
            Drama,
            Educacionais,
            Biografias,
                
        
        }*/
    }

    public int ClassificacaoIndicativa{
        get{ return classificacaoIndicativa;}
        set{
            if(value >=18){

            classificacaoIndicativa = 18;
            }
            else{

            classificacaoIndicativa = value;
            }
            //....

        }
    }
}
