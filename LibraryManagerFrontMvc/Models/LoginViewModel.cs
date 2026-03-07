using System.ComponentModel.DataAnnotations;

namespace LibraryManagerFrontMvc.Models;

public class LoginViewModel
{
  [Required(ErrorMessage = "Email is required")]
  [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
    ErrorMessage = "Le format de l'email n'est pas valide")]
  [MaxLength(45, ErrorMessage = "Max Length is 45")]
  [Display(Name = "Adresse Email")]
  public required string Email { get; set; } = string.Empty;
  
  [Required(ErrorMessage = "Password is required")]
  [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", 
    ErrorMessage = "Le mot de passe doit contenir une majuscule, une minuscule, un chiffre et un caractère spécial.")]
  [MinLength(6, ErrorMessage = "Min Length is 6")]
  [MaxLength(20, ErrorMessage = "Max Length is 20")]
  [Display(Name = "Mot de passe")]
  [DataType(DataType.Password)]
  public required string Password { get; set; } =  string.Empty;
}