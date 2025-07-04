using MiniCaixaEletronicoMultiplas.Data;
using MiniCaixaEletronicoMultiplas.Models;
using MiniCaixaEletronicoMultiplas.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMultiplas.Controllers
{
    public class ContaController
    {
        private readonly Conta _model;
        private readonly ContaView _view;
        private readonly ContaRepositorio _repositorio;

        public ContaController()
        {
            _repositorio = new ContaRepositorio();
            _view = new ContaView();
        }

        public void Iniciar()
        {
            while (true)
            {
                int numeroConta = _view.SolicitarNumeroConta();
                Conta contaLogada = _repositorio.BuscaContaPorNumero(numeroConta);
                if (contaLogada != null)
                {
                    ExecutarMenuDaConta(contaLogada);
                }
                else if (numeroConta == 0)
                {
                    Console.WriteLine("Saindo...");
                    break;
                }
                else
                {
                    _view.ExibirMensagem("Conta não encontrada");
                    _view.PausarEVoltarAoMenu();
                }
            }
        }

        private void ExecutarMenuDaConta(Conta conta)
        {
            bool continuar = true;
            while (continuar)
            {
                string opcao = _view.ObterOpcaoDoMenu(conta.NomeTitular, conta.Saldo);

                switch (opcao)
                {
                    case "1":
                        _view.ExibirMensagem($"Seu saldo detalhado é: {conta.Saldo:C}");
                        break;

                    case "2":
                        var valorDeposito = _view.SolicitarValor("Digite o valor do depósito: ");
                        _model.Depositar(valorDeposito);
                        _view.ExibirMensagem("Depósito realizado com sucesso!");
                        break;

                    case "3":
                        var valorSaque = _view.SolicitarValor("Digite o valor do saque: ");
                        bool sucesso = _model.Sacar(valorSaque);
                        if (sucesso)
                        {
                            _view.ExibirMensagem("Saque realizado com sucesso!");
                        }
                        else
                        {
                            _view.ExibirMensagem("Operação falhou. Verifique o valor digitado ou seu saldo.");
                        }
                        break;

                    case "4":
                        continuar = false;
                        _view.ExibirMensagem("Obrigado por usar nossos serviços. Volte sempre!");
                        break;

                    default:
                        _view.ExibirMensagem("Opção inválida. Tente novamente.");
                        break;
                }

                if (continuar)
                {
                    _view.PausarEVoltarAoMenu();
                }
            }
        }
    }
}
