using Carter;
using DisasterManager.Services.RefugeeCampService.Commands.UpdateRefugeeCamp;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.RefugeeCampService.Commands.UpdateRefugeeCamp
{
    public class UpdateRefugeeCampByCampIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/refugeecamp", async ([FromBody] UpdateRefugeeCampByCampIdCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

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
