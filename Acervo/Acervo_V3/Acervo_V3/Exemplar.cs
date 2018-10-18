using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo_V3
{
    class Exemplar
    {
        //atriutos
        private int tombo;
        private List<Emprestimo> emprestimos;

        //métodos Setter e Getter
        public void setTombo(int value)
        {
            this.tombo = value;
        }
        public int getTombo()
        {
            return this.tombo;
        }

        //Contrutores
        public Exemplar()
        {
            setTombo(0);
            emprestimos = new List<Emprestimo>();
        }
        public Exemplar(int tombo)
        {
            setTombo(tombo);
            emprestimos = new List<Emprestimo>();
        }

        //métodos Funcionais
        //
        //-- Método que cria uma nova instancia de emprestimo e retorna um booleano para tratamento
        public bool Emprestar()
        {
            if(disponivel() == true)
            {
                Emprestimo e = new Emprestimo();
                emprestimos.Add(e);
                return true;
            }
            else
            {
                return false;
            }
        }

        //-- Metodo que realiza a devolução de um exemplar e retorna um booleao para tratamento
        public bool Devolver()
        {
            if (disponivel() == false)
            {
                foreach (Emprestimo e in emprestimos)
                {
                    if (e.getStatus() == false)
                    {
                        e.setDtDevolucao();
                        break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //--Verifica se o livro está disponível para ser emprestado.
        public bool disponivel()
        {
            int num = 0; 

            foreach (Emprestimo e in emprestimos)
            {
                if (e.getStatus() == true)
                {
                    num = 0; //true
                }
                else
                {
                    num = 1; //false
                    break;
                }
            }

            if (num == 0) return true;
            else return false;
        }

        //- Dados resumidos dos emprestimos feitos para esse exemplar
        public String dadosExemplar()
        {
            StringBuilder dados = new StringBuilder();

            dados.Append("Tombo: " + getTombo());
            dados.Append(" - ");
            dados.Append("Disponibilidade: " + disponivel());
            dados.Append("\n");
            dados.Append("Empréstimos Realizados: \n");
            
            foreach(Emprestimo e in emprestimos)
            {
                dados.Append(e.dadosEmprestimo());
                dados.Append("\n");
            }
            return dados.ToString();
        }
    }
}
