using LibraryManagerFrontMvc.Enums;

namespace LibraryManagerFrontMvc.Dtos.Responses;

public class LoginResponceDto
{
  public required UserResponceDto User { get; set; }
  public required string Token { get; set; }
  public UsersRoles Role { get; set; }
}