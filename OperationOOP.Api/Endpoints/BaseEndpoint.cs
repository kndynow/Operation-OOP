namespace OperationOOP.Api.Endpoints;

//Abstract BaseEndpoint for DI of ILogger
public abstract class BaseEndpoint<TRequest, TResponse> : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException(
            "Override this method to MapGet(Post/etc/etc).WithSummary()"
        );
    }
}
