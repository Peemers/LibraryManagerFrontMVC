using System.Security.Claims;
using LibraryManagerFrontMvc.Interfaces.Services;
using LibraryManagerFrontMvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerFrontMvc.Controllers;

public class AuthController : Controller
{
  private readonly IAuthService _authService;

  public AuthController(IAuthService authService)
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
    if (result != null)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Email, result.User.Email),
        new Claim(ClaimTypes.Name, result.User.FirstName),
      };

      var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

      await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

      return RedirectToAction("Index", "Livre");
    }

    ModelState.AddModelError(string.Empty, "Email ou mot de passe incorrecte");
    return View(model);
  }
}