using AutoMapper;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Models.Courses;
using KnowledgeHub.Models.Lectors;
using KnowledgeHub.Models.Students;
using KnowledgeHub.Models.Videos;
using KnowledgeHub.Services.Courses.Models;
using KnowledgeHub.Services.Lectors.Models;
using KnowledgeHub.Services.Students.Models;
using KnowledgeHub.Services.Videos.Models;

namespace KnowledgeHub.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            this.CreateMap<VideoAddFormModel, VideoAddServiceModel>();
            this.CreateMap<VideoAddServiceModel, Video>();
            this.CreateMap<Video, VideoServiceModel>();

            this.CreateMap<Topic, TopicServiceModel>();
            this.CreateMap<CourseAddTopicServiceModel, Topic>();

            this.CreateMap<CourseAddTopicFormModel, CourseAddTopicServiceModel>();
            this.CreateMap<CourseCreateFormModel, CourseCreateServiceModel>();
            this.CreateMap<CourseCreateServiceModel, Course>();
            this.CreateMap<Course, CourseAllServiceModel>();
            this.CreateMap<Course, CourseDetailsServiceModel>();

            this.CreateMap<Category, CategoryServiceModel>();

            this.CreateMap<BecomeLectorFormModel, BecomeLectorServiceModel>();
            this.CreateMap<BecomeLectorServiceModel, Lector>();

            this.CreateMap<BecomeStudentFormModel, BecomeStudentServiceModel>();
            this.CreateMap<BecomeStudentServiceModel, Student>();


        }
    }
}
