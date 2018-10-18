using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo_V3
{
    class Livros
    {
        //atributos
        private List<Livro> acervo;

        //propriedades 
        public void setLivro(Livro livro)
        {
            this.acervo.Add(livro);
        }
        public Livro getLivro(int isbn)
        {
            bool existe = false;
            Livro exem = new Livro();

            foreach (Livro l in acervo)
            {
                if (l.getIsbn() == isbn)
                {
                    existe = true;
                    exem = l;
                    break;
                }
                else
                {
                    existe = false;
                }
            }

            if (existe) return exem;
            else return null;
        }

        //Construtor
        public Livros()
        {
            acervo = new List<Livro>();
        }

        //métodos funcionais
        public void adicionar(Livro livro)
        {
            setLivro(livro);
        }
        public Livro pesquisar(int isbn)
        {
            return getLivro(isbn);
        }
    }
}
