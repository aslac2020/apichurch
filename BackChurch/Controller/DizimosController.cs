using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class DizimosController : ControllerBase
    {
        private readonly IDizimoRepository _dizimoRepository;
        public DizimosController(IDizimoRepository dizimoRepository)
        {
            _dizimoRepository = dizimoRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterDizimos()
        {
            var retorno = await _dizimoRepository.ObterDizimos();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Lista de dizimos não encontrado.");
        }

         [HttpGet("{id}")]
        public async Task<IActionResult> ObterDizimoPorId(int id)
        {
            var retorno = await _dizimoRepository.ObterDizimoPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Dizimo não encontrado.");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarDizimo(DizimosRequest request)
        {
            Dizimos dizimo = new()
            {
                IdMembro = request.IdMembro,
                DataDizimo = request.DataDizimo,
                Valor = request.Valor,
                FormaPagamento = request.FormaPagamento,
                Observacao = request.Observacao
            };

            var retorno = await _dizimoRepository.CriarDizimo(dizimo);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao criar o dizimo.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarDizimo(int id)
        {
            var retorno = await _dizimoRepository.DeletarDizimo(id);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao deletar o dizimo.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarDizimo(DizimosRequest request, int id)
        {
            Dizimos dizimo = new()
            {
                IdDizimo = id,
                IdMembro = request.IdMembro,
                DataDizimo = request.DataDizimo,
                Valor = request.Valor,
                FormaPagamento = request.FormaPagamento,
                Observacao = request.Observacao
            };

            var retorno = await _dizimoRepository.AtualizarDizimo(dizimo);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao atualizar o dizimo");
            }
        }


    }
}
