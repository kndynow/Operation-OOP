using OperationOOP.Core;
using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Data;

public interface IDatabase
{
    List<Plant> Plants { get; set; }
    List<Note> Notes { get; set; }
}

public class Database : IDatabase
{
    public List<Plant> Plants { get; set; } =
        new List<Plant>
        {
            new Bonsai
            {
                Name = "Test Bonsai",
                AgeYears = 5,
                Type = BonsaiType.AcerPalmatum,
                Style = BonsaiStyle.Chokkan,
                CareLevel = CareLevel.Intermediate,
                LastWatered = DateTime.Now.AddDays(-2),
                LastPruned = DateTime.Now.AddDays(-14),
            },
        };
    public List<Note> Notes { get; set; } = new List<Note>();
}
