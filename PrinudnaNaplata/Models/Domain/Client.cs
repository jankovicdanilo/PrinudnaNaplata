namespace PrinudnaNaplata.Domain;

public class Client
{
    public int ClientId { get; set; }
    public string? Name { get; set; }
    public string? Currency { get; set; }
    public string? Address { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? BankAccount { get; set; }
    public string? ProofLabel { get; set; }
    public string? ReferenceNote { get; set; }
    public string? TaxId { get; set; }
    public string? VatNumber { get; set; }
    public decimal? VatRate { get; set; }
    public bool AddVatToAttorneyFee { get; set; }
}
