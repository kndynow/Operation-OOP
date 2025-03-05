using System;
using OperationOOP.Core.Services;

namespace OperationOOP.Api.Endpoints;

public class UpdateBonsai : IEndpoint
{
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/bonsais/{Id}", Handle).WithTags(Tag).WithSummary("Update Bonsai");
    }

    public record Request(int Id, string Name, BonsaiStyle Style, CareLevel CareLevel);

    public record Response(Bonsai bonsai);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
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

        bonsai.Name = request.Name;
        bonsai.Style = request.Style;
        bonsai.CareLevel = request.CareLevel;

        return TypedResults.Ok(new Response(bonsai));
    }
}
