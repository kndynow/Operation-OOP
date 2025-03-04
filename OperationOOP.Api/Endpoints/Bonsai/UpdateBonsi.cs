using System;

namespace OperationOOP.Api.Endpoints;

public class UpdateBonsai : IEndpoint
{
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/bonsais/{Id}", Handle).WithTags(Tag).WithSummary("Update Bonsai");
    }

    public record Request(
        int Id,
        string Name,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
    );

    public record Response(int id);

    private static IResult Handle(Request request, IDatabase db)
    {
        var bonsai = db.Bonsais.Find(b => b.Id == request.Id);

        bonsai.Name = request.Name;
        bonsai.AgeYears = request.AgeYears;
        bonsai.LastWatered = request.LastWatered;
        bonsai.LastPruned = request.LastPruned;
        bonsai.Style = request.Style;
        bonsai.CareLevel = request.CareLevel;

        return TypedResults.Ok(new Response(bonsai.Id));
    }
}
