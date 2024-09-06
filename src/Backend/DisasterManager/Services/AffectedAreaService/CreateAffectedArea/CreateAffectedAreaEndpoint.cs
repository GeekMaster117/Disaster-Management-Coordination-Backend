﻿using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using DisasterManager.Services.AffectedAreaService.CreateAffectedArea;
using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Carter;
using System.Text.Json;

namespace DisasterManager.Endpoints
{
    public class CreateAffectedAreaEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/affectedarea", async ([FromBody] CreateAffectedAreaCommand command, IMediator mediator) =>
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
