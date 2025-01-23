using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class IgrejasSetoresController : ControllerBase
    {

        private readonly IIgrejasSetoresRepository _igrejaSetoresRepository;

        public IgrejasSetoresController(IIgrejasSetoresRepository igrejaRepository)
        {
            _igrejaSetoresRepository = igrejaRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterIgrejasSetores()
        {
            var retorno = await _igrejaSetoresRepository.ObterIgrejasSetores();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Erro ao encontrar as igrejas dos setores");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterIgrejaSetorPorId(int id)
        {
            var retorno = await _igrejaSetoresRepository.ObterIgrejaSetorPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Erro ao encontrar a igreja do setor");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarIgrejaSetor(IgrejasSetoresRequest request)
        {
            IgrejasSetores igreja = new()
            {
                CodIgreja = request.CodIgreja,
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                IdEndereco = request.IdEndereco,
                Aluguel = request.Aluguel,
                ValorAluguel = request.ValorAluguel,
                DataPagamentoAluguel = request.DataPagamentoAluguel,
                IdIgrejaRegional = request.IdIgrejaRegional
            };


            var retorno = await _igrejaSetoresRepository.CriarIgrejaSetor(igreja);

            if (retorno)
            {
                return Ok("Igreja de setor criada com sucesso");
            }
            else
            {
                return BadRequest("Erro ao criar a igreja setorial");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarIgrejaSetor(int id)
        {

            var retorno = await _igrejaSetoresRepository.DeletarIgrejaSetor(id);

            if (retorno)
            {
                return Ok("Igreja do setor excluida com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao deletar a igreja setorial");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarIgrejaSetor(IgrejasSetoresRequest request, int id)
        {
            IgrejasSetores igreja = new()
            {
                IdIgrejaSetor = id,
                CodIgreja = request.CodIgreja,
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                IdEndereco = request.IdEndereco,
                Aluguel = request.Aluguel,
                ValorAluguel = request.ValorAluguel,
                DataPagamentoAluguel = request.DataPagamentoAluguel,
                IdIgrejaRegional = request.IdIgrejaRegional
            };


            var retorno = await _igrejaSetoresRepository.AtualizarIgrejaSetor(igreja);

            if (retorno)
            {
                return Ok("Igreja do setor atualizada com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao atualizar a igreja setorial");
            }
        }

    }
}
