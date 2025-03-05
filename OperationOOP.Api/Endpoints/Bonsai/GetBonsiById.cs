using OperationOOP.Core.Services;

namespace OperationOOP.Api.Endpoints;

public class GetBonsaiById : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/bonsais/{Id}", Handle).WithTags(Tag).WithSummary("Bonsai tree by ID");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        Species Species,
        int AgeYears,
        CareLevel CareLevel,
        BonsaiType Type,
        BonsaiStyle Style,
        DateTime LastWatered,
        DateTime LastPruned
    );

    public static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        var plant = plantService.GetById(request.Id);
        if (plant == null)
        {
            return TypedResults.NotFound($"No plant found with ID {request.Id}");
        }
        // Cast to Bonsai
        if (plant is not Bonsai bonsai)
        {
            return TypedResults.NotFound($"Plant with ID {request.Id} is not a Bonsai");
        }

        var response = new Response(
            Id: bonsai.Id,
            Name: bonsai.Name,
            Species: bonsai.Species,
            AgeYears: bonsai.AgeYears,
            Type: bonsai.Type,
            Style: bonsai.Style,
            CareLevel: bonsai.CareLevel,
            LastWatered: bonsai.LastWatered,
            LastPruned: bonsai.LastPruned
        );

        return TypedResults.Ok(response);
    }
}
