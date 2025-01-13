using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricosMinisterialController : ControllerBase
    {
        private readonly IHistoricoMinisterialRepository _historicoMinisterialRepository;

        public HistoricosMinisterialController(IHistoricoMinisterialRepository historicoMinisterial)
        {
            _historicoMinisterialRepository = historicoMinisterial;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterHistoricoMinisterial()
        {
            var retorno = await _historicoMinisterialRepository.ObterHistoricoMinisterial();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Lista de historico não encontrado.");
        }

         [HttpGet("{id}")]
        public async Task<IActionResult> ObterHistoricoMinisterialPorId(int id)
        {
            var retorno = await _historicoMinisterialRepository.ObterHistoricoMinisterialPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Historico ministerial não encontrado.");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarHistoricoMinisterial(HistoricoMinisterialRequest request)
        {
            HistoricoMinisterial historico = new()
            {
               CodHistorico = request.CodHistorico,
               Cargo = request.Cargo,
               DataBatismo = request.DataBatismo,
               DataBatismoEspirito = request.DataBatismoEspirito,
               DataConversao = request.DataConversao,
               Obreiro = request.Obreiro,
               Dizimista = request.Dizimista
            };

            var retorno = await _historicoMinisterialRepository.CriarHistoricoMinisterial(historico);

            if (retorno)
            {
                return Ok("Histórico ministerial criado com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao criar o histórico ministerial.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarHistoricoMinisterial(int id)
        {
            var retorno = await _historicoMinisterialRepository.DeletarHistoricoMinisterial(id);

            if (retorno)
            {
                return Ok("Historico ministerial excluido com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao deletar o histórico.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarHistoricoMinisterial(HistoricoMinisterialRequest request, int id)
        {
            HistoricoMinisterial historico = new()
            {
               IdHistorico = id,
               CodHistorico = request.CodHistorico,
               Cargo = request.Cargo,
               DataBatismo = request.DataBatismo,
               DataBatismoEspirito = request.DataBatismoEspirito,
               DataConversao = request.DataConversao,
               Obreiro = request.Obreiro,
               Dizimista = request.Dizimista
            };

            var retorno = await _historicoMinisterialRepository.AtualizarHistoricoMinisterial(historico);

            if (retorno)
            {
                return Ok("Historico ministerial atualiazado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao atualizar o histórico ministerial");
            }
        }

    }
}
