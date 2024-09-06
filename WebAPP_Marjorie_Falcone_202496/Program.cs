using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPP_Marjorie_Falcone_202496.Data;
using WebAPP_Marjorie_Falcone_202496.Service.Cliente;
using WebAPP_Marjorie_Falcone_202496.Service.Pago;
using WebAPP_Marjorie_Falcone_202496.Service.Prestamo;

var builder = WebApplication.CreateBuilder(args);
  
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IPagoServices, PagoServices>();
builder.Services.AddScoped<IPrestamoServices, PrestamoServices>();

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
