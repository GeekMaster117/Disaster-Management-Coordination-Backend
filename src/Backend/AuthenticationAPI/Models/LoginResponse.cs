namespace AuthenticationAPI.Models
{
	public class LoginResponse
	{
		public string Token { get; set; } = "";
		public DateTime Expiry { get; set; }
	}
}
