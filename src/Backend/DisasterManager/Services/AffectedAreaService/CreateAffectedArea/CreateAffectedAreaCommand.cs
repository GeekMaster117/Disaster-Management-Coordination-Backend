using MediatR;

namespace DisasterManager.Services.AffectedAreaService.CreateAffectedArea
{
    public class CreateAffectedAreaCommand : IRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public string DisasterType { get; set; } = "";
        public int Severity { get; set; }
    }
}
