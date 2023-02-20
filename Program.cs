using Microsoft.EntityFrameworkCore;
using GroupProject.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                "https://localhost:44470").AllowAnyHeader().AllowAnyMethod(); // we can add more domains to this list, need to make this a config somewhere... TODO: fix the domain list
        });
});



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<GameContext>(opt =>
    opt.UseInMemoryDatabase("Games: "));
builder.Services.AddDbContext<MerchContext>(opt =>
    opt.UseInMemoryDatabase("Merch: "));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

Console.WriteLine("https://localhost:7269/swagger/index.html");
app.Run();
