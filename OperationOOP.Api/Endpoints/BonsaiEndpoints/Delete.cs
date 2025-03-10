namespace OperationOOP.Api.Endpoints.BonsaiEndpoints;

public class Delete : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/bonsais/{Id}", Handle).WithTags(Tag).WithSummary("Delete Bonsai");

    public record Request(int Id);

    public record Response(int Id);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        plantService.Delete(request.Id);

        return TypedResults.Ok($"Bonsai with ID {request.Id} have been removed.");
    }
}
