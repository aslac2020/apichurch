namespace BackChurch.Data.Queries
{
    public class EnderecoIgrejasQueries
    {
        public readonly string BuscarEnderecoIgrejas;
        public readonly string BuscarEnderecoIgrejaId;
        public readonly string InserirEnderecoIgreja;
        public readonly string DeletarEnderecoIgreja;
        public readonly string AtualizarEnderecoIgreja;

        public EnderecoIgrejasQueries()
        {
            BuscarEnderecoIgrejas = BuscarEnderecoDasIgrejas();
            BuscarEnderecoIgrejaId = BuscarEnderecoDeUmaIgreja();
            InserirEnderecoIgreja = InserirEnderecoDeUmaIgreja();
            DeletarEnderecoIgreja = DeletarEnderecoDeUmaIgreja();
            AtualizarEnderecoIgreja = AtualizarEnderecoDeUmaIgreja();
        }

        private string BuscarEnderecoDasIgrejas()
        {
            return $@"
                SELECT * FROM EnderecoIgrejas";
        }

        private string BuscarEnderecoDeUmaIgreja()
        {
            return $@"
                SELECT * FROM EnderecoIgrejas WHERE Id_Endereco = @IdEndereco"
            ;
        }

        private string InserirEnderecoDeUmaIgreja()
        {
            return $@"
                INSERT INTO EnderecoIgrejas (Cep, Logradouro, Numero, Complemento, Bairro, Cidade, Estado)
                VALUES (@Cep, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado )";
        }

        private string DeletarEnderecoDeUmaIgreja()
        {
            return $@"
                DELETE FROM EnderecoIgrejas WHERE Id_Endereco = @IdEndereco";
        }

        private string AtualizarEnderecoDeUmaIgreja()
        {
            return $@"
                UPDATE EnderecoIgrejas SET Cep = @Cep, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado WHERE Id_Endereco = @Id_Endereco";
        }
    }
}
