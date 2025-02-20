using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 
using ConestogaCollegeMerchandise.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container and enable Newtonsoft JSON for JSON Patch support.
builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Register the EF Core context using the connection string from appsettings.json.
builder.Services.AddDbContext<MerchandiseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Optional: Add Swagger for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
