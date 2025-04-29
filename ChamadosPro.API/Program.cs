using ChamadosPro.API.EndPoints;
using ChamadosPro.Infraestructure.Data;
using ChamadosPro.Infraestructure.Repositories;
using ChamadosPro.Infraestructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Permitir chamadas do Blazor WASM
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm", policy =>
    {
        policy.WithOrigins("https://localhost:5239", "http://localhost:5239") // ajuste conforme porta do WASM
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


// Adiciona o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do EF Core
builder.Services.AddDbContext<ChamadoProDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Reposit�rio gen�rico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Reposit�rios espec�ficos
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();

var app = builder.Build();

app.UseCors("AllowBlazorWasm");

// Middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // UI bonita do Swagger
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.AddEndpointsUsuarios();


app.Run();


