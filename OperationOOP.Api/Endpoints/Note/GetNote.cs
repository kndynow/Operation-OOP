namespace OperationOOP.Api.Endpoints;

public class GetNote : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/notes/{Id}", Handle).WithSummary("Get note by ID.");

    public record Request(int Id);

    public record Response(
        int Id,
        string Title,
        string Content,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );

    private static IResult Handle([AsParameters] Request request, IDatabase db)
    {
        try
        {
            var note = db.Notes.Find(n => n.Id == request.Id);

            if (note == null)
            {
                return TypedResults.NotFound($"Note with ID {request.Id} not found");
            }

            return TypedResults.Ok(
                new Response(note.Id, note.Title, note.Content, note.CreatedAt, note.UpdatedAt)
            );
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(
                $"Something went wrong when retrieving note with ID: {request.Id} Exception: {ex.Message}"
            );
        }
    }
}
