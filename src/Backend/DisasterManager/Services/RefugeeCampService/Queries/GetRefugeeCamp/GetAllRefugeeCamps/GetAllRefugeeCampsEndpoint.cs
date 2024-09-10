using Carter;
using DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetAllRefugeeCamps;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp
{
    public class GetAllRefugeeCampsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/refugeecamp", async (IMediator mediator) =>
            {
				JsonSerializerOptions options = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				};
				var response = await mediator.Send(new GetAllRefugeeCampsQuery());
                return Results.Content(
                    JsonSerializer.Serialize(response, options),
                    "application/json",
                    Encoding.UTF8,
                    response.StatusCode
                );
            });
        }
    }
}
