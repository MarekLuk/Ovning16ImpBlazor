using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ovning16ImpBlazor.Server.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Ovning16ImpBlazorServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ovning16ImpBlazorServerContext") ?? throw new InvalidOperationException("Connection string 'Ovning16ImpBlazorServerContext' not found.")));



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
