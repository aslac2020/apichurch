namespace BackChurch.Data.Queries
{
    public class DizimosQueries
    {
        public readonly string BuscarDizimos;
        public readonly string BuscarDizimosPorId;
        public readonly string InserirDizimo;
        public readonly string DeletarDizimo;
        public readonly string AtualizarDizimo;

        public DizimosQueries()
        {
            BuscarDizimos = BuscarPorDizimos();
            BuscarDizimosPorId = BuscarDeterminadoDizimo();
            InserirDizimo = InserirUmDizimo();
            DeletarDizimo = DeletarUmDizimo();
            AtualizarDizimo = AtualizarUmDizimo();
        }

        private string BuscarPorDizimos()
        {
            return $@"
                SELECT 
                    Id_Dizimo AS IdDizimo,
                    Id_Membro AS IdMembro,
                    Valor,
                    Data_Dizimo AS DataDizimo,
                    Forma_Pagamento AS FormaPagamento,
                    Observacao
                FROM Dizimos";
        }

        private string BuscarDeterminadoDizimo()
        {
            return $@"
                SELECT 
                    Id_Dizimo AS IdDizimo,
                    Id_Membro AS IdMembro,
                    Valor,
                    Data_Dizimo AS DataDizimo,
                    Forma_Pagamento AS FormaPagamento,
                    Observacao
                FROM Dizimos WHERE Id_Dizimo = @IdDizimo";
        }

        private string InserirUmDizimo()
        {
            return $@"
                INSERT INTO Dizimos (Id_Membro, Valor, Data_Dizimo, Forma_Pagamento, Observacao)
                VALUES (@IdMembro, @Valor, @DataDizimo, @FormaPagamento, @Observacao )";
        }

        private string DeletarUmDizimo()
        {
            return $@"
                DELETE FROM Dizimos WHERE Id_Dizimo = @IdDizimo";
        }

        private string AtualizarUmDizimo()
        {
            return $@"
                UPDATE Dizimos SET 
                    Id_Membro = @IdMembro,
                    Valor = @Valor,
                    Data_Dizimo = @DataDizimo,
                    Forma_Pagamento = @FormaPagamento,
                    Observacao = @Observacao
                WHERE Id_Dizimo = @IdDizimo";
        }
    }
}
