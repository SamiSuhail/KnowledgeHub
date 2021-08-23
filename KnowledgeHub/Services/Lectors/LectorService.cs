using AutoMapper;
using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Services.Lectors.Models;
using System.Linq;

namespace KnowledgeHub.Services.Lectors
{
    public class LectorService : ILectorService
    {
        private KnowledgeHubDbContext data;
        private IMapper mapper;
        public LectorService(KnowledgeHubDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }
        public int GetId(string userId)
            => this.data.Lectors.FirstOrDefault(l => l.UserId == userId).Id;

        public bool IsLector(string userId)
                => this.data.Lectors.Any(l => l.UserId == userId);

        public void Become(BecomeLectorServiceModel model)
        {
            var lector = mapper.Map<BecomeLectorServiceModel, Lector>(model);

            this.data.Lectors.Add(lector);
            this.data.SaveChanges();
        }


    }
}
