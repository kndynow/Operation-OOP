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

//Care-level
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

//Bonsai Styles
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

//Succulent types/subgroups
public enum SucculentType
{
    [Display(Name = "Aloe vera")]
    AloeVera,

    [Display(Name = "Echeveria Elegans")]
    EcheveriaElegans,

    [Display(Name = "Haworthia Fasciata")]
    HaworthiaFasciata,

    [Display(Name = "Crassula Ovata")]
    CrassulaOvata,

    [Display(Name = "Sedum Morganianum")]
    SedumMorganianum,

    [Display(Name = "Klasius Fehrvatzius")]
    KlasiusFehrvatzius,
}

//Orchid types/subgroups
public enum OrchidType
{
    [Display(Name = "Phalaenopsis")]
    Phalaenopsis,

    [Display(Name = "Cattleya")]
    Cattleya,

    [Display(Name = "Dendrobium")]
    Dendrobium,

    [Display(Name = "Oncidium")]
    Oncidium,

    [Display(Name = "Paphiopedilum")]
    Paphiopedilum,

    [Display(Name = "Ariftiomustang")]
    Ariftiomustang,
}
