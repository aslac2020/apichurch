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
    }

    //public partial class MembroCadastroCompleto {

    //    public int IdMembro { get; set; }
    //    public string CodMembro { get; set; }
    //    public string Nome { get; set; }
    //    public DateTime DataNascimento { get; set; }
    //    public string Email { get; set; }
    //    public string CPF { get;set;}
    //    public string? CNPJ { get; set;}
    //    public string Telefone { get; set; }
    //    public string EstadoCivil { get; set; }
    //    public int IdEndereco { get; set; }
    //    public int IdHistorico { get; set; }
    //    public int IdIgreja { get; set; }
    //    public EnderecoMembro EnderecoDoMembro { get; set; }
    //    public IgrejaMembro IgrejaDoMembro { get; set; }


    //    public class EnderecoMembro
    //    {
    //         public int IdEndereco { get; set; }
    //         public string Cep { get; set; }
    //         public string Logradouro { get; set; }
    //         public string Numero { get; set; }
    //         public string Complemento { get; set; }
    //         public string Bairro { get; set; }
    //         public string Cidade { get;set;}
    //         public string Estado { get; set; }
    //    }

    //    public class IgrejaMembro
    //    {

    //    }
        
    
}
