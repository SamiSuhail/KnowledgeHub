using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Data.Models
{
    public class Student : Person
    {
        public IEnumerable<StudentsVideos> VideosWatched { get; set; }
    }
}
