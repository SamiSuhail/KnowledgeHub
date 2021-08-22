using KnowledgeHub.Services.Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Services.Students
{
    public interface IStudentService
    {
        public int GetId(string userId);

        public bool IsStudent(string userId);

        public void Become(BecomeStudentServiceModel model);
    }
}
