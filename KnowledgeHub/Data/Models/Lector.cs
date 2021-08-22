using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using static KnowledgeHub.Data.DataConstants.Person;

namespace KnowledgeHub.Data.Models
{
    public class Lector : Person
    {
        public IEnumerable<Course> Courses { get; init; } = new List<Course>();
    }
}
