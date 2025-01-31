using KhipoAI.Context;
using KhipoAI.Models;
using Microsoft.EntityFrameworkCore;

namespace KhipoAI.Repositories
{
    public class PlanoCotacaoRepository : IPlanoCotacaoRepository
    {
        private readonly AppDbContext _context;

        public PlanoCotacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlanoCotacao>> GetAllAsync()
        {
            return await _context.PlanosCotacao.ToListAsync();
        }

        public async Task<PlanoCotacao?> GetByIdAsync(int id)
        {
            return await _context.PlanosCotacao.FindAsync(id);
        }

        public async Task AddAsync(PlanoCotacao planoCotacao)
        {
            await _context.PlanosCotacao.AddAsync(planoCotacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PlanoCotacao planoCotacao)
        {
            _context.PlanosCotacao.Update(planoCotacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plano = await _context.PlanosCotacao.FindAsync(id);
            if (plano != null)
            {
                _context.PlanosCotacao.Remove(plano);
                await _context.SaveChangesAsync();
            }
        }
    }
}
