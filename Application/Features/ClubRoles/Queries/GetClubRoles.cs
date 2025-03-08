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
using Microsoft.AspNetCore.Routing;

namespace Application.Clubs.Queries;

public static class GetClubRoles
{
    public const string Endpoint = "api/clubs/{clubId:long}/roles";

    public class GetClubRolesQuery : IRequest<Result<List<ClubRoleDto>>>
    {
        public long ClubId { get; set; }
    }

    public class Validator : AbstractValidator<GetClubRolesQuery>
    {
        public Validator()
        {
            RuleFor(x => x.ClubId).NotEmpty();
        }
    }

    internal sealed class Handler : IRequestHandler<GetClubRolesQuery, Result<List<ClubRoleDto>>>
    {
        private readonly IRepository<ClubRole> _repo;

        public Handler(IRepository<ClubRole> repo) => _repo = repo;

        public async Task<Result<List<ClubRoleDto>>> Handle(GetClubRolesQuery request, CancellationToken ct)
        {
            // Fetch roles from DB where ClubId == request.ClubId
            var roles = await _repo.ListAll(r => r.ClubId == request.ClubId, ct);

            // Map to DTO
            var dtoList = roles.Adapt<List<ClubRoleDto>>();
            return Result<List<ClubRoleDto>>.Success(dtoList);
        }
    }
}

public class GetClubRolesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(GetClubRoles.Endpoint, async (long clubId, ISender sender) =>
            {
                var query = new GetClubRoles.GetClubRolesQuery { ClubId = clubId };
                var result = await sender.Send(query);
                return result.ToHttpResult();
            })
            .WithName("GetClubRoles")
            .WithTags("Clubs");
    }
}
