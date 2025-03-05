using System;
using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Models;

public class Orchid : Plant
{
    public Orchid(OrchidType orchidType)
        : base(Species.Orchid)
    {
        Type = orchidType;
    }

    public OrchidType Type { get; protected set; }
}
