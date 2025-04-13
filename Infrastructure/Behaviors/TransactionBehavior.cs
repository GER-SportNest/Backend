using SportNest.Application.Common;
using SportNest.Infrastructure.Repositories;

namespace SportNest.Infrastructure.Behaviors;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IDbContextFactory _dbContextFactory;
    private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;

    public TransactionBehavior(IDbContextFactory dbContextFactory, ILogger<TransactionBehavior<TRequest, TResponse>> logger)
    {
        _dbContextFactory = dbContextFactory;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!request.GetType().IsAssignableFrom(typeof(ICommandRequest)))
        {
            return await next();
        }
        
        var dbContext = _dbContextFactory.GetDbContext();
        if (dbContext.Database.CurrentTransaction != null)
        {
            return await next();
        }

        TResponse? response = default;

        var strategy = dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                _logger.LogInformation("Begin EFCore transaction for {RequestType}", typeof(TRequest).Name);

                response = await next();

                await dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                _logger.LogInformation("Committed EFCore transaction for {RequestType}", typeof(TRequest).Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Rolling back transaction for {RequestType}", typeof(TRequest).Name);
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });

        // Wird von innerem Scope gesetzt
        return response!;
    }
}
