namespace PrinudnaNaplata.Domain;

public class UserClientAccess
{
    public string UserName { get; set; } = string.Empty;
    public int ClientId { get; set; }
    public int? CanEdit { get; set; }
}
