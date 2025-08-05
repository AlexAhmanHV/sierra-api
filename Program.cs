using Microsoft.EntityFrameworkCore;
using SierraApi.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Lägg till tjänster
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ CORS – Global policy
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ✅ Swagger – endast i utveckling
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ CORS – tillåt alla origins
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
);

// ✅ Lägg till CORS-header även vid fel (t.ex. 500)
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers["Access-Control-Allow-Origin"] = "*";
        return Task.CompletedTask;
    });

    await next.Invoke();
});

// ✅ Övrig middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
