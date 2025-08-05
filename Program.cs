using Microsoft.EntityFrameworkCore;
using SierraApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - more specific configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:3000", "https://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // If you need cookies/auth
    });
});

// PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS must be before routing and controllers
app.UseCors("AllowLocalhost");

// Other middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// Controllers
app.MapControllers();

app.Run();