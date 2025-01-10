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
    }
}
