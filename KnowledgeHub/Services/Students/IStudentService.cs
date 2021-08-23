using KnowledgeHub.Services.Students.Models;

namespace KnowledgeHub.Services.Students
{
    public interface IStudentService
    {
        public int GetId(string userId);

        public bool IsStudent(string userId);

        public void Become(BecomeStudentServiceModel model);
    }
}
