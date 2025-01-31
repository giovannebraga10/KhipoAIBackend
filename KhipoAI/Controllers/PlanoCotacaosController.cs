using KhipoAI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KhipoAI.Controllers
{
    [ApiController]
    [Route("api/planos")]
    public class PlanoCotacaoController : ControllerBase
    {
        private readonly IPlanoCotacaoService _service;

        public PlanoCotacaoController(IPlanoCotacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var planos = await _service.ListarTodosAsync();
            return Ok(planos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plano = await _service.BuscarPorIdAsync(id);
            if (plano == null) return NotFound();
            return Ok(plano);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlanoCotacaoDto dto)
        {
            await _service.CriarAsync(dto.Nome, dto.Descricao);
            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PlanoCotacaoDto dto)
        {
            await _service.AtualizarAsync(id, dto.Nome, dto.Descricao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }
    }

    public record PlanoCotacaoDto(string Nome, string Descricao);

}
