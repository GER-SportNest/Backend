using Application.Common;
using Application.Common.Extensions;
using Application.Repositories;
using Application.Users.DTOs;
using Carter;
using Domain;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Application.Users.Commands;

public static class RegisterUser
{
    public const string Endpoint = "api/users/register";

    public class RegisterUserCommand : IRequest<Result<UserDto>>
    {
        public string DisplayName { get; set; } = default!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    private class Validator : AbstractValidator<RegisterUserCommand>
    {
        public Validator()
        {
            RuleFor(x => x.DisplayName).NotEmpty();
            RuleFor(x => x.Email)
                .Must((cmd, email) => !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(cmd.PhoneNumber))
                .WithMessage("Email or PhoneNumber must be provided.");
        }
    }

    internal sealed class Handler : IRequestHandler<RegisterUserCommand, Result<UserDto>>
    {
        private readonly IRepository<User> _repo;

        public Handler(IRepository<User> repo) => _repo = repo;

        public async Task<Result<UserDto>> Handle(RegisterUserCommand request, CancellationToken ct)
        {
            
            if (request.Email is not null)
            {
                var emailExists = await _repo.Exist(u => u.Email == request.Email, ct);
                if (emailExists)
                {
                    return Result<UserDto>.Failure("Email already in use.", ResultStatus.Conflict);
                }
            }

            if (request.PhoneNumber is not null)
            {
                var phoneExists = await _repo.Exist(u => u.PhoneNumber == request.PhoneNumber, ct);
                if (phoneExists)
                {
                    return Result<UserDto>.Failure("PhoneNumber already in use.", ResultStatus.Conflict);
                }
            }
            var user = new User
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };
            await _repo.Add(user);
            await _repo.SaveChanges(ct);
            return Result<UserDto>.Success(user.Adapt<UserDto>());
        }
    }
}

public class RegisterUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(RegisterUser.Endpoint, async (RegisterUser.RegisterUserCommand cmd, ISender sender) =>
        {
            var result = await sender.Send(cmd);
            return result.ToHttpResult();
        })
        .Produces<UserDto>()
        .Produces(StatusCodes.Status400BadRequest)
        .WithName("RegisterUser")
        .WithTags("Users");
    }
}
