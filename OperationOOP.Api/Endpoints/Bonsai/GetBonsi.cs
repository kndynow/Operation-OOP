using Microsoft.AspNetCore.Http.Features;

namespace OperationOOP.Api.Endpoints;

public class GetBonsai : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/bonsais", Handle).WithTags(Tag).WithSummary("Get all Bonsai trees");

    // Request and Response types
    public record Response(int Id, string Name, DateTime LastWatered, DateTime LastPruned);

    //Logics
    private static IResult Handle(IDatabase db)
    {
        try
        {
            var bonsais = db
                .Bonsais.Select(item => new Response(
                    Id: item.Id,
                    Name: item.Name,
                    LastWatered: item.LastWatered,
                    LastPruned: item.LastPruned
                ))
                .ToList();

            if (!bonsais.Any())
            {
                return TypedResults.NotFound("There are no Bonsai's registerd.");
            }

            return TypedResults.Ok(bonsais);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(
                $"Something went wrong when retrieving list of Bonsais Exception: {ex.Message}"
            );
        }
    }
}
