using LibraryManagerFrontMvc.Enums;

namespace LibraryManagerFrontMvc.Dtos.Responses;

public class UserResponceDto
{
  public Guid Id { get; set; }
  public string Email { get; set; } = string.Empty;
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public DateTime DateDeCreation { get; set; }
  public UsersRoles Role { get; set; }
}