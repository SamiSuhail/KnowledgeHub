using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.Person;

namespace KnowledgeHub.Models.Students
{
    public class BecomeStudentFormModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }
    }
}
