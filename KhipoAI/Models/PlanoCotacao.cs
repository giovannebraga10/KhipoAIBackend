namespace KhipoAI.Models
{

    public class PlanoCotacao
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        
        private PlanoCotacao() { }

        public PlanoCotacao(string nome, string descricao)
        {
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
