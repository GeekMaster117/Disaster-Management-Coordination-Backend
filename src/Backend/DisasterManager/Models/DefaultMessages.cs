﻿namespace DisasterManager.Models
{
	public static class DefaultMessages
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

		public static class BadRequest
		{
			public const int StatusCode = 400;
			public const string Message = "Invalid Request";
		}

		public static class Unauthorized
		{
			public const int StatusCode = 403;
			public const string Message = "Unauthorized";
		}
    }
}
