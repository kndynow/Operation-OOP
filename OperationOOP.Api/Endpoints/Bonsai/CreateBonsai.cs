namespace OperationOOP.Api.Endpoints;

public class CreateBonsai : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/bonsais", Handle).WithTags(Tag).WithSummary("Add new Bonsai");

    public record Request(
        BonsaiType Type,
        string Name,
        int AgeYears,
        BonsaiStyle Style,
        CareLevel CareLevel
    );

    public record Response(string message, Bonsai bonsai);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        var bonsai = new Bonsai(request.Type)
        {
            Name = request.Name,
            Style = request.Style,
            CareLevel = request.CareLevel,
            AgeYears = request.AgeYears,
        };
        plantService.Create(bonsai);

        return TypedResults.Ok(
            new Response($"Bonsai with ID:{bonsai.Id} was successfully added:", bonsai)
        );
    }
}
