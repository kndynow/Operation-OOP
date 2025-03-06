using System;
using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public class Succulent : Plant
{
    public Succulent(SucculentType succulentType)
        : base(Species.Succulent)
    {
        Type = succulentType;
    }

    public SucculentType Type { get; protected set; }
}
