using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SportNest.Application.Common;
using SportNest.Application.Common.Extensions;
using SportNest.Application.Features.Clubs.DTOs;
using SportNest.Application.Repositories;
using SportNest.Domain;

namespace SportNest.Application.Features.Groups.Commands;

public static class CreateGroup
{
    public const string Endpoint = "api/groups/create";

    public record CreateGroupCommand(string Name, string? Description) : IRequest<Result<GroupDto>>;

    public class Validator : AbstractValidator<CreateGroupCommand>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    internal sealed class Handler(IRepository<Group> repo) : IRequestHandler<CreateGroupCommand, Result<GroupDto>>
    {
        public async Task<Result<GroupDto>> Handle(CreateGroupCommand request, CancellationToken ct)
        {
            var group = new Group
            {
                Name = request.Name,
                Description = request.Description
            };
            await repo.Add(group);
            await repo.SaveChanges(ct);
            return Result<GroupDto>.Success(group);
        }
    }
}

public class CreateGroupEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(CreateGroup.Endpoint, async ([FromBody] CreateGroup.CreateGroupCommand cmd, ISender sender) =>
            {
                var result = await sender.Send(cmd);
                return result.ToHttpResult();
            })
            .Produces<GroupDto>()
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("CreateGroup")
            .WithTags("Groups");
    }
}