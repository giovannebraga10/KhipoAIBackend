using KhipoAI.Models;

namespace KhipoAI.Repositories
{
    public interface IPlanoCotacaoRepository
    {
        Task<IEnumerable<PlanoCotacao>> GetAllAsync();
        Task<PlanoCotacao?> GetByIdAsync(int id);
        Task AddAsync(PlanoCotacao planoCotacao);
        Task UpdateAsync(PlanoCotacao planoCotacao);
        Task DeleteAsync(int id);
    }
}
