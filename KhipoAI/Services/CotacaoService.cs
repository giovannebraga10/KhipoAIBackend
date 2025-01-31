using KhipoAI.Models;
using KhipoAI.Repositories;

namespace KhipoAI.Services
{
        public class CotacaoService : ICotacaoService
        {
            private readonly ICotacaoRepository _cotacaoRepository;
            private readonly IPlanoCotacaoRepository _planoCotacaoRepository;

        public CotacaoService(ICotacaoRepository cotacaoRepository, IPlanoCotacaoRepository planoCotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
            _planoCotacaoRepository = planoCotacaoRepository;
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

            var plano = await _planoCotacaoRepository.GetByIdAsync(cotacao.PlanoId);

            if (plano == null)
            {
                throw new Exception("Plano de Cotação inválido.");
            }

            cotacao.AtribuirPlano(plano);

            CalcularValor(cotacao);

            await _cotacaoRepository.AddAsync(cotacao);
        }

            public async Task UpdateAsync(Cotacao cotacao)
            {
                CalcularValor(cotacao);
                await _cotacaoRepository.UpdateAsync(cotacao);
            }

            public async Task DeleteAsync(int id)
            {
                await _cotacaoRepository.DeleteAsync(id);
            }

            
            private decimal CalcularValor(Cotacao cotacao)
            {
                var Valor = cotacao.Valor = cotacao.Peso * (cotacao.Horas * cotacao.Plano.ValorHora);

                return Valor;
            }
        }
   }



