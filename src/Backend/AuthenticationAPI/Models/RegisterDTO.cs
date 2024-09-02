namespace AuthenticationAPI.Models
{
    public class RegisterDTO
    {
        public string Email { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
