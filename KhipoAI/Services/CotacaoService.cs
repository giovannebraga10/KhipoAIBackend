using KhipoAI.Models;
using KhipoAI.Repositories;

namespace KhipoAI.Services
{
    public class CotacaoService : ICotacaoService
    {
        private readonly ICotacaoRepository _cotacaoRepository;

        public CotacaoService(ICotacaoRepository cotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
        }

        public async Task<IEnumerable<Cotacao>> GetAllAsync()
        {
            return await _cotacaoRepository.GetAllAsync();
        }

        public async Task<Cotacao> GetByIdAsync(int id)
        {
            return await _cotacaoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Cotacao cotacao)
        {
            await _cotacaoRepository.AddAsync(cotacao);
        }

        public async Task UpdateAsync(Cotacao cotacao)
        {
            await _cotacaoRepository.UpdateAsync(cotacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _cotacaoRepository.DeleteAsync(id);
        }
    }
}

