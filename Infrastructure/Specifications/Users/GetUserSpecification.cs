using System.Linq.Expressions;
using SportNest.Application.Repositories;
using SportNest.Domain;

namespace SportNest.Infrastructure.Specifications.Users;

public class GetUserSpecification : BaseSpecification<User>
{
    public GetUserSpecification(Expression<Func<User, bool>> criteria)
    {
        ApplyCriteria(criteria);
    }
}