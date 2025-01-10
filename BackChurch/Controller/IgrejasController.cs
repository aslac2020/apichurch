using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class IgrejasController : ControllerBase
    {

        private readonly IIgrejaRepository _igrejaRepository;

        public IgrejasController(IIgrejaRepository igrejaRepository)
        {
            _igrejaRepository = igrejaRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterIgrejas()
        {
            var retorno = await _igrejaRepository.ObterIgrejas();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Erro ao encontrar as igrejas");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterIgrejaPorId(int id)
        {
            var retorno = await _igrejaRepository.ObterIgrejaPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Erro ao encontrar a igreja");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarIgreja(IgrejaRequest request)
        {
            Igrejas igreja = new()
            {
                CodIgreja = request.CodIgreja,
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                IdEndereco = request.IdEndereco,
                Aluguel = request.Aluguel,
                ValorAluguel = request.ValorAluguel,
                DataPagamentoAluguel = request.DataPagamentoAluguel
            };


            var retorno = await _igrejaRepository.CriarIgreja(igreja);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao criar a igreja");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarIgreja(int id)
        {

            var retorno = await _igrejaRepository.DeletarIgreja(id);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao deletar a igreja");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarIgreja(IgrejaRequest request, int id)
        {
            Igrejas igreja = new()
            {
                IdIgreja = id,
                CodIgreja = request.CodIgreja,
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                IdEndereco = request.IdEndereco,
                Aluguel = request.Aluguel,
                ValorAluguel = request.ValorAluguel,
                DataPagamentoAluguel = request.DataPagamentoAluguel
            };


            var retorno = await _igrejaRepository.AtualizarIgreja(igreja);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao atualizar a igreja");
            }
        }

    }
}
