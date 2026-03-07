using LibraryManagerFrontMvc.Dtos.Requests;
using LibraryManagerFrontMvc.Dtos.Responses;
using LibraryManagerFrontMvc.Interfaces.Services;
using LibraryManagerFrontMvc.Models;

namespace LibraryManagerFrontMvc.Services;

public class AuthService : IAuthService
{
  private readonly HttpClient _httpClient;

  public AuthService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }
  public async Task<LoginResponceDto?> LoginAsync(LoginViewModel model)
  {
    LoginRequestDto loginRequest = new LoginRequestDto
    {
      Email = model.Email,
      Password = model.Password
    };

    var response = await _httpClient.PostAsJsonAsync("api/User/login", loginRequest);
    if (response.IsSuccessStatusCode)
    {
      return await response.Content.ReadFromJsonAsync<LoginResponceDto>();
    }
    return null;
  }
}