using LibraryManagerFrontMvc.Interfaces.Services;
using LibraryManagerFrontMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerFrontMvc.Controllers;

public class AuthContoller : Controller
{
  private readonly IAuthService _authService;
  
  public AuthContoller(IAuthService authService)
  {
    _authService = authService;
  }

  [HttpGet]
  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    var result = await _authService.LoginAsync(model);
    if (result == null)
    {
      return RedirectToAction("Index", "Home");
    }
    ModelState.AddModelError(string.Empty,"Email ou mot de passe incorrecte");
    return View(model);
  }
}