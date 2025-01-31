namespace KhipoAI.Models
{
    public class Cotacao
    {
        public int Id { get; private set; }
        public PlanoCotacao Plano { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public decimal Horas { get; private set; }
        public decimal Peso { get; private set; }
    }
}
