using System;

namespace OperationOOP.Api.Endpoints;

public class UpdateSucculent : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Succulent";

    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/succulents/{Id}", Handle).WithTags(Tag).WithSummary("Update Succulent");
    }

    public record Request(int Id, string Name, CareLevel CareLevel);

    public record Response(Succulent succulent);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        //Get existing plant
        var plant = plantService.GetById(request.Id);
        if (plant == null)
        {
            return TypedResults.NotFound($"No plant found with ID {request.Id}");
        }
        // Filter out plants that is not of type succulent and cast plant-object to succulent for correctly displaying info
        if (plant is not Succulent succulent)
        {
            return TypedResults.NotFound($"Plant with ID {request.Id} is not a succulent");
        }
        //Update properties and call update
        succulent.Name = request.Name;
        succulent.CareLevel = request.CareLevel;

        var updatedSucculent = plantService.Update(succulent);
        if (updatedSucculent == null)
        {
            return TypedResults.Problem("Failed to update succulent");
        }

        return TypedResults.Ok(new Response((Succulent)updatedSucculent));
    }
}
