namespace OperationOOP.Api.Endpoints;

public class CreateOrchid : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Orchid";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/orchids", Handle).WithTags(Tag).WithSummary("Add new Orchid");

    public record Request(OrchidType Type, string Name, int AgeYears, CareLevel CareLevel);

    public record Response(string message, Orchid orchid);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        var orchid = new Orchid(request.Type)
        {
            Name = request.Name,
            CareLevel = request.CareLevel,
            AgeYears = request.AgeYears,
        };
        plantService.Create(orchid);

        return TypedResults.Ok(
            new Response($"Orchid with ID:{orchid.Id} was successfully added:", orchid)
        );
    }
}
