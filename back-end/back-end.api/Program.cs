using Backend.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using Backend.DataAccess;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

#region Database and Repositories

string connectionString = "Host=postgres;Port=5432;Database=AuthDB;Username=postgres;Password=postgres";

builder.Services.AddDatabase(connectionString);

builder.Services.AddRepositories();

#endregion

WebApplication app = builder.Build();

if (args.Contains("migrate"))
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    return;
}

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();

