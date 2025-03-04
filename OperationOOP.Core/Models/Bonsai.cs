using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public class Bonsai : IPlant
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Species Species { get; } = Species.Bonsai;
    public BonsaiType Type { get; set; }
    public BonsaiStyle Style { get; set; }
    public CareLevel CareLevel { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
}
