using MiniCaixaEletronicoMultiplas.Controllers;

namespace MiniCaixaEletronicoMultiplas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Cria o maestro (o Controller)
            var controlador = new ContaController();

            // 2. Dá o comando para ele começar a reger a orquestra.
            controlador.Iniciar();

        }
    }
}
