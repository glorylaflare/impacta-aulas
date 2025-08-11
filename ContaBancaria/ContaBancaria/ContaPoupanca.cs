using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria;

public class ContaPoupanca : ContaBancaria
{
    public double TaxaJuros { get; set; }
    private const double TAXA_SAQUE = 2.78;

    // O base é a herança da classe ContaBancaria, similar ao método super()
    public ContaPoupanca(string numero, string titular, decimal saldo, double taxaJuros) : base(numero, titular, saldo)
    {
        TaxaJuros = taxaJuros;
    }

    public void AdicionarJuros()
    {
        decimal juros = Saldo * (decimal) TaxaJuros / 100;
        Saldo += juros;
        Console.WriteLine($"Juros de {TaxaJuros}% adicionados. Novo saldo: {Saldo:C}");
    }

    public override void Sacar(decimal valor)
    {
        Console.WriteLine($"Tentativa de saque, valor: {valor:C} na conta {this.GetType().Name} de {this.Titular}");

        if (valor <= 0)
        {
            Console.WriteLine($"Valor do saque deve ser maior do que 0...");
            return;
        }

        var valorComTaxa = valor + (decimal)TAXA_SAQUE;
        //nova regra de saque
        if (valorComTaxa <= Saldo)
        {
            Saldo -= valorComTaxa;
            Console.WriteLine($"Saque de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para saque, incluindo a taxa de saque.");
        }
    }
}
