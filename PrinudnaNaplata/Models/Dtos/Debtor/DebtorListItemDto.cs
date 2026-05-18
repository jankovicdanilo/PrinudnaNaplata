namespace PrinudnaNaplata.Models.Dtos.Debtor
{
    public class DebtorListItemDto
    {
        public int TotalCount { get; set; }
        public int DuznikID { get; set; }
        public string? ZavedenKodPov { get; set; }
        public string? Ime { get; set; }
        public string? Mjesto { get; set; }
        public decimal? UkupnoDugovanje { get; set; }
    }
}
