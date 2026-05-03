namespace PrinudnaNaplata.Domain;

public class Debtor
{
    public int DebtorId { get; set; }
    public string? CreditorReference { get; set; }
    public string? FullName { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? PersonalId { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? IdCardNumber { get; set; }
    public int? CompanyId { get; set; }
    public bool IsUnknown { get; set; }
    public bool IsDeceased { get; set; }
    public bool IsPensioner { get; set; }
    public string? District { get; set; }
    public string? RealEstate { get; set; }
    public bool? IsLegalEntity { get; set; }
    public bool IsMarked { get; set; }
    public string? Vehicles { get; set; }
    public string? BankAccountNumbers { get; set; }
    public string? Residence { get; set; }
}
