using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHub.Services.Videos
{
    public class VideoService : IVideoService
    {
        private KnowledgeHubDbContext data;
        public VideoService(KnowledgeHubDbContext data)
        {
            this.data = data;
        }
        
                
    }
}
