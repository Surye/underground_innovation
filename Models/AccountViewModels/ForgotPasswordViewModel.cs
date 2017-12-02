using System.ComponentModel.DataAnnotations;

namespace UndergroundInnovation.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
