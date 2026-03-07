using LibraryManagerFrontMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerFrontMvc.Controllers;

[Authorize]
public class LivreController : Controller
{
  private static List<LivreViewModel> _allLivres = new List<LivreViewModel>();
  private readonly string _apiUrl = "http://localhost:5001/api/Livre";
  public async Task<IActionResult> Index()
  {
    if (_allLivres.Count == 0)
    {
      HttpClient client = new HttpClient();
      var response = await client.GetFromJsonAsync<List<LivreViewModel>>(_apiUrl);
      _allLivres = response ?? new List<LivreViewModel>();
    }
    return View(_allLivres);
  }
}