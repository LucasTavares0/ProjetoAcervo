using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo_V3
{
    class Livro
    {
        //atributos
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        //propriedades Getter
        public int getIsbn()
        {
            return this.isbn;
        }
        public string getTitulo()
        {
            return this.titulo;
        }
        public string getAutor()
        {
            return this.autor;
        }
        public string getEditora()
        {
            return this.editora;
        }
        public Exemplar getExemplar(int tombo)
        {
            bool existe = false;
            Exemplar exem = new Exemplar(tombo);

            foreach (Exemplar e in this.exemplares)
            {
                if (e.getTombo() == exem.getTombo())
                {
                    exem = e;
                    existe = true;
                    break;
                }
                else existe = false;
            }
            if (existe) return exem;
            else return null;
        }


        //Propriedades Setter
        public void setIsbn(int value)
        {
            this.isbn = value;
        }
        public void setTitulo(String value)
        {
            this.titulo = value;
        }
        public void setAutor(String value)
        {
            this.autor = value;
        }
        public void setEditora(String value)
        {
            this.editora = value;
        }

        //Contrutores
        public Livro()
        {
            setIsbn(0);
            setTitulo("");
            setAutor("");
            setEditora("");
            exemplares = new List<Exemplar>();
        }
        public Livro(int isbn, string titulo, string autor, string editora)
        {
            setIsbn(isbn);
            setTitulo(titulo);
            setAutor(autor);
            setEditora(editora);
            exemplares = new List<Exemplar>();
        }

        //métodos funcionais
        //
        //--Insere um novo esemplar na lista de exemplares
        public void adicionarExemplar(Exemplar exemplar)
        {
            this.exemplares.Add(exemplar);
        }
        public int qntdExemplares()
        {
            return this.exemplares.Count;
        }
        //--- Retorna a quantidade de livros disponíveis (não emprestados)
        public int qntdDisponiveis()
        {
            int contador = 0;

            foreach (Exemplar e in this.exemplares)
            {
                if (e.disponivel())
                {
                    contador += 1;
                }
            }
            return contador;
        }
        //--- Retorna a quantidade de livros não disponíveis (emprestados)
        public int qntdEmprestimos()
        {
            int contador = 0;

            foreach (Exemplar e in this.exemplares)
            {
                if (e.disponivel())
                {

                }
                else contador += 1;
            }
            return contador;
        }
        //--- Retorna um percentual de livros disponíveis sobre o total de livros
        public double percDisponibilidade()
        {
            double a;

            try
            {
                a = (this.qntdDisponiveis() / this.exemplares.Count) * 100;
            }
            catch(DivideByZeroException)
            {
                a = 0.0;
            }

            return a;
        }
        public Exemplar pesquisar(int tombo)
        {
            return getExemplar(tombo);
        }

        //- Dados resumidos
        public String dadosResumidos()
        {
            StringBuilder dados = new StringBuilder();
            dados.Append("ISBN: " + getIsbn().ToString());
            dados.Append(" - ");
            dados.Append("Título: " + getTitulo());
            dados.Append(" - ");
            dados.Append("Autor: " + getAutor());
            dados.Append(" - ");
            dados.Append("Editora: " + getEditora());
            dados.Append("\n");
            dados.Append("N° de Exemplares: " + qntdExemplares());
            dados.Append(" - ");
            dados.Append("Exemplares disponíveis: " + qntdDisponiveis());
            dados.Append(" - ");
            dados.Append("Exemplares emprestados: " + qntdEmprestimos());
            dados.Append("\n");
            dados.Append("Percentual Disponibilidade: " + percDisponibilidade());
            return dados.ToString();
        }

        //- Dados completos
        public String dadosCompletos()
        {
            StringBuilder dados = new StringBuilder();
            dados.Append(dadosResumidos());
            dados.Append("\n\n");

            foreach(Exemplar e in exemplares)
            {
                dados.Append(e.dadosExemplar());
                dados.Append("\n");
            }

            return dados.ToString();
        }
    }
}
