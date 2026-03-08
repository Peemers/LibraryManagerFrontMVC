using System.Net.Http.Headers;

namespace LibraryManagerFrontMvc.Handlers;

/*
 Auth token Handler astuce apprise avec gemini. C'est un middleware qui va intercepter
 toutes les requetes sortantes et injecter le token qui est stocké en session ou en cookies
 */

public class AuthTokenHandler : DelegatingHandler
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public AuthTokenHandler(IHttpContextAccessor accessor)
  {
    _httpContextAccessor = accessor;
  }

  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    var token = _httpContextAccessor.HttpContext?.Session.GetString("JWToken");
    if (!string.IsNullOrEmpty(token))
    {
      request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    return await base.SendAsync(request, cancellationToken);
  }
}