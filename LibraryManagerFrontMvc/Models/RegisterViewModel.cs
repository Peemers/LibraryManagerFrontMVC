namespace LibraryManagerFrontMvc.Models;

public class RegisterViewModel
{
  public required string Email { get; set; } = string.Empty;
  public required string Password { get; set; } =  string.Empty;
  
  public required string ConfirmPassword { get; set; } =  string.Empty;
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
}