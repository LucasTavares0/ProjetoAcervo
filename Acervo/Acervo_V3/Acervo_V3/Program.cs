using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            //O metodo main sera utilizado para chamar itens da classe view
            //aqui será criado somente o menu interativo
            //as demais mensagem serão tratadas na classe View
            int escolha = -1;
            View v = new View();

            do
            {
                escolha = Program.menu();

                //tratamento da escolha realizada
                switch (escolha)
                {
                    case 0: System.Environment.Exit(0); break;
                    case 1: v.adicionarLivro(); break;
                    case 2: v.pesquisarLivroS(); break;
                    case 3: v.pesquisarLivroA(); break;
                    case 4: v.adicionarExemplar(); break;
                    case 5: v.registrarEmprestimo(); break;
                    case 6: v.registrarDevolucao(); break;
                    default: Console.Clear(); Console.WriteLine("\nEscolha Inválida!!"); Console.ReadKey(); break;
                }
            }
            while(escolha != 0);
        }

        //Menu interativo
        public static int menu()
        {
            int escolha = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("========== ACERVO DE LIVROS ============");
                Console.WriteLine("\n");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar Livro");
                Console.WriteLine("2 - Pesquisar Livro (Sintético)");
                Console.WriteLine("3 - Pesquisar Livro (Analítico)");
                Console.WriteLine("4 - Adicionar Exemplar");
                Console.WriteLine("5 - Registrar Empréstimo");
                Console.WriteLine("6 - Registrar Devolução");
                escolha = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return escolha;
        }
    }
}
