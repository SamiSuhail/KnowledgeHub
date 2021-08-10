using System;
using System.Collections.Generic;
using KnowledgeHub.Models.Topics;

namespace KnowledgeHub.Models.Courses
{
    public class CourseDetailsDisplayModel : CourseAllDisplayModel
    {
        public DateTime? LastModified { get; set; }
        public IEnumerable<TopicDisplayModel> Topics { get; set; } = new List<TopicDisplayModel>();
    }
}
