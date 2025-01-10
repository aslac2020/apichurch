using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecosIgrejasController : ControllerBase
    {
        private readonly IEnderecoIgrejasRepository _enderecoIgrejasRepository;
        public EnderecosIgrejasController(IEnderecoIgrejasRepository enderecoIgrejasRepository)
        {
            _enderecoIgrejasRepository = enderecoIgrejasRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterEnderecoIgrejas()
        {
            var retorno = await _enderecoIgrejasRepository.ObterEnderecoIgrejas();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Lista de igrejas não encontrado.");
        }

         [HttpGet("{id}")]
        public async Task<IActionResult> ObterEnderecoIgrejaPorId(int id)
        {
            var retorno = await _enderecoIgrejasRepository.ObterEnderecoIgrejaPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Endereço da igreja não encontrado.");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarEnderecoIgreja(EnderecoIgrejaRequest request)
        {
            EnderecoIgrejas enderecoIgreja = new()
            {
                Cep = request.Cep,
                Logradouro = request.Logradouro,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Estado = request.Estado
            };

            var retorno = await _enderecoIgrejasRepository.CriarEnderecoIgreja(enderecoIgreja);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao criar o endereço da igreja.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEnderecoIgreja(int id)
        {
            var retorno = await _enderecoIgrejasRepository.DeletarEnderecoIgreja(id);

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
        public async Task<IActionResult> AtualizarEnderecoIgreja(EnderecoIgrejaRequest request, int id)
        {
            EnderecoIgrejas enderecoIgreja = new()
            {
                Id_Endereco = id,
                Cep = request.Cep,
                Logradouro = request.Logradouro,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Estado = request.Estado
            };

            var retorno = await _enderecoIgrejasRepository.AtualizarEnderecoIgreja(enderecoIgreja);

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
