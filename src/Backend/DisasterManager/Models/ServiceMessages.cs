namespace DisasterManager.Models
{
	public static class ServiceMessages
	{
		public const string CreatedAffectedArea = "Created Affected Area";
		public static string DeletedAffectedArea(int id)
		{
			return $"Deleted Affected Area with Id: {id}";
		}
		public static string UpdatedAffectedArea(int id)
		{
			return $"Updated Affected Area with Id: {id}";
		}
		public static string NoAffectedAreaFound(int id)
		{
			return $"No Affected Area found with Id: {id}";
		}
		public const string CreatedRefugeeCamp = "Created Refugee Camp";
		public static string DeletedRefugeeCamp(int id)
		{
			return $"Deleted Refugee Camp with Id: {id}";
		}
		public static string UpdatedRefugeeCamp(int id)
		{
			return $"Updated Refugee Camp with Id: {id}";
		}
		public static string NoRefugeeCampFound(int id)
		{
			return $"No Refugee Camp with Id: {id}";
		}
	}
}
