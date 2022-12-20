using GeekShooping.web.Services;
using GeekShooping.web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Localization;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

//Para consumir API
builder.Services.AddHttpClient<IServiceProduto, ProdutoService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceAPI:ProdutoAPI"])
); 

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["IdentityServer:IdentityServer"];
        //Configurações abaixo usadas para buscar a claims
        //options.GetClaimsFromUserInfoEndpoint = true;        
        //options.ClientId = "geek_shopping";
        options.ClientId = "";
        //options.ClientSecret = "my_super_secret";
        //options.ResponseType = "code";
        //options.ClaimActions.MapJsonKey("role", "role", "role");
        //options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        //options.TokenValidationParameters.NameClaimType = "name";
        //options.TokenValidationParameters.RoleClaimType = "role";
        //options.Scope.Add("geek_shopping");
        //options.SaveTokens = true;
    });

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("en-us") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-us"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
