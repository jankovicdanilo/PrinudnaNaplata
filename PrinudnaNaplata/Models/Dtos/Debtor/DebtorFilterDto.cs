namespace PrinudnaNaplata.Models.Dtos.Debtor
{
    public class DebtorFilterDto
    {
        public string? Ime { get; set; } = null;
        public string? Mjesto { get; set; } = null;
        public string? Reon { get; set; } = null;
        public string? Adresa { get; set; } = null;
        public string? JMBG { get; set; } = null;
        public string? LicniBroj { get; set; } = null;
        public string? ZavedenKodPov { get; set; } = null;
        public string? ZaposlenKod { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool? Nepoznat { get; set; } = null;
        public bool? Umro { get; set; } = null;
        public bool? Penzioner { get; set; } = null;
        public bool? PravnoLice { get; set; } = null;
        public decimal? UkupanDug { get; set; } = null;
        public DateTime? DugOd { get; set; } = null;
        public DateTime? DugDo { get; set; } = null;
        public int KlijentID { get; set; } = 0;
    }
}
