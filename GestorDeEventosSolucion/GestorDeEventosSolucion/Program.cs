using Microsoft.EntityFrameworkCore;
using GestorDeEventos.Infrastructure.Context;
using GestorDeEventos.Infrastructure.Interfaces;
using GestorDeEventos.Infrastructure.Repositories;
using GestorDeEventos.Application.Contract;
using GestorDeEventos.Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEspacioRepository, EspacioRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
builder.Services.AddScoped<IResponsableRepository, ResponsableRepository>();

builder.Services.AddScoped<IEspacioService, EspacioService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IParticipanteService, ParticipanteService>();
builder.Services.AddScoped<IResponsableService, ResponsableService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    _ = dbContext.Database.CanConnect();
}
app.Run();
