using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronico.Data
{
    public class ContaRepositorio
    {
        private static readonly Conta _conta = new Conta(12345, 2000.34m);
        
        public Conta GetConta()
        {
            return _conta;
        }
    }
}
