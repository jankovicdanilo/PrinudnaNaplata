namespace PrinudnaNaplata.Models.Dto.Auth
{
    public class LoginRequestDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
