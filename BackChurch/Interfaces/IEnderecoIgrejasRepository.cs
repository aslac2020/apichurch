using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IEnderecoIgrejasRepository
    {
        Task<bool> CriarEnderecoIgreja(EnderecoIgrejas enderecoIgrejas);
        Task<bool> AtualizarEnderecoIgreja(EnderecoIgrejas enderecoIgrejas);
        Task<bool> DeletarEnderecoIgreja(int id);
        Task<IList<EnderecoIgrejas>> ObterEnderecoIgrejas();
        Task<EnderecoIgrejas> ObterEnderecoIgrejaPorId(int id);
    }
}
