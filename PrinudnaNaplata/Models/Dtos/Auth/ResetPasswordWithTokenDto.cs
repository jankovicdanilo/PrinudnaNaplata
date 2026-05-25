namespace PrinudnaNaplata.Models.Dtos.Auth
{
    public class ResetPasswordWithTokenDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
