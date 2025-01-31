using KhipoAI.Models;

namespace KhipoAI.Services
{
    public interface IPlanoCotacaoService
    {
        Task<IEnumerable<PlanoCotacao>> ListarTodosAsync();
        Task<PlanoCotacao?> BuscarPorIdAsync(int id);
        Task CriarAsync(TipoPlano tipo, string nome, string descricao);
        Task AtualizarAsync(int id, string nome, string descricao);
        Task DeletarAsync(int id);
    }

}
