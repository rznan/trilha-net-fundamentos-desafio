
using System.Diagnostics.Contracts;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            string placa = string.Empty;
            while(true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa = Console.ReadLine();
                if(ValidarPlaca(placa)) break;
                Console.WriteLine("A placa informada é inválida. Siga o padrão LLLNLNN\n" +
                                  "L - letra; N - Número");
            }
            veiculos.Add(placa);
        }

        private static bool ValidarPlaca(string placa)
        {
            bool isValid = true;
            string regraPadraoPlaca = "LLL0L00";
            if(!(placa.Length == 7))
            {
                isValid = false;
            }
            else
            {
                for(int i = 0; i < placa.Length; i++)
                {  
                    // checa se a placa esta de acordo com o padrão
                    if(!(char.IsLetter(placa[i]) == char.IsLetter(regraPadraoPlaca[i])))
                    {
                        isValid = false;
                        break;
                    }
                    if(!(char.IsDigit(placa[i]) == char.IsDigit(regraPadraoPlaca[i])))
                    {
                        isValid = false;
                        break;
                    }
                }           
            }
            return isValid;
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                int.TryParse(Console.ReadLine(), out int horas);
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                // Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Realizar um laço de repetição, exibindo os veículos estacionados
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
