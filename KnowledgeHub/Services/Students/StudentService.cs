using AutoMapper;
using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Services.Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Services.Students
{
    public class StudentService : IStudentService
    {
        private KnowledgeHubDbContext data;
        private IMapper mapper;
        public StudentService(KnowledgeHubDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }

        public void Become(BecomeStudentServiceModel model)
        {
            var student = mapper.Map<BecomeStudentServiceModel, Student>(model);

            this.data.Students.Add(student);
            this.data.SaveChanges();
        }

        public int GetId(string userId)
         => this.data.Students.FirstOrDefault(l => l.UserId == userId).Id;

        public bool IsStudent(string userId)
            => this.data.Students.Any(l => l.UserId == userId);
    }
}
