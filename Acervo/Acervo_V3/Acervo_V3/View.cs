using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo_V3
{
    class View
    {
        //atributo Livro será utilizado para evocar os demais metodos
        private Livros livros;

        //contrutor
        public View()
        {
            this.livros = new Livros();
        }

        //métodos funcionais
        public void adicionarLivro()
        {
            int isbn = 0;
            string titulo, autor, editora;

            try
            {
                Console.Clear();
                Console.WriteLine("======== ADICIONANDO LIVRO =========");
                Console.WriteLine("\nISBN do livro: ");
                isbn = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                adicionarLivro();
            }

            Livro livro = livros.pesquisar(isbn);

            if (livro == null)
            {
                Console.WriteLine("\nTítulo do livro: ");
                titulo = Console.ReadLine();
                Console.WriteLine("\nAutor do livro: ");
                autor = Console.ReadLine();
                Console.WriteLine("\nEditora do livro: ");
                editora = Console.ReadLine();

                //Instanciando um novo livro e passando como parametro
                livro = new Livro(isbn, titulo, autor, editora);
                livros.adicionar(livro);
                Console.Clear();
                Console.WriteLine("Livro adicionado com sucesso!!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Já existe um livro cadastrado com essa ISBN!");
                Console.ReadKey();
            }
        }
        public void pesquisarLivroS()
        {
            int isbn = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("======== PESQUISANDO LIVRO (SINTÉTICO)=========");
                Console.WriteLine("\nISBN do Livro: ");
                isbn = int.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                pesquisarLivroS();
            }

            Livro livro = livros.pesquisar(isbn);

            if(livro == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum livro com essa ISBN no acervo!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n" + livro.dadosResumidos());
                Console.ReadKey();
            }
            
        }
        public void pesquisarLivroA()
        {
            int isbn = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("======== PESQUISANDO LIVRO (ANALÍTICO)=========");
                Console.WriteLine("\nISBN do Livro: ");
                isbn = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                pesquisarLivroS();
            }

            Livro livro = livros.pesquisar(isbn);

            if (livro == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum livro com essa ISBN no acervo!");
                Console.ReadKey();
            }
            else
            {   
                Console.WriteLine("\n" + livro.dadosCompletos());
                Console.ReadKey();
            }
        }
        public void adicionarExemplar()
        {
            int isbn = 0;
            int tombo = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("======== ADICIONANDO EXEMPLAR =========");
                Console.WriteLine("\nISBN do Livro: ");
                isbn = int.Parse(Console.ReadLine());   
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                pesquisarLivroS();
            }

            Livro livro = livros.pesquisar(isbn);

            if (livro == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum livro com essa ISBN no acervo!");
                Console.ReadKey();
            }
            else
            {
                try
                {
                    Console.WriteLine("\nTombo do exemplar adicionado: ");
                    tombo = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    pesquisarLivroS();
                }

                Exemplar exemplar = livro.pesquisar(tombo);

                if (exemplar == null)
                {
                    exemplar = new Exemplar(tombo);
                    livro.adicionarExemplar(exemplar);
                    Console.Clear(); Console.WriteLine("Exemplar adiconado com sucesso!"); Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Já existe um exemplar registrado com esse tombo!");
                    Console.ReadKey();
                }
            }
        }
        public void registrarEmprestimo()
        {
            int isbn = 0;
            int tombo = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("======== REGISTRO DE EMPRÉSTIMO =========");
                Console.WriteLine("\nISBN do Livro: ");
                isbn = int.Parse(Console.ReadLine()); 
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                pesquisarLivroS();
            }

            Livro livro = livros.pesquisar(isbn);

            if (livro == null)
            {

                Console.Clear();
                Console.WriteLine("Não existe nenhum livro com essa ISBN no acervo!");
                Console.ReadKey();
            }
            else
            {   
                try
                {
                    Console.WriteLine("\nTombo do exemplar a emprestar: ");
                    tombo = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    pesquisarLivroS();
                }

                Exemplar exemplar = livro.pesquisar(tombo);
                
                if(exemplar == null)
                {
                    Console.Clear();
                    Console.WriteLine("Não existe nenhum exemplar com esse tombo para este livro!");
                    Console.ReadKey();
                }
                else
                {
                    if(exemplar.Emprestar())
                    {
                        Console.Clear(); Console.WriteLine("Exemplar emprestado com sucesso!"); Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear(); Console.WriteLine("Operação inválida! Exemplar já emprestado."); Console.ReadKey();
                    }
                }
            }
        }
        public void registrarDevolucao()
        {
            int isbn = 0;
            int tombo = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("======== REGISTRO DE DEVOLUÇÃO =========");
                Console.WriteLine("\nISBN do Livro: ");
                isbn = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                pesquisarLivroS();
            }

            Livro livro = livros.pesquisar(isbn);

            if (livro == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum livro com essa ISBN no acervo!");
                Console.ReadKey();
            }
            else
            {
                try
                {
                    Console.WriteLine("\nTombo do exemplar emprestado: ");
                    tombo = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    pesquisarLivroS();
                }

                Exemplar exemplar = livro.pesquisar(tombo);

                if (exemplar == null)
                {
                    Console.Clear();
                    Console.WriteLine("Não existe nenhum exemplar com esse tombo para este livro!");
                    Console.ReadKey();
                }
                else
                {
                    if (exemplar.Devolver())
                    {
                        Console.Clear(); Console.WriteLine("Exemplar devolvido com sucesso!"); Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear(); Console.WriteLine("Operação inválida! Exemplar não está emprestado."); Console.ReadKey();
                    }
                }
            }
        }
    }
}
