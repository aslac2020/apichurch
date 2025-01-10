using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class FrequenciasController : ControllerBase
    {
        private readonly IFrequenciaRepository _frequenciaRepository;
        public FrequenciasController(IFrequenciaRepository frequenciaRepository)
        {
            _frequenciaRepository = frequenciaRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterEnderecoIgrejas()
        {
            var retorno = await _frequenciaRepository.ObterFrequencias();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Lista de frequências não encontrada.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterEnderecoIgrejaPorId(int id)
        {
            var retorno = await _frequenciaRepository.ObterFrequenciaPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Frequência não encontrada.");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarEnderecoIgreja(FrequenciaRequest request)
        {
            Frequencia frequencia = new()
            {
                CodFrequencia = request.CodFrequencia,
                DataFrequencia = request.DataFrequencia,
                IdMembro = request.IdMembro,
                IdEvento = request.IdEvento,
                Presenca = request.Presenca
                              
            };

            var retorno = await _frequenciaRepository.CriarFrequencia(frequencia);

            if (retorno)
            {
                return Ok("Frequência criada com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao criar uma frequência.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEnderecoIgreja(int id)
        {
            var retorno = await _frequenciaRepository.DeletarFrequencia(id);

            if (retorno)
            {
                return Ok("Frequência excluida com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao deletar uma frequência.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEnderecoIgreja(FrequenciaRequest request, int id)
        {
            Frequencia frequencia = new()
            {
                IdFrequencia = id,
                CodFrequencia = request.CodFrequencia,
                DataFrequencia = request.DataFrequencia,
                IdMembro = request.IdMembro,
                IdEvento = request.IdEvento,
                Presenca = request.Presenca
                              
            };

            var retorno = await _frequenciaRepository.AtualizarFrequencia(frequencia);

            if (retorno)
            {
                return Ok("Frequência atualizada com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao atualizar uma frequência.");
            }
        }
    }
}
