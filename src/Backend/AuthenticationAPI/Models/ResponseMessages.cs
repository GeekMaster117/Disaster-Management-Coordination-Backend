namespace AuthenticationAPI.Models
{
	public static class ResponseMessages
	{
		public static class InternalServerError
		{
			public const int StatusCode = 500;
			public const string Message = "Something went wrong :(";
		}

		public static class Success
		{
			public const int StatusCode = 200;
			public const string Message = "Request Successful";
		}

        public static class Unauthorized
        {
			public const int StatusCode = 403;
			public const string Message = "Unauthorized";
        }
    }
}
