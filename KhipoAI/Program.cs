using KhipoAI.Context;
using KhipoAI.Repositories;
using KhipoAI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICotacaoService, CotacaoService>();
builder.Services.AddScoped<ICotacaoRepository, CotacaoRepository>();
builder.Services.AddScoped<IPlanoCotacaoRepository, PlanoCotacaoRepository>();
builder.Services.AddScoped<IPlanoCotacaoService, PlanoCotacaoService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=KhipoAi;Username=postgres;Password=123"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
