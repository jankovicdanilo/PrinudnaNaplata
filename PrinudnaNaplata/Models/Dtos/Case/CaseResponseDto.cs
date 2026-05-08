using PrinudnaNaplata.Domain;

namespace PrinudnaNaplata.Models.Dtos.Case
{
    public record CaseResponseDto
    (
        long? PartijaID,
        string? BrojPartije,
        int? DuznikID,
        string? DuznikIme,
        string? ResenjeBroj,
        string? IVb,
        DateTime? PredatoDana,
        DateTime? DonetoDana,
        decimal? SudskeTakse
    );
}
