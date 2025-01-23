namespace BackChurch.Data.Queries
{
    public class IgrejaQueries
    {

        public readonly string BuscarIgrejas;
        public readonly string BuscarPorUmaIgreja;
        public readonly string BuscarEnderecoIgrejaPorId;
        public readonly string InserirIgreja;
        public readonly string DeletarIgreja;
        public readonly string AtualizarIgreja;

        public IgrejaQueries()
        {
            BuscarIgrejas = BuscarTodasIgrejas();
            BuscarPorUmaIgreja = BuscarIgrejasPorId();
            BuscarEnderecoIgrejaPorId = BuscarEnderecoIgreja();
            InserirIgreja = InserirIgrejas();
            DeletarIgreja = DeletarUmaIgreja();
            AtualizarIgreja = AtualizarUmaIgreja();
        }

        private string BuscarTodasIgrejas()
        {
            return $@"
                SELECT Id_Igreja AS IdIgreja,
                       Cod_Igreja AS CodIgreja, 
                       Nome, 
                       Telefone, 
                       Email, 
                       Id_Endereco AS IdEndereco, 
                       Aluguel, 
                       Valor_Aluguel AS ValorAluguel, 
                       Data_Pagamento_Aluguel AS DataPagamentoAluguel,
                       Id_IgrejaSetor AS IdIgrejaSetor
               FROM Igrejas
            ";
        }

        private string BuscarEnderecoIgreja()
        {
            return $@"
                SELECT * FROM EnderecoIgrejas WHERE Id_Endereco = @IdEndereco";
        }

        private string InserirIgrejas()
        {
            return $@"
                INSERT INTO Igrejas (Cod_Igreja, Nome, Telefone, Email, Id_Endereco, Aluguel, Valor_Aluguel, Data_Pagamento_Aluguel, Id_Igreja_Setor)
                VALUES (@CodIgreja, @Nome, @Telefone, @Email, @IdEndereco, @Aluguel, @ValorAluguel, @DataPagamentoAluguel, @IdIgrejaSetor)";
        }

        private string BuscarIgrejasPorId()
        {
            return $@"
                SELECT Id_Igreja AS IdIgreja,
                       Cod_Igreja AS CodIgreja, 
                       Nome, 
                       Telefone, 
                       Email, 
                       Id_Endereco AS IdEndereco, 
                       Aluguel, 
                       Valor_Aluguel AS ValorAluguel, 
                       Data_Pagamento_Aluguel AS DataPagamentoAluguel,
                       Id_IgrejaSetor AS IdIgrejaSetor
               FROM Igrejas 
                WHERE  Id_Igreja = @IdIgreja ";
        }


        private string DeletarUmaIgreja()
        {
            return $@"
                DELETE FROM Igrejas WHERE Id_Igreja = @IdIgreja";
        }

        private string AtualizarUmaIgreja()
        {
            return $@"
                UPDATE Igrejas SET Cod_Igreja = @CodIgreja, Nome = @Nome, Telefone = @Telefone, Email = @Email, 
                Id_Endereco = @IdEndereco, Aluguel = @Aluguel, Valor_Aluguel = @ValorAluguel, 
                Data_Pagamento_Aluguel = @DataPagamentoAluguel Id_Igreja_Setor = @IdIgrejaSetor
                WHERE Id_Igreja = @IdIgreja,
                ";
        }
    }
}
