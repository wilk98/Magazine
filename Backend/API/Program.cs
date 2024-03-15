using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IMagazynService, MagazynService>();
builder.Services.AddScoped<IDostawcaService, DostawcaService>();
builder.Services.AddScoped<ITowarService, TowarService>();
builder.Services.AddScoped<IEtykietaService, EtykietaService>();
builder.Services.AddScoped<IDokumentPrzyjeciaService, DokumentPrzyjeciaService>();
builder.Services.AddScoped<IPozycjaTowaruService, PozycjaTowaruService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
