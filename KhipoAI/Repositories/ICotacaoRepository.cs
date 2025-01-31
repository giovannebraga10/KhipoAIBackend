using KhipoAI.Models;

namespace KhipoAI.Repositories
{
    public interface ICotacaoRepository
    {
        Task<Cotacao> GetByIdAsync(int id);
        Task<IEnumerable<Cotacao>> GetAllAsync();
        Task AddAsync(Cotacao cotacao);
        Task UpdateAsync(Cotacao cotacao);
        Task DeleteAsync(int id);
    }
}
