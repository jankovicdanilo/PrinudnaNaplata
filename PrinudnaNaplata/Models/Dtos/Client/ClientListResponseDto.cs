namespace PrinudnaNaplata.Models.Dtos.Client
{
    public class ClientListResponseDto
    {
        public int KlijentID { get; set; }
        public string? Naziv { get; set; }
        public string? Valuta { get; set; }
        public string? Adresa { get; set; }
        public string? Adresa2 { get; set; }
        public string? Grad { get; set; }
        public string? PostanskiBroj { get; set; }
        public string? Zemlja { get; set; }
        public string? Racun { get; set; }
        public string? Dokaz { get; set; }
        public string? PozvatiSeNa { get; set; }
        public string? PIB { get; set; }
        public string? PDV { get; set; }
        public decimal? PDVStopa { get; set; }
        public bool DodajPDVNaAdvTarifu { get; set; }
    }
}
