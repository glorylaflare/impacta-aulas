namespace ContaBancaria;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao sistema de Conta Bancária!");
        Console.WriteLine("------------------------");

        //ContaBancaria contaVini = new ContaBancaria("234", "Vinicius", 4003.34m);
        //ContaBancaria contaMaria = new ContaBancaria("453", "Maria", 2930.23m);

        //contaVini.ExibirSaldo();
        //contaMaria.ExibirSaldo();

        //Console.WriteLine("Operações com ContaCorrente");

        //ContaCorrente cc1 = new ContaCorrente("101", "João Silva", 1000.00m, 500);
        //cc1.ExibirSaldo();
        //cc1.Depositar(500.00m);
        //cc1.ExibirSaldo();

        //Console.WriteLine("\n-----------------------------------------------------\n");

        //Console.WriteLine(">>> Operações em Conta Poupança <<<");
        //ContaPoupanca cp = new ContaPoupanca("CP-001", "José Santos", 5000, 0.05); // 5% de juros
        //cp.ExibirSaldo();
        //cp.Sacar(1000);

        //cp.AdicionarJuros();
        //cp.ExibirSaldo();

        //List<ContaBancaria> listaContas = new List<ContaBancaria>();

        //listaContas.Add(new ContaCorrente("204", "João", 1000, 500));
        //listaContas.Add(new ContaPoupanca("205", "Maria", 2000, 5));

        //var valorSaque = 1300;

        //foreach (var conta in listaContas)
        //{
        //    conta.ExibirSaldo();
        //    conta.Sacar(valorSaque);
        //    conta.ExibirSaldo();
        //    Console.WriteLine("FIM...");
        //}

        ContaCorrente cc2 = new ContaCorrente("CC-001", "João", 1000m, 500);
        ContaPoupanca cp2 = new ContaPoupanca("CP-002", "Maria", 2000m, 5.0);

        var seguro = new SeguroDeVida();

        List<ITributavel> listaTributaveis = new List<ITributavel>();

        listaTributaveis.Add(cc2);
        listaTributaveis.Add(seguro);

        //listaTributaveis.Add(cp2);

        Console.WriteLine("Calculando impostos de todos os tributáveis:");

        double totalImpostos = 0;

        foreach (var item in listaTributaveis)
        {
            double tributadoItem = item.CalcularImposto();
            totalImpostos += tributadoItem;
            Console.WriteLine($"Tributo para o item {item.GetType().Name} : {tributadoItem}");
        }
        Console.WriteLine($"Total de Impostos: {totalImpostos}");
    }
}
