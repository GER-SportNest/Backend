using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SportNest.Application.Features.Users.DTOs;
using SportNest.Application.Repositories;
using SportNest.Domain;

namespace SportNest.Application.Features.Users.Queries;

public static class GetUser
{
    public const string Endpoint = "api/users/{userId}";

    public record GetUserQuery(Guid Id) : IRequest<UserDto>;

    public class Validator : AbstractValidator<GetUserQuery>
    {
        public Validator()
        {
            RuleFor(x => x.Id != default);
        }
    }

    internal sealed class Handler (IRepository<User> repository)
        : IRequestHandler<GetUserQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await repository.GetById(request.Id);
            return user.Adapt<UserDto>();
        }
    }

}

public class GetUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(GetUser.Endpoint, async (Guid userId, ISender sender) =>
        {
            var result = await sender.Send(new GetUser.GetUserQuery(userId));
            return result;
        })
            .Produces<UserDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithDescription("Get User based on authorization")
            .WithTags("User")
            .WithOpenApi();
    }
}
