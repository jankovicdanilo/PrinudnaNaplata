namespace PrinudnaNaplata.Models.Dtos.OldAspNet
{
    public class LegacyUser
    {
        public string UserName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string Password { get; set; } = string.Empty;
        public int PasswordFormat { get; set; }
        public string PasswordSalt { get; set; } = string.Empty;
        public string? Email { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
    }
}
