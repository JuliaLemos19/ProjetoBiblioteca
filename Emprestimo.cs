using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Emprestimo
    {
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public Emprestimo(DateTime dataEmprestimo)
        {
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = null;
        }

        public bool EstaAtivo()
        {
            return DataDevolucao == null;
        }
    }
}
