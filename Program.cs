using Models;
using Reto_Back.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(configurePolicy: policy => 
{
    // policy.WithOrigins("*","https://localhost","http://localhost");
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});


// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

EntradaController.InicializarDatos();
PeliculaController.InicializarDatos();
SalaController.InicializarDatos();
SesionController.InicializarDatos();

app.Run();
