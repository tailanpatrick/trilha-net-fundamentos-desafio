using DesafioFundamentos.Models;

namespace DesafioFundamentos.Models {
    public class Estacionamento {
        private decimal precoInicial = 0;
        private decimal precoPorMinuto = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorMinuto) {
            this.precoInicial = precoInicial;
            this.precoPorMinuto = precoPorMinuto;
        }

        public void AdicionarVeiculo() {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine();

            Veiculo veiculo = new Veiculo(placa);

            veiculos.Add(veiculo);

            Console.WriteLine($"Veículo de placa: {placa} foi adicionado com sucesso!");
        }

        public void RemoverVeiculo() {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            Veiculo veiculoEncontrado = veiculos.FirstOrDefault(v => v.Placa.ToUpper() == placa.ToUpper());

            if (veiculoEncontrado != null) {
                (string placaRemovida, TimeSpan tempoEstadia) = veiculoEncontrado.removerVeiculo();

                int totalMinutos = (int)Math.Ceiling(tempoEstadia.TotalMinutes);

                int minutos = tempoEstadia.Minutes;
                int segundos = tempoEstadia.Seconds;

                decimal precoTotal = precoInicial + (totalMinutos * precoPorMinuto);

                veiculos.Remove(veiculoEncontrado);

                Console.WriteLine($"O veículo {veiculoEncontrado.Placa} foi removido e o preço total foi de: R$ {precoTotal}");
                Console.WriteLine($"Tempo total de estadia: {totalMinutos} minuto(s)");
            }
            else {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos() {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any()) {
                Console.WriteLine("------Os veículos estacionados são:-------");
                veiculos.ForEach(veiculo => {
                    TimeSpan estadia = veiculo.TempoEstacionado;
                    int minutos = estadia.Minutes;
                    int segundos = estadia.Seconds;
                    Console.WriteLine($"     {veiculo.Placa} - com tempo estacionado de: {minutos}:{segundos} min:sec");
                });
                Console.WriteLine();
            }
            else {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
