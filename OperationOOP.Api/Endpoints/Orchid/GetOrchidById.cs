namespace OperationOOP.Api.Endpoints;

public class GetOrchidById : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Orchid";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/orchids/{Id}", Handle).WithTags(Tag).WithSummary("Get Orchid by ID");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        string Species,
        string Type,
        int AgeYears,
        string CareLevel,
        DateTime LastWatered,
        DateTime LastPruned
    );

    public static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        var plant = plantService.GetById(request.Id);
        //Check that plant isn't null
        if (plant == null)
        {
            return TypedResults.NotFound($"No plant found with ID {request.Id}");
        }
        // Filter out plants that is not of type orchid, cast to orchid for correctly displaying info
        if (plant is not Orchid orchid)
        {
            return TypedResults.NotFound($"Plant with ID {request.Id} is not a Orchid");
        }

        var response = new Response(
            Id: orchid.Id,
            Name: orchid.Name,
            Species: orchid.Species.ToString(),
            AgeYears: orchid.AgeYears,
            Type: orchid.Type.ToString(),
            CareLevel: orchid.CareLevel.ToString(),
            LastWatered: orchid.LastWatered,
            LastPruned: orchid.LastPruned
        );

        return TypedResults.Ok(response);
    }
}
