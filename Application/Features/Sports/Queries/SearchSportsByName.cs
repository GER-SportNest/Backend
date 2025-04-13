using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SportNest.Application.Common;
using SportNest.Application.Common.Extensions;
using SportNest.Application.Features.Sports.DTOs;
using SportNest.Application.Repositories;
using SportNest.Application.Specifications.Sports;
using SportNest.Domain;

namespace SportNest.Application.Features.Sports.Queries;

public static class SearchSportsByName
{
    /// <summary>
    /// Route zum Suchen von Sportarten.
    /// </summary>
    public const string Endpoint = "api/sports/search";

    /// <summary>
    /// Query-Request (hier als GET-Parameter).
    /// </summary>
    /// <param name="Name">Suchbegriff für den Namen der Sportart</param>
    public record Query([FromQuery] string Name) : IRequest<Result<List<SportDto>>>;

    /// <summary>
    /// Validator, um sicherzustellen, dass der Name nicht leer ist.
    /// </summary>
    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    /// <summary>
    /// Handler für die tatsächliche Datenbanksuche.
    /// Wir verwenden hier ein IRepository, das ein IQueryable liefert.
    /// </summary>
    internal sealed class Handler(ISearchSportsSpecification repo) : IRequestHandler<Query, Result<List<SportDto>>>
    {
        public async Task<Result<List<SportDto>>> Handle(Query request, CancellationToken ct)
        {
            // Beispielhafte Suche per EF.Functions.PlainToTsQuery + Matches()
            // Wir greifen auf das bereits konfigurierte SearchVector zu.
            var sports = await repo.ByName(request.Name).Execute(ct);

            return Result<List<SportDto>>.Success(sports);
        }
    }
}

public class SearchSportsByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // GET-Route, die den Query-Parameter (Name) übernimmt
        app.MapGet(SearchSportsByName.Endpoint, async ([AsParameters] SearchSportsByName.Query query, ISender sender) =>
            {
                // MediatR-Request anstoßen
                var result = await sender.Send(query);
                return result.ToHttpResult();
            })
            .Produces<List<SportDto>>()                // Erfolgreiche Rückgabe: Liste SportDto
            .Produces(StatusCodes.Status400BadRequest) // Bei Validation-Fehlern
            .WithName("SearchSportsByName")
            .WithTags("Sports");
    }
}
