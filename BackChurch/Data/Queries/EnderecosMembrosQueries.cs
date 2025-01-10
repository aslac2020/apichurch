namespace BackChurch.Data.Queries
{
    public class EnderecosMembrosQueries
    {
        public readonly string BuscarEnderecoMembros;
        public readonly string BuscarEnderecoMembrosId;
        public readonly string InserirEnderecoMembros;
        public readonly string DeletarEnderecoMembros;
        public readonly string AtualizarEnderecoMembros;

        public EnderecosMembrosQueries()
        {
            BuscarEnderecoMembros = BuscarEnderecoDosMembros();
            BuscarEnderecoMembrosId = BuscarEnderecoDeUmMembro();
            InserirEnderecoMembros = InserirEnderecoDeUmMembro();
            DeletarEnderecoMembros = DeletarEnderecoDeUmMembro();
            AtualizarEnderecoMembros = AtualizarEnderecoDeUmMembro();
        }

        private string BuscarEnderecoDosMembros()
        {
            return $@"
                SELECT * FROM EnderecoMembros";
        }

        private string BuscarEnderecoDeUmMembro()
        {
           return $@"
                SELECT * FROM EnderecoMembros WHERE Id_Endereco = @IdEndereco";
        }

        private string InserirEnderecoDeUmMembro()
        {
            return $@"
                INSERT INTO EnderecoMembros (Cep, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES (@Cep, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado)";
        }

        private string DeletarEnderecoDeUmMembro()
        {
            return $@"
                DELETE FROM EnderecoMembros WHERE Id_Endereco = @IdEndereco";
        }

        private string AtualizarEnderecoDeUmMembro()
        {
            return $@"
                UPDATE EnderecoMembros SET Cep = @Cep, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado WHERE Id_Endereco = @Id_Endereco";
        }
    }
}
