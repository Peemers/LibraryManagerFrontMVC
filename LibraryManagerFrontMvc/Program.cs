using LibraryManagerFrontMvc.Interfaces.Services;
using LibraryManagerFrontMvc.Services;

var builder = WebApplication.CreateBuilder(args);
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
{
 client.BaseAddress = new Uri(apiBaseUrl ?? throw new InvalidOperationException("Api BaseUrl manquante"));
});

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
  .WithStaticAssets();


app.Run();