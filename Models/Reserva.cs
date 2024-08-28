namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public bool ValidarInformacoes(List<Pessoa> hospedes)
        {

           try
            {
                if (hospedes.Count == 0 || hospedes == null)
                {
                    throw new Exception("Informe as informações dos hóspedes");   
                }


                if (Suite.Capacidade < hospedes.Count)
                {
                    throw new Exception($"A capacidade do apartamento {Suite.TipoSuite} é de {Suite.Capacidade} hóspedes." + 
                                        $" e não comporta o total de {hospedes.Count} hóspedes.");
                }

                return true; 

            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Alerta: {ex.Message}");
                return false;
            }

        }
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {

            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {

            decimal valor = 0;
            double  percentual = 0.1;
            double valorDiaria = 0;

            valor = DiasReservados * Suite.ValorDiaria;


            if (DiasReservados >= 10)
            {
                valorDiaria = Convert.ToDouble(valor);
                valor = Convert.ToDecimal( valorDiaria -  valorDiaria * percentual);
            }

            return valor;
        }
    }
}