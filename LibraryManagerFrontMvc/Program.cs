using LibraryManagerFrontMvc.Handlers;
using LibraryManagerFrontMvc.Interfaces.Services;
using LibraryManagerFrontMvc.Services;

var builder = WebApplication.CreateBuilder(args);
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

#region Services

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
{
  client.BaseAddress = new Uri(apiBaseUrl ?? throw new InvalidOperationException("Api BaseUrl manquante"));
});

builder.Services.AddHttpClient<ILivreService, LivreService>(client =>
{
  client.BaseAddress = new Uri(apiBaseUrl ?? throw new InvalidOperationException("Api BaseUrl manquante"));
});

builder.Services.AddHttpClient<ILivreService, LivreService>(client => {
  client.BaseAddress = new Uri("https://localhost:7001/");
}).AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddAuthentication("CookieAuth")
  .AddCookie("CookieAuth", config =>
  {
    config.Cookie.Name = "UserToken";
    config.LoginPath = "/Auth/Login";
  });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}")
  .WithStaticAssets();


app.Run();