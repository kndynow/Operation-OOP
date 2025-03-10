using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public interface IPlant
{
    public int Id { get; set; }
    string Name { get; set; }
    public Species Species { get; }
    public CareLevel CareLevel { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
}
