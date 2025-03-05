using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public class Bonsai : Plant, IPlant, IEntity
{
    public Guid PlantId { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public int AgeYears { get; set; }
    public Species Species { get; } = Species.Bonsai;
    public BonsaiType Type { get; set; }
    public BonsaiStyle Style { get; set; }
    public CareLevel CareLevel { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }

    public Guid ReferenceId => PlantId;
}
