namespace BackChurch.Domain
{
    public class Membros
    {
        public int IdMembro { get; set; }
        public string CodMembro { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CPF { get;set;}
        public string? CNPJ { get; set;}
        public string Telefone { get; set; }
        public string EstadoCivil { get; set; }
        public int IdEndereco { get; set; }
        public int IdHistorico { get; set; }
        public int IdIgreja { get; set; }
        public int? IdIgrejaSetor { get; set;}
        public int? IdIgrejaCongregacao { get; set;}
    }


    public partial class MembroCadastroCompleto
    {

        public int IdMembro { get; set; }
        public string CodMembro { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string? CNPJ { get; set; }
        public string Telefone { get; set; }
        public string EstadoCivil { get; set; }
        public int IdEndereco { get; set; }
        public int IdHistorico { get; set; }
        public int IdIgreja { get; set; }
        public int IdIgrejaSetor { get; set; }
        public int IdIgrejaCongregacao { get; set; }
        public EnderecoMembro EnderecoDoMembro { get; set; }
        public IgrejaMembro IgrejaDoMembro { get; set; }
        public HistoricoMinisterialMembro HistoricoMinisterialDoMembro { get; set; }
        public IgrejasDoSetor? IgrejaDoMembroNoSetor { get; set;}
        public IngrejaDeCongregacao? IgrejaDoMembroNaCongregacao { get; set;}


        public class EnderecoMembro
        {
            public int IdEndereco { get; set; }
            public string Cep { get; set; }
            public string Logradouro { get; set; }
            public string Numero { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
        }

        public class IgrejaMembro
        {
            public int IdIgreja { get; set; }
            public string CodIgreja { get; set; }
            public string Nome { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public int IdEndereco { get; set; }
            public bool Aluguel { get; set; }
            public decimal? ValorAluguel { get; set; }
            public Endereco? EnderecoDaIgreja { get; set; }
            public DateTime? DataPagamentoAluguel { get; set; } = null;

        }

        public class HistoricoMinisterialMembro {
            public int IdHistorico { get; set; }
            public string CodHistorico { get; set;}
            public string Cargo { get; set;}
            public bool Obreiro { get;set;}
            public DateTime DataConversao { get; set;}
            public DateTime DataBatismo { get; set;}
            public DateTime DataBatismoEspirito { get; set;}
            public bool Dizimista { get; set;}

        }

        public class IgrejasDoSetor
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

        public class IngrejaDeCongregacao
        {
            public int IdIgrejaCongregacao { get; set; }
            public string CodIgreja { get; set; }
            public string Nome { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public int IdEndereco { get; set; }
            public bool Aluguel { get; set; }
            public decimal? ValorAluguel { get; set; }
            public DateTime? DataPagamentoAluguel { get; set; } = null;
            public int? IdIgrejaSetor{ get; set; }
            public EnderecoCongregacao EnderecoDaIgreja { get; set;}
        }
    }


}
