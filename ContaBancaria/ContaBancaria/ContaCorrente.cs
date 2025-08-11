using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria;

public class ContaCorrente : ContaBancaria, ITributavel
{
    public double LimiteChequeEspecial { get; private set; }

    // O construtor apenas repassa os dados para o construtor da classe-mãe.
    public ContaCorrente(string numero, string titular, decimal saldo, double limiteChequeEspecial)
        : base(numero, titular, saldo)
    {
        // O corpo do construtor pode ficar vazio se não houver inicialização extra.
        LimiteChequeEspecial = limiteChequeEspecial;
    }

    public override void Sacar(decimal valor)
    {
        Console.WriteLine($"Tentativa de saque valor: {valor:c} na conta {this.GetType().Name} de {Titular}");
        if (valor <= 0)
        {
            Console.WriteLine("Valor de saque inválido!");
            return;
        }
        if (valor > Saldo + (decimal)LimiteChequeEspecial)
        {
            Console.WriteLine("Saldo insuficiente, incluindo o cheque especial.");
            return;
        }
        Saldo -= valor;
        if (Saldo < 0)
        {
            LimiteChequeEspecial -= (double)(-Saldo);
            Saldo = 0;
        }
        Console.WriteLine($"Saque de {valor:c} realizado com sucesso! Saldo atual: {this.Saldo} , limite cheque especial : {this.LimiteChequeEspecial}");
    }

    public double CalcularImposto()
    {
        return (double)Saldo * 0.02;
    }
}
