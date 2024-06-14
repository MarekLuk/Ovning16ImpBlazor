using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Ovning16ImpBlazor.Data;var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddSingleton <MachineService>();
builder.Services.AddHttpClient<MachineService>(client =>{ client.BaseAddress = new Uri("https://localhost:7028");
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
  
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
