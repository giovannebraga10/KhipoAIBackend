namespace KhipoAI.Models
{

    public class PlanoCotacao
    {
        public int Id { get; set; }
        public TipoPlano Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public decimal ValorHora
        {
            get
            {
                return Tipo switch
                {
                    TipoPlano.Basic => 50,
                    TipoPlano.Pro => 100,
                    TipoPlano.Premium => 150,
                    _ => 0
                };
            }
        }

        public PlanoCotacao(TipoPlano tipo, string nome, string descricao)
        {
            Tipo = tipo;
            Nome = nome;
            Descricao = descricao;
        }
        public void AtualizarDados(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }


}
