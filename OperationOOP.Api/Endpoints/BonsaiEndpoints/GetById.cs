namespace OperationOOP.Api.Endpoints.BonsaiEndpoints;

public class GetById : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/bonsais/{Id}", Handle).WithTags(Tag).WithSummary("Get Bonsai tree by ID");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        Species Species,
        BonsaiType Type,
        BonsaiStyle Style,
        CareLevel CareLevel,
        int AgeYears,
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
        // Filter out plants that is not of type Bonsai, cast to Bonsai for correctly displaying info
        if (plant is not Bonsai bonsai)
        {
            return TypedResults.NotFound($"Plant with ID {request.Id} is not a Bonsai");
        }

        var response = new Response(
            Id: bonsai.Id,
            Name: bonsai.Name,
            Species: bonsai.Species,
            Type: bonsai.Type,
            Style: bonsai.Style,
            CareLevel: bonsai.CareLevel,
            AgeYears: bonsai.AgeYears,
            LastWatered: bonsai.LastWatered,
            LastPruned: bonsai.LastPruned
        );

        return TypedResults.Ok(response);
    }
}
