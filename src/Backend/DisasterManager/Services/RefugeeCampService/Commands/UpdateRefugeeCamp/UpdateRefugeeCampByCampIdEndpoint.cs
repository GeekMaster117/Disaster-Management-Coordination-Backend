﻿using Carter;
using DisasterManager.Models;
using DisasterManager.Services.RefugeeCampService.Commands.UpdateRefugeeCamp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
				JsonSerializerOptions options = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				};

				var response = await mediator.Send(command);

                return Results.Content(
                    JsonSerializer.Serialize(response, options),
                    "application/json",
                    Encoding.UTF8,
                    response.StatusCode
                );
            })
			.RequireAuthorization(policy => policy.RequireRole(UserRoles.Admin));
        }
    }
}
