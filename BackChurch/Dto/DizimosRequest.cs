namespace BackChurch.Dto
{
    public class DizimosRequest
    {
        public int IdMembro { get; set; }
        public DateTime DataDizimo { get; set; }
        public Decimal Valor { get; set; }
        public string FormaPagamento { get; set; }
        public string Observacao { get; set; }
    }
}
