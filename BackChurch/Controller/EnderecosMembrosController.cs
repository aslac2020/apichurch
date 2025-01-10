using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecosMembrosController : ControllerBase
    {
        private readonly IEnderecosMembrosRepository _enderecosMembrosRepository;
        public EnderecosMembrosController(IEnderecosMembrosRepository enderecosMembrosRepository)
        {
            _enderecosMembrosRepository = enderecosMembrosRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterEnderecoIgrejas()
        {
            var retorno = await _enderecosMembrosRepository.ObterEnderecosMembros();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Lista de enderecos não encontrado.");
        }

         [HttpGet("{id}")]
        public async Task<IActionResult> ObterEnderecoIgrejaPorId(int id)
        {
            var retorno = await _enderecosMembrosRepository.ObterEnderecosMembrosPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Endereço não encontrado.");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarEnderecoIgreja(EnderecosMembrosRequest request)
        {
            EnderecosMembros enderecosMembros = new()
            {
                Cep = request.Cep,
                Logradouro = request.Logradouro,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Estado = request.Estado
            };

            var retorno = await _enderecosMembrosRepository.CriarEnderecosMembros(enderecosMembros);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao criar o endereço do membro.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEnderecoIgreja(int id)
        {
            var retorno = await _enderecosMembrosRepository.DeletarEnderecosMembros(id);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao deletar o endereço da igreja.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEnderecoIgreja(EnderecosMembrosRequest request, int id)
        {
            EnderecosMembros enderecosMembros = new()
            {
                IdEndereco = id,
                Cep = request.Cep,
                Logradouro = request.Logradouro,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Estado = request.Estado
            };

            var retorno = await _enderecosMembrosRepository.AtualizarEnderecosMembros(enderecosMembros);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao atualizar o endereço da igreja.");
            }
        }

    }
}
