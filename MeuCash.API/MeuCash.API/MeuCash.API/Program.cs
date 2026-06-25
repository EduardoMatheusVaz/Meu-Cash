using MeuCash.API.ExceptionHandler;
using MeuCash.Application.Services.Implementacoes;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Application.Validators;
using MeuCash.Core.Repositories;
using MeuCash.Infraestrutura;
using MeuCash.Infraestrutura.Persistencia.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAplication();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Banco de Dados

var connectionString = builder.Configuration.GetConnectionString("MeuCash");

builder.Services.AddDbContext<MeuCashDbContext>(options =>
    options.UseSqlServer(connectionString));

#endregion Banco de Dados

#region Repositorios

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();
builder.Services.AddScoped<IMetasRepository, MetaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IContaService, ContaService>();
builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IEntradaService, EntradaService>();
builder.Services.AddScoped<IMetaService, MetaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

#endregion Repositorios


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
