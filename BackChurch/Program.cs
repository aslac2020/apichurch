using BackChurch.Data;
using BackChurch.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IIgrejaRepository, IgrejaRepository>();
builder.Services.AddScoped<IEnderecoIgrejasRepository, EnderecoIgrejaRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IFrequenciaRepository, FrequenciaRepository>();
builder.Services.AddScoped<IDizimoRepository, DizimosRepository>();
builder.Services.AddScoped<IHistoricoMinisterialRepository, HistoricoMinisterialRepository>();
builder.Services.AddScoped<IEnderecosMembrosRepository, EnderecosMembrosRepository>();

builder.Services.AddMemoryCache();

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
