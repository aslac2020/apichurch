namespace BackChurch.Domain
{
    public class Frequencia
    {
        public int IdFrequencia { get; set; }
        public string CodFrequencia { get; set; }
        public int IdMembro { get; set;}
        public int IdEvento { get; set; }
        public DateTime DataFrequencia { get; set; }
        public bool Presenca { get; set; }
        public MembrosPresente MembrosPresenteEvento { get; set; }

        public EventosIgreja EventosDoDia { get; set;}
    }

    public class MembrosPresente
    {

    }

    public class EventosIgreja
    {
        public int IdEvento { get; set; }
        public string CodEvento { get; set; }
        public string Nome { get; set; }
        public DateTime DataEvento { get; set;}
        public string Descricao { get; set; }
        public string LocalEvento { get; set; }
    }
}
