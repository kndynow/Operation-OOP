using System;
using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public abstract class Plant : IPlant, IEntity
{
    //Base constructor to set species
    protected Plant(Species species)
    {
        Species = species;
    }

    public int Id { get; set; }
    public Guid PlantId { get; init; } = Guid.NewGuid();
    public Species Species { get; }
    public string Name { get; set; } = null!;
    public CareLevel CareLevel { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
    public Guid ReferenceId => PlantId;

    private bool NeedsWater()
    {
        return LastWatered <= (DateTime.Now.AddDays(-7));
    }

    public virtual void Water()
    {
        if (NeedsWater())
        {
            LastWatered = DateTime.Now;
        }
    }
}
