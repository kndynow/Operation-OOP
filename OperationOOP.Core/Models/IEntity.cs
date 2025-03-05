using System;

namespace OperationOOP.Core.Models;

//All enteties should have these properties
public interface IEntity
{
    //To test getbyid in swagger
    int Id { get; }

    //To reference note to PlantID
    Guid ReferenceId { get; }
}
