using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Program

    {
        static void Main(string[] args)
        {
            Livros biblioteca = new Livros();
            int opcao;

            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro(biblioteca);
                        break;
                    case 2:
                        PesquisarLivroSintetico(biblioteca);
                        break;
                    case 3:
                        PesquisarLivroAnalitico(biblioteca);
                        break;
                    case 4:
                        AdicionarExemplar(biblioteca);
                        break;
                    case 5:
                        RegistrarEmprestimo(biblioteca);
                        break;
                    case 6:
                        RegistrarDevolucao(biblioteca);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void AdicionarLivro(Livros biblioteca)
        {
            Console.Write("Digite o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());
            Console.Write("Digite o título: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite o autor: ");
            string autor = Console.ReadLine();
            Console.Write("Digite a editora: ");
            string editora = Console.ReadLine();

            Livro novoLivro = new Livro(isbn, titulo, autor, editora);
            biblioteca.adicionar(novoLivro);
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        static void PesquisarLivroSintetico(Livros biblioteca)
        {
            Console.Write("Digite o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.titulo}, Total Exemplares: {livro.QtdeExemplares()}, Disponíveis: {livro.QtdeDisponiveis()}, Empréstimos: {livro.QtdeEmprestimos()}, % Disponibilidade: {livro.PercDisponibilidade():F2}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void PesquisarLivroAnalitico(Livros biblioteca)
        {
            Console.Write("Digite o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.titulo}, Total Exemplares: {livro.QtdeExemplares()}, Disponíveis: {livro.QtdeDisponiveis()}, Empréstimos: {livro.QtdeEmprestimos()}, % Disponibilidade: {livro.PercDisponibilidade():F2}%");
            
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void AdicionarExemplar(Livros biblioteca)
        {
            Console.Write("Digite o ISBN do livro para adicionar um exemplar: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.Write("Digite o número do tombo: ");
                int tombo = int.Parse(Console.ReadLine());
                Exemplar exemplar = new Exemplar(tombo);
                livro.AdicionarExemplar(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarEmprestimo(Livros biblioteca)
        {
            Console.Write("Digite o ISBN do livro para registrar o empréstimo: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.Write("Digite o número do tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());
                var exemplar = livro.exemplares.FirstOrDefault(e => e.tombo == tombo);
                if (exemplar != null && exemplar.Emprestar())
                {
                    Console.WriteLine("Empréstimo registrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exemplar não disponível para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarDevolucao(Livros biblioteca)
        {
            Console.Write("Digite o ISBN do livro para registrar a devolução: ");
            int isbn = int.Parse(Console.ReadLine());
            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.Write("Digite o número do tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());
                var exemplar = livro.exemplares.FirstOrDefault(e => e.tombo == tombo);
                if (exemplar != null && exemplar.Devolver())
                {
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exemplar não está emprestado.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}
