namespace BackChurch.Data.Queries
{
    public class HistoricoMinisterialQueries
    {
        public readonly string BuscarHistoricoMinisterial;
        public readonly string BuscarHistoricoMinisterialPorId;
        public readonly string InserirHistoricoMinisterial;
        public readonly string DeletarHistoricoMinisterial;
        public readonly string AtualizarHistoricoMinisterial;

        public HistoricoMinisterialQueries()
        {
            BuscarHistoricoMinisterial = BuscarPorHistoricoMinisterial();
            BuscarHistoricoMinisterialPorId = BuscarDeterminadoHistoricoMinisterial();
            InserirHistoricoMinisterial = InserirUmHistoricoMinisterial();
            DeletarHistoricoMinisterial = DeletarUmHistoricoMinisterial();
            AtualizarHistoricoMinisterial = AtualizarUmHistoricoMinisterial();
        }

        private string BuscarPorHistoricoMinisterial()
        {
            return $@"SELECT 
                    Id_Historico AS IdHistorico,
                    Cod_Historico AS CodHistorico,
                    Cargo,
                    Obreiro,
                    Data_Conversao AS DataConversao,
                    Data_Batismo AS DataBatismo,
                    Data_Batismo_Espirito AS DataBatismoEspirito,
                    Dizimista
                FROM HistoricoMinisterial";
        }

        private string BuscarDeterminadoHistoricoMinisterial()
        {   
            return $@"SELECT 
                    Id_Historico AS IdHistorico,
                    Cod_Historico AS CodHistorico,
                    Cargo,
                    Obreiro,
                    Data_Conversao AS DataConversao,
                    Data_Batismo AS DataBatismo,
                    Data_Batismo_Espirito AS DataBatismoEspirito,
                    Dizimista
                FROM HistoricoMinisterial
                WHERE Id_Historico = @IdHistorico";
        }

        private string InserirUmHistoricoMinisterial()
        {
            return $@"INSERT INTO HistoricoMinisterial (
                    Cod_Historico,
                    Cargo,
                    Obreiro,
                    Data_Conversao,
                    Data_Batismo,
                    Data_Batismo_Espirito,
                    Dizimista
                ) VALUES (
                    @CodHistorico,
                    @Cargo,
                    @Obreiro,
                    @DataConversao,
                    @DataBatismo,
                    @DataBatismoEspirito,
                    @Dizimista";
        }

        private string DeletarUmHistoricoMinisterial()
        {
            return $@"DELETE FROM HistoricoMinisterial WHERE Id_Historico = @IdHistorico";
        }

        private string AtualizarUmHistoricoMinisterial()
        {
            return $@"UPDATE HistoricoMinisterial SET
                    Cod_Historico = @CodHistorico,
                    Cargo = @Cargo,
                    Obreiro = @Obreiro,
                    Data_Conversao = @DataConversao,
                    Data_Batismo = @DataBatismo,
                    Data_Batismo_Espirito = @DataBatismoEspirito,
                    Dizimista = @Dizimista
                WHERE Id_Historico = @IdHistorico";
        }
    }
}
