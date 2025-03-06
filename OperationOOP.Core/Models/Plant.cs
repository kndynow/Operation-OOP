using System;
using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public abstract class Plant : IPlant
{
    //Base constructor to set species
    protected Plant(Species species)
    {
        Species = species;
    }

    //Properties that all plants will inherite
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Species Species { get; }
    public CareLevel CareLevel { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }

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
