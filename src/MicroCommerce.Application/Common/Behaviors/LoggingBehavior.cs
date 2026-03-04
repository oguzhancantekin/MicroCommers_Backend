using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MicroCommerce.Application.Common.Behaviors;

/// <summary>
/// MediatR pipeline behavior that logs request execution time and details.
/// Warns when requests take longer than 500ms (potential performance issue).
/// </summary>
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("MicroCommerce Request: {Name} {@Request}", requestName, request);

        var stopwatch = Stopwatch.StartNew();
        var response = await next();
        stopwatch.Stop();

        var elapsedMs = stopwatch.ElapsedMilliseconds;

        if (elapsedMs > 500)
        {
            _logger.LogWarning("MicroCommerce Long Running Request: {Name} ({ElapsedMilliseconds} ms) {@Request}",
                requestName, elapsedMs, request);
        }
        else
        {
            _logger.LogInformation("MicroCommerce Request Completed: {Name} ({ElapsedMilliseconds} ms)",
                requestName, elapsedMs);
        }

        return response;
    }
}
