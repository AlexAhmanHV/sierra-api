using Microsoft.EntityFrameworkCore;
using SierraApi.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ✅ Tjänster
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // 🔥 Fix för cykliska referenser som orsakar JSON-serialization error
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Global CORS-policy – inga begränsningar
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ✅ Swagger i dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Tillåt alla origins (för dev/test)
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
);

// ✅ Fånga 500-fel och lägg till CORS-header även i fel
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        context.Response.Headers["Access-Control-Allow-Origin"] = "*";

        await context.Response.WriteAsync("{\"error\": \"Ett oväntat fel inträffade i servern.\"}");
    });
});

// ✅ Övrig middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
