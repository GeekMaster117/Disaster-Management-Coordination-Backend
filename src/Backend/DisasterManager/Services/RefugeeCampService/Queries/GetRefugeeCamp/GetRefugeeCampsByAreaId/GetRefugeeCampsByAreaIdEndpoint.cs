using Carter;
using DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampsByAreaId;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net.Quic;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampsByAreaId
{
    public class GetRefugeeCampsByAreaIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/refugeecamp/area/{id}", async ([FromRoute] int id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetRefugeeCampsByAreaIdQuery()
                {
                    AreaId = id
                });
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
