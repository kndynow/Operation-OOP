using System.ComponentModel;
using OperationOOP.Core.Models.Enums;
using OperationOOP.Core.Services;

namespace OperationOOP.Api.Endpoints;

public class CreateBonsai : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/bonsais", Handle).WithTags(Tag).WithSummary("Create Bonsai");

    public record Request(
        string Name,
        BonsaiStyle Style,
        CareLevel CareLevel,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned
    );

    public record Response(int id);

    private static IResult Handle(Request request, IPlantService plantService)
    {
        var bonsai = new Bonsai()
        {
            Name = request.Name,
            Style = request.Style,
            CareLevel = request.CareLevel,
            AgeYears = request.AgeYears,
            LastWatered = request.LastWatered,
            LastPruned = request.LastPruned,
        };
        plantService.Create(bonsai);

        return TypedResults.Ok(new Response(bonsai.Id));
    }
}
