namespace BackChurch.Domain
{
    public  class IgrejasSetores
    {

        public int IdIgrejaSetor { get; set; }
        public string CodIgreja { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int IdEndereco { get; set; }
        public bool Aluguel { get; set; }
        public decimal? ValorAluguel { get; set; }
        public DateTime? DataPagamentoAluguel { get; set; } = null;
        public int? IdIgrejaRegional { get; set; }
        public EnderecoSetores EnderecoDaIgreja { get; set;}


    }

    public partial class IgrejaSetoresSemEndereco
    {
        public int IdIgrejaSetor { get; set; }
        public string CodIgreja { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int IdEndereco { get; set; }
        public bool Aluguel { get; set; }
        public decimal? ValorAluguel { get; set; }
        public DateTime? DataPagamentoAluguel { get; set; } = null;
        public int? IdIgrejaRegional { get; set; }

    }

    public class EnderecoSetores
    {
        public int Id_Endereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set;}
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get;set;}
        public string Estado { get; set; }


    }
}
