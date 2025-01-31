using KhipoAI.Models;

namespace KhipoAI.Services
{
    public interface ICotacaoService
    {
        Task<IEnumerable<Cotacao>> GetAllAsync();
        Task<Cotacao> GetByIdAsync(int id);
        Task AddAsync(Cotacao cotacao);
        Task UpdateAsync(Cotacao cotacao);
        Task DeleteAsync(int id);
    }
}
