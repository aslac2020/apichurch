namespace BackChurch.Domain
{
    public class Dizimos
    {
        public int IdDizimo { get; set; }
        public int IdMembro { get; set; }
        public DateTime DataDizimo { get; set; }
        public Decimal Valor { get; set; }
        public string FormaPagamento { get; set; }
        public string Observacao { get; set; }
        public RelatorioDizimoMembro DizimoDoMembro { get; set;}
    }

    public class RelatorioDizimoMembro
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

    }


}
