
using Microsoft.EntityFrameworkCore;
using Minimal.Domain.DTOs;
using Minimal.Infra.DB;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

builder.Services.AddDbContext<InfraDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("MySql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql")))
);


app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "seila@gmail.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Login feito com sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});


app.Run();