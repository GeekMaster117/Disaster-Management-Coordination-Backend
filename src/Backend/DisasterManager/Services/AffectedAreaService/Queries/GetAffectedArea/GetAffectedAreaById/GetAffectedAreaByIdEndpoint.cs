using DisasterManager.Models;
using Carter;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById
{
    public class GetAffectedAreaByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/affectedarea/{id:int}", async (int id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetAffectedAreaByIdQuery { Id = id });
                if (response == null)
                {
                    return Results.NotFound();
                }
                return Results.Content(
                    JsonSerializer.Serialize(response),
                    "application/json",
                    Encoding.UTF8
                );
            });
        }
    }
}
