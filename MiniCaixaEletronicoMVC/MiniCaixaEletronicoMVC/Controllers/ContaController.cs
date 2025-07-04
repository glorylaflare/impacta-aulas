using MiniCaixaEletronicoMVC.Models;
using MiniCaixaEletronicoMVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMVC.Controllers
{
    public class ContaController
    {
        private readonly Conta _model;
        private readonly ContaView _view;

        public ContaController()
        {
            _model = new Conta(3000); // Inicializando com um saldo de 1000
            _view = new ContaView(); 
        }

        public void Iniciar()
        { 
            bool continuar = true;
            while(continuar)
            {
                string opcao = _view.ObterOpcaoMenu(_model.Saldo);

                switch(opcao) 
                {
                    case "1":
                        _view.ExibirMensagem($"Seu saldo detalhado é: {_model.Saldo:C}");
                        _view.PausarVoltarAoMenu();
                        break;
                    case "2":
                        decimal ValorDeposito = 1000; // Valor fixo para depósito
                        _model.Depositar(ValorDeposito);
                        break;
                    case "3":
                        decimal ValorSaque = _view.SolicitarValor("Digite o valor do saque:"); // Valor fixo para saque
                        if (_model.Sacar(ValorSaque))
                        {
                            _view.ExibirMensagem($"Saque de {ValorSaque:C} realizado com sucesso!");
                        }
                        else
                        {
                            _view.ExibirMensagem("Saldo insuficiente para realizar o saque.");
                        }
                        break;
                    case "4":
                        _view.ExibirMensagem("Obrigado por usar o Banco CSharp S.A. (MVC)! Até logo!");
                        continuar = false;
                        break;
                    default:
                        _view.ExibirMensagem("Opção inválida. Tente novamente.");
                        break;
                }
            }

            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }
}
