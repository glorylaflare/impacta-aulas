using MiniCaixaEletronicoMultiplas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMultiplas.Data
{
    class ContaRepositorio
    {
        private readonly List<Conta> _contas = new List<Conta>();

        public ContaRepositorio()
        {
            if(!_contas.Any())
            {
                //Pesquisar os métodos da classe List
                _contas.Add(new Conta(101, "Marcelo", 34252.32m));
                _contas.Add(new Conta(101, "Cristiano", 1342.02m));
                _contas.Add(new Conta(101, "Alice", 2345.23m));
            }
        }

        public Conta BuscaContaPorNumero(int numeroConta)
        {
            return _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
        }
    }
}
