namespace OperationOOP.Api.Endpoints;

public class CreateNote : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/notes", Handle).WithSummary("Create notes about plants.");

    public record Request(string Title, string Content, DateTime CreatedAt, DateTime UpdatedAt);

    public record Response(int id);

    private static IResult Handle([FromBody] Request request, [FromServices] IDatabase db)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return TypedResults.BadRequest("Title can not be empty or whitespace.");
        }
        if (string.IsNullOrWhiteSpace(request.Content))
        {
            return TypedResults.BadRequest(
                "Content cannot be empty or whitespace. If you're trying to delete a note please use Delete request."
            );
        }

        try
        {
            var note = new Note();
            note.Id = db.Notes.Any() ? db.Notes.Max(x => note.Id) + 1 : 1;
            note.Title = request.Title;
            note.Content = request.Content;
            note.CreatedAt = request.CreatedAt;
            note.UpdatedAt = request.UpdatedAt;
            db.Notes.Add(note);

            return TypedResults.Created($"/notes/{note.Id}", new Response(note.Id));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex}");

            return TypedResults.StatusCode(500);
        }
    }
}
