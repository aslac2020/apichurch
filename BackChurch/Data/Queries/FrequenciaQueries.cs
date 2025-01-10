namespace BackChurch.Data.Queries
{
    public class FrequenciaQueries
    {
        public readonly string BuscarFrequencias;
        public readonly string BuscarFrequenciaPorId;
        public readonly string InserirFrequencia;
        public readonly string AtualizarFrequencia;
        public readonly string DeletarFrequencia;

        public FrequenciaQueries()
        {
            BuscarFrequencias = BuscarTodasFrequencias();
            BuscarFrequenciaPorId = BuscarDeterminadaFrequencia();
            InserirFrequencia = InserirUmaFrequencia();
            DeletarFrequencia = DeletarDeterminadoFrequencia();
            AtualizarFrequencia = AtualizarDeterminadaFrequencia();
        }

        private string BuscarTodasFrequencias()
        {
            return $@"
                SELECT 
                    Id_Frequencia AS IdFrequencia,
                    Cod_Frequencia AS CodFrequencia,
                    Data_Frequencia AS DataFrequencia,
                    Id_Membro AS IdMembro,
                    Id_Evento AS IdEvento,
                    Presenca
                FROM Frequencia";
        }

        private string BuscarDeterminadaFrequencia()
        {
            return $@"
                SELECT 
                    Id_Frequencia AS IdFrequencia,
                    Cod_Frequencia AS CodFrequencia,
                    Data_Frequencia AS DataFrequencia,
                    Id_Membro AS IdMembro,
                    Id_Evento AS IdEvento,
                    Presenca
                FROM Frequencia WHERE Id_Frequencia = @IdFrequencia";
        }

        private string InserirUmaFrequencia()
        {
            return $@"
                INSERT INTO Frequencia (Cod_Frequencia, Data_Frequencia, Id_Membro, Id_Evento, Presenca)
                VALUES (@CodFrequencia, @DataFrequencia, @IdMembro, @IdEvento, @Presenca )";
        }

        private string DeletarDeterminadoFrequencia()
        {
            return $@"
                DELETE FROM Frequencia WHERE Id_Frequencia = @IdFrequencia";
        }

        private string AtualizarDeterminadaFrequencia()
        {
            return $@"
                UPDATE Frequencia SET 
                    Cod_Frequencia = @CodFrequencia,
                    Data_Frequencia = @DataFrequencia,
                    Id_Membro = @IdMembro,
                    Id_Evento = @IdEvento,
                    Presenca = @Presenca
                WHERE Id_Frequencia = @IdFrequencia";
        }
    }
}
