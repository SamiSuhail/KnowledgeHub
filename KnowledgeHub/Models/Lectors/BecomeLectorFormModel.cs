using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.Person;

namespace KnowledgeHub.Models.Lectors
{
    public class BecomeLectorFormModel
    {
        [Required]
        [MinLength(NameMinLength, ErrorMessage = "Name should be at least 2 symbols.")]
        [MaxLength(NameMaxLength, ErrorMessage = "Name can be mostly 25 symbols.")]
        public string Name { get; set; }

        [Required]
        [MinLength(PhoneNumberMinLength, ErrorMessage = "Phone number should be at least 6 symbols.")]
        [MaxLength(PhoneNumberMaxLength, ErrorMessage = "Phone number can be mostly 30 symbols.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
