using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.AffectedAreaService.Commands.UpdateAffectedArea
{
    public class UpdateAffectedAreaByIdCommand : IRequest<ResponseDTO>
    {
        public int AreaId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public string DisasterType { get; set; } = "";
        public int Severity { get; set; }
    }
}
