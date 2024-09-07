using Carter;
using DisasterManager.Services.RefugeeCampService.Commands.DeleteRefugeeCamp;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.RefugeeCampService.Commands.DeleteRefugeeCamp
{
    public class DeleteRefugeeCampByCampIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/refugeecamp", async ([FromBody] DeleteRefugeeCampByCampIdCommand command, IMediator mediator) =>
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
