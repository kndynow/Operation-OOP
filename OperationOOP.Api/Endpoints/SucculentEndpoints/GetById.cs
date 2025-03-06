namespace OperationOOP.Api.Endpoints.SucculentEndpoints;

public class GetById : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Succulent";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/succulents/{Id}", Handle).WithTags(Tag).WithSummary("Get Succulent by ID");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        Species Species,
        SucculentType Type,
        CareLevel CareLevel,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned
    );

    public static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        var plant = plantService.GetById(request.Id);
        //Check that plant isn't null
        if (plant == null)
        {
            return TypedResults.NotFound($"No plant found with ID {request.Id}");
        }
        // Filter out plants that is not of type succulent, cast to succulent for correctly displaying info
        if (plant is not Succulent succulent)
        {
            return TypedResults.NotFound($"Plant with ID {request.Id} is not a succulent");
        }

        var response = new Response(
            Id: succulent.Id,
            Name: succulent.Name,
            Species: succulent.Species,
            Type: succulent.Type,
            CareLevel: succulent.CareLevel,
            AgeYears: succulent.AgeYears,
            LastWatered: succulent.LastWatered,
            LastPruned: succulent.LastPruned
        );

        return TypedResults.Ok(response);
    }
}
