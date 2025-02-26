using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }
        List<Note> Notes { get; set; }
        List<Link> Links { get; set; }
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
