using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Exemplar
    {
        public int tombo;
        private List<Emprestimo> emprestimos;

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
            emprestimos = new List<Emprestimo>();
        }

        public bool Emprestar()
        {
            if (disponivel())
            {
                emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            foreach (var emprestimo in emprestimos)
            {
                if (emprestimo.EstaAtivo())
                {
                    emprestimo.DataDevolucao = DateTime.Now;
                    return true;
                }
            }
            return false;
        }

        public bool disponivel()
        {
            foreach (var emprestimo in emprestimos)
            {
                if (emprestimo.EstaAtivo())
                {
                    return false;
                }
            }
            return true;
        }

        public int QtdeEmprestimos()
        {
            return emprestimos.Count;
        }
    }
}

