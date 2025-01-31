using KhipoAI.Context;
using KhipoAI.Models;
using KhipoAI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KhipoAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly ICotacaoService _cotacaoService;
        private readonly AppDbContext _context;  // Adicionado para acessar o contexto de dados

        public CotacaoController(ICotacaoService cotacaoService, AppDbContext context)
        {
            _cotacaoService = cotacaoService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotacao>>> GetAll()
        {
            var cotacoes = await _cotacaoService.GetAllAsync();
            return Ok(cotacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cotacao>> GetById(int id)
        {
            var cotacao = await _cotacaoService.GetByIdAsync(id);
            if (cotacao == null)
            {
                return NotFound();
            }
            return Ok(cotacao);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CotacaoRequest request)
        {
            if (request.PlanoId <= 0 || string.IsNullOrEmpty(request.Descricao) || request.Peso <= 0 || request.Horas <= 0)
            {
                return BadRequest("Dados inválidos. PlanoId, Descrição, Peso e Horas devem ser fornecidos e válidos.");
            }

            // Buscar o PlanoCotacao no banco de dados com base no PlanoId
            var plano = await _context.PlanosCotacao.FindAsync(request.PlanoId);

            if (plano == null)
            {
                return BadRequest("Plano não encontrado.");
            }

            // Criar a Cotacao com os dados do request
            var cotacao = new Cotacao(request.PlanoId, request.Descricao, request.Peso, request.Horas, request.Valor);

            // Chamar o serviço para adicionar a cotação
            await _cotacaoService.AddAsync(cotacao);

            return CreatedAtAction(nameof(GetById), new { id = cotacao.Id }, cotacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CotacaoRequest request)
        {
            if (id <= 0 || id != request.PlanoId)
            {
                return BadRequest("ID fornecido não corresponde ao ID da cotação.");
            }

            if (request.Peso <= 0 || request.Horas <= 0)
            {
                return BadRequest("Dados inválidos. Peso e horas devem ser positivos.");
            }

            var plano = await _context.PlanosCotacao.FindAsync(request.PlanoId);

            if (plano == null)
            {
                return BadRequest("Plano não encontrado.");
            }

            var cotacao = new Cotacao(request.PlanoId, request.Descricao, request.Peso, request.Horas, request.Valor);

            await _cotacaoService.UpdateAsync(cotacao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _cotacaoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
