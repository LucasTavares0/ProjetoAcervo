using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo_V3
{
    class Emprestimo
    {
        //atributos
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        //propriedades Setter
        public void setDtEmprestimo()
        {
            this.dtEmprestimo = new DateTime();
            this.dtEmprestimo = DateTime.Now;
        }
        public void setDtDevolucao()
        {
            this.dtDevolucao = new DateTime();
            this.dtDevolucao = DateTime.Now;
        }
        //propriedades Getter
        public string getDtDevolucao()
        {
            if (this.dtDevolucao.ToString() == "01/01/0001 00:00:00") return "Ainda não devolvido.";
            else return this.dtDevolucao.ToString();
        }
        public string getDtEmprestimo()
        {
            return this.dtEmprestimo.ToString();
        }
        public bool getStatus() // true = Disponível, false = Emprestrado
        {
            if (getDtEmprestimo() == null && getDtDevolucao() == "Ainda não devolvido.")
            {
                return true;
            }
            else
            {
                if(getDtEmprestimo() != null && getDtDevolucao() == "Ainda não devolvido.")
                {
                    return false;
                }
                else
                {
                    if (getDtEmprestimo() != null && getDtDevolucao() != "Ainda não devolvido.")
                    {
                        return true;
                    }
                    else return false;
                }
            }
        }

        //contrutores
        public Emprestimo()
        {
            setDtEmprestimo();
        }

        //métodos funcionais
        public String dadosEmprestimo()
        {
            StringBuilder dados = new StringBuilder();
            dados.Append("Data Emprestimo: " + getDtEmprestimo());
            dados.Append(" - ");
            dados.Append("Data Devolução: " + getDtDevolucao());
            return dados.ToString();
        }
    }
}
