using System.ComponentModel.DataAnnotations;

namespace projet_pro_2.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
