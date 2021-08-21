using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Services.Videos.Models
{
    public class VideoServiceModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
