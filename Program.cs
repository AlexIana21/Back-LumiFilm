using Models;
using Reto_Back.Controllers;
using Reto_Back.Repositories;
using Reto_Back.Service;
using Reto_Back.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(""); //Poner la nuestra que sea necesaria.


builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>(provider =>
new PeliculaRepository(connectionString));

builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>(provider =>
new ComentarioRepository(connectionString));

builder.Services.AddScoped<ISalaRepository, SalaRepository>(provider =>
new SalaRepository(connectionString));

builder.Services.AddScoped<ITicketRepository, TicketRepository>(provider =>
new TicketRepository(connectionString));

builder.Services.AddScoped<ISesionRepository, SesionRepository>(provider =>
new SesionRepository(connectionString));

builder.Services.AddScoped<IAdminRespository, AdminRepository>(provider =>
new AdminRepository(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>(provider =>
new UserRepository(connectionString));

builder.Services.AddScoped<IPagoRepository, PagoRepository>(provider =>
new PagoRepository(connectionString));

builder.Services.AddScoped<IAsientoRepository, AsientoRepository>(provider =>
new AsientoRepository(connectionString));

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
builder.Services.AddScoped<ISesionService, SesionService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPagoService, PagoService>();
builder.Services.AddScoped<IAsientoService, AsientoService>();

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
