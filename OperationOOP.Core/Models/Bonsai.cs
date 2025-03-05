using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public class Bonsai : Plant
{
    //Constructor takes Bonsai Type as argument and sets Species to Bonsai
    public Bonsai(BonsaiType bonsaiType)
        : base(Species.Bonsai)
    {
        Type = bonsaiType;
    }

    public BonsaiType Type { get; protected set; }
    public BonsaiStyle Style { get; set; }
}
