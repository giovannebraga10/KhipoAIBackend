namespace KhipoAI.Models
{
    public class Cotacao
    {
        public int Id { get; private set; }
        public int PlanoId { get; private set; }  // Adicionado identificador de plano
        public PlanoCotacao Plano { get; private set; } // Relacionamento com PlanoCotacao
        public string Descricao { get; private set; }
        public decimal Valor { get; set; }
        public decimal Horas { get; private set; }
        public decimal Peso { get; private set; }

        public Cotacao(int planoId, string descricao, decimal peso, decimal horas, decimal valor)
        {
            PlanoId = planoId;  // Relacionando o id do plano
            Descricao = descricao;
            Peso = peso;
            Horas = horas;
            Valor = valor;
        }

        public void AtualizarValor(decimal valor)
        {
            Valor = valor;
        }

        public void AtribuirPlano(PlanoCotacao plano)
        {
            Plano = plano ?? throw new ArgumentNullException(nameof(plano), "Plano de Cotação não pode ser nulo.");
        }

    }
}
