using MediatR;

namespace DisasterManager.Services.AffectedAreaService.GetAffectedArea.GetAllAffectedAreas
{
	public class GetAllAffectedAreasQuery : IRequest<IEnumerable<GetAffectedAreaResponse>>
	{
	}
}
