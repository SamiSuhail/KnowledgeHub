using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHub.Data
{
    public class KnowledgeHubDbContext : IdentityDbContext
    {
        public KnowledgeHubDbContext(DbContextOptions<KnowledgeHubDbContext> options)
            : base(options)
        {
        }
    }
}
