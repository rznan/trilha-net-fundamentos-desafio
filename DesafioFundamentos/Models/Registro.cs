using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Registro
    {
        private string placa { get; set; }
        private decimal valor { get; set; }

        public string Placa { get => placa; }
        public decimal Valor { get => valor; }

        public Registro(string placa, decimal valor)
        {
            this.placa = placa;
            this.valor = valor;
        }

    }
}