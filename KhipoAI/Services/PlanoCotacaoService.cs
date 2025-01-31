using KhipoAI.Models;
using KhipoAI.Repositories;

namespace KhipoAI.Services
{

    public class PlanoCotacaoService : IPlanoCotacaoService
    {
        private readonly IPlanoCotacaoRepository _repository;

        public PlanoCotacaoService(IPlanoCotacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlanoCotacao>> ListarTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PlanoCotacao?> BuscarPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CriarAsync(TipoPlano tipo ,string nome, string descricao)
        {
            var plano = new PlanoCotacao(tipo, nome, descricao);
            await _repository.AddAsync(plano);
        }

        public async Task AtualizarAsync(int id, string nome, string descricao)
        {
            var plano = await _repository.GetByIdAsync(id);
            if (plano != null)
            {
                plano.AtualizarDados(nome, descricao); 
                await _repository.UpdateAsync(plano);
            }
        }

        public async Task DeletarAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }



}
