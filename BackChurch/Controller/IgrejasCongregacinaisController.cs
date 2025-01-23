using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class IgrejasCongregacionaisController : ControllerBase
    {

        private readonly IIgrejasCongregacionaisRepository _igrejasCongregacionaisRepository;

        public IgrejasCongregacionaisController(IIgrejasCongregacionaisRepository igrejasCongregacionaisRepository)
        {
            _igrejasCongregacionaisRepository = igrejasCongregacionaisRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterIgrejasCongregacaos()
        {
            var retorno = await _igrejasCongregacionaisRepository.ObterIgrejasCongregacaos();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Erro ao encontrar as congregações");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterIgrejaCongregacaoPorId(int id)
        {
            var retorno = await _igrejasCongregacionaisRepository.ObterIgrejaCongregacaoPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Erro ao encontrar a congregação");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarIgrejaCongregacao(IgrejasCongregacionaisRequest request)
        {
            IgrejasCongregacionais igreja = new()
            {
                CodIgreja = request.CodIgreja,
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                IdEndereco = request.IdEndereco,
                Aluguel = request.Aluguel,
                ValorAluguel = request.ValorAluguel,
                DataPagamentoAluguel = request.DataPagamentoAluguel,
                IdIgrejaSetor = request.IdIgrejaSetor
            };


            var retorno = await _igrejasCongregacionaisRepository.CriarIgrejaCongregacao(igreja);

            if (retorno)
            {
                return Ok("Congregação criada com sucesso !");
            }
            else
            {
                return BadRequest("Erro ao criar a congregação");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarIgrejaCongregacao(int id)
        {

            var retorno = await _igrejasCongregacionaisRepository.DeletarIgrejaCongregacao(id);

            if (retorno)
            {
                return Ok("Congregação excluida com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao deletar a congregação");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarIgrejaCongregacao(IgrejasCongregacionaisRequest request, int id)
        {
            IgrejasCongregacionais igreja = new()
            {
                IdIgrejaCongregacao = id,
                CodIgreja = request.CodIgreja,
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                IdEndereco = request.IdEndereco,
                Aluguel = request.Aluguel,
                ValorAluguel = request.ValorAluguel,
                DataPagamentoAluguel = request.DataPagamentoAluguel,
                IdIgrejaSetor = request.IdIgrejaSetor
            };


            var retorno = await _igrejasCongregacionaisRepository.AtualizarIgrejaCongregacao(igreja);

            if (retorno)
            {
                return Ok("Congregação atualizada com sucesso");
            }
            else
            {
                return BadRequest("Erro ao atualizar a congregação");
            }
        }

    }
}
