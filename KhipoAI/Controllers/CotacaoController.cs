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

        public CotacaoController(ICotacaoService cotacaoService)
        {
            _cotacaoService = cotacaoService;
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
        public async Task<ActionResult> Add([FromBody] Cotacao cotacao)
        {
            await _cotacaoService.AddAsync(cotacao);
            return CreatedAtAction(nameof(GetById), new { id = cotacao.Id }, cotacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Cotacao cotacao)
        {
            if (id != cotacao.Id)
            {
                return BadRequest();
            }

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
