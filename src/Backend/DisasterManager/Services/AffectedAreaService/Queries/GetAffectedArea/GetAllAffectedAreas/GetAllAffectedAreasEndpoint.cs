using DisasterManager.Models;
using Carter;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAllAffectedAreas;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAllAffectedAreas
{
    public class GetAllAffectedAreasEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/affectedarea", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetAllAffectedAreasQuery());
                return Results.Content(
                    JsonSerializer.Serialize(response),
                    "application/json",
                    Encoding.UTF8,
                    response.StatusCode
                );
            });
        }
    }
}
