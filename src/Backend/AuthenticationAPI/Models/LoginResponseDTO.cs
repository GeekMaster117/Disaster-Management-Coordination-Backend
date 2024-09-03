namespace AuthenticationAPI.Models
{
	public class LoginResponseDTO
	{
		public string Token { get; set; } = "";
		public DateTime Expiry { get; set; }
	}
}
