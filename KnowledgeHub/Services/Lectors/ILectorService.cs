using KnowledgeHub.Services.Lectors.Models;

namespace KnowledgeHub.Services.Lectors
{
    public interface ILectorService
    {
        public int GetId(string userId);

        public bool IsLector(string userId);

        public void Become(BecomeLectorServiceModel model);
    }
}
