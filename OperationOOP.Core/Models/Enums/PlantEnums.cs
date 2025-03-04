using System.ComponentModel.DataAnnotations;

namespace OperationOOP.Core.Models.Enums;

//Plant Enums
public enum Species
{
    [Display(Name = "Bonsai")]
    Bonsai,

    [Display(Name = "Succulent")]
    Succulent,

    [Display(Name = "Orchid")]
    Orchid,
}

public enum CareLevel
{
    [Display(Name = "Beginner")]
    Beginner,

    [Display(Name = "Intermediate")]
    Intermediate,

    [Display(Name = "Advanced")]
    Advanced,

    [Display(Name = "Master")]
    Master,
}

//Bonsai Enums
public enum BonsaiType
{
    [Display(Name = "Acer Palmatum")]
    AcerPalmatum,

    [Display(Name = "Ficus Retusa")]
    FicusRetusa,

    [Display(Name = "Juniperus Procumbens")]
    JuniperusProcumbens,

    [Display(Name = "Pinus Thunbergii")]
    PinusThunbergii,

    [Display(Name = "Ulmus Parvifolia")]
    UlmusParvifolia,

    [Display(Name = "Zelkova Serrata")]
    ZelkovaSerrata,
}

public enum BonsaiStyle
{
    [Display(Name = "Chokkan")]
    Chokkan,

    [Display(Name = "Moyogi")]
    Moyogi,

    [Display(Name = "Shakan")]
    Shakan,

    [Display(Name = "Kengai")]
    Kengai,

    [Display(Name = "Han Kengai")]
    HanKengai,
}
