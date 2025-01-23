namespace BackChurch.Data.Queries
{
    public class IgrejasCongregacionaisQueries
    {

        public readonly string BuscarIgrejas;
        public readonly string BuscarPorUmaIgreja;
        public readonly string BuscarEnderecoIgrejaPorId;
        public readonly string InserirIgreja;
        public readonly string DeletarIgreja;
        public readonly string AtualizarIgreja;

        public IgrejasCongregacionaisQueries()
        {
            BuscarIgrejas = BuscarTodasIgrejasCongregacao();
            BuscarPorUmaIgreja = BuscarIgrejasCongregacaoPorId();
            BuscarEnderecoIgrejaPorId = BuscarEnderecoIgrejaCongregacao();
            InserirIgreja = InserirIgrejasCongregacao();
            DeletarIgreja = DeletarUmaIgrejaCongregacao();
            AtualizarIgreja = AtualizarUmaIgrejaCongregacao();
        }

        private string BuscarTodasIgrejasCongregacao()
        {
            return $@"
                SELECT Id_IgrejaCongregacao AS IdIgrejaCongregacao,
                       Cod_Igreja AS CodIgreja, 
                       Nome, 
                       Telefone, 
                       Email, 
                       Id_Endereco AS IdEndereco,
                       Id_IgrejaSetor as IdIgrejaSetor,
                       Aluguel, 
                       Valor_Aluguel AS ValorAluguel, 
                       Data_Pagamento_Aluguel AS DataPagamentoAluguel
               FROM IgrejasCongregacionais
            ";
        }

        private string BuscarEnderecoIgrejaCongregacao()
        {
            return $@"
                SELECT * FROM EnderecoIgrejas WHERE Id_Endereco = @IdEndereco";
        }

        private string InserirIgrejasCongregacao()
        {
            return $@"
                INSERT INTO IgrejasCongregacionais (Cod_Igreja, Nome, Telefone, Email, Id_Endereco, Aluguel, Valor_Aluguel, Data_Pagamento_Aluguel, Id_IgrejaSetor)
                VALUES (@CodIgreja, @Nome, @Telefone, @Email, @IdEndereco, @Aluguel, @ValorAluguel, @DataPagamentoAluguel, @IdIgrejaSetor)";
        }

        private string BuscarIgrejasCongregacaoPorId()
        {
            return $@"
                SELECT Id_IgrejaCongregacao AS IdIgrejaCongregacao,
                       Cod_Igreja AS CodIgreja, 
                       Nome, 
                       Telefone, 
                       Email, 
                       Id_Endereco AS IdEndereco,
                       Id_IgrejaSetor as IdIgrejaSetor,
                       Aluguel, 
                       Valor_Aluguel AS ValorAluguel, 
                       Data_Pagamento_Aluguel AS DataPagamentoAluguel
               FROM IgrejasCongregacionais 
                WHERE  Id_IgrejaCongregacao = @IdIgrejaCongregacao ";
        }


        private string DeletarUmaIgrejaCongregacao()
        {
            return $@"
                DELETE FROM IgrejasCongregacionais WHERE Id_IgrejaCongregacao = @IdIgrejaCongregacao";
        }

        private string AtualizarUmaIgrejaCongregacao()
        {
            return $@"
                UPDATE IgrejasCongregacionais SET Cod_Igreja = @CodIgreja, Nome = @Nome, Telefone = @Telefone, Email = @Email, 
                Id_Endereco = @IdEndereco, Aluguel = @Aluguel, Valor_Aluguel = @ValorAluguel, 
                Data_Pagamento_Aluguel = @DataPagamentoAluguel, Id_IgrejaSetor= @IdIgrejaSetor
                WHERE  Id_Congregacao = @IdIgrejaCongregacao,
                ";
        }
    }
}
