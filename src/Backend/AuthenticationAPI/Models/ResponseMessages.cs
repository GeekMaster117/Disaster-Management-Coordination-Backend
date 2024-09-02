namespace AuthenticationAPI.Models
{
	public static class ResponseMessages
	{
		public static class InternalServerError
		{
			public const int StatusCode = 500;
			public const string Message = "Something went wrong :(";
		}

		public class Success
		{
			public const int StatusCode = 200;
			public string Message { get; set; } = "";
		}
	}
}
