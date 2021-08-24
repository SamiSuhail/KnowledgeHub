using System;

namespace KnowledgeHub.Services.Videos.Models
{
    public class VideoServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
