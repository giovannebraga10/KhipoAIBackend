using KhipoAI.Context;
using KhipoAI.Models;
using Microsoft.EntityFrameworkCore;

namespace KhipoAI.Repositories
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly AppDbContext _context;

        public CotacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cotacao> GetByIdAsync(int id)
        {
            return await _context.Cotacoes.FindAsync(id);
        }

        public async Task<IEnumerable<Cotacao>> GetAllAsync()
        {
            return await _context.Cotacoes.ToListAsync();
        }

        public async Task AddAsync(Cotacao cotacao)
        {
            await _context.Cotacoes.AddAsync(cotacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cotacao cotacao)
        {
            _context.Cotacoes.Update(cotacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cotacao = await GetByIdAsync(id);
            if (cotacao != null)
            {
                _context.Cotacoes.Remove(cotacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
