using Microsoft.EntityFrameworkCore;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Implementations;
using TurnosConsultorioMedico.Repositories.Interfaces;
using TurnosConsultorioMedico.Services.Implementations;
using TurnosConsultorioMedico.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregamos DbContext con la cadena de conexión
builder.Services.AddDbContext<TurnosContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Hacemos inyección de dependencias en repositories y services
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
builder.Services.AddScoped<ITurnoService, TurnoService>();
builder.Services.AddScoped<IMedicosRepository, MedicosRepository>();
builder.Services.AddScoped<IMedicosService, MedicosService>();



builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

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
