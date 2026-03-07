using LibraryManagerFrontMvc.Dtos.Responses;
using LibraryManagerFrontMvc.Models;

namespace LibraryManagerFrontMvc.Interfaces.Services;

public interface IAuthService
{
  Task<LoginResponceDto?> LoginAsync(LoginViewModel model);
}