using MediatR;

namespace DisasterManager.Services.DeleteAffectedArea
{
	public class DeleteAffectedAreaByIdCommand : IRequest<bool>
	{
		public int Id { get; set; }
	}
}
