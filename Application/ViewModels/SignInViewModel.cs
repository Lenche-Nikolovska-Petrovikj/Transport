using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Please insert username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please insert password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
