using System;
using System.Collections.Generic;

namespace KnowledgeHub.Services.Courses.Models
{
    public class CourseDetailsServiceModel : CourseAllServiceModel
    {
        public DateTime? LastModified { get; set; }
        public IEnumerable<TopicServiceModel> Topics { get; set; } = new List<TopicServiceModel>();
    }
}
