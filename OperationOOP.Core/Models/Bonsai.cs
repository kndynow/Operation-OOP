namespace OperationOOP.Core.Models;

public class Bonsai
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Species Species { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
    public BonsaiStyle Style { get; set; }
    public CareLevel CareLevel { get; set; }
}

// Enum for the style of the bonsai
public enum BonsaiStyle
{
    Chokkan, // Formal Upright
    Moyogi, // Informal Upright
    Shakan, // Slanting
    Kengai, // Cascade
    HanKengai, // Semi-cascade
}

// Enum for the care level of the bonsai
public enum CareLevel
{
    Beginner,
    Intermediate,
    Advanced,
    Master,
}

//Enum for the species of bonsai
public enum Species
{
    AcerPalmatum,
    FicusRetusa,
    JuniperusProcumbens,
    PinusThunbergii,
    UlmusParvifolia,
    ZelkovaSerrata,
}
