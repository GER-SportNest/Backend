using Application.Clubs.DTOs;
using Application.Common;
using Application.Common.Extensions;
using Application.Repositories;
using Carter;
using Domain;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Application.ClubRoles.Commands;

public static class CreateClubRole
{
    public const string Endpoint = "api/clubs/{clubId:long}/roles";

    public class CreateClubRoleCommand : IRequest<Result<ClubRoleDto>>
    {
        public long ClubId { get; set; }
        public string RoleName { get; set; } = default!;
        public string? Permissions { get; set; }
    }

    public class Validator : AbstractValidator<CreateClubRoleCommand>
    {
        public Validator()
        {
            RuleFor(x => x.ClubId).NotEmpty();
            RuleFor(x => x.RoleName).NotEmpty();
        }
    }

    internal sealed class Handler : IRequestHandler<CreateClubRoleCommand, Result<ClubRoleDto>>
    {
        private readonly IRepository<ClubRole> _repo;

        public Handler(IRepository<ClubRole> repo) => _repo = repo;

        public async Task<Result<ClubRoleDto>> Handle(CreateClubRoleCommand request, CancellationToken ct)
        {
            // Optional: check if the club actually exists, or if role name is unique
            // For now, we assume the club is valid.

            var role = new ClubRole
            {
                ClubId = request.ClubId,
                RoleName = request.RoleName,
                PermissionsJson = request.Permissions
            };

            await _repo.Add(role);
            await _repo.SaveChanges(ct);

            return Result<ClubRoleDto>.Success(role.Adapt<ClubRoleDto>());
        }
    }
}

public class CreateClubRoleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(CreateClubRole.Endpoint, async (long clubId, [FromBody] CreateClubRole.CreateClubRoleCommand cmd, ISender sender) =>
            {
                cmd.ClubId = clubId; // from route
                var result = await sender.Send(cmd);
                return result.ToHttpResult();
            })
            .WithName("CreateClubRole")
            .WithTags("Clubs");
    }
}