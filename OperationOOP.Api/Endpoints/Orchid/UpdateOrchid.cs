using System;

namespace OperationOOP.Api.Endpoints;

public class UpdateOrchid : IEndpoint
{
    private const string Tag = "Orchid";

    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/orchids/{Id}", Handle).WithTags(Tag).WithSummary("Update Orchid");
    }

    public record Request(int Id, string Name, CareLevel CareLevel);

    public record Response(Orchid orchid);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        //Get existing plant
        var plant = plantService.GetById(request.Id);
        if (plant == null)
        {
            return TypedResults.NotFound($"No plant found with ID {request.Id}");
        }
        // Filter out plants that is not of type orchid and cast plant-object to orchid for correctly displaying info
        if (plant is not Orchid orchid)
        {
            return TypedResults.NotFound($"Plant with ID {request.Id} is not a orchid");
        }
        //Update properties and call update
        orchid.Name = request.Name;
        orchid.CareLevel = request.CareLevel;

        var updatedOrchid = plantService.Update(orchid);
        if (updatedOrchid == null)
        {
            return TypedResults.Problem("Failed to update orchid");
        }

        return TypedResults.Ok(new Response((Orchid)updatedOrchid));
    }
}
