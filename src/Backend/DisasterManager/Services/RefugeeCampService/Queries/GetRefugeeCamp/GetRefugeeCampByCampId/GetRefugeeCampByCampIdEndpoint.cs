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
            app.MapGet("/refugeecamp/camp/{id}", async ([FromRoute] int id, IMediator mediator) =>
            {
				JsonSerializerOptions options = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				};
				var response = await mediator.Send(new GetRefugeeCampByCampIdQuery()
                {
                    CampId = id
                });

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
