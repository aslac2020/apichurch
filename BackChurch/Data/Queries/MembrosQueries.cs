namespace BackChurch.Data.Queries
{
    public class MembrosQueries
    {

        public readonly string BuscarMembros;
        public readonly string BuscarMembroPorId;
        public readonly string InserirMembros;
        public readonly string DeletarMembros;
        public readonly string AtualizarMembros;

        public MembrosQueries()
        {
            BuscarMembros = BuscarTodosMembros();
            BuscarMembroPorId = BuscarUmMembro();
            InserirMembros = InserirUmMembro();
            DeletarMembros = DeletarUmMembro();
            AtualizarMembros = AtualizarUmaMembro();
        }

        private string BuscarTodosMembros()
        {
            return $@"
                SELECT
             Id_Membro as IdMembro,
             Cod_Membro as CodMembro,
             Nome,
             Data_Nascimento as DataNascimento,
             Email,
             CPF,
             CNPJ,
             Telefone,
             Estado_Civil as EstadoCivil,
             Id_Endereco as IdEndereco,
             Id_Historico as IdHistorico,
             Id_Igreja as IdIgreja,
             Id_IgrejaSetor as IdIgrejaSetor,
             Id_IgrejaCongregacao as IdIgrejaCongregacao
             FROM Membros";
        }

        private string BuscarUmMembro()
        {
           return $@"
                  SELECT
            Id_Membro as IdMembro,
            Cod_Membro as CodMembro,
            Nome,
            Data_Nascimento as DataNascimento,
            Email,
            CPF,
            CNPJ,
            Telefone,
            Estado_Civil as EstadoCivil,
            Id_Endereco as IdEndereco,
            Id_Historico as IdHistorico,
            Id_Igreja as IdIgreja,
            Id_IgrejaSetor as IdIgrejaSetor,
            Id_IgrejaCongregacao as IdIgrejaCongregacao
            FROM Membros
                WHERE Id_Membro = @IdMembro";
        }

        private string InserirUmMembro()
        {
            return $@"
                INSERT INTO Membros
                (Cod_Membro, Nome, Data_Nascimento, Email, CPF, CNPJ, Telefone, Estado_Civil, Id_Endereco, Id_Historico, Id_Igreja, Id_IgrejaSetor, Id_IgrejaCongregacao)
                VALUES
                (@CodMembro, @Nome, @DataNascimento, @Email, @CPF, @CNPJ, @Telefone, @EstadoCivil, @IdEndereco, @IdHistorico, @IdIgreja, @IdIgrejaSetor, @IdIgrejaCongregacao)";
        }

        private string DeletarUmMembro()
        {
            return $@"
                DELETE FROM Membros
                WHERE Id_Membro = @IdMembro";
        }

        private string AtualizarUmaMembro()
        {
           return $@"
                UPDATE Membros
                SET Cod_Membro = @CodMembro,
                    Nome = @Nome,
                    Data_Nascimento = @DataNascimento,
                    Email = @Email,
                    CPF = @CPF,
                    CNPJ = @CNPJ,
                    Telefone = @Telefone,
                    Estado_Civil = @EstadoCivil,
                    Id_Endereco = @IdEndereco,
                    Id_Historico = @IdHistorico,
                    Id_Igreja = @IdIgreja,
                    Id_IgrejaSetor = @IdIgrejaSetor,
                    Id_IgrejaCongregacao = @IdIgrejaCongregacao
                WHERE Id_Membro= @IdMembro";
        }
    }
}
