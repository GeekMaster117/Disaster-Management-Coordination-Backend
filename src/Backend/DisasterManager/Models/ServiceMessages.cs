namespace DisasterManager.Models
{
	public static class ServiceMessages
	{
		public const string CreatedAffectedArea = "Created Affected Area";
		public static string DeletedAffectedArea(int id)
		{
			return $"Deleted Affected Area found with Id: {id}";
		}
		public static string UpdatedAffectedArea(int id)
		{
			return $"Updated Affected Area found with Id: {id}";
		}
		public static string NoAffectedAreaFound(int id)
		{
			return $"No Affected Area found with Id: {id}";
		}
	}
}
