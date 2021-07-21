using KnowledgeHub.Models;
using System.Collections.Generic;

namespace KnowledgeHub.Services
{
    public interface ICourseService
    {
        public IEnumerable<CoursesCategoryModel> AllCategories();
        public void SeedCategories();
    }
}
