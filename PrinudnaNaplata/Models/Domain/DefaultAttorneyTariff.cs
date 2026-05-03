namespace PrinudnaNaplata.Domain;

public class DefaultAttorneyTariff
{
    public int Id { get; set; }
    public decimal? TariffAmount { get; set; }
    public decimal? TariffPercentage { get; set; }
    public int? ClientId { get; set; }
}
