using Microsoft.EntityFrameworkCore;
using SportNest.Application.Repositories;
using SportNest.Application.Specifications.Sports;
using SportNest.Domain;

namespace SportNest.Infrastructure.Specifications.Sports;

public class SearchSportsSpecification(IRepository<Sport> repository) : BaseSpecification<Sport>(repository), ISearchSportsSpecification
{
    public ISearchSportsSpecification ByName(string name)
    {
        return (ISearchSportsSpecification) ApplyCriteria(x => x.SearchVector.Matches(EF.Functions.PlainToTsQuery("german", name)));
    }
}