using System.Collections.Generic;

namespace KnowledgeHub.Data.Models
{
    public class Lector : Person
    {
        public IEnumerable<Course> Courses { get; init; } = new List<Course>();
    }
}
