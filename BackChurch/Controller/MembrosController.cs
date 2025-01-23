using BackChurch.Domain;
using BackChurch.Dto;
using BackChurch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackChurch.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MembrosController : ControllerBase
    {

        private readonly IMembrosRepository _membrosRepository;

        public MembrosController(IMembrosRepository membrosRepository)
        {
            _membrosRepository = membrosRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterIgrejas()
        {
            var retorno = await _membrosRepository.ObterMembros();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest("Erro ao encontrar os membros");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterIgrejaPorId(int id)
        {
            var retorno = await _membrosRepository.ObterMembroPorId(id);
            return retorno != null ? Ok(retorno) : BadRequest("Erro ao encontrar o membro");
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarIgreja(MembrosRequest request)
        {
            Membros membro = new()
            {
                CodMembro = request.CodMembro,
                Nome = request.Nome,
                CPF = request.CPF,
                CNPJ = request?.CNPJ,
                Telefone = request.Telefone,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                EstadoCivil = request.EstadoCivil,
                IdEndereco = request.IdEndereco,
                IdHistorico = request.IdHistorico,
                IdIgreja = request.IdIgreja,
                IdIgrejaSetor = request?.IdIgrejaSetor,
                IdIgrejaCongregacao = request?.IdIgrejaCongregacao
            };


            var retorno = await _membrosRepository.CriarMembro(membro);

            if (retorno)
            {
                return Ok("Membro cadastrado com sucesso!");
            }
            else
            {
                return BadRequest("Erro ao criar o membro");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarIgreja(int id)
        {

            var retorno = await _membrosRepository.DeletarMembro(id);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao deletar o membro");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarIgreja(MembrosRequest request, int id)
        {
              Membros membro = new()
              {
                IdMembro = id,
                CodMembro = request.CodMembro,
                Nome = request.Nome,
                CPF = request.CPF,
                CNPJ = request?.CNPJ,
                Telefone = request.Telefone,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                EstadoCivil = request.EstadoCivil,
                IdEndereco = request.IdEndereco,
                IdHistorico = request.IdHistorico,
                IdIgreja = request.IdIgreja,
                IdIgrejaSetor = request?.IdIgrejaSetor,
                IdIgrejaCongregacao = request?.IdIgrejaCongregacao
              };


            var retorno = await _membrosRepository.AtualizarMembro(membro);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao atualizar o membro");
            }
        }

    }
}
