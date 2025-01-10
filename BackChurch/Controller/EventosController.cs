using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventosController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterEventos()
        {
            var retorno = await _eventoRepository.ObterEventos();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Erro ao encontrar os eventos");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterEventoPorId(int id)
        {
            var retorno = await _eventoRepository.ObterEventoPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Erro ao encontrar um evento");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarEvento(EventoRequest request)
        {
            Eventos evento = new()
            {
                 CodEvento = request.CodEvento,
                 Nome = request.Nome,
                 LocalEvento = request.LocalEvento,
                 DataEvento = request.DataEvento,
                 Descricao = request.Descricao
               
            };

            var retorno = await _eventoRepository.CriarEvento(evento);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao criaro o evento");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarIgreja(int id)
        {

            var retorno = await _eventoRepository.DeletarEvento(id);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao deletar o evento");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarIgreja(EventoRequest request, int id)
        {
             Eventos evento = new()
             {
                 IdEvento = id,
                 CodEvento = request.CodEvento,
                 Nome = request.Nome,
                 LocalEvento = request.LocalEvento,
                 DataEvento = request.DataEvento,
                 Descricao = request.Descricao
               
             };


            var retorno = await _eventoRepository.AtualizarEvento(evento);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao atualizar o evento");
            }
        }


    }
}
