namespace PrinudnaNaplata.Models.Dtos.Auth
{
    public class PasswordChangeRequestDto
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
