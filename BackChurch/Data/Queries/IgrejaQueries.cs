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
                       Data_Pagamento_Aluguel AS DataPagamentoAluguel
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
                INSERT INTO Igrejas (Cod_Igreja, Nome, Telefone, Email, Id_Endereco, Aluguel, Valor_Aluguel, Data_Pagamento_Aluguel)
                VALUES (@CodIgreja, @Nome, @Telefone, @Email, @IdEndereco, @Aluguel, @ValorAluguel, @DataPagamentoAluguel)";
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
                       Data_Pagamento_Aluguel AS DataPagamentoAluguel
               FROM Igrejas 
                WHERE  Id_Igreja = @IdIgreja ";
        }


        //   private string BuscarIgrejasPorId()
        //{
        //    return $@"
        //       SELECT i.Id_Igreja AS IdIgreja,
        //               i.Cod_Igreja AS CodIgreja, 
        //               i.Nome, 
        //               i.Telefone, 
        //               i.Email, 
        //               i.Aluguel, 
        //               i.Valor_Aluguel AS ValorAluguel, 
        //               i.Data_Pagamento_Aluguel AS DataPagamentoAluguel,
        //               e.Id_Endereco AS IdEndereco,
        //               e.Cep,
        //               e.Logradouro,
        //               e.Numero,
        //               e.Complemento,
        //               e.Bairro,
        //               e.Cidade,
        //               e.Estado
        //       FROM Igrejas i 
        //       LEFT JOIN EnderecoIgrejas e ON i.Id_Endereco = e.Id_Endereco
        //        WHERE  i.Id_Igreja = @IdIgreja ";
        //}

        private string DeletarUmaIgreja()
        {
            return $@"
                DELETE FROM Igrejas WHERE Id_Igreja = @IdIgreja";
        }

        private string AtualizarUmaIgreja()
        {
            return $@"
                UPDATE Igrejas SET Cod_Igreja = @CodIgreja, Nome = @Nome, Telefone = @Telefone, Email = @Email, Id_Endereco = @IdEndereco, Aluguel = @Aluguel, Valor_Aluguel = @ValorAluguel, Data_Pagamento_Aluguel = @DataPagamentoAluguel WHERE Id_Igreja = @IdIgreja";
        }
    }
}
