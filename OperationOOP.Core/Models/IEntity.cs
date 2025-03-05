using System;

namespace OperationOOP.Core.Models;

//All enteties should have these properties
public interface IEntity
{
    int Id { get; }
    Guid ReferenceId { get; }
}
