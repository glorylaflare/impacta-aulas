using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria;

public class ContaBancaria
{
    public string Numero { get; set; }
    public string Titular { get; set; }
    public decimal Saldo { get; set; }

    public ContaBancaria(string numero, string titular)
    {
        Numero = numero;
        Titular = titular;
    }

    public ContaBancaria(string numero, string titular, decimal saldo)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldo;
    }

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"Deposito de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
        }
        else
        {
            Console.WriteLine("O valor deve ser positivo.");
        }
    }

    // O virtual serve para liberar o método para alteração, utilizando Polimorfismo
    public virtual void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor deve ser positivo...");
        }
        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para operação...");
        }

        Saldo -= valor;
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual : {Saldo:C}");
    }
}
