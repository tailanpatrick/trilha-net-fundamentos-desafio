using System.Diagnostics;

namespace DesafioFundamentos.Models {
    public class Veiculo {
        public string Placa { get; private set; }
        private Stopwatch CronometroEstadia;

        public TimeSpan TempoEstacionado => CronometroEstadia.Elapsed;

        public Veiculo(string placa) {
            this.Placa = placa;
            this.CronometroEstadia = new Stopwatch();
            this.CronometroEstadia.Start();
        }

        public (string placa, TimeSpan tempoEstadia) removerVeiculo() {
            this.CronometroEstadia.Stop();
            return (this.Placa, this.CronometroEstadia.Elapsed);
        }
    }

}