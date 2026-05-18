namespace PrinudnaNaplata.Models.Dtos.Case
{
    public record CaseListItemDto
    {
        public long PartijaID { get; init; }
        public string? BrojPartije { get; init; }
        public int DuznikID { get; init; }
        public string? DuznikIme { get; init; }
        public string? ResenjeBroj { get; init; }
        public string? IVb { get; init; }
        public DateTime? PredatoDana { get; init; }
        public DateTime? DonetoDana { get; init; }
        public decimal? SudskeTakse { get; init; }
        public int TotalCount { get; init; }
    }
}