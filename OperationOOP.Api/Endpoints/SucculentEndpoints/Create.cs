namespace OperationOOP.Api.Endpoints.SucculentEndpoints;

public class Create : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Succulent";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/succulents", Handle).WithTags(Tag).WithSummary("Add new Succulent");

    public record Request(SucculentType Type, string Name, int AgeYears, CareLevel CareLevel);

    public record Response(string message, Succulent succulent);

    private static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        var succulent = new Succulent(request.Type)
        {
            Name = request.Name,
            CareLevel = request.CareLevel,
            AgeYears = request.AgeYears,
        };
        plantService.Create(succulent);

        return TypedResults.Ok(
            new Response($"Succulent with ID:{succulent.Id} was successfully added:", succulent)
        );
    }
}
