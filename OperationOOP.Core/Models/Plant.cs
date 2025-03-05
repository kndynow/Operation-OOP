using System;
using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public abstract class Plant : IPlant, IEntity
{
    public int Id { get; set; }
    public Guid PlantId { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
    public Species Species { get; set; }
    public CareLevel CareLevel { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
    public Guid ReferenceId => PlantId;
}
