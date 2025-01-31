namespace KhipoAI.Models
{
    public class CotacaoRequest
    {
        public int PlanoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Horas { get; set; }
        public decimal Peso { get; set; }
    }
}
