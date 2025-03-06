namespace OperationOOP.Api.Endpoints.SucculentEndpoints;

public class Delete : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Succulent";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/succulents/{Id}", Handle).WithTags(Tag).WithSummary("Delete Succulent");

    public record Request(int Id);

    public record Response(int Id);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        plantService.Delete(request.Id);

        return TypedResults.Ok($"Succulent with ID {request.Id} have been removed.");
    }
}
