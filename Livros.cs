using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Livros
    {
        private List<Livro> acervo; 

        public Livros() { 
        
        acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            
            acervo.Add(livro);
        }
        public Livro Pesquisar(int isbn) => acervo.FirstOrDefault(l => l.isbn == isbn);
    }
}

