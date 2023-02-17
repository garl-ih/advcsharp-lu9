using Microsoft.EntityFrameworkCore;
using GroupProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<GameContext>(opt =>
    opt.UseInMemoryDatabase("Games: "));
builder.Services.AddDbContext<MerchContext>(opt =>
    opt.UseInMemoryDatabase("Merch: "));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
