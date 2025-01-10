namespace BackChurch.Data.Queries
{
    public class EventosQueries
    {
        public readonly string BuscarEventos;
        public readonly string BuscarEventoPorId;
        public readonly string InserirEvento;
        public readonly string DeletarEvento;
        public readonly string AtualizarEvento;

        public EventosQueries()
        {
            BuscarEventos = BuscarTodosEventos();
            BuscarEventoPorId = BuscarDeterminadoEvento();
            InserirEvento = InserirUmEvento();
            DeletarEvento = DeletarDeterminadoEvento();
            AtualizarEvento = AtualizarDeterminadoEvento();
        }

        private string BuscarTodosEventos()
        {
            return $@"
                SELECT 
                    Id_Evento AS IdEvento,
                    Cod_Evento AS CodEvento,
                    Nome,
                    Data_Evento AS DataEvento,
                    Local_Evento AS LocalEvento,
                    Descricao
                FROM Eventos";
        }

        private string BuscarDeterminadoEvento()
        {
            return $@"
                SELECT 
                    Id_Evento AS IdEvento,
                    Cod_Evento AS CodEvento,
                    Nome,
                    Data_Evento AS DataEvento,
                    Local_Evento AS LocalEvento,
                    Descricao
                FROM Eventos WHERE Id_Evento = @IdEvento";
        }

        private string InserirUmEvento()
        {
            return $@"
                INSERT INTO Eventos (Cod_Evento, Nome, Data_Evento, Descricao, Local_Evento)
                VALUES (@CodEvento, @Nome, @DataEvento, @Descricao, @LocalEvento )";
        }

        private string DeletarDeterminadoEvento()
        {
            return $@"
                DELETE FROM Eventos WHERE Id_Evento = @IdEvento";
        }

        private string AtualizarDeterminadoEvento()
        {
            return $@"
                UPDATE Eventos SET 
                Cod_Evento = @CodEvento,
                Nome = @Nome, 
                Data_Evento = @DataEvento, 
                Descricao = @Descricao, 
                Local_Evento = @LocalEvento 
                WHERE Id_Evento = @IdEvento";
        }
    }
}
