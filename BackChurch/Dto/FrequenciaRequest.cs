namespace BackChurch.Dto
{
    public class FrequenciaRequest
    {
        public string CodFrequencia { get; set; }
        public int IdMembro { get; set;}
        public int IdEvento { get; set; }
        public DateTime DataFrequencia { get; set; }
        public bool Presenca { get; set; }
    }
}
