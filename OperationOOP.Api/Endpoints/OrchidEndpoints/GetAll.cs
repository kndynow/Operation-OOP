namespace OperationOOP.Api.Endpoints.OrchidEndpoints;

public class GetAll : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Orchid";

    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/orchids", Handle).WithTags(Tag).WithSummary("Get all Orchids");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        Species Species,
        OrchidType Type,
        CareLevel CareLevel,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned
    );

    //Logics
    private static IResult Handle(IPlantService plantService)
    {
        var orchids = plantService
            .GetAll()
            .Where(p => p is Orchid)
            .Cast<Orchid>()
            .Select(b => new Response(
                b.Id,
                b.Name,
                b.Species,
                b.Type,
                b.CareLevel,
                b.AgeYears,
                b.LastWatered,
                b.LastPruned
            ));

        return TypedResults.Ok(orchids);
    }
}
