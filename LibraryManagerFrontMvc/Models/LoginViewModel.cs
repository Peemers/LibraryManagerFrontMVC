namespace LibraryManagerFrontMvc.Models;

public class LoginViewModel
{
  public required string Email { get; set; } = string.Empty;
  public required string Password { get; set; } =  string.Empty;
}