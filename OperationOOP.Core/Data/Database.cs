using OperationOOP.Core;
using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Data;

public interface IDatabase
{
    List<Bonsai> Bonsais { get; set; }
    List<Note> Notes { get; set; }
}

public class Database : IDatabase
{
    public List<Bonsai> Bonsais { get; set; } =
        new List<Bonsai>()
        {
            new Bonsai()
            {
                Id = 1,
                Name = "Bubba",
                AgeYears = 1,
                CareLevel = CareLevel.Beginner,
                LastWatered = DateTime.Now,
                LastPruned = DateTime.Today,
                Style = BonsaiStyle.Moyogi,
            },
            new Bonsai()
            {
                Id = 2,
                Name = "Fehrvatz",
                AgeYears = 1,
                CareLevel = CareLevel.Master,
                LastWatered = DateTime.Now,
                LastPruned = DateTime.Today,
                Style = BonsaiStyle.Shakan,
            },
            new Bonsai()
            {
                Id = 3,
                Name = "Larsa",
                AgeYears = 1,
                CareLevel = CareLevel.Intermediate,
                LastWatered = DateTime.Now,
                LastPruned = DateTime.Today,
                Style = BonsaiStyle.HanKengai,
            },
        };
    public List<Note> Notes { get; set; } = new List<Note>();
}
