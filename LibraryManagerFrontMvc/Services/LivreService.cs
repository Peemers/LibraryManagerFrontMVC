using LibraryManagerFrontMvc.Interfaces.Services;
using LibraryManagerFrontMvc.Models;

namespace LibraryManagerFrontMvc.Services;

public class LivreService : ILivreService
{
  private readonly HttpClient _client; //inject http comme d'hab
  
  public LivreService(HttpClient client)
  {
    _client = client;
  }


  public async Task<List<LivreViewModel>> GetAllLivresAsync()
  {
    var response = await _client.GetFromJsonAsync<List<LivreViewModel>>("api/Livre");
    return response ?? new List<LivreViewModel>();
  }

  public async Task<LivreViewModel?> GetByIdAsync(Guid id)
  {
    var response = await _client.GetFromJsonAsync<LivreViewModel>($"api/Livre/{id}");
    return response;
  }

  public async Task<LivreViewModel?> CreateLivreAsync(LivreViewModel livre)
  {
    var response = await _client.PostAsJsonAsync("api/Livre", livre);
    return response.IsSuccessStatusCode
    ? await response.Content.ReadFromJsonAsync<LivreViewModel>()
    : null;
  }
}