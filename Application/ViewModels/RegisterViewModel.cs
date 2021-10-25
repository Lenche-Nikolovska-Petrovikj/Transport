using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please insert first name!")]
        [Display(Name = "Enter first name:")]
        
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please insert last name!")]
        [Display(Name = "Enter last name:")]
        
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please insert email address!")]
        [Display(Name = "Enter email address:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please insert username!")]
        [Display(Name = "Enter username:")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please insert password!")]
        [Display(Name = "Enter password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password!")]
        [Display(Name = "Confirm password:")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
