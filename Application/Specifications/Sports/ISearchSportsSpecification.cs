using SportNest.Application.Repositories;
using SportNest.Domain;

namespace SportNest.Application.Specifications.Sports;

public interface ISearchSportsSpecification : ISpecification<Sport>
{
    public ISearchSportsSpecification ByName(string name);
}