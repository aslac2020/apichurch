namespace BackChurch.Domain
{
    public class HistoricoMinisterial
    {
        public int IdHistorico { get; set; }
        public string CodHistorico { get; set;}
        public string Cargo { get; set;}
        public bool Obreiro { get;set;}
        public DateTime DataConversao { get; set;}
        public DateTime DataBatismo { get; set;}
        public DateTime DataBatismoEspirito { get; set;}
        public bool Dizimista { get; set;}

    }
}
