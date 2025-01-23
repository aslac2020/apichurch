namespace BackChurch.Dto
{
    public class IgrejasSetoresRequest
    {
        public string CodIgreja { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int IdEndereco { get; set; }
        public bool Aluguel { get; set; }
        public decimal? ValorAluguel { get; set; }
        public DateTime? DataPagamentoAluguel { get; set; } = null;
        public int? IdIgrejaRegional { get; set;}

    }
}
