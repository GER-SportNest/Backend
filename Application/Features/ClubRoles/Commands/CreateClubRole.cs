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
using SportNest.Application.Features.ClubRoles.DTOs;
using SportNest.Application.Repositories;
using SportNest.Domain;

namespace SportNest.Application.Features.ClubRoles.Commands;

public static class CreateClubRole
{
    public const string Endpoint = "api/clubs/{clubId:long}/roles";

    public record CreateClubRoleCommand(long ClubId, string RoleName, string? Permissions)
        : IRequest<Result<ClubRoleDto>>;

    public class Validator : AbstractValidator<CreateClubRoleCommand>
    {
        public Validator()
        {
            RuleFor(x => x.ClubId).NotEmpty();
            RuleFor(x => x.RoleName).NotEmpty();
        }
    }

    internal sealed class Handler (
        IRepository<Club> clubRepository,
        IRepository<ClubRole> clubRoleRepository)
        : IRequestHandler<CreateClubRoleCommand, Result<ClubRoleDto>>
    {

        public async Task<Result<ClubRoleDto>> Handle(CreateClubRoleCommand request, CancellationToken ct)
        {
            var doesClubExist = !await clubRepository.Exist(x => x.Id == request.ClubId, ct);
            if(doesClubExist)
                return Result<ClubRoleDto>.Failure(ErrorResults.ClubDoesNotExist);

            var doesClubRoleAlreadyExist = await clubRoleRepository.Exist(x => x.RoleName == request.RoleName
                                                            && x.ClubId == request.ClubId, 
                ct);
            
            if(doesClubRoleAlreadyExist)
                return Result<ClubRoleDto>.Failure(ErrorResults.ClubRoleAlreadyExists);

            var role = new ClubRole
            {
                ClubId = request.ClubId,
                RoleName = request.RoleName,
                PermissionsJson = request.Permissions
            };

            await clubRoleRepository.Add(role);
            await clubRoleRepository.SaveChanges(ct);

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
                var result = await sender.Send(cmd with { ClubId = clubId});
                return result.ToHttpResult();
            })
            .WithName("CreateClubRole")
            .WithTags("Clubs");
    }
}