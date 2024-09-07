using Carter;
using DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampByCampId;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampByCampId
{
    public class GetRefugeeCampByCampIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/refugeecamp", async ([FromBody] GetRefugeeCampByCampIdQuery query, IMediator mediator) =>
            {
                var response = await mediator.Send(query);

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
