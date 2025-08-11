using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria;

public class SeguroDeVida : ITributavel
{
    public double CalcularImposto()
    {
        return 50.0; // Valor fixo de imposto para o seguro de vida
    }
}
