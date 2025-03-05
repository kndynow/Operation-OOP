using System;

namespace OperationOOP.Api.Endpoints;

public class GetAllSucculents : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Succulent";

    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/succulents", Handle).WithTags(Tag).WithSummary("Get all succulents");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        string Species,
        string Type,
        string CareLevel,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned
    );

    //Logics
    private static IResult Handle(IPlantService plantService)
    {
        var succulents = plantService
            .GetAll()
            .Where(p => p is Succulent)
            .Cast<Succulent>()
            .Select(b => new Response(
                b.Id,
                b.Name,
                b.Species.ToString(),
                b.Type.ToString(),
                b.CareLevel.ToString(),
                b.AgeYears,
                b.LastWatered,
                b.LastPruned
            ));

        return TypedResults.Ok(succulents);
    }
}
