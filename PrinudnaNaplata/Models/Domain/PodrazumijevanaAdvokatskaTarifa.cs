namespace PrinudnaNaplata.Domain;

public class PodrazumijevanaAdvokatskaTarifa
{
    public int Id { get; set; }
    public decimal? Tarifa { get; set; }
    public decimal? TarifaProcenat { get; set; }
    public int? KlijentID { get; set; }
}
