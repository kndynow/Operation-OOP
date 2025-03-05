using System;

namespace OperationOOP.Api.Endpoints;

public class DeleteOrchid : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Orchid";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/orchids/{Id}", Handle).WithTags(Tag).WithSummary("Delete Orchid");

    public record Request(int Id);

    public record Response(int Id);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        plantService.Delete(request.Id);

        return TypedResults.Ok($"Orchid with ID {request.Id} have been removed.");
    }
}
