using System;

namespace OperationOOP.Core.Models;

public class Note : IEntity
{
    public int Id { get; set; }
    public Guid ReferenceId { get; private init; } = Guid.NewGuid();
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
