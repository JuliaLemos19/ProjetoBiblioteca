using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Livro
   
    {
        // Atributos
        public int isbn;
        public string titulo;
        public string autor;
        public string editora;
        public List<Exemplar> exemplares;

        // Construtor
        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            exemplares = new List<Exemplar>();
        }

    
        public void AdicionarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            int count = 0;
            foreach (var exemplar in exemplares)
            {
                if (exemplar.disponivel = true)
                    count++;
            }
            return count;
        }

        public int QtdeEmprestimos()
        {
            int count = 0;
            foreach (var exemplar in exemplares)
            {
                if (!exemplar.disponivel)
                    count++;
            }
            return count;
        }

        public double PercDisponibilidade()
        {
            int total = QtdeExemplares();
            if (total == 0) return 0;
            return (double)QtdeDisponiveis() / total * 100;
        }
    }




}

