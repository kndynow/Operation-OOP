using System;

namespace OperationOOP.Api.Endpoints;

public class DeleteBonsai : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/bonsais{Id}", Handle).WithTags(Tag).WithSummary("Delete Bonsai");

    public record Request(int Id);

    public record Response(int Id);

    private static IResult Handle([AsParameters] Request request, IDatabase db)
    {
        var bonsai = db.Bonsais.Find(b => b.Id == request.Id);

        db.Bonsais.Remove(bonsai);

        return TypedResults.NotFound($"Bonsai with ID {bonsai.Id} have been removed.");
    }
}
