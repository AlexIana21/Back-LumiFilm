using Models;
using Reto_Back.Controllers;
using Reto_Back.Repositories;
using Reto_Back.Service;
using Reto_Back.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(""); //Poner la nuestra que sea necesaria.


builder.Services.AddScoped<IPeliculaRepoitory, PeliculaRepoitory>(provider =>
new PeliculaRepoitory(connectionString));

builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>(provider =>
new ComentarioRepository(connectionString));

builder.Services.AddScoped<ISalaRepository, SalaRepoitory>(provider =>
new SalaRepoitory(connectionString));

builder.Services.AddScoped<ITicketRepository, TicketRepository>(provider =>
new TicketRepository(connectionString));





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services 
builder.Services.AddScoped<IPeliculaService, PeliculaService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<ISalaService, SalaService>();
builder.Services.AddScoped<ITicketService, TicketService>();

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

app.Run();
