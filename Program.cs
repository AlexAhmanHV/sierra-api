using Microsoft.EntityFrameworkCore;
using SierraApi.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Lägg till controllers
builder.Services.AddControllers();

// ✅ Swagger (API-dokumentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ CORS-policy – tillåt alla origins (för utveckling och temporärt för produktion)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ✅ PostgreSQL via Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ✅ Swagger – endast i utvecklingsmiljö
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ CORS måste aktiveras FÖRE controller-routingen – och ALLTID, oavsett miljö
app.UseCors("AllowAllOrigins");

// ✅ Middleware för HTTPS och auth
app.UseHttpsRedirection();
app.UseAuthorization();

// ✅ Aktivera API-routingen
app.MapControllers();

// ✅ Starta appen
app.Run();
