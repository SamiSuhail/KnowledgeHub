using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.User;

namespace KnowledgeHub.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }
    }
}
