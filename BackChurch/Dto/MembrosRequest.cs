namespace BackChurch.Dto
{
    public class MembrosRequest
    {
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
    }
}
