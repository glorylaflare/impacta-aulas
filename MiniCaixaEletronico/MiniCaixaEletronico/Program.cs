using MiniCaixaEletronico.Business;

namespace MiniCaixaEletronico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaService contaService = new ContaService();
            string nome = "Marcelo";
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao Mini Caixa Eletrônico!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Bem vindo {nome}! O seu saldo é {contaService.VerSaldo().ToString("C")}.");
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Consultar Saldo");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Depositar");
                Console.WriteLine("4 - Sair");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao) {
                    case "4":
                        continuar = false;
                        Console.WriteLine("Obrigado por usar o Mini Caixa Eletrônico! Até logo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        continue;
                }
            }
        }
    }
}
