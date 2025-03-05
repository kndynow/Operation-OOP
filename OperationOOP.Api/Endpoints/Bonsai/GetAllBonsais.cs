namespace OperationOOP.Api.Endpoints;

public class GetAllBonsais : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/bonsais", Handle).WithTags(Tag).WithSummary("Get all Bonsai trees");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        string Species,
        string Type,
        string Style,
        string CareLevel,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned
    );

    //Logics
    private static IResult Handle(IPlantService plantService)
    {
        var bonsais = plantService
            .GetAll()
            .Where(p => p is Bonsai)
            .Cast<Bonsai>()
            .Select(b => new Response(
                b.Id,
                b.Name,
                b.Species.ToString(),
                b.Type.ToString(),
                b.Style.ToString(),
                b.CareLevel.ToString(),
                b.AgeYears,
                b.LastWatered,
                b.LastPruned
            ));

        return TypedResults.Ok(bonsais);
    }
}
