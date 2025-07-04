using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMVC.Models
{
    public class Conta
    {
        public decimal Saldo { get; set; }

        public Conta(decimal saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");
            }
            Saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do saque deve ser maior que zero.");
            }
            if (valor > Saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");
            }
            Saldo -= valor;
            return true;
        }
    }
}
