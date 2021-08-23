using System.Collections.Generic;

namespace KnowledgeHub.Data.Models
{
    public class Student : Person
    {
        public IEnumerable<StudentsVideos> VideosWatched { get; set; }
    }
}
