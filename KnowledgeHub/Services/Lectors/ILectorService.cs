using KnowledgeHub.Models.Lectors;
using KnowledgeHub.Services.Lectors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Services.Lectors
{
    public interface ILectorService
    {
        public int GetId(string userId);

        public bool IsLector(string userId);

        public void Become(BecomeLectorServiceModel model);
    }
}
