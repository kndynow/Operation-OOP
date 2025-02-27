﻿namespace OperationOOP.Api.Endpoints;

public class GetBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/bonsais/{id}", Handle).WithSummary("Bonsai trees");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        Species Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
    );

    // private static Response Handle([AsParameters] Request request, IDatabase db)
    // {
    //     var bonsai = db.Bonsais.Find(bonsai => bonsai.Id == request.Id);

    //     // map bonsai to response dto
    //     var response = new Response(
    //         Id: bonsai.Id,
    //         Name: bonsai.Name,
    //         Species: bonsai.Species,
    //         AgeYears: bonsai.AgeYears,
    //         LastWatered: bonsai.LastWatered,
    //         LastPruned: bonsai.LastPruned,
    //         Style: bonsai.Style,
    //         CareLevel: bonsai.CareLevel
    //     );

    //     return response;
    // }

    public static IResult Handle([AsParameters] Request request, IDatabase db)
    {
        try
        {
            var bonsi = db.Bonsais.Find(b => b.Id == request.Id);

            if (bonsi == null)
            {
                return TypedResults.NotFound($"Bonsai with ID {request.Id} not found");
            }
            return TypedResults.Ok(
                new Response(
                    Id: bonsi.Id,
                    Name: bonsi.Name,
                    Species: bonsi.Species,
                    AgeYears: bonsi.AgeYears,
                    LastWatered: bonsi.LastWatered,
                    LastPruned: bonsi.LastPruned,
                    Style: bonsi.Style,
                    CareLevel: bonsi.CareLevel
                )
            );
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(
                $"Something went wrong when retrieving bonsai with ID: {request.Id} Exception: {ex.Message}"
            );
        }
    }
}
