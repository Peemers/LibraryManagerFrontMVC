using System.Security.Claims;
using LibraryManagerFrontMvc.Enums;
using LibraryManagerFrontMvc.Interfaces.Services;
using LibraryManagerFrontMvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerFrontMvc.Controllers;

public class AuthController : Controller
{
  private readonly IAuthService _authService;
  private readonly HttpClient _httpClient;

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
      HttpContext.Session.SetString("JWToken", result.Token);
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Email, result.User.Email),
        new Claim(ClaimTypes.Name, result.User.FirstName),
        new Claim(ClaimTypes.Role, result.User.Role.ToString()),
      };

      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

      return RedirectToAction("Index", "Livre");
    }

    ModelState.AddModelError(string.Empty, "Email ou mot de passe incorrecte");
    return View(model);
  }

  [HttpGet]
  public IActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Register(RegisterViewModel form)
  {
    if (!ModelState.IsValid)
    {
      return View(form);
    }
    var result = await _authService.CreateUser(form);

    if (result != null)
    {
      TempData["Success"] = "Inscription reussie, vous pouvez maintenant vous connecter";
      return RedirectToAction("Login", "Auth");
    }
    ModelState.AddModelError(string.Empty, "Erreur lors de l'inscription");
    TempData["Error"] = "Echec d'inscription";
    
    return View(form);
  }
  
  [HttpPost]
  public async Task<IActionResult> Logout()
  {
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    HttpContext.Session.Clear();
    return RedirectToAction("Login");
  }
}