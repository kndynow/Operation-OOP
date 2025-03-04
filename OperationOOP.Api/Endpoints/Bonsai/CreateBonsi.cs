﻿using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Api.Endpoints;

public class CreateBonsai : IEndpoint
{
    //To group related endpoints
    private const string Tag = "Bonsai";

    public static void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/bonsais", Handle).WithTags(Tag).WithSummary("Create Bonsai");

    public record Request(
        string Name,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
    );

    public record Response(int id);

    private static IResult Handle(Request request, IDatabase db)
    {
        var bonsai = new Bonsai();

        bonsai.Id = db.Bonsais.Any() ? db.Bonsais.Max(bonsai => bonsai.Id) + 1 : 1;
        bonsai.Name = request.Name;
        bonsai.AgeYears = request.AgeYears;
        bonsai.LastWatered = request.LastWatered;
        bonsai.LastPruned = request.LastPruned;
        bonsai.Style = request.Style;
        bonsai.CareLevel = request.CareLevel;

        db.Bonsais.Add(bonsai);

        return TypedResults.Ok(new Response(bonsai.Id));
    }
}
