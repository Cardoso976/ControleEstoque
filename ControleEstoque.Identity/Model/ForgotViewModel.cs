using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Identity.Model
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}