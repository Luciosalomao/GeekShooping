using GeekShooping.web.Services;
using GeekShooping.web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

//Para consumir API
builder.Services.AddHttpClient<IServiceProduto, ProdutoService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceAPI:ProdutoAPI"])
); 

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
