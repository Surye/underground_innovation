using System.ComponentModel.DataAnnotations;

namespace UndergroundInnovation.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
