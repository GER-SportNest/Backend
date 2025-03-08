using Application.Clubs.DTOs;
using Application.Repositories;
using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Clubs.Commands;

public static class CreateClub
{
    public const string Endpoint = "api/clubs/create";

    public class CreateClubCommand : IRequest<ClubDto>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }

    public class Validator : AbstractValidator<CreateClubCommand>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    internal sealed class Handler : IRequestHandler<CreateClubCommand, ClubDto>
    {
        private readonly IRepository<Club> _repo;

        public Handler(IRepository<Club> repo) => _repo = repo;

        public async Task<ClubDto> Handle(CreateClubCommand request, CancellationToken ct)
        {
            var club = new Club
            {
                Name = request.Name,
                Description = request.Description
            };
            await _repo.Add(club);
            await _repo.SaveChanges(ct);
            return club.Adapt<ClubDto>();
        }
    }
}

public class CreateClubEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(CreateClub.Endpoint, async ([FromBody] CreateClub.CreateClubCommand cmd, ISender sender) =>
            {
                var result = await sender.Send(cmd);
                return Results.Ok(result);
            })
            .Produces<ClubDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("CreateClub")
            .WithTags("Clubs");
    }
}