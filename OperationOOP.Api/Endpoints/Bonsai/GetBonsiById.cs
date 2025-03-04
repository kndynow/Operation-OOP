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
        BonsaiType BonsaiType,
        BonsaiStyle BonsaiStyle,
        CareLevel CareLevel,
        DateTime LastWatered,
        DateTime LastPruned
    );

    public static IResult Handle([AsParameters] Request request, IDatabase db)
    {
        try
        {
            var bonsai = db.Bonsais.Find(b => b.Id == request.Id);

            if (bonsai == null)
            {
                return TypedResults.NotFound($"Bonsai with ID {request.Id} not found");
            }
            return TypedResults.Ok(
                new Response(
                    Id: bonsai.Id,
                    Name: bonsai.Name,
                    Species: bonsai.Species,
                    AgeYears: bonsai.AgeYears,
                    BonsaiType: bonsai.Type,
                    BonsaiStyle: bonsai.Style,
                    CareLevel: bonsai.CareLevel,
                    LastWatered: bonsai.LastWatered,
                    LastPruned: bonsai.LastPruned
                )
            );
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(
                $"Something went wrong when retrieving bonsai with ID: {request.Id} Exception: {ex.Message}"
            );
        }
    }
}
