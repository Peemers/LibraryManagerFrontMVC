using System.ComponentModel.DataAnnotations;

namespace LibraryManagerFrontMvc.Models;

public class RegisterViewModel
{
  [Required(ErrorMessage = "Email is required")]
  [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
    ErrorMessage = "Le format de l'email n'est pas valide")]
  [MaxLength(45, ErrorMessage = "Max Length is 45")]
  [Display(Name = "Email")]
  [DataType(DataType.EmailAddress)]
  public required string Email { get; set; } = string.Empty;
  
  [Required(ErrorMessage = "Password is required")]
  [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&+#=]).{6,20}$", 
    ErrorMessage = "Le mot de passe doit contenir une majuscule, une minuscule, un chiffre et un caractère spécial.")]
  [MinLength(6, ErrorMessage = "Min Length is 6")]
  [MaxLength(20, ErrorMessage = "Max Length is 20")]
  [DataType(DataType.Password)]
  [Display(Name = "Mot de passe")]
  public required string Password { get; set; } =  string.Empty;
  
  [Required(ErrorMessage = "Password is required")]
  [MinLength(6, ErrorMessage = "Min Length is 6")]
  [MaxLength(20, ErrorMessage = "Max Length is 20")]
  [DataType(DataType.Password)]
  [Display(Name = "Confirmation Mot de passe")]
  [Compare("Password", ErrorMessage = "Les passwords ne correspondent pas")]
  public required string ConfirmPassword { get; set; } =  string.Empty;
  
  [Required(ErrorMessage = "Le prénom est requis")]
  [MinLength(2, ErrorMessage = "Min Length is 2")]
  [MaxLength(15, ErrorMessage = "Max Length is 15")]
  public string FirstName { get; set; } = string.Empty;
  
  [Required(ErrorMessage = "Le prénom est requis")]
  [MinLength(2, ErrorMessage = "Min Length is 2")]
  [MaxLength(15, ErrorMessage = "Max Length is 15")]
  public string LastName { get; set; } = string.Empty;
}