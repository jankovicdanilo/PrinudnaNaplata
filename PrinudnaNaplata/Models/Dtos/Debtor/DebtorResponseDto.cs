namespace PrinudnaNaplata.Models.Dtos.Debtor
{
    public class DebtorResponseDto
    {
        public int DuznikID { get; set; }
        public string? ZavedenKodPov { get; set; }
        public string? Ime { get; set; }
        public string? Mjesto { get; set; }
        public string? Adresa { get; set; }
        public string? JMBG { get; set; }
        public string? RegBr { get; set; }
        public string? LicniBroj { get; set; }
        public int? PreduzeceID { get; set; }
        public bool Nepoznat { get; set; }
        public bool Umro { get; set; }
        public bool Penzioner { get; set; }
        public string? Reon { get; set; }
        public string? Nekretnina { get; set; }
        public bool? PravnoLice { get; set; }
        public bool Oznacen { get; set; }
        public string? Vozila { get; set; }
        public string? BrojeviRacuna { get; set; }
        public string? Prebivaliste { get; set; }
    }
}
