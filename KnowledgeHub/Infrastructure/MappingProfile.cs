using AutoMapper;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Models.Courses;
using KnowledgeHub.Models.Videos;
using KnowledgeHub.Services.Courses.Models;
using KnowledgeHub.Services.Videos.Models;

namespace KnowledgeHub.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //this.CreateMap<Category, CarCategoryServiceModel>();

            //this.CreateMap<Car, LatestCarServiceModel>();
            //this.CreateMap<CarDetailsServiceModel, CarFormModel>();

            //this.CreateMap<Car, CarServiceModel>()
            //    .ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));

            //this.CreateMap<Car, CarDetailsServiceModel>()
            //    .ForMember(c => c.UserId, cfg => cfg.MapFrom(c => c.Dealer.UserId))
            //    .ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));

            this.CreateMap<VideoAddFormModel, VideoAddServiceModel>();
            this.CreateMap<VideoAddServiceModel, Video>();
            this.CreateMap<Video, VideoServiceModel>();

            this.CreateMap<Topic, TopicServiceModel>();
            this.CreateMap<CourseAddTopicServiceModel, Topic>();

            this.CreateMap<CourseAddTopicFormModel, CourseAddTopicServiceModel>();
            this.CreateMap<CourseCreateFormModel, CourseCreateServiceModel>();
            this.CreateMap<CourseCreateServiceModel, Course>();
            this.CreateMap<Course, CourseAllServiceModel>();
                //.ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));
            this.CreateMap<Course, CourseDetailsServiceModel>();

             this.CreateMap<Category, CategoryServiceModel>();




        }
    }
}
