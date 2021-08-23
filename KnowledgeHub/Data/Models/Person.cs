using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.Person;

namespace KnowledgeHub.Data.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }
    }
}
