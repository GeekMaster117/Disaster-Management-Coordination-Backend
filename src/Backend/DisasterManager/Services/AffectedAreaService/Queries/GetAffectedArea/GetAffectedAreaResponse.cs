namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea
{
    public class GetAffectedAreaResponse
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public string DisasterType { get; set; } = "";
        public int Severity { get; set; }
    }
}
