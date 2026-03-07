using LibraryManagerFrontMvc.Interfaces.Services;
using LibraryManagerFrontMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerFrontMvc.Controllers;

[Authorize]
public class LivreController : Controller
{
  private readonly ILivreService _livre;

  public LivreController(ILivreService livre)
  {
    _livre = livre;
  }
  
  public async Task<IActionResult> Index()
  {
    var livres = await _livre.GetAllLivresAsync();
    
    return View(livres ?? new List<LivreViewModel>());
  }
  
  [HttpGet]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Create(LivreViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }
    var result = await _livre.CreateLivreAsync(model);
    if (result != null)
    {
      TempData["Succes"] = "Livre bien ajouté";
      return RedirectToAction("Index");
    }
    ModelState.AddModelError("", "Creation Failed");
    return View(model);
  } 
}