namespace BackChurch.Data.Queries
{
    public class IgrejasSetoresQueries
    {

        public readonly string BuscarIgrejas;
        public readonly string BuscarPorUmaIgreja;
        public readonly string BuscarEnderecoIgrejaPorId;
        public readonly string InserirIgreja;
        public readonly string DeletarIgreja;
        public readonly string AtualizarIgreja;

        public IgrejasSetoresQueries()
        {
            BuscarIgrejas = BuscarTodasIgrejasSetores();
            BuscarPorUmaIgreja = BuscarIgrejasSetoresPorId();
            BuscarEnderecoIgrejaPorId = BuscarEnderecoIgrejaSetor();
            InserirIgreja = InserirIgrejasSetores();
            DeletarIgreja = DeletarUmaIgrejaSetor();
            AtualizarIgreja = AtualizarUmaIgrejaSetor();
        }

        private string BuscarTodasIgrejasSetores()
        {
            return $@"
                SELECT Id_IgrejaSetor AS IdIgrejaSetor,
                       Cod_Igreja AS CodIgreja, 
                       Nome, 
                       Telefone, 
                       Email, 
                       Id_Endereco AS IdEndereco,
                       Id_IgrejaRegional as IdIgrejaRegional,
                       Aluguel, 
                       Valor_Aluguel AS ValorAluguel, 
                       Data_Pagamento_Aluguel AS DataPagamentoAluguel
               FROM IgrejasSetores
            ";
        }

        private string BuscarEnderecoIgrejaSetor()
        {
            return $@"
                SELECT * FROM EnderecoIgrejas WHERE Id_Endereco = @IdEndereco";
        }

        private string InserirIgrejasSetores()
        {
            return $@"
                INSERT INTO IgrejasSetores (Cod_Igreja, Nome, Telefone, Email, Id_Endereco, Aluguel, Valor_Aluguel, Data_Pagamento_Aluguel, Id_IgrejaRegional)
                VALUES (@CodIgreja, @Nome, @Telefone, @Email, @IdEndereco, @Aluguel, @ValorAluguel, @DataPagamentoAluguel, @IdIgrejaRegional)";
        }

        private string BuscarIgrejasSetoresPorId()
        {
            return $@"
                SELECT Id_IgrejaSetor AS IdIgrejaSetor,
                       Cod_Igreja AS CodIgreja, 
                       Nome, 
                       Telefone, 
                       Email, 
                       Id_Endereco AS IdEndereco,
                       Id_IgrejaRegional as IdIgrejaRegional,
                       Aluguel, 
                       Valor_Aluguel AS ValorAluguel, 
                       Data_Pagamento_Aluguel AS DataPagamentoAluguel
               FROM IgrejasSetores 
                WHERE  Id_IgrejaSetor = @IdIgrejaSetor ";
        }


        private string DeletarUmaIgrejaSetor()
        {
            return $@"
                DELETE FROM IgrejasSetores WHERE Id_IgrejaSetor = @IdIgrejaSetor";
        }

        private string AtualizarUmaIgrejaSetor()
        {
            return $@"
                UPDATE IgrejasSetores SET Cod_Igreja = @CodIgreja, Nome = @Nome, Telefone = @Telefone, Email = @Email, 
                Id_Endereco = @IdEndereco, Aluguel = @Aluguel, Valor_Aluguel = @ValorAluguel, 
                Data_Pagamento_Aluguel = @DataPagamentoAluguel, Id_IgrejaRegional = @IdIgrejaRegional
                WHERE Id_IgrejaSetor = @IdIgrejaSetor,
                ";
        }
    }
}
