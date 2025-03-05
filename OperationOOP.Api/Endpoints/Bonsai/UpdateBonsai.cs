using System;

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
        //Get existing plant
        var plant = plantService.GetById(request.Id);
        if (plant == null)
        {
            return TypedResults.NotFound($"No plant found with ID {request.Id}");
        }
        // Filter out plants that is not of type bonsai and cast plant-object to bonsai for correctly displaying info
        if (plant is not Bonsai bonsai)
        {
            return TypedResults.NotFound($"Plant with ID {request.Id} is not a bonsai");
        }
        //Update properties and call update
        bonsai.Name = request.Name;
        bonsai.CareLevel = request.CareLevel;

        var updatedBonsai = plantService.Update(bonsai);
        if (updatedBonsai == null)
        {
            return TypedResults.Problem("Failed to update bonsai");
        }

        return TypedResults.Ok(new Response((Bonsai)updatedBonsai));
    }
}
