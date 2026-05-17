namespace PrinudnaNaplata.Models.Dtos.Court
{
    public record CourtResponseDto
    (
        long SudID,
        string? Naziv,
        string? Mjesto,
        string? KratakNaziv,
        string? KratakPuniNaziv
    );
}
